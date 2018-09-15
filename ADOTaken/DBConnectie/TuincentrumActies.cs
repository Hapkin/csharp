using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectie;
using System.Data.Common;
using System.Transactions;
using System.Collections.ObjectModel;

namespace DBConnectie
{
    public class TuincentrumActies
    {
        public int LeverancierToevoegen(Leverancier eenLeverancier)
        {
            var manager = new DBTuincerntrum();
            int nieuwId;
            using (var conTuin = manager.GetConnection())
            {
                using (var comToevoegen = conTuin.CreateCommand())
                {
                    comToevoegen.CommandType = CommandType.StoredProcedure;
                    comToevoegen.CommandText = "LeverancierToevoegen";
                    var parNaam = comToevoegen.CreateParameter();
                    parNaam.ParameterName = "@Naam";
                    parNaam.Value = eenLeverancier.Naam;
                    comToevoegen.Parameters.Add(parNaam);
                    var parAdres = comToevoegen.CreateParameter();
                    parAdres.ParameterName = "@Adres";
                    parAdres.Value = eenLeverancier.Adres;
                    comToevoegen.Parameters.Add(parAdres);
                    var parPostNr = comToevoegen.CreateParameter();
                    parPostNr.ParameterName = "@PostNr";
                    parPostNr.Value = eenLeverancier.PostNr;
                    comToevoegen.Parameters.Add(parPostNr);
                    var parWoonplaats = comToevoegen.CreateParameter();
                    parWoonplaats.ParameterName = "@Woonplaats";
                    parWoonplaats.Value = eenLeverancier.Woonplaats;
                    comToevoegen.Parameters.Add(parWoonplaats);
                    conTuin.Open();
                    //ExecuteNonQuery wordt Scalar omdat je nu 1 waarde moet terugkrijgen (ID)
                    nieuwId = Convert.ToInt32(comToevoegen.ExecuteScalar());
                }
            }
            return nieuwId;
        }

        
        public int EindejaarsKorting()
        {
            var manager = new DBTuincerntrum();
            using (var conTuin = manager.GetConnection())
            {
                using (var comKorting = conTuin.CreateCommand())
                {
                    comKorting.CommandType = CommandType.StoredProcedure;
                    comKorting.CommandText = "EindejaarsKorting";
                    conTuin.Open();
                    return comKorting.ExecuteNonQuery();
                }
            }
        }
        

