using IdentityModel.Client;

namespace BLL.Services.Interfaces
{
    public interface ITokenService
    {
        Task<TokenResponse> GetToken(string scope);
    }
}
