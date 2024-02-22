using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NutriSyncBackend.Context.Repositories;
using NutriSyncBackend.Models;

namespace NutriSyncIntegrationTests;

public class CustomWebApplicationFactory: WebApplicationFactory<Program>
{
    public IRepository<Product> _productRepository;
    public IRepository<Plan> _planRepository;
    public NutriSyncDBContext _testNutriSyncDbContext;

    public CustomWebApplicationFactory()
    {
        _testNutriSyncDbContext = new NutriSyncDBContext(new DbContextOptions<NutriSyncDBContext>());
        _productRepository = new ProductRepository(_testNutriSyncDbContext);
        _planRepository = new PlanRepository(_testNutriSyncDbContext);

    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove any existing DbContext registration
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<NutriSyncDBContext>));

            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            // Add DbContext using in-memory database provider
            services.AddDbContext<NutriSyncDBContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });


            // Register other services
            services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IRepository<Plan>, PlanRepository>();
        });

        builder.UseEnvironment("Test");
    }
}