using System;

namespace EntityLayer.OrderDto
{
    public class PaymentDto
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public string ExpDate { get; set; }
        public int CvnNumber { get; set; }
    }
}
