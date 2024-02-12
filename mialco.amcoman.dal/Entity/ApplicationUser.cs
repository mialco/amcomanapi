using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.dal.Entity
{
	public class ApplicationUser:IdentityUser
	{
        public string? Custom { get; set; }
    }
}
