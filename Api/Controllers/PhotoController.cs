using Api.Models;
using Api.View;
using Api.ViewModel.Interface;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        protected readonly IPhotoViewModel _vm;
        public PhotoController(IPhotoViewModel vm)
        {
            _vm = vm;
        }

        [HttpGet("getAll")]
        public async Task<List<EntityPhotoView>> GetAll()
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
        public async Task<EntityPhotoView> Post([FromBody] EntityPhotoView view)
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

        [HttpPost("postBlob")]
        public async Task<List<EntityPhotoView>> PostBlob([FromForm] List<EntityPhotoView> list)
        {
            try
            {
                await _vm.InsertList(list);
                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("put")]
        public async Task<EntityPhotoView> Put([FromBody] EntityPhotoView view)
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
        public async Task<IActionResult> Delete([FromBody] EntityPhotoView view)
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