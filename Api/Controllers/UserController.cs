using Api.View;
using Api.ViewModel.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        protected readonly IUserViewModel _vm;
        public UserController(IUserViewModel vm)
        {
            _vm = vm;
        }

        [HttpGet("getById")]
        public async Task<EntityUserView> GetById(Guid id)
        {
            try
            {
                return await _vm.GetById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("post")]
        public async Task<EntityUserView> Post([FromBody] EntityUserView view)
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
        public async Task<EntityUserView> Put([FromBody] EntityUserView view)
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
    }
}