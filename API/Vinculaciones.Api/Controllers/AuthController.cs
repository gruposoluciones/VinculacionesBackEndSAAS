using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vinculaciones.Api.common;
using Vinculaciones.Api.extensions;
using Vinculaciones.Application.common;
using Vinculaciones.Application.dtos;
using Vinculaciones.Application.gateways;
using Vinculaciones.Application.usecases.users.login;
using Vinculaciones.Application.usecases.users.register;

namespace Vinculaciones.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthGateway _authGateway;
        public AuthController(IAuthGateway authGateway)
        {
            _authGateway = authGateway;
        }

        [HttpPost("register", Name = "Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                var responseModel = new ApiResponse<UserDto, List<ErrorField>>(
                statusCode: 400,
                success: false,
                data: null,
                error: ModelState.ToErrorList()
            );
                return StatusCode(400, responseModel);
            }
            var result = await _authGateway.Register(request);
            var response = new ApiResponse<UserDto, string>(
                statusCode: (int)result.ResultCode,
                success: result.Success,
                data: result.Value?.UserDto,
                error: result.Error
            );
            return StatusCode((int)result.ResultCode, response);
        }
        [HttpPost("login", Name = "Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                var responseModel = new ApiResponse<LoginUserResponse, List<ErrorField>>(
                statusCode: 400,
                success: false,
                data: null,
                error: ModelState.ToErrorList()
            );
                return StatusCode(400, responseModel);
            }
            var result = await _authGateway.Login(request);
            var response = new ApiResponse<LoginUserResponse, string>(
                statusCode: (int)result.ResultCode,
                success: result.Success,
                data: result.Value,
                error: result.Error
            );
            //Hacer append de token (pending)
            return StatusCode((int)result.ResultCode, response);
        }
    }
}
