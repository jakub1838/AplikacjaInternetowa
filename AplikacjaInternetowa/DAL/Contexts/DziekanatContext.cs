using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplikacjaInternetowa.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaInternetowa.DAL.Contexts //zmien
{
    public class DziekanatContext :DbContext
    {
        public DziekanatContext(DbContextOptions<DziekanatContext> options) : base(options)
        {

        }
        public DbSet<Zajecia> Zajecia { get; set; }
        /*public DbSet<Student> Studenci { get; set; }*/
    }
}
