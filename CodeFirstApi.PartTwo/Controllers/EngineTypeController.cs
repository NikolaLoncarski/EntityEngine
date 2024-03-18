using CodeFirstApi.PartTwo.Model;
using CodeFirstApi.PartTwo.Service.Interface;
using CodeFirstApi.PartTwo.Service.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApi.PartTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineTypeController : ControllerBase
    {
        private readonly IEngineTypeService _engineTypeService;

        public EngineTypeController(IEngineTypeService engineTypeService)
        {
            _engineTypeService = engineTypeService;
        }


        [HttpGet]
        [Route("GetEngineType")]
        public async Task<ActionResult<IEnumerable<EngineType>>> GetAsync(int id)
        {
            var data = await _engineTypeService.GetEngineTypeService(id);
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteEngineType")]
        public async Task<ActionResult<IEnumerable<EngineType>>> DeleteEngineType(int id)
        {
             await _engineTypeService.DeleteEngineTypeService(id);
            return NoContent();
        }
        [HttpPost]
        [Route("CreateEngineType")]
        public async Task<ActionResult<IEnumerable<EngineType>>> CreateCar(EngineType engineType)
        {
            var data = await _engineTypeService.CreateEngineTypeService(engineType);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateEngineType")]
        public async Task<ActionResult<IEnumerable<EngineType>>> UpdateCar([FromBody] EngineType engineType)
        {
           var updatedEngine = await _engineTypeService.UpdateEngineTypeService(engineType);
            return Ok(updatedEngine);

        }


        [HttpGet]
        [Route("GetAllEngineTypes")]
        public async Task<ActionResult<IEnumerable<EngineType>>> GetAllEngineTypes()
        {
            var allEngineTypes = await _engineTypeService.GetAllEngineTypesService();
            return Ok(allEngineTypes);

        }
    }
}
