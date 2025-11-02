using Microsoft.AspNetCore.Mvc;
using ShiftLogger.Service;
using static ShiftLogger.Models.ShiftLoggerDto.ShiftLoggerDto;

namespace ShiftLogger.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShiftLoggerController : ControllerBase
{
    private readonly IShiftLoggerService _shiftLoggerService;

    public ShiftLoggerController(IShiftLoggerService shiftLoggerService) //dependency injecction
    {
        _shiftLoggerService = shiftLoggerService;
    }

    [HttpPost("shift-in")]
    public async Task<ActionResult> ShiftIn(ShiftInDto shiftInDto)
    {
        try
        {
            await _shiftLoggerService.ShiftIn(shiftInDto);
            return Ok("Shift Started successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error During Shift in operation.", details = ex.Message });
        }
    }

    [HttpPost("shift-out")]
    public async Task<ActionResult> ShiftOut(ShiftOutDto shiftOutDto)
    {
        try
        {
            await _shiftLoggerService.ShiftOut(shiftOutDto);
            return Ok("Shift ended successfully.");
        }
        catch(InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error During Shift out operation    .", details = ex.Message });
        }
    }
}

