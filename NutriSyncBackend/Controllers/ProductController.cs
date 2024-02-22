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

    [HttpPost("CreateProduct")]
    public IActionResult Create([FromBody] Product product)
    {
        _productRepository.Create(product);
        return Ok(_productRepository.GetById(product.ProductId));
    }

    [HttpGet("Get/{id}")]
    public IActionResult GetById(int id)
    {
        var product = _productRepository.GetById(id);
        return Ok(product);
    }
}