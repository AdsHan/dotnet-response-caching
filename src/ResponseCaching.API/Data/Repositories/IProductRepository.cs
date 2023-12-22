using ResponseCaching.API.Data.Entities;

namespace ResponseCaching.API.Data.Repositories;

public interface IProductRepository : IDisposable
{
    Task<IEnumerable<ProductModel>> GetAllAsync();
    Task SaveAsync();
    void Add(ProductModel obj);
}