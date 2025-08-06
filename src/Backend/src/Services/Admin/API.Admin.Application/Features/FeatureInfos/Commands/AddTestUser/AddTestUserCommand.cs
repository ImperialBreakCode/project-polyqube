using API.Shared.Application.Interfaces;

namespace API.Admin.Application.Features.FeatureInfos.Commands.AddTestUser
{
    public record AddTestUserCommand(string FeatureId, string UserId) : ICommand;
}
