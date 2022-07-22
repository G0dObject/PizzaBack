namespace Pizza.Domain.Entity
{
    public class Pizza : Item
    {
        public override string? Type { get => GetType().Name; set { } }
    }
}
