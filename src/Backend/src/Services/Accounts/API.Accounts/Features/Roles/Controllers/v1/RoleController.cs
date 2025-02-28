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
        [ProducesResponseType<ICollection<RoleDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _sender.Send(_roleQueryFactory.CreateGetAllRolesQuery());
            var roleDTOs = _mapper.Map<ICollection<RoleDTO>>(roles);

            return Ok(roleDTOs);
        }
    }
}
