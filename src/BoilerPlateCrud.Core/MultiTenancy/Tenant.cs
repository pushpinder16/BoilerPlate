using Abp.MultiTenancy;
using BoilerPlateCrud.Authorization.Users;

namespace BoilerPlateCrud.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
