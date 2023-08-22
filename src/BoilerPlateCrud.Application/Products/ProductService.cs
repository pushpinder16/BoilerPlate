using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;
using BoilerPlateCrud.Authorization;
using BoilerPlateCrud.Product;
using BoilerPlateCrud.Products.dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerPlateCrud.Products
{
  public class ProductService : BoilerPlateCrudAppServiceBase
  {
    private readonly IProductManager _productManager;
    private readonly IWebHostEnvironment _environment;
    private readonly IRepository<Product.Products, int> _eventRepository;
    private readonly ILogger<ProductService> _logger;
    private readonly IUnitOfWorkManager _unitOfWorkManager;
    public ProductService(IProductManager productManager, IUnitOfWorkManager unitOfWorkManager, IRepository<Product.Products, int> eventRepository, ILogger<ProductService> logger, IWebHostEnvironment environment)
    {
      _productManager = productManager;
      _unitOfWorkManager = unitOfWorkManager;
      _eventRepository = eventRepository;
      _environment = environment;
      _logger = logger;
    }


    public async Task CreateAsync(Productdto input)
    {
      try
      {
        var product = Product.Products.Create(input.ProductId, input.Name, input.Quantity);
        _eventRepository.Insert(product);
        await CurrentUnitOfWork.SaveChangesAsync();
      }
      catch (Exception err)
      {
        throw err;
      }
    }

    public async Task UpdateAsync(UpdateProductDto input)
    {
      try
      {
        var product = Product.Products.Update(input.Id, input.ProductId, input.Name, input.Quantity);
        await _productManager.UpdateAsync(product);
        await CurrentUnitOfWork.SaveChangesAsync();
      }
      catch (Exception err)
      {
        throw err;
      }
    }

    public async Task<Product.Products> GetAsync(EntityDto<int> input)
    {
      try
      {

        var product = await _productManager.GetAsync(input.Id);
        await CurrentUnitOfWork.SaveChangesAsync();
        return product;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }


    public async Task<dynamic> GetAllAsync()
    {
      try
      {
        var product = _eventRepository.GetAllIncluding();
        var count = _eventRepository.GetAll().Count();
        var list = product.ToList();
        var data = new
        {
          totalCount = count,
          items = list
        };
        return data;
      }
      catch (Exception ex)
      {
        throw new UserFriendlyException(ex.Message.ToString());
      }
    }

    public async Task<ObjectResult> Delete(EntityDto<int> input)
    {
      var @event = await _productManager.GetAsync(input.Id);
      _productManager.Delete(@event);
      
      return new OkObjectResult("Deleted");
    }



  }
}
