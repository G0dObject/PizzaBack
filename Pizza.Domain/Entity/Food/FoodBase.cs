namespace Pizza.Domain.Entity.Food
{
    public abstract class FoodBase : EntityBase
    {
        public abstract string Name { get; set; }
        public abstract decimal Price { get; set; }        
   }
}
