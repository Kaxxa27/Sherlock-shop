using System.ComponentModel.DataAnnotations;

namespace SherlockShop.WEB.Models;

public class ProductDto
{	
	public int ProductId { get; set; }
	public string Name { get; set; }
	public double Price { get; set; }
	public string CategoryName { get; set; }
	public string Description { get; set; }
	public byte[]? Image { get; set; }
}
