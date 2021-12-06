using AplikacjaInternetowa.DAL.Contexts;
using AplikacjaInternetowa.DAL.Models;
using System.Collections.Generic;

namespace AplikacjaInternetowa.Interfaces
{
    public interface IObslugaBazDanych
    {
        public DziekanatContext Context { get; set; }
        void DodajZajeciaDoPlanu(Zajecia zajecia);
        void DodajStudent(Student student);
        string UsunStudent(int id);
        List<Zajecia> GetZajecia();
        List<Student> GetStudenci();
    }
}
