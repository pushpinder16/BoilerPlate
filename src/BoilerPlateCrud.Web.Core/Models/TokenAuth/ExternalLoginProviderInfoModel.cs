using Abp.AutoMapper;
using BoilerPlateCrud.Authentication.External;

namespace BoilerPlateCrud.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
