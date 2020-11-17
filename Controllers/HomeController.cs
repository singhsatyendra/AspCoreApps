using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YoYoTestDemo.Models;
using YoYoTestDemo.Services;
using YoYoTestDemo.ViewModel;

namespace YoYoTestDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IPlayerService _playerService;

        public HomeController(ILogger<HomeController> logger, IPlayerService playerService)
        {
            _logger = logger;
            _playerService = playerService;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel();

            var allPlayers = _playerService.GetPlayers();

            homeViewModel.players = allPlayers;
            return View(homeViewModel);
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
