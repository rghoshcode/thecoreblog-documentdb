using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Azure.Documents;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tcb_documentdb.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        private IDocdbRepository<Blog> _repository;
        public BlogsController(IDocdbRepository<Blog> repository)
        {
            _repository = repository;
            _repository.Initialize();
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Blog> Get(string id)
        {
            return await _repository.GetAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<Document> Post([FromBody]Blog value)
        {
            return await _repository.CreateAsync(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
