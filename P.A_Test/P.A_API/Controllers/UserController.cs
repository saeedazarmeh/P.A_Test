using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P.A_Contract.EndPoint.Result;
using P.A_Service.Users.Contracts.DTOs;
using P.A_Service.Users.Contracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;

namespace P.A_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("addPersonel")]
        public async Task<ApiResult> AddPersonel(AddPersonelDTO dto)
        {
            var id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            await _userService.AddPersonel(dto,id);
            return new ApiController().CommandResult();
        }

        [HttpGet]
        [EnableRateLimiting("fixed")]
        public async Task<ApiResult<List<UserResultDTO>>> GetUserPersonels()
        {
            var id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var personels=await _userService.GetUsersPersonels( id);
            return new ApiController().QueryResult<List<UserResultDTO>>(personels);
        }
        [HttpDelete("{personelId}")]
        public async Task<ApiResult> RemovePersonel(int personelId)
        {
            var id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            await _userService.RemovePersonel(personelId, id);
            return new ApiController().CommandResult();
        }
    }
}
