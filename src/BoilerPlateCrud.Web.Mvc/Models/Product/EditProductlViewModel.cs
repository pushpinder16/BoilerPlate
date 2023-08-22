using BoilerPlateCrud.Products.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoilerPlateCrud.Web.Models.Product
{
  public class EditProductlViewModel
  {
    public Productdto Product { get; set; }

    public IReadOnlyList<Productdto> Products { get; set; }



  }
}
