using Microsoft.EntityFrameworkCore;

namespace Lab1.Services;

public class LoggingService 
{
    private readonly LibraryDbContext _context;

    public LoggingService(LibraryDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Log>> GetFilteredLogsAsync(int? requestId, string? routeUrl, DateTime? start, DateTime? end)
    {
        var query = _context.Logs.AsQueryable();

        if (requestId.HasValue)
            query = query.Where(log => log.RequestId == requestId.Value);

        if (!string.IsNullOrEmpty(routeUrl))
            query = query.Where(log => log.RouteURL == routeUrl);

        if (start.HasValue && end.HasValue)
            query = query.Where(log => log.Timestamp >= start.Value && log.Timestamp <= end.Value);

        return await query.ToListAsync();
    }
    
    public async Task<IEnumerable<Log>> GetAllLogsAsync()
    {
        return await _context.Logs.ToListAsync();
    }

    public async Task<IEnumerable<Log>> GetLogsByRequestIdAsync(int requestId)
    {
        return await _context.Logs
            .Where(log => log.RequestId == requestId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Log>> GetLogsByRouteUrlAsync(string routeUrl)
    {
        return await _context.Logs
            .Where(log => log.RouteURL == routeUrl)
            .ToListAsync();
    }

    public async Task<IEnumerable<Log>> GetLogsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return await _context.Logs
            .Where(log => log.Timestamp >= startDate && log.Timestamp <= endDate)
            .ToListAsync();
    }

    public async Task SaveLogAsync(Log logEntry)
    {
        _context.Logs.Add(logEntry);
        await _context.SaveChangesAsync();
    }
}
