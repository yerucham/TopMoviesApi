using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace eWave.TopMovies.Models
{
    [XmlRoot("Movies")]
    public class Movies
    {
        [XmlElement("Movie")]
        public List<Movie> moviesItems { get; set; }
    }
}
