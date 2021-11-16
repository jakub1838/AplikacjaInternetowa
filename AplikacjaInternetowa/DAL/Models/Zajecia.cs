using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikacjaInternetowa.DAL.Models //<-- Ważne żeby konwencja nazw została zachowana !!! ZMIEN NAMESPACE
{
    public class Zajecia //<-- klasa publiczna
    {
        public int ID { get; set; }// <-- ważne żeby było "ID" dużymi literami
        public string NazwaZajec { get; set; }
        public DateTime TerminZajec { get; set; }
    }
}
