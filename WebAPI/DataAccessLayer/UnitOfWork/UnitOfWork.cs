using AutoMapper;
using DataAccessLayer.Models;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingCartContext _context;
        private readonly IMapper _iMapper;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private ICustomerRepository _customerRepository;
        private IOrderRepository _orderRepository;

        public UnitOfWork(ShoppingCartContext shoppingCartContext, IMapper iMapper)
        {
            _context = shoppingCartContext;
            _iMapper = iMapper;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(_context, _iMapper);
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository = _categoryRepository ?? new CategoryRepository(_context, _iMapper);
            }
        }

        public ICustomerRepository CustomerRepository
        {
            get
            {
                return _customerRepository = _customerRepository ?? new CustomerRepository(_context, _iMapper);
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                return _orderRepository = _orderRepository ?? new OrderRepository(_context, _iMapper);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.DisposeAsync();
        }
    }
}
