
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Factories
{
    public class LoginModelFactory : ILoginModelFactory
    {
        private readonly IUserService userService;
        private readonly IJWTService jWTService;

        public LoginModelFactory(IUserService userService,
                                        IJWTService jWTService)
        {
            this.userService = userService;
            this.jWTService = jWTService;
        }

        public async Task<LoginModel> PrepareLoginModel(LoginModel model)
        {
            model.Password = ComputeSha256Hash(model.Password);
            return await Task.FromResult(model);
        }

        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public async Task<TokenResponse> PrepareTokenResponseAsync(LoginModel loginModel)
        {
            if (loginModel == null)
            {
                throw new ArgumentException();
            }
            var customer = await userService.GetCustomer(loginModel.Username, loginModel.Password);
            var tokenResponse = new TokenResponse();
            if (customer!=null)
            {
                tokenResponse.AuthStatus = true;
                tokenResponse.AuthorizationToken = await PrepareJWTToken();
            }
            return await Task.FromResult(tokenResponse);
        }

        private async Task<string> PrepareJWTToken()
        {
            var token = this.jWTService.GenerateJSONWebToken();
            return await Task.FromResult(token);
        }
    }
}
