using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.CustomerDto
{
    public class CustomerForLoginDto
    {
        public int CustomerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
