using AplikacjaInternetowa.DAL.Contexts;
using AplikacjaInternetowa.DAL.Models;
using System.Collections.Generic;

namespace AplikacjaInternetowa.Interfaces
{
    public interface IObslugaBazDanych
    {
        public DziekanatContext Context { get; set; }
        void DodajZajeciaDoPlanu(Zajecia zajecia);
        List<Zajecia> GetZajecia();

    }
}
