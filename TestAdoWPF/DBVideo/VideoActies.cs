using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Transactions;

namespace DBVideo
{
    public class VideoActies
    {
        public ObservableCollection<Films> GetFilms()
        {
            ObservableCollection<Films> lFilms = new ObservableCollection<Films>();
            var manager = new DBconnectie();
            using (var connection = manager.GetConnection())
            {
                using (var mijnCommand = connection.CreateCommand())
                {
                    mijnCommand.CommandType = CommandType.Text;
                    //mijnCommand.CommandText = "SELECT BandNr ,Titel ,Genres.GenreNr AS GNR ,Genres.Genre AS G ,InVoorraad ,UitVoorraad ,Prijs ,TotaalVerhuurd FROM Films INNER JOIN Genres ON Genres.GenreNr = Films.GenreNr ORDER BY Titel";
                    mijnCommand.CommandText = "SELECT BandNr ,Titel ,GenreNr ,InVoorraad ,UitVoorraad ,Prijs ,TotaalVerhuurd FROM Films ORDER BY Titel";


                    connection.Open();

                    using (var reader = mijnCommand.ExecuteReader())
                    {
                        Int32 kolomNr = reader.GetOrdinal("BandNr");
                        Int32 kolomTitel = reader.GetOrdinal("Titel");
                        Int32 kolomGNR = reader.GetOrdinal("GenreNr");
                        //Int32 kolomG = reader.GetOrdinal("G");
                        Int32 kolomIn = reader.GetOrdinal("InVoorraad");
                        Int32 kolomUit = reader.GetOrdinal("UitVoorraad");
                        Int32 kolomPrijs = reader.GetOrdinal("Prijs");
                        Int32 kolomVerhuurd = reader.GetOrdinal("TotaalVerhuurd");

                        while (reader.Read())
                        {
                            lFilms.Add(
                                new Films(reader.GetInt32(kolomNr),
                                reader.GetString(kolomTitel),
                                //(new Genres(reader.GetInt32(kolomGNR), reader.GetString(kolomG))),
                                reader.GetInt32(kolomGNR),
                                reader.GetInt32(kolomIn),
                                reader.GetInt32(kolomUit),
                                reader.GetDecimal(kolomPrijs),
                                reader.GetInt32(kolomVerhuurd)
                                ));
                        }
                    }//reader
                }//mijncommand
            }//connectie



            return lFilms;
        }
        public ObservableCollection<Genres> GetGenres()
        {
            ObservableCollection<Genres> lGenres = new ObservableCollection<Genres>();
            var manager = new DBconnectie();
            using (var connection = manager.GetConnection())
            {
                using (var mijnCommand = connection.CreateCommand())
                {
                    mijnCommand.CommandType = CommandType.Text;
                    mijnCommand.CommandText = "SELECT * FROM Genres";


                    connection.Open();

                    using (var reader = mijnCommand.ExecuteReader())
                    {
                        Int32 kolomGNR = reader.GetOrdinal("GenreNr");
                        Int32 kolomG = reader.GetOrdinal("Genre");
                        
                        while (reader.Read())
                        {
                            lGenres.Add(
                                new Genres(reader.GetInt32(kolomGNR),
                                reader.GetString(kolomG)
                                ));
                        }
                    }//reader
                }//mijncommand
            }//connectie



            return lGenres;
        }

        public List<Films> Opslaan(List<Films> lOpslaan)
        {
            List<Films> mislukt = new List<Films>();
            var manager = new DBconnectie();
            using (var connection = manager.GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    //command.CommandType = CommandType.Text;
                    //command.CommandText = "INSERT INTO Films(Titel,GenreNr,InVoorraad,UitVoorraad,Prijs,TotaalVerhuurd) VALUES(@titel, @genreNr, @inVoorraad ,@uitVoorraad ,@prijs,@totaalVerhuurd)";
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "NieuweFilmToevoegen";

                    //@titel, @genreNr, @inVoorraad ,@uitVoorraad ,@prijs,@totaalVerhuurd

              
                    var partitel = command.CreateParameter();
                    partitel.ParameterName = "@titel";
                    command.Parameters.Add(partitel);
                    var pargenreNr = command.CreateParameter();
                    pargenreNr.ParameterName = "@genreNr";
                    command.Parameters.Add(pargenreNr);

                    var parVoorraad = command.CreateParameter();
                    parVoorraad.ParameterName = "@inVoorraad";
                    command.Parameters.Add(parVoorraad);
                    var parUit = command.CreateParameter();
                    parUit.ParameterName = "@uitVoorraad";
                    command.Parameters.Add(parUit);
                    var parPrijs = command.CreateParameter();
                    parPrijs.ParameterName = "@prijs";
                    command.Parameters.Add(parPrijs);
                    var parVerhuurd = command.CreateParameter();
                    parVerhuurd.ParameterName = "@totaalVerhuurd";
                    command.Parameters.Add(parVerhuurd);


                    //output
                    /*
                    var parBandNr = command.CreateParameter();
                    parBandNr.DbType = DbType.Int16;
                    parBandNr.Direction = ParameterDirection.Output;
                    parBandNr.ParameterName = "@bandNr";
                    command.Parameters.Add(parBandNr);*/

                    connection.Open();


                    foreach (Films film in lOpslaan)
                    {
                        try
                        {
                            //@titel, @genreNr, @inVoorraad ,@uitVoorraad ,@prijs,@totaalVerhuurd
                            partitel.Value = film.Titel;
                            //pargenreNr.Value = film.Genre.Nummer;
                            pargenreNr.Value = film.GenreNr;
                            parVoorraad.Value = film.InVoorraad;
                            parUit.Value = film.UitVoorraad;
                            parPrijs.Value = film.Prijs;
                            parVerhuurd.Value = film.TotaalVerhuurd;
                            //film.BandNr = (int)parBandNr.Value;
                            
                            //ExecuteScalar();
                            //if (command.ExecuteNonQuery() == 0)
                            //    mislukt.Add(film);

                            //command.CommandText = "SELECT @@IDENTITY";
                            film.BandNr = int.Parse(command.ExecuteScalar().ToString());

                        }
                        catch (Exception)
                        {
                            mislukt.Add(film);
                        }
                    }


                }//command
            }//connection


