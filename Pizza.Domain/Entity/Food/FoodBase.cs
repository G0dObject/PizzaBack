namespace Pizza.Domain.Entity.Food
{
    public abstract class FoodBase : EntityBase
    {
        public abstract string Title { get; set; }
        public abstract string ImageUrl { get; set; }
        public abstract decimal Rating { get; set; }
        public abstract decimal Price { get; set; }
    }
}
