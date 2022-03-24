﻿using Cinemahub2.Models;
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
    public class UserController : Controller
    {
        private IUserService userService;
        private UserManager<User> userManager;

        public UserController(UserManager<User> userManager, IUserService userService)
        {
            this.userService = userService;
            this.userManager = userManager;
        }



        [HttpGet]
        public async Task<IActionResult> Details()
        {
            User user = await userManager.GetUserAsync(User);
            TempData["loggedId"] = user.Id;
            UserDTO userDTO = userService.GetById(user.Id);


            return View(userDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserDTO userDTO)
        {

            User user = await userManager.GetUserAsync(User);
            _ = TempData["loggedId"];
            userService.Update(user.Id, userDTO);


            return RedirectToAction(nameof(Details));
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            User user = await userManager.GetUserAsync(User);
            userService.Delete(user.Id);

            return RedirectToAction("Logout", "Account");
        }

    }
}
