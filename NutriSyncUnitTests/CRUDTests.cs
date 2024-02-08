using NutriSyncBackend.Context.Repositories;
using NutriSyncBackend.Models;


namespace NutriSyncUnitTests;

public class CrudTests
{
    private IRepository<Product> _productRepository;
    private NutriSyncDBContext _dbContext;
    
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
        Environment.SetEnvironmentVariable("ASPNETCORE_ISSUERSIGNINGKEY", "FakeSigningKey11");
        Environment.SetEnvironmentVariable("ASPNETCORE_VALIDAUDIENCE", "FakeAudience");
        Environment.SetEnvironmentVariable("ASPNETCORE_VALIDISSUER", "FakeIssuer");
        _dbContext = new NutriSyncDBContext();
       
    }

    [SetUp]
    public void SetUp()
    {
        _productRepository = new ProductRepository(_dbContext);
    }

    [Test]
    public void ProductRepositoryCRUDTests()
    {
        var product = new Product
            {
                ProductId = 3,
                Description = "Legkomolyabb hely",
                Price = 25m,
                ProductName = "Pitbull"
            }
            ;
        _productRepository.Create(product);
        Assert.That(_productRepository.GetById(3), Is.Not.Null);
        
        Assert.That(_productRepository.GetById(3).Description, Is.EqualTo("Legkomolyabb hely"));
        
        var newProduct = _productRepository.GetById(3);
        newProduct.Price = 40m;
        _productRepository.Update(newProduct);
        Assert.That(newProduct.Price, Is.EqualTo(40m));
        
        _productRepository.Delete(3);
        Assert.That(_productRepository.GetById(3), Is.Null);
    }
    
}