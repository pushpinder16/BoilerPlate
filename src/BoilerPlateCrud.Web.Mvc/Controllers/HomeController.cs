using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using BoilerPlateCrud.Controllers;

namespace BoilerPlateCrud.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : BoilerPlateCrudControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
