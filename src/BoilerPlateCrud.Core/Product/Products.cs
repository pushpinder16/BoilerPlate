using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerPlateCrud.Product
{
  public class Products : FullAuditedEntity<int>
  {
    
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }


    public static Products Create(int ProductId, string Name, int Quantity)
    {
      var product = new Products
      {
        ProductId = ProductId,
        Name = Name,
        Quantity = Quantity,
        IsDeleted = false
      };

      return product;
    }
    public static Products Update(int Id, int ProductId, string Name, int Quantity)
    {
      var product = new Products
      {
        Id = Id,
        ProductId = ProductId,
        Name = Name,
        Quantity = Quantity,
        IsDeleted = false
      };

      return product;
    }

   
  }

}
