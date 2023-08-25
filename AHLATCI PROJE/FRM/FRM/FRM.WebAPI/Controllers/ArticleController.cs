using FRM.Business.Implementations;
using FRM.Business.Interfaces;
using FRM.Model.Dto.Articles;
using FRM.Model.Dto.Category;
using FRM.Model.Dto.User;
using Infrastructure.Utilities.ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FRM.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : BaseController
    {
        private readonly IArticleBs _articleBs;
        public ArticleController(IArticleBs articleBs)
        {
            _articleBs = articleBs;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<ArticleGetDto>>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = (typeof(ApiResponse<NoData>)))]
        [HttpGet]
        public async Task<ActionResult<List<ArticleGetDto>>> GetAllArticles()
        {
            var response = await _articleBs.GetAllAsync("Category","Author");
            return SendResponse(response);

        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<ArticleGetDto>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = (typeof(ApiResponse<NoData>)))]
        [HttpGet("byCategoryId")]
        public async Task<ActionResult<ArticleGetDto>> GetByCategoryId([FromRoute] int categoryId, params string[] includeList)
        {
            var response = await _articleBs.GetByCategoryAsync(categoryId);
            return SendResponse(response);
        }


        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<ArticleGetDto>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = (typeof(ApiResponse<NoData>)))]
        [HttpGet("byAuthorId")]
        public async Task<ActionResult<ArticleGetDto>> GetByAuthorId([FromRoute] int authorID, params string[] includeList)
        {
            var response = await _articleBs.GetByAuthorIdAsync(authorID);
            return SendResponse(response);
        }




        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<ArticleGetDto>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = (typeof(ApiResponse<NoData>)))]
        [HttpGet("byId")]
        public async Task<ActionResult<ArticleGetDto>> GetById([FromRoute] int articleId, params string[] includeList)
        {
            var response = await _articleBs.GetByIdAsync(articleId);
            return SendResponse(response);
        }

        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(201, Type = typeof(ApiResponse<ArticlePostDto>))]
        [Produces("application/json", "text/plain")]
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] ArticlePostDto dto)
        {
            var insertedArticle = await _articleBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = insertedArticle.Data.ArticleId }, insertedArticle.Data);
        }



        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [Produces("application/json", "text/plain")]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ArticlePutDto dto)
        {
            var response = await _articleBs.UpdateAsync(dto);
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
            var response = await _articleBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
