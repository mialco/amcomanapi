
using mialco.amcoman.dal;
using mialco.amcoman.dal.Entity;
using mialco.amcoman.mockRepo;
using mialco.amcoman.repository;
using mialco.amcoman.repository.abstraction;
using mialco.amcoman.shared;
using mialco.amcoman.shared.Abstraction;
//using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

namespace AmcomanApi
{
	public class Program
	{
		public static void Main(string[] args)
		{

			string SqlConnectionStringName = "MSSqlConnectionString";
			var builder = WebApplication.CreateBuilder(args);
			var vars = new IAmcomanVars();

			// Configure serilog here
			var logger = new LoggerConfiguration()
				.ReadFrom.Configuration(builder.Configuration)
				.WriteTo.Console()
				.Enrich.FromLogContext()
				.CreateLogger();
			builder.Logging.ClearProviders();
			builder.Logging.AddSerilog(logger);


			vars.JwtIssuer = Environment.GetEnvironmentVariable("Jwt:Issuer", EnvironmentVariableTarget.Machine);
			vars.JwtKey = Environment.GetEnvironmentVariable("Jwt:Key", EnvironmentVariableTarget.Machine);
			if (vars.JwtIssuer == null || vars.JwtKey == null)
			{
				Console.WriteLine("Jwt:Issuer or Jwt:Key environment variables are not set");
				Environment.Exit(1);
			}



			IConfiguration configuration = builder.Configuration;
			var connectionString = configuration.GetConnectionString(SqlConnectionStringName);


			//Add Identity
			//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
			//	.AddEntityFrameworkStores<AmcomanContext>()
			//	.AddDefaultTokenProviders();

			builder.Services.AddIdentityCore<ApplicationUser>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 8;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = true;
				options.User.RequireUniqueEmail = true;
			})
			.AddRoles<IdentityRole>()
			.AddEntityFrameworkStores<AmcomanContext>()
				;

			//Add Authentication
			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				//options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.SaveToken = true;
				options.RequireHttpsMetadata = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true, // Set this true if you have set the issuer in the JwtBearerOptions
					ValidateAudience = true, //set this true if you have set the audience in the JwtBearerOptions
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = vars.JwtIssuer,
					ValidAudience = vars.JwtIssuer,
					ClockSkew = System.TimeSpan.Zero,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(vars.JwtKey)),
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
			/// configure serilog here





			//TODO: retrieve environment variables from the environment before configuring the JwtBearer	
			// Show the error message if the environment variables are not set

			builder.Services.AddLogging(//Cofigure serilog here
										//
										);
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();


			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

			builder.Services.AddDbContext<AmcomanContext>(options =>
			{
				options.UseSqlServer(connectionString);
				options.UseSqlServer(b => b.MigrationsAssembly("AmcomanApi"));
			});

			builder.Services.AddScoped(typeof(ICategoriesAndGroupsRepository), typeof(CategoriesAndGroupsRepository));
			builder.Services.AddScoped(typeof(IAflRepository<>), typeof(AflEFRepository<>));
			builder.Services.AddScoped(typeof(IGroupsRepository), typeof(GroupsRepository));
			builder.Services.AddSingleton<IAmcomanApiUtils, AmcomanApiUtils>();
			builder.Services.AddSingleton<IAmcomanVars>(vars);
			builder.Services.AddSingleton<IConfiguration>(configuration);

			var app = builder.Build();


			//app.UseExceptionHandler(errorApp =>
			//{
			//	errorApp.Run(async context =>
			//	{
			//		context.Response.StatusCode = 500;
			//		context.Response.ContentType = "text/html";
			//		await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
			//		await context.Response.WriteAsync("ERROR!<br><br>\r\n");
			//		var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();

			//		// Use exceptionHandlerPathFeature to process the exception (for example, 
			//		// logging), but do NOT expose sensitive error information directly to 
			//		// the client.
			//		if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
			//		{
			//			await context.Response.WriteAsync("File error thrown!<br><br>\r\n");
			//		}
			//		await context.Response.WriteAsync("<a href=\"/\">Home</a><br>\r\n");
			//		await context.Response.WriteAsync("</body></html>\r\n");
			//		await context.Response.WriteAsync(new string(' ', 512)); // Padding for IE
			//		await context.Response.WriteAsync(exceptionHandlerPathFeature.Error.ToString());
			//	});
			//});




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
			
			app.UseRouting(); //Not sure if needed


			app.UseAuthentication();
			app.UseAuthorization();



			app.MapControllers();

			DbDataInitializer.Seed(app);
			app.Run();

		}
	}
}
