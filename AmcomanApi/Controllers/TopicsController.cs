using mialco.amcoman.dal.Entity;
using mialco.amcoman.repository.abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmcomanApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TopicsController : ControllerBase
	{
		private ITopicsRepository<Topic> _topicRepository;
		private ITopicsRepository<TopicTemplate> _topicTemplateRepository;
		public TopicsController(ITopicsRepository<TopicTemplate> topicTemplateRepository, ITopicsRepository<Topic> topicsRepository)
		{
			_topicTemplateRepository = topicTemplateRepository;
			_topicRepository = topicsRepository;
		}

		[HttpGet("template")]
		public IActionResult GetTemplate()
		{
			return Ok(_topicTemplateRepository.GetAll());
		}

		[HttpGet("topic")]
		public IActionResult GetTopic()
		{
			return Ok(_topicRepository.GetAll());
		}

		[HttpGet("template/{id}")]
		public IActionResult GetTemplate(int id)
		{
			return Ok(_topicTemplateRepository.Get(id));
		}

		[HttpGet("topic/{id}")]
		public IActionResult GetTopic(int id)
		{
			return Ok(_topicTemplateRepository.Get(id));
		}

		[HttpGet("template/name/{name}")]
		public IActionResult GetTemplate(string name)
		{
			return Ok(_topicTemplateRepository.GetByName(name));
		}

		[HttpGet("topic/name/{name}")]
		public IActionResult GetTopic(string name)
		{
			return Ok(_topicRepository.GetByName(name));
		}

		[HttpPost]
		public IActionResult Post([FromBody] TopicTemplate topicTemplate)
		{
			//_topicTemplateRepository.Add(topicTemplate);
			return  BadRequest();
		}

		[HttpPut]
		public IActionResult Put([FromBody] TopicTemplate topicTemplate)
		{
			//_topicTemplateRepository.Update(topicTemplate);
			return BadRequest();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			//_topicTemplateRepository.Delete(id);
			return BadRequest();
		}
	}
}
