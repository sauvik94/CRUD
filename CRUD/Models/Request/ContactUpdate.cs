namespace WebApplication1.Models.Request
{
    public class ContactUpdate
    {
        public int ContactId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
    }
}
