using BLL.Services.Interfaces;
using IdentityModel.Client;

namespace BLL.Services
{
    public class TokenService : ITokenService
    {
        private DiscoveryDocumentResponse _discDocument { get; set; }
        public TokenService()
        {
            using (var client = new HttpClient())
            {
                _discDocument = client.GetDiscoveryDocumentAsync("http://localhost:5188/.well-known/openid-configuration").Result;
            }
        }
        public async Task<TokenResponse> GetToken(string scope)
        {
            using (var client = new HttpClient())
            {
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = _discDocument.TokenEndpoint,
                    ClientId = "cwm.client",
                    Scope = scope,
                    ClientSecret = "secret"
                });
                if (tokenResponse.IsError)
                {
                    throw new Exception("Token Error");
                }
                Console.WriteLine(tokenResponse);
                return tokenResponse;
            }
        }


    }
}
