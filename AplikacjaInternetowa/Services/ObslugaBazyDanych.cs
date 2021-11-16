using AplikacjaInternetowa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaInternetowa.Services
{
    public class ObslugaBazyDanych : IObslugaBazDanych
    {
        public string DodajZajeciaDoPlanu(string nazwa)
        {
            int id = new Random().Next();
            string komunikat = $"Zajecia o nazwie {nazwa} zostały dodane do planu pod id {id}";
            Console.WriteLine(komunikat);
            return komunikat;
        }
    }
}