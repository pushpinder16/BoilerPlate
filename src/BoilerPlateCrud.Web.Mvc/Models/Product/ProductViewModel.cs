using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoilerPlateCrud.Web.Models.Product
{
  public class ProductViewModel
  {
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

    public static ProductViewModel Create( int productId, string name, int quantity)        
    {
      var @event = new ProductViewModel
      {
        ProductId = productId,
        Name = name,
        Quantity = quantity,

      };

      return @event;
    }
    
  }

}
