namespace Pizza.Domain.Entity.Food
{
    public abstract class FoodBase : EntityBase
    {
        public virtual string? Title { get; set; }
        public virtual string? ImageUrl { get; set; }
        public virtual decimal Rating { get; set; }
        public virtual decimal Price { get; set; }
       
    }
}
