using CustomFizzBuzzApi.Interfaces;
using CustomFizzBuzzApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomFizzBuzzApi.Controllers;

[Route("api/CustomFizzBuzz")]
[ApiController]
public class CustomFizzBuzzController : ControllerBase
{
    private readonly CustomFizzBuzzLoggerContext _loggerContext;
    private readonly ICustomFizzBuzzService _customFizzBuzzService;

    public CustomFizzBuzzController(CustomFizzBuzzLoggerContext loggerContext
        , ICustomFizzBuzzService customFizzBuzzService)
    {
        _loggerContext = loggerContext;
        _customFizzBuzzService = customFizzBuzzService;
    }

    [HttpPost]
    public async Task<ActionResult<CustomFizzBuzzResponseDTO>> GetCustomFizzBuzzOutput([FromBody] CustomFizzBuzzRequestDTO requestModel)
    {
        try
        {
            return _customFizzBuzzService.GenerateCustomFizzBuzzOutput(requestModel);
        }
        finally
        {
            _loggerContext.Entry(requestModel).State = EntityState.Modified;


            try
            {
                await _loggerContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}