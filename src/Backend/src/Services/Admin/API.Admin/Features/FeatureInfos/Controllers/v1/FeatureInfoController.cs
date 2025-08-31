using API.Admin.Application.Features.FeatureInfos.Commands.AddTestUser;
using API.Admin.Application.Features.FeatureInfos.Factories;
using API.Admin.Features.FeatureInfos.Models.Requests;
using API.Admin.Features.FeatureInfos.Models.Responses;
using API.Shared.Web.Attributes;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Admin.Features.FeatureInfos.Controllers.v1
{
    [Route("api/v{version:apiVersion}/feature-infos")]
    [ApiController]
    [ApiVersion(1)]
    public class FeatureInfoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;
        private readonly IFeatureInfoQueryFactory _queryFactory;

        public FeatureInfoController(IMapper mapper, ISender ender, IFeatureInfoQueryFactory queryFactory)
        {
            _mapper = mapper;
            _sender = ender;
            _queryFactory = queryFactory;
        }

        [HttpGet("get-feature-info/{featureName}")]
        [ProducesResponseType<FeatureInfoResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [AuthorizeAdminScope]
        public async Task<IActionResult> GetFeatureInfoByName(string featureName, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(_queryFactory.CreateGetFeatureInfoByNameQuery(featureName), cancellationToken);
            var dto = _mapper.Map<FeatureInfoResponseDTO>(result);

            return Ok(dto);
        }

        [HttpPost("add-test-user")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [AuthorizeAdminScope]
        public async Task<IActionResult> AddTestUser(AddTestUserRequestDTO testUserRequestDTO, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<AddTestUserCommand>(testUserRequestDTO);
            await _sender.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
