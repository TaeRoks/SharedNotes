using System.Security.Cryptography.X509Certificates;

namespace SharedNotes.Shared.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public  required string Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
