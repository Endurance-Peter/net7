using FormulaApi.Data;

namespace FormulaApi.Core;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;
    private readonly ILogger _logger;

    public UnitOfWork(ApiDbContext context,
    ILoggerFactory logger)
    {
        _context = context;
        _logger = logger.CreateLogger("create logs");  
        Drivers = new DriverRepository(_context, _logger); 
    }
    public IDriverRepository Drivers {get; private set;}

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
