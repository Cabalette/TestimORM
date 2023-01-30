using Microsoft.EntityFrameworkCore;
using Npgsql;
namespace TestimORM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string con = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplcationContext>(o => o.UseNpgsql(con));
            var app = builder.Build();
            var options = new DbContextOptionsBuilder<ApplcationContext>().UseNpgsql(con).Options;
            app.UseDefaultFiles();
            app.UseStaticFiles();

            //using (ApplcationContext db = new ApplcationContext(options))
            //{
            //    Car car1 = new Car { id = 4, maker = "Moscow", model = "a1", price = 1234 };
            //    db.cars.Add(car1);
            //    db.SaveChanges();
            //}
            //using (ApplcationContext db = new ApplcationContext(options))
            //{
            //    var cars = db.carscolors.ToList();
            //    Console.WriteLine("Users list:");
            //    foreach (CarsColors car in cars)
            //    {

            //        Console.WriteLine(car.carid);
            //    }
            //}

            //app.MapGet("/", async (ApplcationContext db) => await db.cars.ToListAsync());

            //app.MapGet("/api/cars/{id:int}", async (int id, ApplcationContext db) => await Car.GetCars(id, db));

            //app.MapDelete("/api/cars/{id:int}", async (int id, ApplcationContext db) => await Car.DeleteCar(id, db));

            //app.MapPost("/api/cars", async (Car car, ApplcationContext db) => await Car.PostCar(car, db));

            //app.MapPut("/api/cars", async (Car newcar, ApplcationContext db) => await Car.PutCar(newcar, db));

            using (ApplcationContext db = new ApplcationContext(options))
            {
                //var que = db.cars.Join(db.colors, car => car.id, color => color.id, (car, color) => new { Id=car.id, Model = car.model, Color = color.name }).
                //    Join(db.carscolors, first => first.Id, second => second.carid, (f, s) => new{ carid=f.Id, carscolorsid=s.carid  });
                //var que = db.cars.GroupBy(a => a.maker).Select(a=> new {maker=a.Key, count = a.Count()});

                var que = db.Database.exe("select cars.id,maker,model,price from colors join cars on colors.id=cars.id where colors.id in(select colorid from carscolors where carid=3 )").OrderBy(car=>car.id);

                foreach (var car in que)
                    Console.WriteLine($"{car.model}");
            }


            //app.Run();
        }


    }
}


