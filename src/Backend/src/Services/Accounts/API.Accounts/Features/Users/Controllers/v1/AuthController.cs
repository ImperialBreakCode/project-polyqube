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

        [HttpPost("validate-access-token")]
        public async Task<IActionResult> VerifyToken(ValidateAccessTokenRequestDTO validateAccessTokenRequest)
        {
            var validateCommand = _mapper.Map<ValidateAccessTokenCommand>(validateAccessTokenRequest);
            var validationResult = await _sender.Send(validateCommand);
            var reponseDTO = _mapper.Map<AccessTokenPayloadResponseDTO>(validationResult);

            return Ok(reponseDTO);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshTokens(RefreshAuthTokensRequestDTO refreshTokensRequestDTO)
        {
            var refreshTokensCommand = _mapper.Map<RefreshAuthTokensCommand>(refreshTokensRequestDTO);
            var result = await _sender.Send(refreshTokensCommand);
            var responseDTO = _mapper.Map<RefreshAuthTokensResponseDTO>(result);

            return Ok(responseDTO);
        }
    }
}
