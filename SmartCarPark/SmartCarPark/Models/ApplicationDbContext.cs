using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SmartCarPark.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("ConnectionString")
        {
            Database.SetInitializer(new ApplicationDbInitializer());
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Apartment> Apartments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }

    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);

            Apartment a = new Apartment { No = "D-1", LastName = "Gürses", Cars = new System.Collections.Generic.List<Car>() };
            Car c = new Car { Apartment = a, Plate = "34 MG 74" };
            a.Cars.Add(c);
            context.Apartments.Add(a);
        }
    }
}
