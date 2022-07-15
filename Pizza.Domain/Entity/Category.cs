namespace Pizza.Domain.Entity
{
    public class Category : EntityBase
    {
        public ICollection<string>? Name { get; set; }
    }
}
