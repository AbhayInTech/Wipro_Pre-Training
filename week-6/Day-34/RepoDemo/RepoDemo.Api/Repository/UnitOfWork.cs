using RepoDemo.Api.Data;
using RepoDemo.Api.Models;
using RepoDemo.Api.Repository.Interfaces;

namespace RepoDemo.Api.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IGenericRepository<Product>? _productRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IGenericRepository<Product> Products
        {
            get
            {
                _productRepository ??= new GenericRepository<Product>(_context);
                return _productRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
