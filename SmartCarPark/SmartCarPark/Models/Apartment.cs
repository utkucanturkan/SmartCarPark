using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCarPark.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        [Required]
        public string No { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public static List<ApartmentListModel> List()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Apartments.Select(i => new ApartmentListModel { Id = i.Id, No = i.No, LastName = i.LastName }).ToList();
            }
        }

        public static List<CarListModel> GetCars(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Cars.Where(x => x.ApartmentNo == id).Select(c => new CarListModel { Id = c.Id, Plate = c.Plate, ApartmentNo = c.Apartment.No, Owner = c.Apartment.LastName }).ToList();
            }
        }

        public static void Add(Apartment a)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Apartments.Add(new Apartment { No = a.No, LastName = a.LastName });
                db.SaveChanges();
            }
        }

        public static Apartment Get(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Apartments.Find(id);
            }
        }


        public static void Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Apartment a = db.Apartments.Find(id);
                if (a != null)
                {
                    db.Apartments.Remove(a);
                    db.SaveChanges();
                }
            }
        }

        public static void Update(Apartment model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

    }

    public class ApartmentListModel
    {
        public int Id { get; set; }
        public string No { get; set; }
        public string LastName { get; set; }
    }
}
