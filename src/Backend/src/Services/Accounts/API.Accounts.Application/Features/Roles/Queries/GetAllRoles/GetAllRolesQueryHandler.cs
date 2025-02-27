using API.Accounts.Application.Features.Roles.Models;
using API.Accounts.Domain;
using API.Accounts.Domain.Aggregates;
using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Accounts.Application.Features.Roles.Queries.GetAllRoles
{
    internal class GetAllRolesQueryHandler : IQueryHandler<GetAllRolesQuery, ICollection<RoleQueryViewModel>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _roleRepository = unitOfWork.RoleRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<RoleQueryViewModel>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            ICollection<Role> roles = await _roleRepository.GetAllRolesAsync();

            return _mapper.Map<ICollection<RoleQueryViewModel>>(roles);
        }
    }
}
