using API.Accounts.Application.Features.Users.Commands.LoginUser;
using API.Accounts.Application.Features.Users.Commands.RefreshAuthTokens;
using API.Accounts.Application.Features.Users.Commands.ValidateAccessToken;
using API.Accounts.Application.Features.Users.Factories;
using API.Accounts.Features.Users.Models.Requests;
using API.Accounts.Features.Users.Models.Responses;
using API.Shared.Web.Extensions;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        private readonly ISessionQueryFactory _sessionQueryFactory;
        private readonly ISessionCommandFactory _sessionCommandFactory;

        public AuthController(
            ISender sender, 
            IMapper mapper, 
            ISessionQueryFactory sessionQueryFactory, 
            ISessionCommandFactory sessionCommandFactory)
        {
            _sender = sender;
            _mapper = mapper;
            _sessionQueryFactory = sessionQueryFactory;
            _sessionCommandFactory = sessionCommandFactory;
        }


        [HttpPost("login")]
        [ProducesResponseType<LoginResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login(LoginUserRequestDTO loginUserRequest, CancellationToken cancellationToken)
        {
            var loginCommand = _mapper.Map<LoginUserCommand>(loginUserRequest);
            var loginResponse = await _sender.Send(loginCommand, cancellationToken);
            var loginResponseDTO = _mapper.Map<LoginResponseDTO>(loginResponse);

            return Ok(loginResponseDTO);
        }

        [HttpPost("validate-access-token")]
        [ProducesResponseType<AccessTokenPayloadResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> VerifyToken(ValidateAccessTokenRequestDTO validateAccessTokenRequest, CancellationToken cancellationToken)
        {
            var validateCommand = _mapper.Map<ValidateAccessTokenCommand>(validateAccessTokenRequest);
            var validationResult = await _sender.Send(validateCommand, cancellationToken);
            var reponseDTO = _mapper.Map<AccessTokenPayloadResponseDTO>(validationResult);

            return Ok(reponseDTO);
        }

        [HttpPost("refresh")]
        [ProducesResponseType<RefreshAuthTokensResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RefreshTokens(RefreshAuthTokensRequestDTO refreshTokensRequestDTO, CancellationToken cancellationToken)
        {
            var refreshTokensCommand = _mapper.Map<RefreshAuthTokensCommand>(refreshTokensRequestDTO);
            var result = await _sender.Send(refreshTokensCommand, cancellationToken);
            var responseDTO = _mapper.Map<RefreshAuthTokensResponseDTO>(result);

            return Ok(responseDTO);
        }

        [HttpGet("get-current-user-sessions")]
        [Authorize]
        [ProducesResponseType<SessionResponseDTO>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCurrentUserSessions()
        {
            var userId = this.GetUserId();
            var sessions = await _sender.Send(_sessionQueryFactory.CreateGetSessionsByUserIdQuery(userId));
            var sessionsDTO = _mapper.Map<ICollection<SessionResponseDTO>>(sessions);

            return Ok(sessionsDTO);
        }

        [HttpDelete("revoke-current-user-sessions")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RevokeCurrentUserSessions()
        {
            var userId = this.GetUserId();
            await _sender.Send(_sessionCommandFactory.CreateDeleteSessionsByUserIdCommand(userId));

            return NoContent();
        }
    }
}
