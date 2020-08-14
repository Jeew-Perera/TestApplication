using System.Collections.Generic;

namespace DataAccessLayer.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string CustomerAddress { get; set; }
        public int? Phone { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
