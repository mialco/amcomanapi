using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.dal
{
	public class AmcomanIdentityContext<ApplicationUser>:IdentityDbContext
	{
		public AmcomanIdentityContext(DbContextOptions<AmcomanIdentityContext<IdentityUser>> options) 
			: base(options) 
		{
		
		}	
	}
}
