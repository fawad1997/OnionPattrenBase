using AutoMapper;
using DomainLayer.Models;
using DomainLayer.ViewModels;
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
        private readonly IMapper _mapper;

        public OwnerController(IRepositoryWrapper repositoryWrapper, ILogger<OwnerController> logger,IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _logger = logger;
            _mapper = mapper;
        }

        //GET: api/<OwnerController>
        [HttpGet]
        public IActionResult Get()
        {
            var owners = _repositoryWrapper.Owner.FindAll();
            var ownerVM = _mapper.Map<List<OwnerDTO>>(owners);
            return Ok(ownerVM);
        }


        // GET api/<OwnerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var owner = _repositoryWrapper.Owner.FindByCondition(x=>x.OwnerId==id).FirstOrDefault();
            if (owner == null)
                return NotFound();
            var ownerVM = _mapper.Map<OwnerDTO>(owner);
            return Ok(ownerVM);
        }

        // POST api/<OwnerController>
        [HttpPost]
        public IActionResult Post([FromBody] OwnerDTO ownerVM)
        {
            if (ModelState.IsValid)
            {
                var owner = _mapper.Map<Owner>(ownerVM);
                _repositoryWrapper.Owner.Create(owner);
                _repositoryWrapper.Save();
                return Created("~api/owner/", owner);
            }
            return BadRequest();
        }

        // PUT api/<OwnerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OwnerDTO ownerVM)
        {
            if (ModelState.IsValid)
            {
                bool ownerExists =_repositoryWrapper.Owner.FindByCondition(x => x.OwnerId == id).Any();
                if (!ownerExists)
                    return NotFound();
                ownerVM.OwnerId = id;
                var owner = _mapper.Map<Owner>(ownerVM);
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
