namespace AgriEnergyConnect.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public DateTime DateAdded { get; set; }

        // 👇 Add this to fix your error
        public int FarmerId { get; set; }
    }
}

