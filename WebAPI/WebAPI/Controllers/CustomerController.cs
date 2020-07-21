using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IBusinessCustomer _iBusinessCustomer;

        //private readonly ApplicationSettings _appSettings;

        //public CustomerController(ShoppingCartContext context, IOptions<ApplicationSettings> appSettings)
        public CustomerController(IBusinessCustomer iBusinessCustomer)
        {
            _iBusinessCustomer = iBusinessCustomer;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<Object> Register([FromBody] Customer customer)
        {
            var returnVal = _iBusinessCustomer.RegisterCustomer(customer);
            if (returnVal.Equals(-1))
            {
                return Conflict();
            }
            else
            {
                return Ok();
            }

            //byte[] saltBytes = GeneratePasswordSalt();
            //byte[] passwordAsBytes = Encoding.UTF8.GetBytes(customer.Password);
            //List<byte> passwordWithSaltBytes = new List<byte>();
            //passwordWithSaltBytes.AddRange(passwordAsBytes);
            //passwordWithSaltBytes.AddRange(saltBytes);
            //string a = Convert.ToBase64String(SHA256.Create().ComputeHash(passwordWithSaltBytes.ToArray())); //password
            //string b = Convert.ToBase64String(saltBytes);

            //customer.Password = a;
            //customer.Salt = b;

            //_context.Customer.Add(customer);

            //try
            //{
            //    _context.SaveChanges();
            //}
            //catch (DbUpdateException)
            //{
            //    if (CustomerExists(customer.Email))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return Ok(customer);
            ////return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);

        }

        //private bool CustomerExists(string email)
        //{
        //    return _context.Customer.Any(e => e.Email == email);
        //}

        //private byte[] GeneratePasswordSalt()
        //{
        //    int keyLength = 20;
        //    var rngCsp = new RNGCryptoServiceProvider();
        //    byte[] randomBytes = new byte[keyLength];
        //    rngCsp.GetBytes(randomBytes);
        //    return randomBytes;
        //}

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
