using eWave.TopMovies.eWave.TopMovies.BL;
using eWave.TopMovies.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace eWave.TopMovies.eWave.TopMovies.DAL
{
    public class MoviesXmlContext
    {
        public static List<Movie> AddMovie(Movie movie)
        {
            if (!File.Exists("Movies.xml"))
            {
                CreateXml(movie);
            }
            else
            {
                CheckIfGreaterThanTen();
                AddMovieElement(movie);
            }
            return GetMovies();
        }

        private static void CheckIfGreaterThanTen()
        {
            var movieList = DeserializeMoviesXml();
            if (movieList.Count >= 10)
            {
                int movieIdToDelete = Movies_BL.GetMovieMinRating(movieList);
                DeleteMovieElament(movieIdToDelete);
            }
        }

        public static List<Movie> GetMovies()
        {
            return DeserializeMoviesXml();
        }

        internal static Movie GetMovie(int id)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Movie));
            var xDoc = XDocument.Load("Movies.xml");
            var movieElemant = xDoc.Root.Descendants("Movie").FirstOrDefault(x => x.Element("Id").Value == id.ToString());
            Movie _movie = (Movie)serializer.Deserialize(movieElemant.CreateReader());
            return _movie;
        }

        public static void CreateXml(Movie movie)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = true;
            using (XmlWriter writer = XmlWriter.Create("Movies.xml", settings))
            {
                writer.WriteStartElement("Movies");
                writer.WriteStartElement("Movie");
                writer.WriteElementString("Id", movie.Id.ToString());
                writer.WriteElementString("Title", movie.Title);
                writer.WriteElementString("Category", movie.Category);
                writer.WriteElementString("ImgUrl", movie.ImgUrl.ToString());
                writer.WriteElementString("Rating", movie.Rating.ToString());
                writer.WriteEndElement();
                writer.Flush();
            }
        }

        public static void AddMovieElement(Movie movie)
        {
            Random rnd = new Random();
            XDocument doc_ = XDocument.Load(("Movies.xml"));
            XElement school = doc_.Element("Movies");
            school.Add(new XElement("Movie",
                  new XElement("Id", rnd.Next(0, int.MaxValue)),
                       new XElement("Title", movie.Title),
                         new XElement("Category", movie.Category),
                           new XElement("ImgUrl", movie.ImgUrl),
                            new XElement("Rating", movie.Rating)
                       ));
            doc_.Save("Movies.xml");
        }

        public static void UpdateMovieElemant(int id, Movie movie)
        {
            var xDoc = XDocument.Load("Movies.xml");
            var movieElemant = xDoc.Root.Descendants("Movie").FirstOrDefault(x => x.Element("Id").Value == id.ToString());
            movieElemant.Element("Title").Value = movie.Title;
            movieElemant.Element("Category").Value = movie.Category;
            movieElemant.Element("Rating").Value = movie.Rating.ToString();
            movieElemant.Element("ImgUrl").Value = movie.ImgUrl;
            xDoc.Save("Movies.xml");

        }

        public static void DeleteMovieElament(int id)
        {
            var xDoc = XDocument.Load("Movies.xml");
            var movieElemant = xDoc.Root.Descendants("Movie").FirstOrDefault(x => x.Element("Id").Value == id.ToString());
            movieElemant.Remove();
            xDoc.Save("Movies.xml");

        }

        public static List<Movie> DeserializeMoviesXml()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Movies));
            List<Movie> movies = new List<Movie>();
            using (FileStream fileStream = new FileStream("Movies.xml", FileMode.Open))
            {
                Movies _moviesXml = (Movies)serializer.Deserialize(fileStream);
                movies = _moviesXml.moviesItems;
            }
            return movies;
        }
    }

}
