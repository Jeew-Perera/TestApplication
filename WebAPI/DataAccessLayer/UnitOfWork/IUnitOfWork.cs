namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        void Commit();
        void Rollback();
    }
}
