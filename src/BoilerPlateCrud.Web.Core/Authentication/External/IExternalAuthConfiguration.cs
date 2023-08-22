using System.Collections.Generic;

namespace BoilerPlateCrud.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