            return mislukt;
        }
        public List<Films> Verwijderen(List<Films> lVerwijderen)
        {
            List<Films> mislukt = new List<Films>();
            var manager = new DBconnectie();
            

            using (var connect = manager.GetConnection())
            {
                using (var command = connect.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "DELETE from Films WHERE BandNr = @bandNr";
                    var parNr = command.CreateParameter();
                    parNr.ParameterName = "@bandNr";
                    command.Parameters.Add(parNr);
                    connect.Open();
                    foreach (Films film in lVerwijderen)
                    {
                        try
                        {
                            if (film.BandNr != 0) //bandNr zetten
                            {
                                parNr.Value = film.BandNr;
                                if (command.ExecuteNonQuery() == 0)
                                    mislukt.Add(film);
                            }
                        }
                        catch (Exception)
                        {

                            mislukt.Add(film);
                        }

                    }
                }//command
            }//connect
            return mislukt;
        }



        public List<Films> Aanpassen(List<Films> lAanpassen)
        {

            List<Films> mislukt = new List<Films>();
            var manager = new DBconnectie();
            using (var connection = manager.GetConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "UPDATE Films SET Titel = @titel, GenreNr = @genreNr, InVoorraad = @invoorraad, UitVoorraad = @uitVoorraad, Prijs=@prijs, TotaalVerhuurd =@totaalVerhuurd WHERE(BandNr = @bandNr); ";



                    //WHERE
                    var parBandNr = command.CreateParameter();
                    parBandNr.ParameterName = "@bandNr";
                    command.Parameters.Add(parBandNr);

                    //SETTERS
                    var partitel = command.CreateParameter();
                    partitel.ParameterName = "@titel";
                    command.Parameters.Add(partitel);
                    

                    var pargenreNr = command.CreateParameter();
                    pargenreNr.ParameterName = "@genreNr";
                    command.Parameters.Add(pargenreNr);

                    var parVoorraad = command.CreateParameter();
                    parVoorraad.ParameterName = "@inVoorraad";
                    command.Parameters.Add(parVoorraad);
                    var parUit = command.CreateParameter();
                    parUit.ParameterName = "@uitVoorraad";
                    command.Parameters.Add(parUit);
                    var parPrijs = command.CreateParameter();
                    parPrijs.ParameterName = "@prijs";
                    command.Parameters.Add(parPrijs);
                    var parVerhuurd = command.CreateParameter();
                    parVerhuurd.ParameterName = "@totaalVerhuurd";
                    command.Parameters.Add(parVerhuurd);

                    connection.Open();


                    foreach (Films film in lAanpassen)
                    {
                        try
                        {
                            //@titel, @genreNr, @inVoorraad ,@uitVoorraad ,@prijs,@totaalVerhuurd
                            parBandNr.Value = film.BandNr;
                            partitel.Value = film.Titel;
                            pargenreNr.Value = film.GenreNr;
                            parVoorraad.Value = film.InVoorraad;
                            parUit.Value = film.UitVoorraad;
                            parPrijs.Value = film.Prijs;
                            parVerhuurd.Value = film.TotaalVerhuurd;
                            

                            if (command.ExecuteNonQuery() == 0)
                                mislukt.Add(film);
                        }
                        catch (Exception)
                        {
                            mislukt.Add(film);
                        }
                    }


                }//command
            }//connection

    
            return mislukt;
        }
    }
}
