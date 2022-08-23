using Pizza.Persistent.EntityTypeContext;
namespace Pizza.Persistent
{
	public static class Initializer
	{
		public static async Task Initialize(this Context context)
		{
			_ = await context.Database.EnsureDeletedAsync();

			_ = await context.Database.EnsureCreatedAsync();
		}
	}
}
