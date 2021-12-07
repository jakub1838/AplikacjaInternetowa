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

        public void DodajStudent(Student student)
        {
            using var transaction = Context.Database.BeginTransaction();
            try
            {
                if (int.Parse(student.NumerIndeksu) < 1000 && int.Parse(student.NumerIndeksu) > 0)
                {
                    Context.Studenci.Add(student);
                    Context.SaveChanges();
                    transaction.Commit();
                }
                else
                {
                    throw new ArgumentException("Numer indeksu musi się mieścić pomiędzy 0 a 1000");
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }
        public void DodajZajeciaDoPlanu(Zajecia zajecia)
        {
            using var transaction = Context.Database.BeginTransaction();
            try
            {
                Context.Zajecia.Add(zajecia);
                Context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public List<Student> GetStudenci()
        {
            return Context.Studenci.ToList();
        }

        public List<Zajecia> GetZajecia()
        {
            return Context.Zajecia.ToList();
        }

        public string UsunStudent(int id)
        {
            using var transaction = Context.Database.BeginTransaction();
            try
            {
                var student = Context.Studenci.First(m => m.ID == id);
                string s = $"{student.Imie} {student.Nazwisko}";
                if (student is null) throw new ArgumentException("Student nie istnieje");
                Context.Studenci.Remove(student);
                Context.SaveChanges();
                transaction.Commit();
                return s;
            } catch (Exception)
            {
                transaction.Rollback();
                return "Bad";
            }
        }
    }
}