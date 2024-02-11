
using mialco.amcoman.dal;
using mialco.amcoman.dal.Entity;
using mialco.amcoman.mockRepo;
using mialco.amcoman.repository;
using mialco.amcoman.repository.abstraction;
using mialco.amcoman.shared;
using mialco.amcoman.shared.Abstraction;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

			//TODO: retrieve environment variables from the environment before configuring the JwtBearer	
			// Show the error message if the environment variables are not set
			builder.Services.AddAuthentication()
			.AddJwtBearer("JwtBearer", options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = Environment.GetEnvironmentVariable("Jwt:Issuer", EnvironmentVariableTarget.Machine),
					ValidAudience = Environment.GetEnvironmentVariable("Jwt:Issuer", EnvironmentVariableTarget.Machine),
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("Jwt:Key", EnvironmentVariableTarget.Machine)))
				};
			});
			//.AddOAuth("OAuth", options =>
			//{
			//	//TODO : Configure your OAuth options here with Google account
			//	// The code here is given as an example by Microsoft copilot
			//	// Configure your OAuth options here
			//	//options.ClientId = configuration["Google:ClientId"];
			//	//options.ClientSecret = configuration["Google:ClientSecret"];
			//	//options.CallbackPath = new PathString("/signin-google");
			//	//options.AuthorizationEndpoint = GoogleDefaults.AuthorizationEndpoint;
			//	//options.TokenEndpoint = GoogleDefaults.TokenEndpoint;
			//	//options.UserInformationEndpoint = GoogleDefaults.UserInformationEndpoint;
			//	//options.SaveTokens = true;
			//});


			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddCors(options =>
			{
				options.AddDefaultPolicy(builder =>
				{
					builder.WithOrigins("http://localhost:4200", "https://localhost:44351")
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});

			//builder.Services.AddScoped(typeof(IAflRepository<Category>),typeof(CategoryAndGroupRepository));	
			builder.Services.AddDbContext<AmcomanContext>(options =>
			{
				options.UseSqlServer(connectionString);
				options.UseSqlServer(b => b.MigrationsAssembly("AmcomanApi"));
			});
			builder.Services.AddScoped(typeof(ICategoriesAndGroupsRepository), typeof(CategoriesAndGroupsRepository));
			builder.Services.AddScoped(typeof(IAflRepository<>), typeof(AflEFRepository<>));
			builder.Services.AddScoped(typeof(IGroupsRepository), typeof(GroupsRepository));
			builder.Services.AddSingleton<IAmcomanApiUtils, AmcomanApiUtils>();



			var app = builder.Build();

			app.UseExceptionHandler(errorApp =>
			{
				errorApp.Run(async context =>
				{
					context.Response.StatusCode = 500;
					context.Response.ContentType = "text/html";
					await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
					await context.Response.WriteAsync("ERROR!<br><br>\r\n");
					var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

					// Use exceptionHandlerPathFeature to process the exception (for example, 
					// logging), but do NOT expose sensitive error information directly to 
					// the client.
					if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
					{
						await context.Response.WriteAsync("File error thrown!<br><br>\r\n");
					}
					await context.Response.WriteAsync("<a href=\"/\">Home</a><br>\r\n");
					await context.Response.WriteAsync("</body></html>\r\n");
					await context.Response.WriteAsync(new string(' ', 512)); // Padding for IE
					await context.Response.WriteAsync(exceptionHandlerPathFeature.Error.ToString());
				});
			});

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseCors(builder =>
			{
				builder
				.AllowAnyOrigin()
				.AllowAnyMethod()
				.AllowAnyHeader();

			});
			app.UseHttpsRedirection();

			//app.UseAuthentication();
			app.UseAuthorization();


			app.MapControllers();

			DbDataInitializer.Seed(app);
			app.Run();

		}
	}
}
