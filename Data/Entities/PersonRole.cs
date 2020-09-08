using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSite.Data.Entities
{
    public class PersonRole
    {
        [Key]
        public int Id { get; set; }

        [StringLength(45)]
        public string Name { get; set; }

        public virtual ICollection<MoviePersons> MoviePersons { get; set; }
    }
}
