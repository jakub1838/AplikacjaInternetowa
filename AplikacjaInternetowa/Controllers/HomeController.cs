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
            this.obslugaBazyDanych.Context = bazaDanychDziekanatu;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/Planzajec")]
        public IActionResult PlanZajec()
        {
            List<Zajecia> planZajec = obslugaBazyDanych.GetZajecia();
            return View(planZajec);
        }
        /*
        [HttpGet]
        [Route("/Studenci")]
        public IActionResult 
        [HttpGet]
        [Route("{controller}/hello")]*/
        public IActionResult Powitanie()
        {
            return Ok("Hello world!");
        }
        [HttpGet]
        [Route("{controller}/DodajDoPlanuForm")]
        public IActionResult DodajDoPlanuForm()
        {
            return View();
        }
        [HttpPost]
        [Route("{controller}/DodajDoPlanu")]

        public IActionResult DodajDoPlanu(Zajecia zajecia)
        {
            obslugaBazyDanych.DodajZajeciaDoPlanu(zajecia);
            return Ok($"Dodano zajecia {zajecia.NazwaZajec} do planu");
            
        }
    }
}
