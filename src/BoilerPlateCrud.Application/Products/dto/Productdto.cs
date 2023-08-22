using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerPlateCrud.Products.dto
{
  [AutoMapTo(typeof(Product.Products))]
  public class Productdto
  { 
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }

  }

}
