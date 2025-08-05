using API.Admin.Application.Features.FeatureInfos.Command.AddTestUser;
using API.Admin.Features.FeatureInfos.Models.Requests;
using API.Shared.Web.Attributes;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Admin.Features.FeatureInfos.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion(1)]
    public class FeatureInfoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public FeatureInfoController(IMapper mapper, ISender ender)
        {
            _mapper = mapper;
            _sender = ender;
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
