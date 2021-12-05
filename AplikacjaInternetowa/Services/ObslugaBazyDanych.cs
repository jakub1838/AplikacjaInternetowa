using AplikacjaInternetowa.DAL.Contexts;
using AplikacjaInternetowa.DAL.Models;
using AplikacjaInternetowa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaInternetowa.Services
{
    public class ObslugaBazyDanych : IObslugaBazDanych
    {
        public DziekanatContext Context { get; set; }
        public void DodajZajeciaDoPlanu(Zajecia zajecia)
        {
            Context.Zajecia.Add(zajecia);
            Context.SaveChanges();
        }

        public List<Zajecia> GetZajecia()
        {
            return Context.Zajecia.ToList();
        }
    }
}