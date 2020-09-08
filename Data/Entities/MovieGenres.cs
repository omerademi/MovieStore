using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSite.Data.Entities
{
    public class MovieGenres
    {

        public int MovieID { get; set; }
        public int GenreID { get; set; }

        [StringLength(50)]
        public Movie Movie { get; set; }
        public Genres Genre { get; set; }
    }
}
