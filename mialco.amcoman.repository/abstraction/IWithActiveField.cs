using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.repository.abstraction
{
	public interface IWithActiveField<T> where T : class
	{
		public IEnumerable<T> GetActive(bool isActive);
		public IEnumerable<T> GetActive(bool isActive, int page, int pageSize);
	}
}
