using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SerivceLayer.Service.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http.Description;

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

        //GET: api/<OwnerController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repositoryWrapper.Owner.FindAll());
        }


        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _repositoryWrapper.Owner.FindByCondition(x=>x.OwnerId==id).FirstOrDefault();
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST api/<OwnerController>
        [HttpPost]
        public IActionResult Post([FromBody] Owner owner)
        {
            if (ModelState.IsValid)
            {
                _repositoryWrapper.Owner.Create(owner);
                _repositoryWrapper.Save();
                return Created("~api/owner/", owner);
            }
            return BadRequest();
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Owner owner)
        {
            if (ModelState.IsValid)
            {
                owner.OwnerId = id;
                _repositoryWrapper.Owner.Update(owner);
                _repositoryWrapper.Save();
                return Ok();
            }
            return BadRequest();
        }

        // DELETE api/<OwnerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var owner = _repositoryWrapper.Owner.FindByCondition(x => x.OwnerId == id).FirstOrDefault();
            if (owner == null)
                return NotFound();
            _repositoryWrapper.Owner.Delete(owner);
            _repositoryWrapper.Save();
            return Ok();
        }
    }
}
