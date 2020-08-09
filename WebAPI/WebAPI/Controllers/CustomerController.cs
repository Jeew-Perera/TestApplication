using System;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.CustomerDto;
using AutoMapper;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _iBusinessCustomer;
        public CustomerController(ICustomerManager iBusinessCustomer)
        {
            _iBusinessCustomer = iBusinessCustomer; //manager
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(CustomerForRegisterDto customer)
        {
            if (!await _iBusinessCustomer.RegisterCustomer(customer))
                return BadRequest("Email address already exists");
            return Ok();

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(CustomerForLoginDto customerForLoginDto)
        {
            var customer = await _iBusinessCustomer.Login(customerForLoginDto.Email, customerForLoginDto.Password);
            if (customer == null)
            {
                return BadRequest(new { message = "Username or password incorrect" });
            }
            else if (customer.Token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(new { token = customer.Token });
            }
        }

        [HttpGet]
        [Authorize]
        [Route("UserProfile")]
        public async Task<CustomerProfileDto> GetUserProfile()
        {
            string email = User.Claims.First(c => c.Type == "UserID").Value;
            CustomerProfileDto user = await _iBusinessCustomer.GetProfileDetails(email);
            return user;
        }

        //[HttpPost]
        //[Route("Login")]
        //public async Task<ActionResult> Login(string email, string password)
        //{
        //    email = "rukkantha@gmail.com";
        //    password = "12345";
        //    var user = _context.Customer.Where(c => c.Email == email).FirstOrDefault();
        //    var saltValue = user.Salt;
        //    byte[] saltBytes = Convert.FromBase64String(saltValue);
        //    byte[] passwordAsBytes = Encoding.UTF8.GetBytes(password);
        //    List<byte> passwordWithSaltBytes = new List<byte>();
        //    passwordWithSaltBytes.AddRange(passwordAsBytes);
        //    passwordWithSaltBytes.AddRange(saltBytes);
        //    string a = Convert.ToBase64String(SHA256.Create().ComputeHash(passwordWithSaltBytes.ToArray())); //password

        //    if (user != null && a == user.Password)
        //    {
        //        var tokenString = GenerateJSONWebToken(user);
        //        return Ok(new { token = tokenString });
        //        //return "Good";
        //    }
        //    else
        //    {
        //        //return "Bad";
        //        return BadRequest(new { message = "Username or password incorrect" });
        //    }
        //}

        //private string GenerateJSONWebToken(Customer userInfo)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(_appSettings.Issuer,
        //      _appSettings.Issuer,
        //      null,
        //      expires: DateTime.Now.AddMinutes(120),
        //      signingCredentials: credentials
        //    );

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}
