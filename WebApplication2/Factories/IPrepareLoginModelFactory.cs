
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Factories
{
    public interface IPrepareLoginModelFactory
    {
        Task<TokenResponse> PrepareTokenResponseAsync(LoginModel loginModel);
    }
}
