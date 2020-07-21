using AutoMapper;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DACustomer : IDACustomer
    {
        private readonly ShoppingCartContext _context;
        private readonly IMapper _iMapper;

        public DACustomer(ShoppingCartContext context, IMapper iMapper)
        {
            _context = context;
            _iMapper = iMapper;
        }

        public async Task<Object> RegisterCustomer(Customer customer)
        {
            byte[] saltBytes = GeneratePasswordSalt();
            byte[] passwordAsBytes = Encoding.UTF8.GetBytes(customer.Password);
            List<byte> passwordWithSaltBytes = new List<byte>();
            passwordWithSaltBytes.AddRange(passwordAsBytes);
            passwordWithSaltBytes.AddRange(saltBytes);
            string a = Convert.ToBase64String(SHA256.Create().ComputeHash(passwordWithSaltBytes.ToArray())); //password
            string b = Convert.ToBase64String(saltBytes);

            customer.Password = a;
            customer.Salt = b;

            _context.Customer.Add(customer);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.Email))
                {
                    //return Conflict(); 
                    return -1;
                }
                else
                {
                    throw;
                }
            }

            return 1;
            
            //return Ok(customer);
            //return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);

        }
        private byte[] GeneratePasswordSalt()
        {
            int keyLength = 20;
            var rngCsp = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[keyLength];
            rngCsp.GetBytes(randomBytes);
            return randomBytes;
        }

        private bool CustomerExists(string email)
        {
            return _context.Customer.Any(e => e.Email == email);
        }

    }
}
