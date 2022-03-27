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
    public class ActorController : Controller
    {
        private IActorService actorService;
        private UserManager<User> userManager;
        public ActorController(IActorService actorService, UserManager<User> userManager)
        {
            this.actorService = actorService;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
           List<ActorDTO> actors = actorService.GetAll();

            return View(actors);
        }
       public async Task<IActionResult> UserActorsAsync()
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            if (user is null)
            {
                return RedirectToAction(nameof(Index));
            }
            List<ActorDTO> actors = actorService.GetUserActors(user.Id);
            return View(actors);
        }
        public IActionResult Details(int id)
        {
            ViewBag.MyProperty = actorService.GetDtoById(id);
            List<MoviesDTO> movieActors = actorService.GetMovieActors(id);
            
            return View(movieActors);
        }
        public IActionResult Edit()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> EditAsync(int id)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            Actor actor = actorService.GetById(id);
            if (user is null)
            {
                return RedirectToAction(nameof(Index));
            }
            if (actor.UserId != user.Id)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(actorService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, Actor actor)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            if (user is null)
            {
                return RedirectToAction(nameof(Index));
            }
            if (actorService.GetById(id).UserId != user.Id)
            {
                return RedirectToAction(nameof(Index));
            }
            actorService.Edit(actor);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Actor actor)
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
            actorService.Create(actor, user);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            Actor actor = actorService.GetById(id);
            if (user is null)
            {
                return RedirectToAction(nameof(Index));
            }
            if (actor.UserId != user.Id)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }
        public async Task<IActionResult> ConfirmDeleteAsync(int id)
        {
            User user = await userManager.GetUserAsync(User).ConfigureAwait(false);
            Actor actor = actorService.GetById(id);
            if (user is null)
            {
                return RedirectToAction(nameof(Index));
            }
            if (actor.UserId != user.Id)
            {
                return RedirectToAction(nameof(Index));
            }
            actorService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult ViewActor(int id)
        {
            return View(actorService.GetById(id));
        } 
    }
}
