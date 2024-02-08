using mialco.amcoman.dal;
using mialco.amcoman.repository;
using mialco.amcoman.repository.abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.integration.testing
{
	public class IntegrationTestingBase
	{

		private readonly string ConnectionStringName = "MSSqlConnectionString";
		private string _connectionString = string.Empty;
		public IntegrationTestingBase()
		{
			//Read the appsettings.json file
			var configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();
			//Read the connection string from the appsettings.json file
			_connectionString = configuration.GetConnectionString(ConnectionStringName) ?? string.Empty;
			ConfigureServices();

		}

		private void ConfigureServices()
		{
			var serviceCollection = new ServiceCollection();


			// Register your services here, just like in your real Startup class
			serviceCollection.AddDbContext<AmcomanContext>(options => 
			options.UseSqlServer(_connectionString));

			serviceCollection.AddScoped(typeof(ICategoriesAndGroupsRepository), typeof(CategoriesAndGroupsRepository));
			serviceCollection.AddScoped(typeof(IAflRepository<>), typeof(AflEFRepository<>));
			serviceCollection.AddScoped(typeof(IGroupsRepository), typeof(GroupsRepository));
			ServiceProvider = serviceCollection.BuildServiceProvider();

		}

		protected ServiceProvider ? ServiceProvider { get; private set; }
		


	}
}
