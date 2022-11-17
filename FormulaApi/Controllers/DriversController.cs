using FormulaApi.Core;
using FormulaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormulaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DriversController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public DriversController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _unitOfWork.Drivers.All());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var driver = await _unitOfWork.Drivers.GetById(id);
        if(driver == null) return NotFound();

        return Ok(driver);
    }

    [HttpPost]
    public async Task<IActionResult> AddDriver(Driver driver)
    { 
        await _unitOfWork.Drivers.Add(driver);
        await _unitOfWork.CompleteAsync();
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> AddDriver(int id)
    {
        var driver = await _unitOfWork.Drivers.GetById(id);
        if(driver == null) return NotFound();

        await _unitOfWork.Drivers.Delete(driver);
        await _unitOfWork.CompleteAsync();

        return Ok();

    }
    
}