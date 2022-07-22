namespace JournalingAppBackEnd.Models
{
    public class Entry
    {
        public int ID { get; set; }
        public int JournalId { get; set; }
        public string Text { get; set; } = null!;
    }
}
