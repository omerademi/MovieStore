using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieSite.Data.Entities
{
    public class MoviePersons
    {
        public int MovieID { get; set; }
        public int PersonID { get; set; }
        public int PersonRoleID { get; set; }

        public Movie Movie { get; set; }
        public Persons Person { get; set; }
        public PersonRole PersonRole { get; set; }

    }
}
