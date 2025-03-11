using API.Shared.Web.Models;
using Newtonsoft.Json;
using System.Text;
using API.Shared.Web.Factories;
using Microsoft.Extensions.Options;
using API.Shared.Web.Options;
using Microsoft.AspNetCore.Mvc;

namespace API.Shared.Web.Auth
{
    internal class HttpAccessTokenValidator : IAccessTokenValidator
    {
        private readonly IAuthFactory _authFactory;
        private readonly IOptionsMonitor<AuthValidationOptions> _authOptions;

        public HttpAccessTokenValidator(IAuthFactory authFactory, IOptionsMonitor<AuthValidationOptions> authOptions)
        {
            _authFactory = authFactory;
            _authOptions = authOptions;
        }

        public async Task<AccessTokenValidationResult> Validate(string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                var request = _authFactory.CreateValidateAccessTokenRequest(accessToken);

                var requestBody = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                var url = _authOptions.CurrentValue.Authority + _authOptions.CurrentValue.AccessTokenValidationEndpoint;
                var response = await httpClient.PostAsync(url, requestBody);
                var jsonContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<AccessTokenPayloadResponseDTO>(jsonContent);
                    return _authFactory.ValidateAccessTokenValidationResult(result, null);
                }

                var errorResult = JsonConvert.DeserializeObject<ProblemDetails>(jsonContent);
                return _authFactory.ValidateAccessTokenValidationResult(null, errorResult);
            }
        }
    }
}
