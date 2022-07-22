namespace JournalingAppBackEnd.Models
{
    public class Journal
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Entry>? Entries { get; set; }
    }
}
