using mialco.amcoman.dal;
using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository.abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mialco.amcoman.repository
{
	public class TopicRepository: ITopicsRepository<Topic>
	{
		private AmcomanContext _amcomanContext;
		private DbSet<Topic> _topicSet;
		public TopicRepository(AmcomanContext amcomanContext)
		{
			_amcomanContext=amcomanContext;
			_topicSet=_amcomanContext.Topics;
		}

		Topic IGetByNameRepository<Topic>.GetByName(string name)
		{
			using(_amcomanContext)
			{
				DbSet<Topic> topics = _amcomanContext.Topics;
				return topics.FirstOrDefault(p => p.Name == name);
			}
		}

		IEnumerable<Topic> IAflRepository<Topic>.GetAll(int page, int pageSize)
		{
			return _topicSet.Skip((page - 1) * pageSize).Take(pageSize).ToList();
		}

		IEnumerable<Topic> IAflRepository<Topic>.GetAll()
		{
			return _topicSet.ToList();
		}

		Topic IAflRepository<Topic>.Get(int id)
		{
			return _topicSet.FirstOrDefault(p => p.Id == id);
		}
	}
}
