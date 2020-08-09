﻿using AutoMapper;
using DataAccessLayer.Models;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShoppingCartContext _context;
        private readonly IMapper _iMapper;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private ICustomerRepository _customerRepository;

        public UnitOfWork(ShoppingCartContext shoppingCartContext, IMapper iMapper)
        {
            _context = shoppingCartContext;
            _iMapper = iMapper;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(_context,_iMapper);
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

        public void Commit()
        {
            _context.SaveChangesAsync();
        }

        public void Rollback()
        {
            _context.DisposeAsync();
        }
    }
}
