using DataAccessLayer.UnitOfWork;
using EntityLayer.OrderDto;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitOfWork _iUnitOfWork;
        private readonly IEmailSender _iEmailSender;

        public OrderManager(IUnitOfWork iUnitOfWork, IEmailSender iEmailSender)
        {
            _iUnitOfWork = iUnitOfWork;
            _iEmailSender = iEmailSender;
        }

        public async Task<OrderDto> SaveOrder(OrderDto orderDto)
        {
            try
            {
                await _iUnitOfWork.OrderRepository.SaveOrder(orderDto);
                await _iUnitOfWork.Commit();
                emailInvoice(orderDto);
                return null;
            }
            catch (Exception ex)
            {
                _iUnitOfWork.Rollback();
                return null;
            }
        }

        private void emailInvoice(OrderDto orderDto)
        {
            IEnumerable<GetOrderDto> allOrders = _iUnitOfWork.OrderRepository.GetLastOrderDetails(orderDto.BillingDetails.CustomerId);
            GetOrderDto lastOrder = allOrders.First();

            string mailBody = "<h1 style='color:red;text-align:center;'>Jeew Bakes Invoice Details</h1>"
                + "<p>Date : " + orderDto.OrderDate + "</p>"
                + "<p> Order number : " + lastOrder.OrderId + "</p>"
                + "<p> Full name : " + orderDto.BillingDetails.CustomerName + "</p>"
                + "<p> Address : " + orderDto.BillingDetails.CustomerAddress + "</p>"
                + "<p> Email : " + orderDto.BillingDetails.Email + "</p>"
                + "<br> <h3> Receiver Details as follows; </h3>"
                + "<p> Receiver Name : " + orderDto.ReceiverName + "</p>"
                + "<p> Receiver Address : " + orderDto.ReceiverAddress + "</p>"
                + "<p> Receiver Phone : " + orderDto.ReceiverPhone + "</p>";

            mailBody = mailBody
                 + "<br><br> <h3> Your Order Details as Below </h3>"
                 + "<table border='1'>"
                 + "<thead> <tr> <th>Product</th> <th>Unit Price</th> <th>Quantity</th> <th>Sub Total</th> </tr> </thead>"
                 + "<tbody> ";

            for (int i = 0; i < orderDto.OrderedProducts.Count; i++)
            {
                mailBody = mailBody
                    + "<tr> <td> " + orderDto.OrderedProducts[i].ProductName + "</td>"
                    + "<td> " + orderDto.OrderedProducts[i].UnitPrice + "</td>"
                    + "<td> " + orderDto.OrderedProducts[i].Quantity + "</td>"
                    + "<td> " + (orderDto.OrderedProducts[i].UnitPrice * orderDto.OrderedProducts[i].Quantity) + "</td>";
            }
            mailBody = mailBody + "</tr> </tbody> </table>";

            _iEmailSender.Send(orderDto.BillingDetails.Email, "Jeew Bakes - Invoice", mailBody);

            //mailBody = CreateEmailBody(orderDto);
        }

        //private string CreateEmailBody(OrderDto orderDto)
        //{
        //    //var invoiceFilePath = _iWebHostEnvironment.WebRootPath
        //    return null;
        //}

        public async Task<IEnumerable<GetOrderDto>> GetAllOrderDetails(int cusId)
        {
            return await _iUnitOfWork.OrderRepository.GetAllOrderDetails(cusId);
        }
    }
}
