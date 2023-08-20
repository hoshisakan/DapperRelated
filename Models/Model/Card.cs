namespace Models.Model
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Attack { get; set; }
        public int HealthPoint { get; set; }
        public int Defense { get; set; }
        public int Cost { get; set; }
    }
}
