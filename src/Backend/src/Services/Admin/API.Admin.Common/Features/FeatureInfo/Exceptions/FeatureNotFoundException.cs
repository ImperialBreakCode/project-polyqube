using API.Shared.Common.Exceptions;

namespace API.Admin.Common.Features.FeatureInfo.Exceptions
{
    public class FeatureNotFoundException : NotFoundException
    {
        private const string MESSAGE = "Feature info not found.";

        public FeatureNotFoundException() : base(MESSAGE)
        {
        }
    }
}