        public void UpdateThenRemoveLeverancier(int leverancier1, int leverancier2)
        {
            var manager = new DBTuincerntrum();
            var opties = new TransactionOptions();
            opties.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

            //TransactionScope
            using (var MijnTransactie = new TransactionScope(TransactionScopeOption.Required, opties))
            {
                using (var MijnConnectie = manager.GetConnection())
                {
                    using (var MijnCommand = MijnConnectie.CreateCommand())
                    {
                        MijnCommand.CommandType = CommandType.StoredProcedure;
                        MijnCommand.CommandText = "VervangLeverancier";
                        //(@leverancierID1 int, @leverancierID2 int)

                        var par1 = MijnCommand.CreateParameter();
                        par1.ParameterName = "@leverancierID1";
                        par1.Value = leverancier1;
                        MijnCommand.Parameters.Add(par1);

                        var par2 = MijnCommand.CreateParameter();
                        par2.ParameterName = "@leverancierID2";
                        par2.Value = leverancier2;
                        MijnCommand.Parameters.Add(par2);

                        MijnConnectie.Open();

                        if (MijnCommand.ExecuteNonQuery() == 0)
                        {
                            throw new Exception("Planten niet geupdate 1 van de leveranciers bestaat niet");
                        }
                    } // using MijnCommand

                    MijnConnectie.Close();

                    using (var MijnCommand = MijnConnectie.CreateCommand())
                    {
                        MijnCommand.CommandType = CommandType.StoredProcedure;
                        MijnCommand.CommandText = "removeLeverancier";
                        //(@leverancierID1 int)

                        var par1 = MijnCommand.CreateParameter();
                        par1.ParameterName = "@leverancierID1";
                        par1.Value = 14;
                        MijnCommand.Parameters.Add(par1);

                        MijnConnectie.Open();

                        if (MijnCommand.ExecuteNonQuery() == 0)
                        {
                            throw new Exception("leverancier kon niet verwijderd worden");
                        }

                    } // using MijnCommand
                    MijnConnectie.Close();
                } // using MijnConnectie

                //TransactionScope afsluiten!!
                MijnTransactie.Complete();
            } // using MijnTransactie


            
        }
        public decimal BerekenGemKostprijs(string soort)
        {
            var manager = new DBTuincerntrum();

            using (var MijnConnectie = manager.GetConnection())
            {
                using (var MijnCommand = MijnConnectie.CreateCommand())
                {
                    MijnCommand.CommandType = CommandType.Text;
                    MijnCommand.CommandText = 
"SELECT (SUM([VerkoopPrijs])/COUNT(*)) "+
"FROM[Tuincentrum].[dbo].[Planten] "+
"INNER JOIN[Tuincentrum].[dbo].[Soorten] ON[Soorten].[SoortNr] = [Planten].[SoortNr] "+
"WHERE[Soorten].[Soort] = @soort";


                    var par1 = MijnCommand.CreateParameter();
                    par1.ParameterName = "@soort";
                    par1.Value = soort;
                    MijnCommand.Parameters.Add(par1);

                    MijnConnectie.Open();

                    Object resultaat = MijnCommand.ExecuteScalar();
                    if (resultaat == null)
                    {
                        throw new Exception("soort bestaat niet");
                    }
                    else
                    {
                        return (Decimal)resultaat;
                    }
                } // using MijnCommand
            } //using MijnConnectie
        }
        public PlantGegevens PlantGegevensOpzoeken(int plantNr)
        {
            var manager = new DBTuincerntrum();

            using (var MijnConnectie = manager.GetConnection())
            {
                using (var MijnCommand = MijnConnectie.CreateCommand())
                {
                    MijnCommand.CommandType = CommandType.StoredProcedure;
                    MijnCommand.CommandText = "PlantenGegevens";
/*
@plantnr int,
@plantnaam nvarchar(30) OUTPUT,
@soort nvarchar(10) OUTPUT,
@leverancier nvarchar(30) OUTPUT,
@kleur nvarchar(10) OUTPUT,
@kostprijs money OUTPUT )
*/
                    //input
                    var parPlantNr = MijnCommand.CreateParameter();
                    parPlantNr.ParameterName = "@plantnr";
                    parPlantNr.Value = plantNr;
                    MijnCommand.Parameters.Add(parPlantNr);
                    
                    //output
                    var parNaam = MijnCommand.CreateParameter();
                    parNaam.ParameterName = "@plantnaam";
                    parNaam.DbType = DbType.String;
                    parNaam.Size = 30;
                    parNaam.Direction = ParameterDirection.Output;
                    MijnCommand.Parameters.Add(parNaam);

                    var parSoort = MijnCommand.CreateParameter();
                    parSoort.ParameterName = "@soort";
                    parSoort.DbType = DbType.String;
                    parSoort.Size = 10;
                    parSoort.Direction = ParameterDirection.Output;
                    MijnCommand.Parameters.Add(parSoort);

                    var parLeverancier = MijnCommand.CreateParameter();
                    parLeverancier.ParameterName = "@leverancier";
                    parLeverancier.DbType = DbType.String;
                    parLeverancier.Size = 30;
                    parLeverancier.Direction = ParameterDirection.Output;
                    MijnCommand.Parameters.Add(parLeverancier);

                    var parKleur = MijnCommand.CreateParameter();
                    parKleur.ParameterName = "@kleur";
                    parKleur.DbType = DbType.String;
                    parKleur.Size = 10;
                    parKleur.Direction = ParameterDirection.Output;
                    MijnCommand.Parameters.Add(parKleur);

                    var parKostprijs = MijnCommand.CreateParameter();
                    parKostprijs.ParameterName = "@kostprijs";
                    parKostprijs.DbType = DbType.Currency;
                    parKostprijs.Size = 30;
                    parKostprijs.Direction = ParameterDirection.Output;
                    MijnCommand.Parameters.Add(parKostprijs);

                    MijnConnectie.Open();
                    MijnCommand.ExecuteNonQuery();
                    if (parNaam.Value.Equals(DBNull.Value))
                        throw new Exception("PLantgegevens niet gevonden...");
                    PlantGegevens result = new PlantGegevens(plantNr, parNaam.Value.ToString(), parSoort.Value.ToString(), parLeverancier.Value.ToString(), parKleur.Value.ToString(), (Decimal)parKostprijs.Value);
                    return result;



                }
            }
            
        }





