namespace TestimORM
{
    public class Color
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Car> cars { get; set; } = new();
    }
}
