using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DBConnectie
{
    public class LeverancierActies
    {
        public ObservableCollection<Leverancier> GetLeveranciers()
        {
            ObservableCollection<Leverancier> leveranciers = new ObservableCollection<Leverancier>();
            var manager = new DBTuincerntrum();
            using (var connection = manager.GetConnection())
            {
                using (var mijnCommand = connection.CreateCommand())
                {
                    mijnCommand.CommandType = CommandType.Text;
                    mijnCommand.CommandText = "Select * from Leveranciers";
                    connection.Open();

                    using (var reader = mijnCommand.ExecuteReader())
                    {
                        Int32 kolomNr = reader.GetOrdinal("LevNr");
                        Int32 kolomNaam = reader.GetOrdinal("Naam");
                        Int32 kolomAdres = reader.GetOrdinal("Adres");
                        Int32 kolomPostNr = reader.GetOrdinal("PostNr");
                        Int32 kolomWoonplaats = reader.GetOrdinal("Woonplaats");

                        while (reader.Read())
                        {
                            leveranciers.Add(
                                new Leverancier(reader.GetInt32(kolomNr),
                                reader.GetString(kolomNaam),
                                reader.GetString(kolomAdres),
                                reader.GetString(kolomPostNr),
                                reader.GetString(kolomWoonplaats)));
                        }
                    }//reader
                }//mijncommand
            }//connectie



                return leveranciers;
        }



        public List<Leverancier> SchrijfVerwijdering(List<Leverancier> leveranciers)
        {
            var manager = new DBTuincerntrum();
            List<Leverancier> mislukt = new List<Leverancier>();

            using (var connect = manager.GetConnection())
            {
                using (var command = connect.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE from Leveranciers WHERE LevNr = @levNr";
                    var parNr = command.CreateParameter();
                    parNr.ParameterName = "@levNr";
                    command.Parameters.Add(parNr);
                    connect.Open();
                    foreach (Leverancier lev in leveranciers)
                    {
                        try
                        {
                            parNr.Value = lev.LevNr;
                            if (command.ExecuteNonQuery() == 0)
                                mislukt.Add(lev);
                        }
                        catch (Exception)
                        {

                            mislukt.Add(lev);
                        }

                    }
                }//command
            }//connect
            return mislukt;

        }

        public List<Leverancier> SchrijfToevoegingen(List<Leverancier> leveranciers)
        {
            var manager = new DBTuincerntrum();
            List<Leverancier> mislukt = new List<Leverancier>();
            using (var connection = manager.GetConnection() )
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT INTO leveranciers(Naam, Adres, PostNr, Woonplaats) VALUES(@naam, @adres,@postcode,@gemeente)";

                    var parNaam = command.CreateParameter();
                    parNaam.ParameterName = "@naam";
                    command.Parameters.Add(parNaam);
                    var parAdres = command.CreateParameter();
                    parAdres.ParameterName = "@adres";
                    command.Parameters.Add(parAdres);
                    var parPostNr = command.CreateParameter();
                    parPostNr.ParameterName = "@postcode";
                    command.Parameters.Add(parPostNr);
                    var parGemeente = command.CreateParameter();
                    parGemeente.ParameterName = "@gemeente";
                    command.Parameters.Add(parGemeente);

                    connection.Open();


                    foreach (Leverancier    lev in leveranciers)
                    {
                        try
                        {
                            parNaam.Value = lev.Naam;
                            parAdres.Value = lev.Adres;
                            parPostNr.Value = lev.PostNr;
                            parGemeente.Value = lev.Woonplaats;
                            if(command.ExecuteNonQuery()==0)
                                mislukt.Add(lev);
                        }
                        catch(Exception)
                        {
                            mislukt.Add(lev);
                        }
                    }


                }//command
            }//connection

            return mislukt;
        }

        public List<Leverancier> SchrijfWijzigingen(List<Leverancier> leveranciers)
        {
            var manager = new DBTuincerntrum();
            List<Leverancier> mislukt = new List<Leverancier>();

            using (var connection = manager.GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE leveranciers SET Naam= @naam, Adres=@adres, PostNr=@postnr, Woonplaats=@gemeente WHERE LevNr = @levNr";

                    var parNaam = command.CreateParameter();
                    parNaam.ParameterName = "@naam";
                    command.Parameters.Add(parNaam);
                    var parAdres = command.CreateParameter();
                    parAdres.ParameterName = "@adres";
                    command.Parameters.Add(parAdres);
                    var parPostNr = command.CreateParameter();
                    parPostNr.ParameterName = "@postcode";
                    command.Parameters.Add(parPostNr);
                    var parGemeente = command.CreateParameter();
                    parGemeente.ParameterName = "@gemeente";
                    command.Parameters.Add(parGemeente);

                    var parLevNr = command.CreateParameter();
                    parLevNr.ParameterName = "@levNr";
                    command.Parameters.Add(parLevNr);

                    connection.Open();


                    foreach (Leverancier lev in leveranciers)
                    {
                        try
                        {
                            parNaam.Value = lev.Naam;
                            parAdres.Value = lev.Adres;
                            parPostNr.Value = lev.PostNr;
                            parGemeente.Value = lev.Woonplaats;
                            parLevNr.Value = lev.LevNr;
                            if (command.ExecuteNonQuery() == 0)
                                mislukt.Add(lev);
                        }
                        catch (Exception)
                        {

                            mislukt.Add(lev);
                        }
                    }

                    }//command
            }//connection
            return mislukt;
        }

    }
}
