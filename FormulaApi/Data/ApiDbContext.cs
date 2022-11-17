using FormulaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FormulaApi.Data;

public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        :base(options)
    {
        
    }

    public virtual DbSet<Driver>? Drivers { get; set; }
}