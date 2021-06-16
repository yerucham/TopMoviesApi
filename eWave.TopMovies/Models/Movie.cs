using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace eWave.TopMovies.Models
{
    
    public class Movie
    {
        public Movie() { }
        public Movie(int id, string title, string category, int rating, string imgUrl)
        {
            Id = id;
            Title = title;
            Category = category;
            Rating = rating;
            ImgUrl = imgUrl;
        }

        [XmlElement("Id")]
        public int Id { get; set; }
        [XmlElement("Title")]
        public string Title { get; set; }
        [XmlElement("Category")]
        public string Category { get; set; }
        [XmlElement("Rating")]
        public int Rating { get; set; }
        [XmlElement("ImgUrl")]
        public string ImgUrl { get; set; }
    }
}
