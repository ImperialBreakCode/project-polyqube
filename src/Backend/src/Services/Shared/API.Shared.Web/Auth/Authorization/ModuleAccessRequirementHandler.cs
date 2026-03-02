using API.Shared.Common.Constants;
using API.Shared.Domain.Interfaces.CacheRepo.Accounts;
using Microsoft.AspNetCore.Authorization;

namespace API.Shared.Web.Auth.Authorization
{
    internal class ModuleAccessRequirementHandler : AuthorizationHandler<ModuleAccessRequirement>
    {
        private readonly IReadSessionAccessInfoRepository _sessionInfoRepository;

        public ModuleAccessRequirementHandler(IReadSessionAccessInfoRepository sessionInfoRepository)
        {
            _sessionInfoRepository = sessionInfoRepository;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ModuleAccessRequirement requirement)
        {
            if (!context.User.HasClaim(c => c.Type == APIClaimNames.SessionId) 
                && !context.User.HasClaim(c => c.Type == APIClaimNames.SubjectClaim))
            {
                return Task.CompletedTask;
            }

            string userId = context.User.FindFirst(x => x.Type == APIClaimNames.SubjectClaim)!.Value;
            string sessionId = context.User.FindFirst(x => x.Type == APIClaimNames.SessionId)!.Value;
            var sessionAccessInfo = _sessionInfoRepository.GetSessionInfo(sessionId, userId);
            if (sessionAccessInfo == null)
            {
                return Task.CompletedTask;
            }

            if (sessionAccessInfo.AccessModules.Any(requirement.RequiredModules.Contains))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
