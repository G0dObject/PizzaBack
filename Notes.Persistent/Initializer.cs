using Pizza.Persistent.EntityTypeContext;
namespace Pizza.Persistent
{
    public static class Initializer
    {
        public static async Task Initialize(Context context)
        {
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }
    }
}
