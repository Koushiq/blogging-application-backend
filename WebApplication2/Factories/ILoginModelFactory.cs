
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Factories
{
    public interface ILoginModelFactory
    {
        Task<LoginModel> PrepareLoginModel(LoginModel model);
        Task<TokenResponse> PrepareTokenResponseAsync(LoginModel loginModel);
    }
}
