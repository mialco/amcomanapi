
using mialco.amcoman.dal;
using mialco.amcoman.dal.Entity;
using mialco.amcoman.mockRepo;
using mialco.amcoman.repository;
using mialco.amcoman.repository.Abstraction;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace AmcomanApi
{
	public class Program
	{
		public static void Main(string[] args)
		{

			string SqlConnectionStringName = "MSSqlConnectionString";

			var builder = WebApplication.CreateBuilder(args);

			IConfiguration configuration = builder.Configuration;
			var connectionString = configuration.GetConnectionString(SqlConnectionStringName);


			// Add services to the container.
			//builder.Services.AddScoped<IAflRepository<AflProduct>, AflMockRepo<AflProduct>>();
			//builder.Services.AddScoped(DbContext, AmcomanContext);
			//builder.Services.AddTransient(typeof(IAflRepository<AflProduct>), typeof(AflEFRepository<AflProduct>));
			//builder.Services.AddScoped<IAflRepository<AflProduct>, AflEFRepository<AflProduct>>();
	
			//builder.Services.AddScoped(IDbCon DbContext,app.dbContext)
			//builder.Services.AddScoped<




			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddCors(options=>
			{
				options.AddDefaultPolicy(builder => {
					builder.WithOrigins("http://localhost:4200", "https://localhost:44351")
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});

			builder.Services.AddScoped(typeof(IAflRepository<>), typeof(AflEFRepository<>));
			builder.Services.AddDbContext<AmcomanContext>(options =>
			{
				options.UseSqlServer(connectionString);
				options.UseSqlServer(b => b.MigrationsAssembly("AmcomanApi"));
			});


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseCors(builder=>
			{
				builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();

			});
			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			DbDataInitializer.Seed(app);
			app.Run();
		}
	}
}
