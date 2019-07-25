using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApi.Models;
using ContactApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository repo;

        public ContactsController(IContactRepository contactRepository)
        {
            this.repo = contactRepository;
        }

        [HttpGet]
        public IActionResult All()
        {
            return Ok(repo.All());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = repo.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Contact model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            repo.Create(model);
            var uri = Url.Action("Get", new { id = model.Id });
            return Created(uri, model);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Contact model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                repo.Update(model);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                repo.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}