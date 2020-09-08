using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSite.Data.Entities
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(20)]
        public string MovieLenght { get; set; }

        public double Rating { get; set; }

        public DateTime? DateReleased { get; set; }

        public string PosterPath { get; set; }

        public virtual ICollection<MovieGenres> MovieGenres { get; set; }
        public virtual ICollection<MoviePersons> MoviePersons { get; set; }
    }
}
