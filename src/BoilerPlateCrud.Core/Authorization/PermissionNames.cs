namespace BoilerPlateCrud.Authorization
{
    public static class PermissionNames
    {
        public const string Pages_Tenants = "Pages.Tenants";

        public const string Pages_Users = "Pages.Users";
        public const string Pages_Users_Activation = "Pages.Users.Activation";

        public const string Pages_Roles = "Pages.Roles";
        public const string Pages_Products = "Pages.Products";

        public static string Pages_Product { get; internal set; }
  }
}
