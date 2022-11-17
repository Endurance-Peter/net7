using FormulaApi.Data;
using FormulaApi.Models;

namespace FormulaApi.Core;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(ApiDbContext context,
    ILogger logger) : base(context,logger)
    {
        
    }

    
}