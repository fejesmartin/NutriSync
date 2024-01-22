using Microsoft.AspNetCore.Mvc;
using NutriSyncBackend.Context.Repositories;

namespace NutriSyncBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController: ControllerBase
{
    private readonly PlanRepository _planRepository;
    
    public ProductController(PlanRepository planRepository)
    {
        _planRepository = planRepository;
    }

    public IActionResult GetAllProducts()
    {
        var products = _planRepository.GetAll();
        return Ok(products);
    }
}