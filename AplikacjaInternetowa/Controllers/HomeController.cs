using AplikacjaInternetowa.DAL.Contexts;
using AplikacjaInternetowa.DAL.Models;
using AplikacjaInternetowa.Interfaces;
using AplikacjaInternetowa.Models;
using AplikacjaInternetowa.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace AplikacjaInternetowa.Controllers
{
    public class HomeController : Controller
    {
        public readonly IObslugaBazDanych obslugaBazyDanych;

        private readonly DziekanatContext bazaDanychDziekanatu;

        public HomeController(IObslugaBazDanych obslugaBazyDanych, DAL.Contexts.DziekanatContext bazaDanychDziekanatu = null)
        {
            this.obslugaBazyDanych = obslugaBazyDanych;
            this.bazaDanychDziekanatu = bazaDanychDziekanatu;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/Planzajec")]
        public IActionResult PlanZajec()
        {
            /*
            List<Zajecia> planZajec = new List<Zajecia>()
            {
                new Zajecia(DateTime.Now, "Progs1", "Chicago", 1),
                new Zajecia(DateTime.Now.AddHours(8), "Progs2", "Chicago", 2),
                new Zajecia(DateTime.Now.AddDays(2), "Progs3", "Chicago", 3),
            };
            */
            List<Zajecia> planZajec = bazaDanychDziekanatu.Zajecia.ToList();

            return View(planZajec);
        }
        [HttpGet]
        [Route("{controller}/hello")]
        public IActionResult Powitanie()
        {
            return Ok("Hello world!");
        }
        [HttpPost]
        [Route("{controller}/DodajDoPlanu/{nazwa}")]

        public IActionResult DodajDoPlanu(string nazwa)
        {
            if (nazwa == null) return BadRequest(new { komunikat = $"Zle" });

            string komunikat = obslugaBazyDanych.DodajZajeciaDoPlanu(nazwa);

            return Ok(new { komunikat = komunikat });
            
        }
    }
}