        public ObservableCollection<PlantGegevens> GetLijstPlanten(Soort keuzesoort)
        {
            ObservableCollection<PlantGegevens> lPlanten = new ObservableCollection<PlantGegevens>();
            var manager = new DBTuincerntrum();

            using (var MijnConnectie = manager.GetConnection())
            {
                using (var MijnCommand = MijnConnectie.CreateCommand())
                {
                    MijnCommand.CommandType = CommandType.Text;

                    if (keuzesoort != null)
                    {
                        MijnCommand.CommandText =
                            MijnCommand.CommandText =
                            "SELECT Planten.PlantNr, Planten.Naam ,Soorten.Soort AS Soort ,Leveranciers.Naam AS Leverancier ,[Kleur] ,[VerkoopPrijs] FROM Tuincentrum.dbo.Planten INNER JOIN Tuincentrum.dbo.Soorten ON Soorten.SoortNr = Planten.SoortNr INNER JOIN Tuincentrum.dbo.Leveranciers ON Leveranciers.LevNr = Planten.Levnr WHERE Soorten.SoortNr = @soortNr";
                        var parZoals = MijnCommand.CreateParameter();
                        parZoals.ParameterName = "@soortNr";
                        parZoals.Value = keuzesoort.SoortNr;
                        MijnCommand.Parameters.Add(parZoals);
                    }
                    else
                        MijnCommand.CommandText =
                            "SELECT Planten.PlantNr, Planten.Naam ,Soorten.Soort AS Soort ,Leveranciers.Naam AS Leverancier ,[Kleur] ,[VerkoopPrijs] FROM Tuincentrum.dbo.Planten INNER JOIN Tuincentrum.dbo.Soorten ON Soorten.SoortNr = Planten.SoortNr INNER JOIN Tuincentrum.dbo.Leveranciers ON Leveranciers.LevNr = Planten.Levnr";

                    MijnConnectie.Open();
                    using (var objPlant = MijnCommand.ExecuteReader())
                    {
                        //Int32 plantNr = objPlant.GetOrdinal("BrouwerNr");
                        //GetOrdinal => nakijken welke kolom op welk nummer zit
                        Int32 kolomNrNr = objPlant.GetOrdinal("PlantNr");
                        Int32 kolomNrNaam = objPlant.GetOrdinal("Naam");
                        Int32 kolomNrSoort = objPlant.GetOrdinal("Soort");
                        Int32 kolomNrLeverancier = objPlant.GetOrdinal("Leverancier");
                        Int32 kolomNrKleur = objPlant.GetOrdinal("Kleur");
                        Int32 kolomNrPrijs = objPlant.GetOrdinal("VerkoopPrijs");
                        
                        while (objPlant.Read())
                        {
                            /*PlantGegevens(
                                string naam, 
                                string soort, 
                                string leverancier, 
                                string kleur,
                                decimal kprijs)*/
                            lPlanten.Add(
                                new PlantGegevens(
                                    objPlant.GetInt32(kolomNrNr), 
                                    objPlant.GetString(kolomNrNaam),
                                    objPlant.GetString(kolomNrSoort),
                                    objPlant.GetString(kolomNrLeverancier),
                                    objPlant.GetString(kolomNrKleur),
                                    objPlant.GetDecimal(kolomNrPrijs)));

                        } // do while
                    } // using rdrBrouwers
                } // using comBrouwers
            } // using conBieren

            return lPlanten;
        }
        public ObservableCollection<Soort> GetLijstSoorten()
        {
            ObservableCollection<Soort> lPlanten = new ObservableCollection<Soort>();
            var manager = new DBTuincerntrum();

            using (var MijnConnectie = manager.GetConnection())
            {
                using (var MijnCommand = MijnConnectie.CreateCommand())
                {
                    MijnCommand.CommandType = CommandType.Text;
                    MijnCommand.CommandText =
                        "SELECT * FROM Soorten";

                    MijnConnectie.Open();
                    using (var objSoort = MijnCommand.ExecuteReader())
                    {
                        //GetOrdinal => nakijken welke kolom op welk nummer zit
                        Int32 kolomNrSoortNr = objSoort.GetOrdinal("SoortNr");
                        Int32 kolomNrSoort = objSoort.GetOrdinal("Soort");
                        Int32 kolomNrMagazijn = objSoort.GetOrdinal("MagazijnNr");
                        

                        while (objSoort.Read())
                        {
                            lPlanten.Add(
                                new Soort(
                                    objSoort.GetInt32(kolomNrSoortNr),
                                    objSoort.GetString(kolomNrSoort),
                                    objSoort.GetByte(kolomNrMagazijn)));

                        } // do while
                    }// using objSoort
                } // using MijnCommand
            } // using MijnConnectie

            return lPlanten;
        }

