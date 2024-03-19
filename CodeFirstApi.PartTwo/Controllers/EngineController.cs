using CodeFirstApi.PartTwo.Data.Model;
using CodeFirstApi.PartTwo.Interface;
using CodeFirstApi.PartTwo.Model;
using CodeFirstApi.PartTwo.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApi.PartTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private readonly IEngineService _engineService;

        public EngineController(IEngineService engineService)
        {
            _engineService = engineService;
        }


        [HttpGet]
        [Route("GetEngine")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var data = await _engineService.GetEngineService(id);
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteEngine")]
        public async Task<IActionResult> DeleteEngine(int id)
        {
             await _engineService.DeleteEngineService(id);
            return Ok();
        }
        [HttpPost]
        [Route("CreateEngine")]
        public async Task<IActionResult> CreateEngine(Engine engine)
        {
            var engineId = await _engineService.CreateEngineService(engine);
            return Ok(engineId);
        }

        [HttpPut]
        [Route("UpdateEngine")]
        public async Task<IActionResult> UpdateEngine([FromBody] Engine engine)
        {
          var updatedEngine =  await _engineService.UpdateEngineService(engine);
            return Ok(updatedEngine);

        }
        [HttpGet]
        [Route("GetAllEngines")]
        public async Task<ActionResult<IEnumerable<Engine>>> GetAllEngines()
        {
            var allEngines = await _engineService.GetAllEngineService();
            return Ok(allEngines);

        }
    }
}
