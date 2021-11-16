using AplikacjaInternetowa.DAL.Contexts;
using AplikacjaInternetowa.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaInternetowa.Data
{
    public static class DziekanatDatabaseinitialiser
    {
        public static void Initialize(DziekanatContext context) // publiczna, statyczna metoda ma przyjmować zmienną typu Context naszej bazy
        {
            context.Database.EnsureCreated();

            if (context.Zajecia.Any())
            {
                return;
            }
            

            var zajecia = new Zajecia[]
            {
                new Zajecia{NazwaZajec = "Programowanie .NET",      TerminZajec = DateTime.Now.AddDays(2)},
                new Zajecia{NazwaZajec = "Programowanie C#",        TerminZajec = DateTime.Now.AddDays(2).AddHours(4)},
                new Zajecia{NazwaZajec = "Programowanie Java",      TerminZajec = DateTime.Now.AddDays(1).AddHours(2)},
                new Zajecia{NazwaZajec = "Bazy danych",             TerminZajec = DateTime.Now.AddDays(3).AddHours(1)},
                new Zajecia{NazwaZajec = "Wzorce projektowe",       TerminZajec = DateTime.Now.AddDays(5).AddHours(6)},
                new Zajecia{NazwaZajec = "Zarządzanie projektem",   TerminZajec = DateTime.Now.AddDays(7).AddHours(3)},
                new Zajecia{NazwaZajec = "UX",                      TerminZajec = DateTime.Now.AddDays(4).AddHours(3)},
                new Zajecia{NazwaZajec = "Microsoft",               TerminZajec = DateTime.Now.AddDays(1).AddHours(2)}
            };

            context.AddRange(zajecia);
            context.SaveChanges();

          
        }
    }
}