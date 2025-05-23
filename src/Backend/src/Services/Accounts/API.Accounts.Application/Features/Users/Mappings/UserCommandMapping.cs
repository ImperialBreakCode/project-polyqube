using API.Accounts.Application.Features.Users.Commands.SetProfilePicture;
using API.Accounts.Application.Features.Users.Commands.UpdateUserDetails;
using API.Accounts.Domain.Aggregates.UserAggregate;
using API.Shared.Application.Contracts.FileStorage.Requests;
using AutoMapper;
using MassTransit;

namespace API.Accounts.Application.Features.Users.Mappings
{
    internal class UserCommandMapping : Profile
    {
        public UserCommandMapping()
        {
            CreateMap<UpdateUserDetailsCommand, UserDetails>();

            CreateMap<(SetProfilePictureCommand, MessageData<Stream>), SaveProfilePictureRequest>()
                .ConstructUsing(x => new(x.Item1.FileName, x.Item1.MimeType, x.Item2, x.Item1.UserId));

            CreateMap<UserDetails, RemoveProfilePictureRequest>()
                .ConstructUsing(x => new(x.ProfilePicturePath));
        }
    }
}
