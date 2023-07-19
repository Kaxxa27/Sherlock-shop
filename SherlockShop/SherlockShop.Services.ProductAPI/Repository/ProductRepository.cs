﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SherlockShop.Services.ProductAPI.DbContexts;
using SherlockShop.Services.ProductAPI.Models;
using SherlockShop.Services.ProductAPI.Models.Dto;
using System.Reflection.Metadata.Ecma335;

namespace SherlockShop.Services.ProductAPI.Repository;

public class ProductRepository : IProductRepository
{
	private readonly ApplicationDbContext _db;
	private IMapper _mapper;

    public ProductRepository(ApplicationDbContext db, IMapper mapper)
    {
		_db = db;
		_mapper = mapper;
    }

    public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
	{
		Product product = _mapper.Map<ProductDto, Product>(productDto);

		if(product.ProductId > 0)
		{
			_db.Products.Update(product);
		}
		else
		{
			_db.Products.Add(product);
		}
		
		await _db.SaveChangesAsync();

		return _mapper.Map<Product, ProductDto>(product);
	}

	public async Task<bool> DeleteProduct(int productId)
	{
		try
		{
			Product? product = await _db.Products.FirstOrDefaultAsync(pr => pr.ProductId == productId);
			
			if (product is null)
				return false;

			_db.Products.Remove(product);
			await _db.SaveChangesAsync();

			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public async Task<ProductDto> GetProductById(int id)
	{
		Product? product = await _db.Products.Where(pr => pr.ProductId == id).FirstOrDefaultAsync();
		return _mapper.Map<ProductDto>(product);
	}

	public async Task<IEnumerable<ProductDto>> GetProducts()
	{
		IEnumerable<Product> products = await _db.Products.ToListAsync();
		return _mapper.Map<List<ProductDto>>(products);
	}
}
