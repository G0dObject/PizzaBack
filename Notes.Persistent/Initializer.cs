using Pizza.Persistent.EntityTypeContext;

namespace Pizza.Persistent
{
    public static class Initializer
    {
        public static void  Initialize(Context context)
        {
             context.Database.EnsureDeleted();           
             context.Database.EnsureCreated();
        }
    }
}
