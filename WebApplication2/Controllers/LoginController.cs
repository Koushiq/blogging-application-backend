using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService userService;

        public LoginController(IUserService userService)
        {
            this.userService = userService;
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
        public async Task<ActionResult<LoginModel>> IndexAsync(LoginModel loginModel)
        {
            if (loginModel == null)
            {
                throw new ArgumentException();
            }
            if (!ModelState.IsValid)
            {
                return loginModel;
            }
            //string username = loginModel.Username;
            //string password = loginModel.Password;
            //var customer = await userService.GetCustomer(username, password);

            //if (customer == null)
            //{
            //    return NoContent();
            //}

            //return Ok();

        }
    }
}
