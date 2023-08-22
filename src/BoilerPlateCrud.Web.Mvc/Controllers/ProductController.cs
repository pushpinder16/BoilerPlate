using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using BoilerPlateCrud.Controllers;
using BoilerPlateCrud.Product;
using BoilerPlateCrud.Products;
using BoilerPlateCrud.Web.Models.Product;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoilerPlateCrud.Web.Controllers
{
  [AbpMvcAuthorize]
  public class ProductController : BoilerPlateCrudControllerBase
  {
    private readonly IProductManager _productManager;
    private readonly IWebHostEnvironment _environment;
    private readonly IRepository<Product.Products, int> _eventRepository;
    private readonly ILogger<ProductService> _logger;
    private readonly IUnitOfWorkManager _unitOfWorkManager;
    public ProductController(ProductManager productManager, IUnitOfWorkManager unitOfWorkManager, IRepository<Product.Products, int> eventRepository, ILogger<ProductService> logger, IWebHostEnvironment environment)
    {
      _productManager = productManager;
      _unitOfWorkManager = unitOfWorkManager;
      _eventRepository = eventRepository;
      _environment = environment;
      _logger = logger;
    }


    public async Task<IActionResult> Index()
        {
      var productList = new List<ProductListViewModel>();
      var productLists = await GetListAsync();
      foreach (var product in productLists)
      {
        var productobj = new ProductListViewModel
        {
          Id= product.Id,
          Name = product.Name,
          ProductId= product.ProductId,
          Quantity= product.Quantity

        };

        productList.Add(productobj);

      }
      return View(productList);
    }
    [HttpPost]
   [UnitOfWork]
    public async Task<IActionResult> Save([FromBody]ProductListViewModel input)
      {

      var products = Product.Products.Create(input.ProductId, input.Quantity.ToString(), input.ProductId);
      await _productManager.CreateAsync(products);

      return RedirectToAction("Index", "Products");
    }

  

    [HttpPost]
    [UnitOfWork]
    public async Task<IActionResult> EditModal(int id)
    {
      try
      {
        var product = await _productManager.GetAsync(id);
        var Products = new ProductListViewModel
        {
          Id= product.Id,
          Name = product.Name,
          ProductId = product.ProductId,
          Quantity = product.Quantity,
        
        };

        return PartialView("_EditModal", Products);
      }
      catch (Exception ex)
      {
        ViewBag.ErrorMessage = ex.Message;

        return View("Index");
      }
    }


    [HttpGet]
    [UnitOfWork]
    public async Task<IActionResult> Get(int id)
    {
      try
      {

        var product = await _productManager.GetAsync(id);
        return View("Index", product);
      }
      catch (Exception ex)
      {
        ViewBag.ErrorMessage = ex.Message;

        return View("Index");
      }
    }


    [HttpGet]
    [UnitOfWork]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        var product = await _productManager.GetAsync(id);

        //_productManager.Delete(product);

        return View("Index", product);
      }
      catch (Exception ex)
      {
        ViewBag.ErrorMessage = ex.Message;

       

        return View("Index");
      }
    }
    public async Task<List<Product.Products>> GetListAsync()
    {
      var product = await _eventRepository.GetAll().ToListAsync();
      return product;
    }

  }
}
