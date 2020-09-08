using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieSite.Data.Entities;

namespace MovieSite.Data
{
    public class MovieDbContext : IdentityDbContext<IdentityUser>
    {
        public MovieDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Persons> Persons { get; set; }
        public DbSet<PersonRole> PersonRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Movie Genres reference
            modelBuilder.Entity<MovieGenres>().HasKey(mg => new { mg.MovieID, mg.GenreID });

            // Movie Persons Reference
            modelBuilder.Entity<MoviePersons>().HasKey(mp => new { mp.MovieID, mp.PersonID, mp.PersonRoleID });

            //Seeding Data

            // Genres Seeding

            modelBuilder.Entity<Genres>().HasData
                (
                    new Genres()
                    {
                        Id = 1,
                        Name = "Action"
                    },
                    new Genres()
                    {
                        Id = 2,
                        Name = "Drama"
                    },
                    new Genres()
                    {
                        Id = 3,
                        Name = "Thriller"
                    },
                    new Genres()
                    {
                        Id = 4,
                        Name = "Crime"
                    },
                     new Genres()
                     {
                         Id = 5,
                         Name = "Comedy"
                     }
                );

            //Person Role seeding

            modelBuilder.Entity<PersonRole>().HasData
               (
                   new PersonRole()
                   {
                       Id = 1,
                       Name = "Director"
                   },
                   new PersonRole()
                   {
                       Id = 2,
                       Name = "Actor"
                   },
                   new PersonRole()
                   {
                       Id = 3,
                       Name = "Screenplay"
                   }
               );

            // Persons seeding

            modelBuilder.Entity<Persons>().HasData
               (
                   new Persons()
                   {
                       Id = 1,
                       FirstName = "Cathy",
                       LastName = "Yan",
                       Biography = "Cathy Yan is a filmmaker based in New York City, born in China and raised between Hong Kong and Washington, DC. " +
                       "She is known for Dead Pigs (2018) and DC Extended Universe Film Birds of Prey.",
                       Gender = "Female",
                       PlaceOfBirth = "China"
                   },
                   new Persons()
                   {
                       Id = 2,
                       FirstName = "Christina",
                       LastName = "Hodson",
                       Biography = "Christina Hodson is a screenwriter whose screenplays include Shut In (2016) and Bumblebee (2018). She has had " +
                       "three scripts on the Black List, an annual list of Hollywood's best liked unproduced screenplays.",
                       Gender = "Female",
                       PlaceOfBirth = "London, England"
                   },
                   new Persons()
                   {
                       Id = 3,
                       FirstName = "Margot",
                       LastName = "Robbie",
                       Biography = "Margot Elise Robbie (born 2 July 1990) is an Australian actress and film producer. She is known for her role as " +
                       "Donna Freedman on the soap opera Neighbours, which earned her two Logie Award nominations. In 2011, Robbie began starring as Laura " +
                       "Cameron in the ABC drama series Pan Am. Following Pan Am's cancellation, Robbie has appeared in the feature films About Time (2013), " +
                       "The Wolf of Wall Street (2013), Suicide Squad (2016) and many more. In 2017 she starred in the biographical film I, Tonya, which earned " +
                       "her many accolades including her first Academy Award nomination. Since 2016 she has been married to British assistant director and " +
                       "producer Tom Ackerley.",
                       Gender = "Female",
                       PlaceOfBirth = "Dalby, Queensland, Australia",
                       DateOfBirth = new DateTime(1990 / 07 / 02)
                   },
                   new Persons()
                   {
                       Id = 4,
                       FirstName = "Joe",
                       LastName = "Russo",
                       Biography = "Anthony and Joe Russo, known together professionally as the Russo brothers, are Emmy Award-winning American film and television " +
                        "directors. The brothers direct most of their work jointly, and they also occasionally work as producers, actors, and editors. The Russos are " +
                        "from Cleveland, Ohio, and were born a year apart. They are alumni of Case Western Reserve University.",
                       Gender = "Male",
                       PlaceOfBirth = "Cleveland, Ohio, USA",
                       DateOfBirth = new DateTime(1971 / 07 / 08),
                   },
                   new Persons()
                   {
                       Id = 5,
                       FirstName = "Sam",
                       LastName = "Hargrave",
                       Gender = "Male"
                   },
                   new Persons()
                   {
                       Id = 6,
                       FirstName = "Chris",
                       LastName = "Hemsworth",
                       Biography = "Chris Hemsworth (born 11 August 1983) is an Australian actor. He is best known for his roles as Kim Hyde in the Australian TV series " +
                         "Home and Away (2004) and as Thor in the Marvel Cinematic Universe films Thor (2011), The Avengers (2012), Thor: The Dark World (2013) and Avengers: " +
                         "Age of Ultron (2015). He has also appeared in the science fiction action film Star Trek(2009), the thriller adventure A Perfect Getaway (2009), the " +
                         "horror comedy The Cabin in the Woods (2012), the dark fantasy action film Snow White and the Huntsman (2012), the war film Red Dawn (2012) and the" +
                         " biographical sports drama film Rush (2013).",
                       Gender = "Male",
                       PlaceOfBirth = "Melbourne, Victoria, Australia",
                       DateOfBirth = new DateTime(1983 / 08 / 11),
                   }

               ); ;

