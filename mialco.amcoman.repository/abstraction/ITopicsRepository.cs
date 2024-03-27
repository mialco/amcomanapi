using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.repository.abstraction
{
	public interface ITopicsRepository<T> : IAflRepository<T>, IGetByNameRepository<T> where T : class
	{
	}
}
