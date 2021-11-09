using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SerivceLayer.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BaseProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private IRepositoryWrapper _repositoryWrapper;
        private readonly ILogger<OwnerController> _logger;

        public OwnerController(IRepositoryWrapper repositoryWrapper, ILogger<OwnerController> logger)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
        }

        // GET: api/<OwnerController>
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return _repositoryWrapper.Owner.FindAll();
        }

        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            return _repositoryWrapper.Owner.FindByCondition(x=>x.Name=="Fawad").FirstOrDefault();
        }

        // POST api/<OwnerController>
        [HttpPost]
        public void Post([FromBody] Owner owner)
        {
            if (ModelState.IsValid)
            {
                _repositoryWrapper.Owner.Create(owner);
                _repositoryWrapper.Save();
            }
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Owner owner)
        {
            if (ModelState.IsValid)
            {
                owner.OwnerId = id;
                _repositoryWrapper.Owner.Update(owner);
                _repositoryWrapper.Save();
            }
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var owner = _repositoryWrapper.Owner.FindByCondition(x => x.OwnerId == id).FirstOrDefault();
            _repositoryWrapper.Owner.Delete(owner);
            _repositoryWrapper.Save();
        }
    }
}
