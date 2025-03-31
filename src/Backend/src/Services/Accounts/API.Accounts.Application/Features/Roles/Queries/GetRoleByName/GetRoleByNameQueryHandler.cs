using API.Accounts.Application.Features.Roles.Models;
using API.Accounts.Common.Features.Roles.Exceptions;
using API.Accounts.Domain;
using API.Accounts.Domain.Repositories;
using API.Shared.Application.Interfaces;
using AutoMapper;

namespace API.Accounts.Application.Features.Roles.Queries.GetRoleByName
{
    internal class GetRoleByNameQueryHandler : IQueryHandler<GetRoleByNameQuery, RoleQueryViewModel>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetRoleByNameQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _roleRepository = unitOfWork.RoleRepository;
            _mapper = mapper;
        }

        public async Task<RoleQueryViewModel> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetByNameAsync(request.RoleName, cancellationToken);

            if (role is null)
            {
                throw new RoleNotFoundException();
            }

            return _mapper.Map<RoleQueryViewModel>(role);
        }
    }
}
