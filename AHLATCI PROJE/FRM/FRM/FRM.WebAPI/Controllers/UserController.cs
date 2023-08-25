using FRM.Business.Implementations;
using FRM.Business.Interfaces;
using FRM.Model.Dto.User;
using Infrastructure.Utilities.ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FRM.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserBs _userBs;

        public UserController(IUserBs userBs)
        {
            _userBs = userBs;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<UserGetDto>>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = (typeof(ApiResponse<NoData>)))]
        [HttpGet]
        public async Task<ActionResult<List<UserGetDto>>>GetAllUser()
        {
            var response = await _userBs.GetAllAsync();
            return SendResponse(response);

        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<UserGetDto>))]
        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(404, Type = (typeof(ApiResponse<NoData>)))]
        [HttpGet("byId")]
        public async Task<ActionResult<UserGetDto>> GetById([FromRoute]int userId, params string[] includeList)
        {
            var response = await _userBs.GetByIdAsync(userId);
            return SendResponse(response);
        }


        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(201, Type = typeof(ApiResponse<UserPostDto>))]
        [Produces("application/json", "text/plain")]
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] UserPostDto dto)
        {
            var insertedUser = await _userBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = insertedUser.Data.UserId }, insertedUser.Data);
        }







        [ProducesResponseType(500, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        [Produces("application/json", "text/plain")]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UserPutDto dto)
        {
            var response = await _userBs.UpdateAsync(dto);
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
            var response = await _userBs.DeleteAsync(id);
            return SendResponse(response);
        }

    }
}
