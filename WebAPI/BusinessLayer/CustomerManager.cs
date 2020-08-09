using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.UnitOfWork;
using EntityLayer.CustomerDto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CustomerManager : ICustomerManager
    {
        private IUnitOfWork _iUnitOfWork;
        private readonly IConfiguration _iConfiguration;

        public CustomerManager(IUnitOfWork iUnitOfWork, IConfiguration iConfiguration)
        {
            _iUnitOfWork = iUnitOfWork;
            _iConfiguration = iConfiguration;
        }

        public async Task<bool> RegisterCustomer(CustomerForRegisterDto customerForRegisterDto)
        {
            customerForRegisterDto.Email = customerForRegisterDto.Email.ToLower();

            if (await _iUnitOfWork.CustomerRepository.CustomerExists(customerForRegisterDto.Email))
                return false;

            var newCustomer = await _iUnitOfWork.CustomerRepository.RegisterCustomer(customerForRegisterDto, customerForRegisterDto.Password);
            
            //_iUnitOfWork.Commit();

            return true;

        }
        
        public async Task<CustomerForLoginDto> Login(string username, string password)
        {
            var userFromRepo = await _iUnitOfWork.CustomerRepository.Login(username.ToLower(), password);

            if (userFromRepo == null)
                return null;

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.CustomerId.ToString()),
                new Claim(ClaimTypes.Email , userFromRepo.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_iConfiguration.GetSection("ApplicationSettings:Secret_Key").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            string serializetoken = tokenHandler.WriteToken(token);

            return new CustomerForLoginDto
            {
                Token = serializetoken
            };
        }

        public async Task<CustomerProfileDto> GetProfileDetails(string email)
        {
            return await _iUnitOfWork.CustomerRepository.GetProfileDetails(email);
        }

    }
}
