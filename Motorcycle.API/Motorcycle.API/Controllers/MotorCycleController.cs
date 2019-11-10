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

        /// <summary>
        /// List of motorcycles
        /// </summary>     
        /// <returns>List of motorcycles</returns>
        /// <response code="200">Returns motorcycle list</response>
        /// <response code="404">If the item is null</response> 
        
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Get()
        {
            var list = _motorCycleRepository.Get();
            if (list != null)
                return Ok(list);

            return NotFound(list);
        }

        /// <summary>
        /// Get a specific motorcycle.
        /// </summary>
        /// <param name="id"></param>  
        /// <returns>Spesific motorcycle</returns>
        /// <response code="200">Returns Spesific motorcycle</response>
        /// <response code="404">If the item is null</response> 
        
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            var model = _motorCycleRepository.GetById(id);
            if (model != null)
                return Ok(model);

            return NotFound(model);
        }

        /// <summary>
        /// Add motorcycle.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/motorcycle
        ///     {
        ///        	"Id":2000,
        ///         "Model":"Honda - Africa Twin -1000",
        ///         "IsAutomatic":true,
        ///         "Year":2020
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>
        /// <returns>A newly created motorcycle</returns>
        /// <response code="200">Returns the newly created motorcycle</response>
        /// <response code="400">If the item is null</response>    
        
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] MotorCycle request)
        {
            var result= _motorCycleRepository.Add(request);
            if (result)
                return Ok(result);

            return BadRequest(result);
        }

        /// <summary>
        ///  Update a specific motorcycle.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/motorcycle/3
        ///     {
        ///         "Model":"Honda - Africa Twin -1000",
        ///         "IsAutomatic":true,
        ///         "Year":2020
        ///     }
        ///
        /// </remarks>
        /// <param name="request"></param>   
        /// <returns>A newly updated motorcycle</returns>
        /// <response code="200">Returns the newly updated motorcycle</response>
        /// <response code="404">If the item is null</response> 
        
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] MotorCycle request)
        {
            var model = _motorCycleRepository.Update(request, id);
            if (model!=null)
                return Ok(model);

            return NotFound(model);      
        }

        /// <summary>
        /// Delete a specific motorcycle.
        /// </summary>
        /// <param name="id"></param>   
        /// <returns>Delete process result</returns>
        /// <response code="200">Deleted motorcycle</response>
        /// <response code="404">If the item is null</response> 
        
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            var result = _motorCycleRepository.Delete(id);
            if (result)
                return Ok(result);

            return NotFound(result); 
        }
    }
}
