using Microsoft.EntityFrameworkCore;
using SherlockShop.Services.ProductAPI.Models;

namespace SherlockShop.Services.ProductAPI.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    
    }

    public DbSet<Product> Products { get; set; }
}
