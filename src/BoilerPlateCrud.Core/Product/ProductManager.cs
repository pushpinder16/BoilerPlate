using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerPlateCrud.Product
{
  public class ProductManager : IProductManager
  {
    private readonly IRepository<Product.Products, int> _eventRepository;

    public ProductManager(IRepository<Product.Products, int> eventRepository)
    {
      _eventRepository = eventRepository;
    }

    public async Task CreateAsync(Product.Products @event)
    {
      await _eventRepository.InsertAsync(@event);
    }



    //public Task<Product.Products> GetAsync(GetProductdto int id)
    //  {
    //      var list = _eventRepository.GetAllList().Where(x => x.Id == id).FirstOrDefault(); ;
    //    //return Task.Run(async() =>
    //    //{
    //    //  var list2 = await _eventRepository.GetAllListAsync();
    //    //  var product = list.Where(x => x.Id == id).FirstOrDefault();
    //    //  if (product == null)
    //    //  {
    //    //    throw new UserFriendlyException("Could not found the event, maybe it's deleted!");
    //    //  }
    //      return list;

    //  }

    public Task<Product.Products> GetAsync(int id)
    {
      return Task.Run(() =>
    {
     var @event = _eventRepository.GetAll().Where(x => x.Id == id).FirstOrDefault();
      if (@event == null)
      {
        return null;
      }
       return @event;
      });
    }

    public async Task UpdateAsync(Product.Products @event)
    {
      await _eventRepository.UpdateAsync(@event);
    }

  
    public void Delete(Product.Products @event)
    {
      _eventRepository.Delete(@event);
    }

  }
}






