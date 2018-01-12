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

        // GET: api/blogs
        [HttpGet]
        public Task<List<Document>> Get()
        {
            return _repository.GetAllBlogs();
        }

        // GET api/blogs/1
        [HttpGet("{id}")]
        public async Task<Blog> Get(string id)
        {
            return await _repository.GetAsync(id);
        }

        // POST api/blogs
        [HttpPost]
        public async Task<Document> Post([FromBody]Blog value)
        {
            return await _repository.CreateAsync(value);
        }

        // PUT api/blogs/5
        [HttpPut("{id}")]
        public async Task<Document> Put(string id, [FromBody]Blog value)
        {
            return await _repository.UpdateAsync(id, value);
        }

        // DELETE api/blogs/5
        [HttpDelete("{id}")]
        public async void Delete(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
