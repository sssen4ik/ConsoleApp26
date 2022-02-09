using System;
using System.Linq;

namespace ConsoleApp26
{
    class Program
    {
        static void Main(string[] args)
        {
           using(AutoSaloneContext db = new AutoSaloneContext())
            {
                db.Marks.Add(new Mark() { MarkName = "Toyota" });
                db.SaveChanges();

                db.Cars.Add(new Car() { MarkId = db.Marks.Select(o => o.Id).First(), Model = "rav4", Engine = "Electro", Price = 21000 });
                db.SaveChanges();

                Car c = db.Cars.Where(o => o.Id == 1).First();
                db.Cars.Remove(c);
                db.SaveChanges();
            }
        }
    }
}
