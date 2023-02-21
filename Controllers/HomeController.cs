//using Fluent.Infrastructure.FluentModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proUrl.Ds;
using proUrl.Models;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Security.Claims;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proUrl.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly SignInManager<IdentityUser> SignInManager;
        private readonly DbData _dataContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DbData dataContext)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("List")]
        [Authorize]
        public IActionResult Links()
        {
            var currentUser = HttpContext.User;
            var userid = currentUser.FindFirstValue(ClaimTypes.NameIdentifier);
            var tempdata = _dataContext.Users.Where(u => u.Id == userid);
            if(tempdata != null)
            {
                var data = _dataContext.UrlPairs.Where(u => u.UrlUser.Id == userid).ToList();
                return View(data);
            }
            else
            {
                var data1 = _dataContext.UrlPairs.Where(u => u.UrlUser == null).ToList();
                return View(data1);
            }

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}