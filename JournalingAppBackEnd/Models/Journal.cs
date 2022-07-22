namespace JournalingAppBackEnd.Models
{
    public class Journal
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public ICollection<Entry>? Entries { get; set; }
    }
}
