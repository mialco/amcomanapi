using mialco.amcoman.shared.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.test
{

	public class Setup
	{


		public static ServiceProvider? ServiceProvider { get; private set; }

		[OneTimeSetUp]
		public void setup()
		{
			ConfigureServices();
		}

		private  void ConfigureServices()
		{
			var serviceCollection = new ServiceCollection();

			serviceCollection.AddSingleton(typeof(IAmcomanApiUtils), typeof(AmcomanApiUtils));
			serviceCollection.AddTransient(typeof(Tests));
			ServiceProvider = serviceCollection.BuildServiceProvider();

		}



		[OneTimeTearDown] 
		public void teardown() { 
		}
	}
}
