using Microsoft.EntityFrameworkCore;
using NutriSyncBackend.Models;
using NutriSyncBackend.Context.Repositories;

public class ProductRepository : IRepository<Product>
{
    private readonly NutriSyncDBContext _dbContext;
    private readonly ILogger _logger;

    public ProductRepository(NutriSyncDBContext dbContext, ILogger logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public IEnumerable<Product> GetAll()
    {
        try
        {
            _logger.LogInformation("Getting all products from the database.");
            return _dbContext.Products.ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving all products.");
            throw;
        }
    }

    public Product? GetById(int id)
    {
        try
        {
            _logger.LogInformation("Getting product by ID: {ProductId}", id);
            return _dbContext.Products.Find(id);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving all products.");
            throw;
        }
    }

    public void Create(Product obj)
    {
        try
        {
            _logger.LogInformation("Creating new product: {@Product}", obj);
            _dbContext.Products.Add(obj);
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving all products.");
            throw;
        }
       
    }

    public void Update(Product obj)
    {
        try
        {
            _logger.LogInformation("Updating product: {@Product}", obj);
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving all products.");
            throw;
        }
       
    }

    public void Delete(int id)
    {
        try
        {
            _logger.LogInformation("Deleting product with ID: {ProductId}", id);
            var product = _dbContext.Products.Find(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving all products.");
            throw;
        }
       
    }
}
