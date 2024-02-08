using Microsoft.AspNetCore.Mvc;
using NutriSyncBackend.Context.Repositories;
using NutriSyncBackend.Models;

namespace NutriSyncBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController: ControllerBase
{
    private readonly IRepository<Product> _productRepository;
    
    public ProductController(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }
    
    [HttpGet("GetAllProducts")]
    public IActionResult GetAllProducts()
    {
        var products = _productRepository.GetAll();
        return Ok(products);
    }
}