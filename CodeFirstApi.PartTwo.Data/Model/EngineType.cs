namespace CodeFirstApi.PartTwo.Model
{
    public class EngineType
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }

      public int? EngineId { get; set; }
        public Engine? Engine { get; set; }
    }
}
