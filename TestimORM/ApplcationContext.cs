using Microsoft.EntityFrameworkCore;

namespace TestimORM
{
    public class ApplcationContext : DbContext
    {
        public DbSet<Car> cars { get; set; } = null!;
        public DbSet<Color> colors { get; set; } = null!;
        public DbSet<CarsColors> carscolors { get; set; }=null!;
        
        public ApplcationContext(DbContextOptions<ApplcationContext> options) : base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CarsColors>().HasKey(u => new { u.carid, u.colorid });
            //modelBuilder.Entity<Car>().HasData(
            //        new Car { id = 1, model = "Tom", maker = "Moscow", price = 37 }
            //);
        }
    }
}
