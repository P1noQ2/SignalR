using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence;
using Persistence.Context;
using Persistence.Models;
using SIgnalR.Models;

namespace SIgnalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private UnitOfWork work;

        public HomeController(ILogger<HomeController> logger,SignalRContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            work = new UnitOfWork(context);
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            ViewBag.CurrentUserName = currentUser.UserName;
            var messages = await work.Messages.GetAll();
            return View(messages);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Message msg)
        {
            if (ModelState.IsValid)
            {
                msg.FromUser = User.Identity.Name;
                var sender = await _userManager.GetUserAsync(User);
                msg.UserId = sender.Id;
                msg.To = User.Identity.Name;
                await work.Messages.Add(msg);
                await work.Complete();
                return Ok();
            }
            return Error();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
