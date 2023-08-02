using Core.Abstraction;
using Core.Entities;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace SpecPattern.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeveloperController : ControllerBase
{
    
    public readonly IGenericRepository<Developer> _repository;
    public DeveloperController(IGenericRepository<Developer> repository)
    {
        _repository = repository;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var developers = await _repository.GetAllAsync();
        return Ok(developers);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var developer = await _repository.GetByIdAsync(id);
        return Ok(developer);
    }
    [HttpGet("specify")]
    public async Task<IActionResult> Specify()
    {
        var specification = new DeveloperByIncomeSpecification();
        //var specification = new DeveloperByIncomeSpecification();
        var developers = _repository.FindWithSpecificationPattern(specification);
        return Ok(developers);
    }
}
