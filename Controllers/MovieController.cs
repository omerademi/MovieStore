using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieSite.Data;
using MovieSite.Data.Entities;
using MovieSite.Models;

namespace MovieSite.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieDbContext _context;

        public MovieController(MovieDbContext context)
        {
            _context = context;
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            return View(await _context.Movies.ToListAsync());
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            var genres = _context.Genres.AsEnumerable();
            var persons = _context.Persons.AsEnumerable();

            MovieViewModel movieViewModel = new MovieViewModel
            {
                GenresList = GetSelectListItemGenres(genres),
                PersonsList = GetSelectListItemPersons(persons)
            };
            return View(movieViewModel);
        }

        private IEnumerable<SelectListItem> GetSelectListItemPersons(IEnumerable<Persons> persons)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in persons)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.FirstName + " " + element.LastName,
                });
            }
            return selectList;
        }

        private IEnumerable<SelectListItem> GetSelectListItemGenres(IEnumerable<Genres> genres)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in genres)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel movieModel)
        {
            if (ModelState.IsValid)
            {
                var movie = new Movie()
                {
                    Title = movieModel.Title,
                    Description = movieModel.Description,
                    MovieLenght = movieModel.MovieLenght,
                    Rating = movieModel.Rating,
                    DateReleased = movieModel.DateReleased,
                    PosterPath = movieModel.PosterPath
                };
                _context.Add(movie);
                _context.SaveChanges();

                var getMovie = _context.Movies.Find(movie.MovieID);
                var listOfPersons = new List<MoviePersons>();
                listOfPersons.Add(new MoviePersons()
                {
                    MovieID = getMovie.MovieID,
                    PersonID = movieModel.SelectedDirector,
                    PersonRoleID = 1
                });
                listOfPersons.Add(new MoviePersons()
                {
                    MovieID = getMovie.MovieID,
                    PersonID = movieModel.SelectedScreenplay,
                    PersonRoleID = 3
                });
                foreach (var actorID in movieModel.SelectedActors)
                {
                    listOfPersons.Add(new MoviePersons()
                    {
                        MovieID = getMovie.MovieID,
                        PersonID = Convert.ToInt32(actorID),
                        PersonRoleID = 2
                    });
                }
                foreach (var item in listOfPersons)
                {
                    _context.Add(item);
                }
               

                var listOfGenres = new List<MovieGenres>();
                foreach (var genreId in movieModel.SelectedGenres)
                {
                    listOfGenres.Add(new MovieGenres
                    {
                        MovieID = getMovie.MovieID,
                        GenreID = Convert.ToInt32(genreId)
                    });
                }

                foreach (var item in listOfGenres)
                {
                    _context.Add(item);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieModel);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,MovieLenght,Raiting,DateReleased,PosterPath")] Movie movie)
        {
            if (id != movie.MovieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieID == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieID == id);
        }



    }
}
