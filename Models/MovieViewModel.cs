using Microsoft.AspNetCore.Mvc.Rendering;
using MovieSite.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSite.Models
{
    public class MovieViewModel
    {
        // Movie Data

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Display(Name = "Runtime")]
        public string MovieLenght { get; set; }

        public double Rating { get; set; }

        [Display(Name = "Release Date")]
        public DateTime? DateReleased { get; set; }

        public string PosterPath { get; set; }

        public int SelectedDirector { get; set; }
        public IEnumerable<string> SelectedActors { get; set; }
        public int SelectedScreenplay { get; set; }


        // Genres Data
        public IEnumerable<SelectListItem> GenresList { get; set; }
        public IEnumerable<string> SelectedGenres { get; set; }

        // Person
        public IEnumerable<SelectListItem> PersonsList { get; set; }
        public int PersonID { get; set; }

    }
}
