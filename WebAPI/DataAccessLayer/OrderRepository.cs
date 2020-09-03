using AutoMapper;
using DataAccessLayer.Models;
using EntityLayer.OrderDto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShoppingCartContext _context;
        private readonly IMapper _iMapper;

        public OrderRepository(ShoppingCartContext context, IMapper iMapper)
        {
            _context = context;
            _iMapper = iMapper;
        }

        public async Task<OrderDto> SaveOrder(OrderDto orderDto)
        {
            orderDto.cardDetails.Date = DateTime.Now;
            orderDto.cardDetails.Amount = orderDto.OrderTotal;
            Order order = _iMapper.Map<Order>(orderDto);
            order.OrderStatus = "Order Placed";
            //order.ShippingAddress = orderDto.ReceiverAddress;
            //order.CustomerId = orderDto.BillingDetails.CustomerId;
            await _context.Order.AddAsync(order);
            return orderDto;
        }

    }
}
