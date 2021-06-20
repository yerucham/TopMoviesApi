using eWave.TopMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWave.TopMovies.eWave.TopMovies.BL
{
    public class Movies_BL
    {

        public static int GetMovieMinRating(List<Movie> movies)
        {
            List<Movie> sortedListByRating = movies.OrderBy(o => o.Rating).ToList();

            return sortedListByRating[0].Id;
        }
    }
}
