using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.CustomerDto;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerManager _iCustomerManager;
        public CustomerController(ICustomerManager iCustomerManager)
        {
            _iCustomerManager = iCustomerManager;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(CustomerForRegisterDto customer)
        {
            if (!await _iCustomerManager.RegisterCustomer(customer))
                return BadRequest("Email address already exists");
            return Ok();

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(CustomerForLoginDto customerForLoginDto)
        {
            var customer = await _iCustomerManager.Login(customerForLoginDto.Email, customerForLoginDto.Password);
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
            CustomerProfileDto user = await _iCustomerManager.GetProfileDetails(email);
            return user;
        }
    }
}
