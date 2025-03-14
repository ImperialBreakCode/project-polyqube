using API.Accounts.Application.Features.Users.Commands.LoginUser;
using API.Accounts.Application.Features.Users.Commands.RefreshAuthTokens;
using API.Accounts.Application.Features.Users.Commands.ValidateAccessToken;
using API.Accounts.Features.Users.Models.Requests;
using API.Accounts.Features.Users.Models.Responses;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Accounts.Features.Users.Controllers.v1
{
    [Route("api/v{version:apiVersion}/auth")]
    [ApiController]
    [ApiVersion(1)]
    public class AuthController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public AuthController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }


        [HttpPost("login")]
        [ProducesResponseType<LoginResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginUserRequestDTO loginUserRequest)
        {
            var loginCommand = _mapper.Map<LoginUserCommand>(loginUserRequest);
            var loginResponse = await _sender.Send(loginCommand);
            var loginResponseDTO = _mapper.Map<LoginResponseDTO>(loginResponse);

            return Ok(loginResponseDTO);
        }

        [HttpPost("validate-access-token")]
        [ProducesResponseType<AccessTokenPayloadResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> VerifyToken(ValidateAccessTokenRequestDTO validateAccessTokenRequest)
        {
            var validateCommand = _mapper.Map<ValidateAccessTokenCommand>(validateAccessTokenRequest);
            var validationResult = await _sender.Send(validateCommand);
            var reponseDTO = _mapper.Map<AccessTokenPayloadResponseDTO>(validationResult);

            return Ok(reponseDTO);
        }

        [HttpPost("refresh")]
        [ProducesResponseType<RefreshAuthTokensResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RefreshTokens(RefreshAuthTokensRequestDTO refreshTokensRequestDTO)
        {
            var refreshTokensCommand = _mapper.Map<RefreshAuthTokensCommand>(refreshTokensRequestDTO);
            var result = await _sender.Send(refreshTokensCommand);
            var responseDTO = _mapper.Map<RefreshAuthTokensResponseDTO>(result);

            return Ok(responseDTO);
        }
    }
}
