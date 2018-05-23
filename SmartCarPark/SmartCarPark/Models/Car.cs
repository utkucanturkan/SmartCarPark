using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SmartCarPark.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Plate { get; set; }
        public int ApartmentNo { get; set; }
        [ForeignKey("ApartmentNo")]
        public virtual Apartment Apartment { get; set; }

        public static List<CarListModel> List()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Cars.Select(i => new CarListModel { Id = i.Id, Plate = i.Plate, ApartmentNo = i.Apartment.No, Owner = i.Apartment.LastName }).ToList();
            }
        }

        public void Add(Car c)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Cars.Add(c);
                db.SaveChanges();
            }
        }

        public static void Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Car c = db.Cars.Find(id);
                if (c != null)
                {
                    db.Cars.Remove(c);
                    db.SaveChanges();
                }
            }
        }

        public static Car Get(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.Cars.Find(id);
            }
        }

        public void Edit(int id, Car car)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Car c = db.Cars.Find(Id);
                if (c != null && isValidCar(car.Plate) == null)
                {
                    c.Plate = car.Plate;
                    c.ApartmentNo = car.ApartmentNo;
                    db.SaveChanges();
                }
            }
        }

        public static Car isValidCar(string plate)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Car c = db.Cars.Where(x => x.Plate == plate).FirstOrDefault();
                if (c != null)
                {
                    c.Apartment = c.Apartment;
                    return c;
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public class CarListModel
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string ApartmentNo { get; set; }
        public string Owner { get; set; }
    }
}
