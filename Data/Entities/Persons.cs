using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSite.Data.Entities
{
    public class Persons
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(700)]
        public string Biography { get; internal set; }

        [StringLength(50)]
        public string PlaceOfBirth { get; internal set; }

        [StringLength(10)]
        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }

        public virtual ICollection<MoviePersons> MoviePersons { get; set; }
    }
}
