using AutoMapper;
using SherlockShop.Services.ProductAPI.Models;
using SherlockShop.Services.ProductAPI.Models.Dto;

namespace SherlockShop.Services.ProductAPI;

public class MappingConfig
{
	public static MapperConfiguration RegisterMaps()
	{
		var mappingConfig = new MapperConfiguration(config => {

			//config.CreateMap<ProductDto, Product>().ReverseMap();
			config.CreateMap<ProductDto, Product>();
			config.CreateMap<Product, ProductDto>();

		}); 

		return mappingConfig;
	}
}
