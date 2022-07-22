namespace JournalingAppBackEnd.Models
{
    public class Entry
    {
        public int ID { get; set; }
        public string Text { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
