using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication2.Factories;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ILoginModelFactory loginModelFactory;

        public LoginController(IUserService userService,
                               ILoginModelFactory loginModelFactory)
        {
            this.userService = userService;
            this.loginModelFactory = loginModelFactory;
        }
        //[HttpGet]
        //[Route("login")]
        //[Produces("application/json")]

        //public async Task<ActionResult<LoginModel>> IndexAsync()
        //{
        //    return new LoginModel() { };
        ////}
        //[HttpPost]
        //[Route("TokenResponse")]
        //public async Task<IActionResult<TokenResponse>> TokenResponse(LoginModel loginModel)
        //{

        //}
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenResponse>> IndexAsync(LoginModel loginModel)
        {
            if (loginModel == null)
            {
                throw new ArgumentException();
            }

            var token = await this.loginModelFactory.PrepareTokenResponseAsync(loginModel);

            return token;

        }
    }
}
