using eWave.TopMovies.Models;
using eWave.TopMovies.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace eWave.TopMovies.Controllers
{

   
    [Route("api/[controller]")]
    [ApiController]  
    public class MoviesController : ControllerBase
    {
        private iMovieRepository _movieRepository;

        public MoviesController(iMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return  _movieRepository.Get();
        }

        [HttpGet("{id}")]
        public Movie GetMovie(int id)
        {
            return  _movieRepository.Get(id);
        }

        [HttpPost]
        public  List<Movie> PostMovies([FromBody] Movie movie)
        {
            return _movieRepository.Create(movie);
   
        }

        [HttpPut]
        public async Task<ActionResult> PutMovies(int id, [FromBody] Movie movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
             _movieRepository.Update(id,movie);
            return Ok(_movieRepository.Get());
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {

            var movieToDelete =  _movieRepository.Get(id);
            if (movieToDelete==null)
            {
                return NotFound();
            }
             _movieRepository.Delete(id);
            return Ok(_movieRepository.Get());
        }
    }
}
