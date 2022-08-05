using Pizza.Application.Common.Mapping.Profiles;
using Pizza.Persistent;
using Pizza.Persistent.DependencyInjection;
using Pizza.Persistent.EntityTypeContext;

namespace Pizza.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

            _ = builder.Services.AddControllers();
            _ = builder.Services.AddEndpointsApiExplorer();
            _ = builder.Services.AddSwaggerGen();
            _ = builder.Services.AddDbDependency(builder.Configuration, builder.Environment.IsDevelopment());
            _ = builder.Services.AddIdentityDependency();
            _ = builder.Services.AddAutoMapper(typeof(AppMappingProfile));
            
            WebApplication? app = builder.Build();

            using Context? db = app.Services.CreateScope().ServiceProvider.GetRequiredService<Context>();
            _ = Task.Run(async () => await Initializer.Initialize(db));

            if (app.Environment.IsDevelopment())
            {
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI();
            }

            _ = app.UseHttpsRedirection();
            _ = app.UseAuthentication();
            _ = app.UseAuthorization();
            _ = app.MapControllers();

            _ = app.Map("/", () => "this Work");
            app.Run();
        }
    }
}