        public List<PlantGegevens> SchrijfWijzigingen(List<PlantGegevens> aangepastePlanten)
        {
            List<PlantGegevens> nietDoorgevoerdePlanten = new List<PlantGegevens>();
            var manager = new DBTuincerntrum();
            using (var conBieren = manager.GetConnection())
            {
                using (var comUpdate = conBieren.CreateCommand())
                {
                    comUpdate.CommandType = CommandType.Text;
                    comUpdate.CommandText = "UPDATE Planten SET Kleur = @kleur, VerkoopPrijs = @prijs WHERE PlantNr = @plantNr";

                    var parPlantNr = comUpdate.CreateParameter();
                    parPlantNr.ParameterName = "@plantNr";
                    comUpdate.Parameters.Add(parPlantNr);

                    var parPlantKleur = comUpdate.CreateParameter();
                    parPlantKleur.ParameterName = "@kleur";
                    comUpdate.Parameters.Add(parPlantKleur);

                    var parPlantPrijs = comUpdate.CreateParameter();
                    parPlantPrijs.ParameterName = "@prijs";
                    comUpdate.Parameters.Add(parPlantPrijs);

                    conBieren.Open();
                    foreach (PlantGegevens eenPlant in aangepastePlanten)
                    {
                        try
                        {
                            parPlantNr.Value = eenPlant.Nummer;
                            parPlantKleur.Value = eenPlant.Kleur;
                            parPlantPrijs.Value = eenPlant.Kostprijs;

                            // indien je een null naar de DB moet sturen
                            //if (eenPlant.Omzet.HasValue)
                            //{
                            //    parOmzet.Value = eenPlant.Omzet;
                            //}
                            //else { parOmzet.Value = DBNull.Value; }
                            

                            if (comUpdate.ExecuteNonQuery() == 0)
                                nietDoorgevoerdePlanten.Add(eenPlant);
                        }
                        catch (Exception)
                        {
                            nietDoorgevoerdePlanten.Add(eenPlant);
                        }
                    } // foreach
                } // comUpdate
            } // conBieren
            return nietDoorgevoerdePlanten;
        }



    }
}
