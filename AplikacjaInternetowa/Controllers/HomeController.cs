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
        
        [HttpGet]
        [Route("/Studenci")]
        public IActionResult Studenci()
        {
            List<Student> studenci = obslugaBazyDanych.GetStudenci();
            return View(studenci);
        }

        [HttpGet]
        [Route("{controller}/hello")]
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
        [HttpGet]
        [Route("{controller}/DodajDoStudentForm")]
        public IActionResult DodajDoStudentForm()
        {
            return View();
        }
        [HttpPost]
        [Route("{controller}/DodajDoStudent")]
        public IActionResult DodajDoStudent(Student student)
        {
            try {
                obslugaBazyDanych.DodajStudent(student);
                return Ok($"Dodano {student.Imie} {student.Nazwisko} do listy studentów");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /* widok nie działa :C
        [HttpGet("{controller}/UsunStudentForm")]
        public IActionResult UsunStudentForm()
        {
            return View();
        }
        */
        [HttpDelete("{ID}")]
        public IActionResult UsunStudent(int ID)
        {
            try
            {
                string osoba = obslugaBazyDanych.UsunStudent(ID);
                return Ok($"Usunieto {osoba} z listy studentów");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
