using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P.A_API.JWT;
using P.A_Contract.EndPoint.Result;
using P.A_Contract.Service.SecurityUtil;
using P.A_Service.Users.Contracts;
using P.A_Service.Users.Contracts.DTOs;

namespace P.A_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ApiResult> RegisterUser(AddUserDTO dto)
        {
            await _userService.RegisterUser(dto);
            return new ApiController().CommandResult();
        }

        [HttpPost("Login")]
        public async Task<ApiResult<TokenResultDTO>> Login([FromBody] LoginDTO dto)
        {
            UserResultDTO user = await _userService.GetUserByPhone(dto.Phone);

            OperationResult<TokenResultDTO> result = new();
            if (user == null)
            {
                result = OperationResult<TokenResultDTO>.Error("UserName Or password is wrong");
                return new ApiController().CommandResult(result);
            }
            if (!Sha256Hasher.IsCompare(user.Password, dto.Password))
            {
                result = OperationResult<TokenResultDTO>.Error("UserName Or password is wrong");
                return new ApiController().CommandResult(result);
            }

            result = await UserTokensCreator(user);
            return new ApiController().CommandResult(result);
        }

        [Authorize]
        [HttpDelete("Logout")]
        public async Task<ApiResult<string?>> Logout()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var hashedToken = Sha256Hasher.Hash(token);
            var userToken = await _userService.GetUserHashedToken(hashedToken);
            OperationResult<string> result = new();
            if (userToken == null)
            {
                result = OperationResult<string>.NotFound();
                return new ApiController().CommandResult(result);
            }
            await _userService.RemoveUserToken(userToken);
            result = OperationResult<string>.Success("operation was done", "Ok");
            return new ApiController().CommandResult(result);
        }

        [NonAction]//this attribute use to ignor method as API method
        public async Task<OperationResult<TokenResultDTO>> UserTokensCreator(UserResultDTO user)
        {

            ///this is use for calculate expire date of Tokens
            var activeDurationToken = 7; //day

            var token = JwtTokenBuilder.BuildToken(user, activeDurationToken);

            var expierdHashedTokenDate = DateTime.Now.AddDays(activeDurationToken);
            var hashedToken = Sha256Hasher.Hash(token);
            await _userService.AddUserToken(user.Id, new AddTokenDTO(hashedToken, expierdHashedTokenDate));
            return OperationResult<TokenResultDTO>.Success(new TokenResultDTO()
            {
                Token = token,
            }, "Ok");
        }
    }
}
