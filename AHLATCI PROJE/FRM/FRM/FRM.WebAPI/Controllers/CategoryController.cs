using FRM.Business.Implementations;
using FRM.Business.Interfaces;
using FRM.Model.Dto.Category;
using FRM.Model.Dto.User;
using Infrastructure.Utilities.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace FRM.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly ICategoryBs _categoryBs;
        public CategoryController(ICategoryBs categoryBs)
        {
                _categoryBs = categoryBs;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = (typeof(ApiResponse<NoData>)))]
        [HttpGet]
        public async Task<ActionResult<List<CategoryGetDto>>> GetAllCategory()
        {
            var response = await _categoryBs.GetAllAsync("Articles");
            return SendResponse(response);

        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<CategoryGetDto>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = (typeof(ApiResponse<NoData>)))]
        [HttpGet("byId")]
        public async Task<ActionResult<CategoryGetDto>> GetById([FromRoute] int categoryID, params string[] includeList)
        {
            var response = await _categoryBs.GetByIdAsync(categoryID);
            return SendResponse(response);
        }


        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(201, Type = typeof(ApiResponse<CategoryPostDto>))]
        [Produces("application/json", "text/plain")]
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] CategoryPostDto dto)
        {
            var insertedCategory = await _categoryBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = insertedCategory.Data.CategoryId }, insertedCategory.Data);
        }



        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [Produces("application/json", "text/plain")]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] CategoryPutDto dto)
        {
            var response = await _categoryBs.UpdateAsync(dto);
            return SendResponse(response);
        }


        [ProducesResponseType(404, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [Produces("application/json", "text/plain")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _categoryBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
