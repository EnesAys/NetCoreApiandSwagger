using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Motorcycle.DATA.Model;
using Motorcycle.DATA.Repositories;

namespace Motorcycle.API.Controllers
{
    [Route("api/motorcycle")]
    [ApiController]
    public class MotorCycleController : ControllerBase
    {
        private readonly IRepository<MotorCycle> _motorCycleRepository;

        public MotorCycleController(IRepository<MotorCycle> motorCycleRepository)
        {
            _motorCycleRepository = motorCycleRepository;
        }
        // GET: api/motorcycle
        [HttpGet]
        public IActionResult Get()
        {
            var list = _motorCycleRepository.Get();
            if (list != null)
                return Ok(list);

            return NotFound(list);
        }

        // GET: api/motorcycle/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var model = _motorCycleRepository.GetById(id);
            if (model != null)
                return Ok(model);

            return NotFound(model);
        }

        // POST: api/motorcycle
        [HttpPost]
        public IActionResult Post([FromBody] MotorCycle request)
        {
            var result= _motorCycleRepository.Add(request);
            if (result)
                return Ok(result);

            return BadRequest(result);
        }

        // PUT: api/motorcycle/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MotorCycle request)
        {
            var model = _motorCycleRepository.Update(request, id);
            if (model!=null)
                return Ok(model);

            return NotFound(model);      
        }

        // DELETE: api/motorcycle/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _motorCycleRepository.Delete(id);
            if (result)
                return Ok(result);

            return NotFound(result); 
        }
    }
}
