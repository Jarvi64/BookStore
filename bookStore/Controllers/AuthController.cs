using bookStore.CustomeActionFilter;
using bookStore.Models.Domain;
using bookStore.Models.Dto;
using bookStore.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace bookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<Customer> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<Customer> userManager,ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        [ValidateModel] 
        public async Task<IActionResult> Register([FromBody] RegisterCustomerDto model)
        {
            var customer = new Customer
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                StreetNumber = model.StreetNumber,
                StreetName = model.StreetName,
                PostalCode = model.PostalCode,
                Province = model.Province,
                Country = model.Country
            };
            var result = await userManager.CreateAsync(customer, model.Password);

            if (result.Succeeded)
            {
                return Ok("User registered successfully.");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }


            [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestDto model)
        {
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null) {
                var checkPass = await userManager.CheckPasswordAsync(user, model.Password);
                if (checkPass) {
                    var jwtToken = tokenRepository.CreateJWTToken(user);
                    var res = new LoginResponceDto { Jwt = jwtToken };
                    return Ok(res);
                }
            }
                return BadRequest("UserName or Password incorrect");
          
        }
    }
}
