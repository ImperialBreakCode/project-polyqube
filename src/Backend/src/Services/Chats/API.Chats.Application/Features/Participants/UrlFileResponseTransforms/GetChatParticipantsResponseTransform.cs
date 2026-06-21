using API.Chats.Application.Features.Participants.Queries.GetChatParticipants;
using API.Shared.Application.Contracts.FileStorage.Requests;
using API.Shared.Application.FileUrlTransform;
using API.Shared.Domain.CacheEntities.FileStorage;
using API.Shared.Domain.Interfaces.CacheRepo;
using MassTransit;

namespace API.Chats.Application.Features.Participants.UrlFileResponseTransforms
{
    internal class GetChatParticipantsResponseTransform(
        IRequestClient<GenerateAccountsFileUrlRequest> requestClient,
        IReadCacheRepository<FilePathCache> readFileCacheRepository)
        : FileUrlTransformer<GetChatParticipantsResponse>(requestClient, readFileCacheRepository)
    {
        public override async Task InterceptAndProcessResponse(GetChatParticipantsResponse model)
        {
            foreach (var participant in model.Participants)
            {
                if (participant.UserProfile?.ProfilePicture is not null)
                {
                    participant.UserProfile.ProfilePicture = await GetUrlPath(participant.UserProfile.ProfilePicture);
                }

                if (participant.ChatAgent?.ProfilePicture is not null)
                {
                    participant.ChatAgent.ProfilePicture = await GetUrlPath(participant.ChatAgent.ProfilePicture);
                }
            }
        }
    }
}
