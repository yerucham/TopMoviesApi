using eWave.TopMovies.eWave.TopMovies.DAL;
using eWave.TopMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace eWave.TopMovies.Repositories
{
    public class MovieRepository : iMovieRepository
    {
        public List<Movie> Create(Movie movie)
        {
           return MoviesXmlContext.AddMovie(movie);
        }
         
        public void Delete(int id)
        {
            MoviesXmlContext.DeleteMovieElament(id);
           
        }

        public List<Movie> Get()
        {   
            return MoviesXmlContext.GetMovies();
        }

        public XElement Get(int id)
        {
           return MoviesXmlContext.GetMovie(id);
        }
            public void Update(int id,Movie movie)
        {
            MoviesXmlContext.UpdateMovieElemant(id,movie);
        }
    }
}
