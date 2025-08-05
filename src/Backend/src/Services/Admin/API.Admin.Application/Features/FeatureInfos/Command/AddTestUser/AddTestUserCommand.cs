using API.Shared.Application.Interfaces;

namespace API.Admin.Application.Features.FeatureInfos.Command.AddTestUser
{
    public record AddTestUserCommand(string FeatureId, string UserId) : ICommand;
}
