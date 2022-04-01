using Cinemahub2.Models;
using Cinemahub2.Models.DTOs;
using Cinemahub2.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinemahub2.Controllers
{
    public class MoviesController : Controller
    {
       private IMoviesService movieService;
        private UserManager<User> userManager;
        public MoviesController(IMoviesService movieService, UserManager<User> userManager)
        {
            this.movieService = movieService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            List<MoviesDTO> movies = movieService.GetAll();

            return View(movies);
        }
        public async Task<IActionResult> UserMoviesAsync()
         {
             User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
             if (user is null)
             {
                 return RedirectToAction(nameof(Index));
             }
             List<MoviesDTO> movies = movieService.GetUserMovies(user.Id);
             return View(movies);
         }
        public IActionResult Details(int id)
        {
            ViewBag.movie = movieService.GetById(id);
            //Movies movie = movieService.GetById(id);
            return View();
        }
        public IActionResult Edit()
         {
             return View();
         }
         [HttpGet]
         public async Task<IActionResult> EditAsync(int id)
         {
             User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
             Movies movie = movieService.GetById(id);
             if (user is null)
             {
                 return RedirectToAction(nameof(Index));
             }
             /*if (movie.UserId != user.Id)
             {
                 return RedirectToAction(nameof(Index));
             }*/
             return View(movieService.GetById(id));
         }
         [HttpPost]
         public async Task<IActionResult> EditAsync(int id, Movies movie)
         {
             User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
             if (user is null)
             {
                 return RedirectToAction(nameof(Index));
             }
             if (movieService.GetById(id).UserId != user.Id)
             {
                 return RedirectToAction(nameof(Index));
             }
             movieService.Edit(movie);
             return RedirectToAction(nameof(Index));
         }
         [HttpGet]
         public IActionResult Create()
         {
             return View();
         }
         [HttpPost]
         public async Task<IActionResult> Create(Movies movie)
         {
             User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
             if (user is null)
             {
                 return RedirectToAction(nameof(Index));
             }
             if (!ModelState.IsValid)
             {
                 return View();
             }
             movieService.Create(movie, user);
             return RedirectToAction(nameof(Index));
         }
         [HttpGet]
         public async Task<IActionResult> DeleteAsync(int id)
         {
             User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
             Movies movie = movieService.GetById(id);
             if (user is null)
             {
                 return RedirectToAction(nameof(Index));
             }
             /*if (movie.UserId != user.Id)
             {
                 return RedirectToAction(nameof(Index));
             }*/
             return View(movie);
         }
         public async Task<IActionResult> ConfirmDeleteAsync(int id)
         {
             User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
             Movies movie = movieService.GetById(id);
             if (user is null)
             {
                 return RedirectToAction(nameof(Index));
             }
             /*if (movie.UserId != user.Id)
             {
                 return RedirectToAction(nameof(Index));
             }*/
             movieService.Delete(id);
             return RedirectToAction(nameof(Index));
         }
         [HttpGet]
         public IActionResult ViewActor(int id)
         {
             return View(movieService.GetById(id));
         }
    }
}
