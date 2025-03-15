using API.Accounts.Application.Features.Roles.Factories;
using API.Accounts.Features.Roles.Models;
using Asp.Versioning;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Accounts.Features.Roles.Controllers.v1
{
    [Route("api/v{version:apiVersion}/roles")]
    [ApiController()]
    [ApiVersion(1)]
    public class RoleController : ControllerBase
    {
        private readonly IRoleQueryFactory _roleQueryFactory;
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public RoleController(IRoleQueryFactory roleQueryFactory, IMapper mapper, ISender sender)
        {
            _roleQueryFactory = roleQueryFactory;
            _mapper = mapper;
            _sender = sender;
        }

        [HttpGet("get-all-roles")]
        [ProducesResponseType<ICollection<RoleResponseDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllRoles(CancellationToken cancellationToken)
        {
            var roles = await _sender.Send(_roleQueryFactory.CreateGetAllRolesQuery(), cancellationToken);
            var roleDTOs = _mapper.Map<ICollection<RoleResponseDTO>>(roles);

            return Ok(roleDTOs);
        }

        [HttpGet("get-by-name/{roleName}")]
        [ProducesResponseType<RoleResponseDTO>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRoleByName(string roleName, CancellationToken cancellationToken)
        {
            var role = await _sender.Send(_roleQueryFactory.CreateGetRoleByNameQuery(roleName), cancellationToken);
            var roleDTO = _mapper.Map<RoleResponseDTO>(role);

            return Ok(roleDTO);
        }
    }
}
