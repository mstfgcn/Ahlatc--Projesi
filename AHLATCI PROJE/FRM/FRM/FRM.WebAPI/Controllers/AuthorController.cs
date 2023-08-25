using FRM.Business.Implementations;
using FRM.Business.Interfaces;
using FRM.Model.Dto.Author;
using FRM.Model.Dto.Category;
using FRM.Model.Dto.User;
using Infrastructure.Utilities.ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FRM.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController
    {
        private readonly IAuthorBs _authorBs;

        public AuthorController(IAuthorBs authorBs)
        {
                _authorBs = authorBs;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<AuthorGetDto>>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = (typeof(ApiResponse<NoData>)))]
        [HttpGet]
        public async Task<ActionResult<List<AuthorGetDto>>> GetAllAuthors()
        {
            var response = await _authorBs.GetAllAsync("Articles");
            return SendResponse(response);

        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AuthorGetDto>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = (typeof(ApiResponse<NoData>)))]
        [HttpGet("byId")]
        public async Task<ActionResult<AuthorGetDto>> GetById([FromRoute] int authorId, params string[] includeList)
        {
            var response = await _authorBs.GetByAuthorIdAsync(authorId);
            return SendResponse(response);
        }



        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(201, Type = typeof(ApiResponse<AuthorPostDto>))]
        [Produces("application/json", "text/plain")]
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] AuthorPostDto dto)
        {
            var insertedAuthor = await _authorBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = insertedAuthor.Data.AuthorId }, insertedAuthor.Data);
        }



        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [Produces("application/json", "text/plain")]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] AuthorPutDto dto)
        {
            var response = await _authorBs.UpdateAsync(dto);
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
            var response = await _authorBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
