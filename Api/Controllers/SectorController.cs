using Api.View;
using Api.ViewModel.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorController : ControllerBase
    {
        protected readonly ISectorViewModel _vm;
        public SectorController(ISectorViewModel vm)
        {
            _vm = vm;
        }

        [HttpGet("getAll")]
        public async Task<List<EntitySectorView>> GetAll()
        {
            try
            {
                return await _vm.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("post")]
        public async Task<EntitySectorView> Post([FromBody] EntitySectorView view)
        {
            try
            {
                await _vm.Insert(view);
                return view;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("put")]
        public async Task<EntitySectorView> Put([FromBody] EntitySectorView view)
        {
            try
            {
                await _vm.Update(view);
                return view;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] EntitySectorView view)
        {
            try
            {
                await _vm.Delete(view);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}