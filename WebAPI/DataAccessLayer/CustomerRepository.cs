using AutoMapper;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EntityLayer.CustomerDto;
using System;

namespace DataAccessLayer
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ShoppingCartContext _context;
        private readonly IMapper _iMapper;

        public CustomerRepository(ShoppingCartContext context, IMapper iMapper)
        {
            _context = context;
            _iMapper = iMapper;
        }

        public async Task<CustomerForRegisterDto> RegisterCustomer(CustomerForRegisterDto customerForRegisterDto, string password)
        {
            GenerateHashAndSalt(password, out byte[] hash, out byte[] salt);

            Customer customer = _iMapper.Map<CustomerForRegisterDto, Customer>(customerForRegisterDto);

            customer.Password = hash;
            customer.Salt = salt;

            await _context.Customer.AddAsync(customer);

            return customerForRegisterDto;
        }
        private void GenerateHashAndSalt(string cusPassword, out byte[] hash, out byte[] salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(cusPassword));
            }
        }

        public async Task<bool> CustomerExists(string email)
        {
            if (await _context.Customer.AnyAsync(e => e.Email == email))
                return true;
            return false;
        }

        public async Task<CustomerForLoginDto> Login(string email, string password)
        {
            var user = await _context.Customer.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null)
                return null;

            if (!ValidatePassword(password, user.Password, user.Salt))
                return null;

            return _iMapper.Map<CustomerForLoginDto>(user);
        }

        private bool ValidatePassword(string cusPassword, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(cusPassword));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public async Task<CustomerProfileDto> GetProfileDetails(string email)
        {
            var customer = await _context.Customer.FirstOrDefaultAsync(c => c.Email == email);
            return _iMapper.Map<CustomerProfileDto>(customer);
        }
    }
}
