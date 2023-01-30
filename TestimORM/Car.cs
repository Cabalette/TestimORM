using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace TestimORM
{
    public class Car
    {
        public int id { get; set; }
        public string model { get; set; }
        public string maker { get; set; }
        public int price { get; set; }
        public List<Color> colors { get; set; } = new();
        public static async Task<IResult> GetCars(int id, ApplcationContext db)
        {
            Car? car = await db.cars.FirstOrDefaultAsync(u => u.id == id);

            if (car == null) return Results.NotFound(new { message = "Автомобиль не найден" });

            return Results.Json(car);
        }
        public static async Task<IResult> DeleteCar(int id, ApplcationContext db)
        {
            Car? car = await db.cars.FirstOrDefaultAsync(u => u.id == id);

            if (car == null) return Results.NotFound(new { message = "Автомобиль не найден" });

            db.cars.Remove(car);
            await db.SaveChangesAsync();
            return Results.Json(car);
        }
        public static async Task<Car> PostCar(Car car, ApplcationContext db)
        {
            await db.cars.AddAsync(car);
            await db.SaveChangesAsync();
            return car;
        }
        public static async Task<IResult> PutCar(Car newcar, ApplcationContext db)
        {
            var car = await db.cars.FirstOrDefaultAsync(u => u.id == newcar.id);

            if (car == null) return Results.NotFound(new { message = "Пользователь не найден" });

            car.id = newcar.id;
            car.model = newcar.model;
            car.maker = newcar.maker;
            car.price = newcar.price;
            await db.SaveChangesAsync();
            return Results.Json(car);

        }
    }
}
