﻿using Microsoft.EntityFrameworkCore;
using ResponseCaching.API.Data.Entities;

namespace ResponseCaching.API.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly CatalogDbContext _dbContext;

    public ProductRepository(CatalogDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(ProductModel product)
    {
        _dbContext.Add(product);
    }

    public async Task<IEnumerable<ProductModel>> GetAllAsync()
    {
        return await _dbContext.Products
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
