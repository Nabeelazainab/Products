using Microsoft.EntityFrameworkCore;
namespace Product2.Models;
    public class ProductContext : DbContext
{
    public ProductContext(DbContextOptions<ProductContext> options)
       : base(options)
    {
    }
    public DbSet<Productitems> TodoItems { get; set; } = null!;
    
    }

