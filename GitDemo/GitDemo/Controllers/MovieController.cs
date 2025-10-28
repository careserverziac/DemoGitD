using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using GitDemo.Models;

namespace GitDemo.Controllers
{
    public class MovieController : Controller
    {
        // Simulated database
        private static List<Movie> movies = new List<Movie>
        {
            new Movie { Id = 1, Name = "Inception" },
            new Movie { Id = 2, Name = "The Dark Knight" },
            new Movie { Id = 3, Name = "Interstellar" }
        };

        // GET: Movies
        public ActionResult Index()
        {
            return View(movies);
        }

        // GET: Movies/Details/1
        public ActionResult Details(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.Id = movies.Max(m => m.Id) + 1;
                movies.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Edit/2
        public ActionResult Edit(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // POST: Movies/Edit/2
        [HttpPost]
        public ActionResult Edit(Movie updatedMovie)
        {
            if (ModelState.IsValid)
            {
                var movie = movies.FirstOrDefault(m => m.Id == updatedMovie.Id);
                if (movie == null)
                    return HttpNotFound();

                movie.Name = updatedMovie.Name;
                return RedirectToAction("Index");
            }
            return View(updatedMovie);
        }

        // GET: Movies/Delete/3
        public ActionResult Delete(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // POST: Movies/Delete/3
        //[HttpPost, ActionName("Delete")]
        [HttpPost]

        public ActionResult DeleteConfirmed(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
                movies.Remove(movie);

            return RedirectToAction("Index");
        }
    }
}
