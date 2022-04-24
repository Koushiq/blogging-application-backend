
using System;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Factories
{
    public class PrepareLoginModelFactory : IPrepareLoginModelFactory
    {
        private readonly IUserService userService;

        public PrepareLoginModelFactory(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<TokenResponse> PrepareTokenResponseAsync(LoginModel loginModel)
        {
            if (loginModel == null)
            {
                throw new ArgumentException();
            }
            var customer = await userService.GetCustomer(loginModel.Username, loginModel.Password);
            var tokenResponse = new TokenResponse();
            if (customer == null)
            {
                return await Task.FromResult(tokenResponse);
            }
            tokenResponse.AuthStatus = true;
            tokenResponse.AuthorizationToken = await PrepareJWTToken(loginModel) ;
            return await Task.FromResult(tokenResponse);
        }

        private async Task<string> PrepareJWTToken(LoginModel loginModel)
        {
            return null;
        }
    }
}
