using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnectie;
using System.Data.Common;
using System.Transactions;

namespace DBConnectie
{
    public class TuincentrumActies
    {
        public void LeverancierToevoegen(Leverancier eenLeverancier)
        {
            var manager = new DBTuincerntrum();
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
                    comToevoegen.ExecuteNonQuery();
                }
            }
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
                        par1.Value = 14;
                        MijnCommand.Parameters.Add(par1);

                        var par2 = MijnCommand.CreateParameter();
                        par2.ParameterName = "@leverancierID2";
                        par2.Value = 3;
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
                    PlantGegevens result = new PlantGegevens(parNaam.Value.ToString(), parSoort.Value.ToString(), parLeverancier.Value.ToString(), parKleur.Value.ToString(), (Decimal)parKostprijs.Value);
                    return result;



                }
            }
            
        }











                }
}
