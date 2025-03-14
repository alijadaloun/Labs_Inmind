using Lab1;
using Lab1.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LogsController : ControllerBase
{
    private readonly LoggingService _logService;

    public LogsController(LoggingService logService)
    {
        _logService = logService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllLogs()
    {
        var logs = await _logService.GetAllLogsAsync();
        return Ok(logs);
    }

    [HttpGet("by-request-id/{requestId}")]
    public async Task<IActionResult> GetByRequestId(int requestId)
    {
        var logs = await _logService.GetLogsByRequestIdAsync(requestId);
        return Ok(logs);
    }

    [HttpGet("by-route-url")]
    public async Task<IActionResult> GetByRouteUrl([FromQuery] string routeUrl)
    {
        var logs = await _logService.GetLogsByRouteUrlAsync(routeUrl);
        return Ok(logs);
    }

    [HttpGet("by-date-range")]
    public async Task<IActionResult> GetByDateRange([FromQuery] DateTime start, [FromQuery] DateTime end)
    {
        var logs = await _logService.GetLogsByDateRangeAsync(start, end);
        return Ok(logs);
    }
    [HttpGet]
    public async Task<IActionResult> GetFilteredLogs(
        [FromQuery] int? requestId,
        [FromQuery] string? routeUrl,
        [FromQuery] DateTime? start,
        [FromQuery] DateTime? end)
    {
        var logs = await _logService.GetFilteredLogsAsync(requestId, routeUrl, start, end);
        return Ok(logs);
    }

    [HttpPost]
    public async Task<IActionResult> SaveLog([FromBody] Log logEntry)
    {
        if (logEntry == null)
            return BadRequest("Log data is null.");

        await _logService.SaveLogAsync(logEntry);
        return Ok(new { message = "Log stored successfully." });
    }
}