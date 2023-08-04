using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SherlockShop.WEB.Models;
using SherlockShop.WEB.Services.IServices;
using System.Reflection.Metadata.Ecma335;

namespace SherlockShop.WEB.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> ProductIndex()
    {
        List<ProductDto>? list = new();
        var response = await _productService.GetAllProductsAsync<ResponseDto>();

        if (response != null && response.IsSuccess)
            list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));

        return View(list);
    }

    [HttpGet]
    public async Task<IActionResult> ProductCreate()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProductCreate(ProductDto model)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.CreateProductAsync<ResponseDto>(model);

            if (response != null && response.IsSuccess)
                return RedirectToAction(nameof(ProductIndex));
        }

        return View(model);
    }
}
