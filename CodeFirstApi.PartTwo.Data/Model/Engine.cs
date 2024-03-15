namespace CodeFirstApi.PartTwo.Model
{
    public class Engine
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public string Brand { get; set; }
        public int SerialNumber { get; set; }

        public ICollection<EngineType> EngineTypes { get; set; } 
    }
}
