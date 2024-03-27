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
	public class TopicTemplateRepository:ITopicsRepository<TopicTemplate>
	{
		private AmcomanContext _amcomanContext;
		private DbSet<TopicTemplate> _topicTemplateSet;
		public TopicTemplateRepository(AmcomanContext amcomanContext)
		{
			_amcomanContext=amcomanContext;
			_topicTemplateSet=_amcomanContext.TopicTemplates;
		}

		TopicTemplate IGetByNameRepository<TopicTemplate>.GetByName(string name)
		{
			using(_amcomanContext)
			{
				DbSet<TopicTemplate> topicTemplates = _amcomanContext.TopicTemplates;
				return topicTemplates.FirstOrDefault(p => p.Name == name);
			}
		}

		IEnumerable<TopicTemplate> IAflRepository<TopicTemplate>.GetAll(int page, int pageSize)
		{
			return _topicTemplateSet.Skip((page - 1) * pageSize).Take(pageSize).ToList();
		}

		IEnumerable<TopicTemplate> IAflRepository<TopicTemplate>.GetAll()
		{
			return _topicTemplateSet.ToList();
		}

		TopicTemplate IAflRepository<TopicTemplate>.Get(int id)
		{
			return _topicTemplateSet.FirstOrDefault(p => p.Id == id);
		}
	}
}
