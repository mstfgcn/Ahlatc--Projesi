using FRM.Business.Interfaces;
using FRM.Model.Dto.AdminPanelUser;
using Infrastructure.Utilities.ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FRM.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAdminPanelUserBs _adminPanelUserBs;

        public AuthController(IAdminPanelUserBs adminPanelUserBs)
        {
            _adminPanelUserBs = adminPanelUserBs;
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AdminPanelUserDto>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        [HttpGet("login")]
        public async Task<ActionResult> LogIn([FromQuery] string userName, [FromQuery] string password)
        {
            var response = await _adminPanelUserBs.LogInAsync(userName, password);
            return SendResponse(response);

        }
    }
}
