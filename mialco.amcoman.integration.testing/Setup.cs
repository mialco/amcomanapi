using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace mialco.amcoman.integration.testing
{
	[Category("Integration")]
	[TestFixture]
	[SetUpFixture]
	public class Setup
	{


		

		[OneTimeSetUp]
		public void Test1()
		{
		//var services = new ServiceCollection(); 
			
		//Assert.Pass();
		}
	}
}
