namespace Pizza.Domain.Entity
{
    public class User : EntityBase
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Nick { get; set; }
        public int? CartId { get; set; }
        public Cart? Cart { get; set; }
    }
}
