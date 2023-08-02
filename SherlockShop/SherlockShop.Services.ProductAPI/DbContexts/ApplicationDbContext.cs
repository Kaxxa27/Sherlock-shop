using Microsoft.EntityFrameworkCore;
using SherlockShop.Services.ProductAPI.Models;

namespace SherlockShop.Services.ProductAPI.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    
    }

    public DbSet<Product> Products { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.Entity<Product>().HasData(new Product
		{
			ProductId = 1,
			Name = "Belstaff milford",
			Price = 5000,
			CategoryName = "Coat",
			Description = "The greatest coat of Sherlock Holmes himself.",
			Image = { }
		});
		modelBuilder.Entity<Product>().HasData(new Product
		{
			ProductId = 2,
			Name = "Mycroft's umbrella",
			Price = 2999,
			CategoryName = "Umbrella",
			Description = "An umbrella that can protect not only from the rain.",
			Image = { }
		});
		modelBuilder.Entity<Product>().HasData(new Product
		{
			ProductId = 3,
			Name = "Sherlock's scarf",
			Price = 400,
			CategoryName = "Scarf",
			Description = "Nothing personal - just a scarf.",
			Image = { }
		});
		modelBuilder.Entity<Product>().HasData(new Product
		{
			ProductId = 4,
			Name = "Sherlock's Violin",
			Price = 7777,
			CategoryName = "Musical instrument",
			Description = "How do you feel about the violin?",
			Image = { }
		});
	}
}
