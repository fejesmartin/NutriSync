using Microsoft.EntityFrameworkCore;
using NutriSyncBackend.Models;

namespace NutriSyncBackend.Context.Repositories;

public class ProductRespository: IRepository<Product>
{
    public NutriSyncDBContext _dbContext;
    public ProductRespository(NutriSyncDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Product> GetAll()
    {
        return _dbContext.Products.ToList();
    }

    public Product? GetById(int id)
    {
        return _dbContext.Products.Find(id);
    }

    public void Create(Product obj)
    {
        _dbContext.Products.Add(obj);
        _dbContext.SaveChanges();
    }

    public void Update(Product obj)
    {
        _dbContext.Entry(obj).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var product = _dbContext.Products.Find(id);
        if (product != null)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}