using BoilerPlateCrud.Products.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoilerPlateCrud.Web.Models.Product
{
  public class ProductListViewModel
  {
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
  }
}
