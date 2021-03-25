using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieList.Models;


namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        //add the _context (allows you to edit/delete)
        private MovieDBContext context { get; set; }

        //constructor
        public HomeController(MovieDBContext con)
        {
            context = con;
        }

        //add the _repository (allows you to delete)

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
          //  _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Movie m)
        {
            //this will add the movie that we just submitted into our database
            if (ModelState.IsValid)
            {
                context.Movies.Add(m);
                context.SaveChanges();
            }


            return View("MovieList", context.Movies);
        }

        public IActionResult Edit(int MovieID)
        {
            //gets you to the edit page and passes in the object you're edited so that it can autopopulate
            if (ModelState.IsValid)
            {
                Movie myMovie = context.Movies.Find(MovieID);
                context.Movies.Update(myMovie);
                context.SaveChanges();
            }

            return View("MovieEditForm", context.Movies.Find(MovieID));
        }

        public IActionResult Delete(int MovieID)
        {
            //Delete method which will find the movie and then delete it from the database
            if (ModelState.IsValid)
            {
                Movie myMovie = context.Movies.Find(MovieID);
                context.Movies.Remove(myMovie);
                context.SaveChanges();
            }
            //we have to pass in both because the object reference has to be set to the instance of an object
            return View("MovieList", context.Movies);
        }


        public IActionResult MovieList()
        {
            return View(context.Movies);
        }

        //returns podcast page
        public IActionResult Podcast()
        {
            return View();
        }

        public IActionResult MovieEditForm(Movie movie)
        {
            //edit the row
            if (ModelState.IsValid)
            {

                context.Movies.Update(movie);
                context.SaveChanges();


            }
            //passing back in the movie we just edited
            return View("MovieList", context.Movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
