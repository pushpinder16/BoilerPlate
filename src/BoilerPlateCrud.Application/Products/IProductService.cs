using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BoilerPlateCrud.Products.dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerPlateCrud.Products
{
  public interface IProductService : IApplicationService
  {
    Task<ObjectResult> CreateAsync(Productdto input);

    Task<ObjectResult> UpdateAsync(Productdto input);

    void  DeleteAsync(EntityDto<int> input);
    Task<ListResultDto<Productdto>> GetListAsync(GetAllProductsdto input);
  }
}
