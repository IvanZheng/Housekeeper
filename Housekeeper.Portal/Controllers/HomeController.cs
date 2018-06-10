using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Housekeeper.Domain.Models;
using Housekeeper.Domain.Repositories;
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

        public async Task<IActionResult> Index()
        {
            var houses = await _repository.FindAll<House>()
                                          .ToListAsync()
                                          .ConfigureAwait(false);
            Console.WriteLine(houses?.Count);
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
