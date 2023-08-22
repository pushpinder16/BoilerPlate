using Abp.Application.Services.Dto;
using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerPlateCrud.Product
{
  public interface IProductManager : IDomainService
  {
    Task CreateAsync(Products @event);
    Task UpdateAsync(Products @event);
    // void Delete(int id );

    void Delete(Products @event);
    Task<Products> GetAsync(int id);

  }
}
