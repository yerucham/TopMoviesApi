using eWave.TopMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace eWave.TopMovies.Repositories
{
    public interface iMovieRepository
    {
        List<Movie> Get();
        Movie Get(int id);
        List<Movie> Create(Movie movie);
        void Update(int id,Movie movie);
        void Delete(int id);
    }
}