            // Movie seeding

            modelBuilder.Entity<Movie>().HasData
                (
                    new Movie()
                    {
                        MovieID = 1,
                        Title = "Birds of Prey (and the Fantabulous Emancipation of One Harley Quinn)",
                        Description = "Harley Quinn joins forces with a singer, an assassin and a police detective to help a young girl who had a hit placed on her " +
                        "after she stole a rare diamond from a crime lord.",
                        DateReleased = new DateTime(02 / 07 / 2020),
                        MovieLenght = "1h 49m",
                        Rating = 7.2,
                        PosterPath = "BirdsofPrey.jpg"

                    },
                    new Movie()
                    {
                        MovieID = 2,
                        Title = "Extraction",
                        Description = "Tyler Rake, a fearless mercenary who offers his services on the black market, embarks on a dangerous mission when he is hired " +
                        "to rescue the kidnapped son of a Mumbai crime lord…",
                        DateReleased = new DateTime(04 / 24 / 2020),
                        MovieLenght = "1h 56m",
                        Rating = 7.5,
                        PosterPath = "Extraction.jpg"

                    }
                );

            // Movie Genres seeding

            modelBuilder.Entity<MovieGenres>().HasData(
              new MovieGenres { MovieID = 1, GenreID = 1 },
              new MovieGenres { MovieID = 1, GenreID = 4 },
              new MovieGenres { MovieID = 1, GenreID = 5 },
              new MovieGenres { MovieID = 2, GenreID = 1 },
              new MovieGenres { MovieID = 2, GenreID = 2 },
              new MovieGenres { MovieID = 2, GenreID = 3 }
            );

            // Movie Persons seeding

            modelBuilder.Entity<MoviePersons>().HasData(

                new MoviePersons
                {
                    MovieID = 1,
                    PersonID = 1,
                    PersonRoleID = 1
                },
                new MoviePersons
                {
                    MovieID = 1,
                    PersonID = 3,
                    PersonRoleID = 2
                },
                new MoviePersons
                {
                    MovieID = 1,
                    PersonID = 2,
                    PersonRoleID = 3
                },
                new MoviePersons
                {
                    MovieID = 2,
                    PersonID = 5,
                    PersonRoleID = 1
                },
                new MoviePersons
                {
                    MovieID = 2,
                    PersonID = 6,
                    PersonRoleID = 2
                },
                new MoviePersons
                {
                    MovieID = 2,
                    PersonID = 4,
                    PersonRoleID = 3
                }
           );



            base.OnModelCreating(modelBuilder);


        }
    }
}
