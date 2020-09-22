using AutoMapper;
using DataAccessLayer.Models;
using EntityLayer.OrderDto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
            Order order = _iMapper.Map<Order>(orderDto);
            order.OrderStatus = "Order Placed";
            await _context.Order.AddAsync(order);

            return orderDto;
        }

        public async Task<IEnumerable<GetOrderDto>> GetAllOrderDetails(int cusId)
        {
            var orders = await (from order in _context.Order
                                join
                                   orderProduct in _context.OrderProduct
                                   on order.OrderId equals orderProduct.OrderId
                                join
                                   product in _context.Product
                                on orderProduct.ProductId equals product.ProductId
                                where order.CustomerId == cusId
                                select new GetOrderDto()
                                {
                                    OrderId = order.OrderId,
                                    Quantity = orderProduct.Quantity,
                                    UnitPrice = (double)product.UnitPrice,
                                    ProductName = product.ProductName,
                                    OrderDate = order.OrderDate,
                                    OrderTotal = (double)order.OrderTotal,
                                    ShippingAddress = order.ShippingAddress
                                })
                                .Distinct().OrderByDescending(x => x.OrderId).ToListAsync();

            return orders;
        }

        public IEnumerable<GetOrderDto> GetLastOrderDetails(int cusId)
        {
            var allOrders = (from order in _context.Order
                             join
                                orderProduct in _context.OrderProduct
                                on order.OrderId equals orderProduct.OrderId
                             join
                                product in _context.Product
                             on orderProduct.ProductId equals product.ProductId
                             where order.CustomerId == cusId
                             select new GetOrderDto()
                             {
                                 OrderId = order.OrderId,
                                 Quantity = orderProduct.Quantity,
                                 UnitPrice = (double)product.UnitPrice,
                                 ProductName = product.ProductName,
                                 OrderDate = order.OrderDate,
                                 OrderTotal = (double)order.OrderTotal,
                                 ShippingAddress = order.ShippingAddress
                             })
                             .Distinct().OrderByDescending(x => x.OrderId).ToList();
            return allOrders;
        }

    }
}
