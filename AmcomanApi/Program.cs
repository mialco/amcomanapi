
using mialco.amcoman.dal.Entity;
using mialco.amcoman.mockRepo;
using mialco.amcoman.repository.Abstraction;

namespace AmcomanApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddScoped<IAflRepository<AflProduct>, AflMockRepo<AflProduct>>();

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

			app.Run();
		}
	}
}
