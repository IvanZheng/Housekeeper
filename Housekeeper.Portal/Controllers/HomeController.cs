using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Housekeeper.Domain.Models;
using Housekeeper.Domain.Repositories;
using HouseKeeper.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Housekeeper.Portal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHousekeeperRepository _repository;
        public HomeController(IHousekeeperRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            ViewData["dbcontextCount"] = HousekeeperDbContext.Count;

            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
