using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Pizza.Api.Services;
using Pizza.Application.Common.Mapping.Profiles;
using Pizza.Application.Interfaces.Services;
using Pizza.Persistent;
using Pizza.Persistent.DependencyInjection;
using Pizza.Persistent.EntityTypeContext;
using System.Text;
using System.Text.Json.Serialization;

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
			_ = builder.Services.AddScoped<SeedService>();
			_ = builder.Services.AddAutoMapper(typeof(AppMappingProfile));
			_ = builder.Services.AddCors(f => f.AddPolicy("test", f =>
			{
				f.AllowAnyHeader();
				f.AllowAnyMethod();
				f.WithOrigins("https://localhost:3000");

			}));

			_ = builder.Services.AddDbDependency(builder.Configuration, builder.Environment.IsDevelopment());
			_ = builder.Services.AddIdentityDependency();
			_ = builder.Services.AddAuthenticationDependency(builder.Configuration);
			_ = builder.Services.AddMvc()
				.AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
			_ = builder.Services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

			WebApplication? app = builder.Build();

			using Context? db = app.Services.CreateScope().ServiceProvider.GetRequiredService<Context>();
			_ = Task.Run(async () => await Initializer.Initialize(db));


			using SeedService service = app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedService>();
			_ = Task.Run(async () => await service.Seed());



			if (app.Environment.IsDevelopment())
			{

			}
			_ = app.UseSwagger();
			_ = app.UseSwaggerUI();
			_ = app.UseHttpsRedirection();

			app.Map("/", () => "Still Work");

			_ = app.UseRouting();
			_ = app.UseAuthentication();
			_ = app.UseAuthorization();
			_ = app.MapControllers();
			_ = app.UseCors("test");
			app.Run();
		}
	}
}
