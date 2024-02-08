using mialco.amcoman.dal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.repository.abstraction
{
	public interface IGroupsRepository: IAflRepository<CategoryGroup>, IWithActiveField<CategoryGroup>
	{
	}
}
