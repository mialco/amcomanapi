using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.repository.abstraction
{
	public interface IGetByNameRepository<T>
	{
		public T GetByName(string name);
	}
}
