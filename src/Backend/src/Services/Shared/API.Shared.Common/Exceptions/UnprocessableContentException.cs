using API.Shared.Common.Exceptions.Base;
using System.Net;

namespace API.Shared.Common.Exceptions
{
    public class UnprocessableContentException : APIException
    {
        private const string MESSAGE = "Multiple validation errors occured.";

        private readonly IDictionary<string, string[]> errors;

        public UnprocessableContentException(IDictionary<string, string[]> errors) : base(MESSAGE, HttpStatusCode.UnprocessableContent)
        {
            this.errors = errors;
        }

        public IDictionary<string, string[]> Errors => errors;
    }
}
