using ApiNET.Repository;
using ApiNET.Services;
using ApiNET.ViewModel;
using Ninject;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ApiNET.Controllers
{
    public class PersonsController : ApiController
    {
        
        private readonly IPersonRepository _personRepository = new PersonRepository();


        // GET: api/Persons
        [Authorize]
        [HttpGet]
        [SwaggerOperation("GetAll")]
        [Route("api/Persons/getAll")]
        public async Task<IEnumerable<PersonViewModel>> Get()
        {

            return _personRepository.GetAll();
        }
        // GET: api/Persons/5
        [HttpGet]
        [SwaggerOperation("GetByIin")]
        
        public PersonViewModel GetByIin(string iin)
        {

            return _personRepository.GetByIin(iin);
        }
        // POST: api/Persons
        [HttpPost]
        [SwaggerOperation("Create")]
        public IHttpActionResult Post([FromBody]PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _personRepository.Create(personViewModel);
            return Created(Request.RequestUri + personViewModel.Iin.ToString(), personViewModel);
        }

        // PUT: api/Persons/012345678910
        [HttpPut]
        [SwaggerOperation("Update")]
        public IHttpActionResult Put(string iin,[FromBody]PersonViewModel personViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            personViewModel.Iin = iin;
            _personRepository.Update(personViewModel);
            return Ok();
        }
        // DELETE: api/Persons/012345678910
        [HttpDelete]
        [SwaggerOperation("Delete")]
        public IHttpActionResult Delete(string iin)
        {
            _personRepository.Delete(iin);
            return Ok();
        }

    }
}
