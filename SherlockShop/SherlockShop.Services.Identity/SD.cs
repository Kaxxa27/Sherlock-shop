using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace SherlockShop.Services.Identity
{
    public static class SD
    {
        // Role 
        public const string Admin = "Admin";
        public const string Customer = "Customer";

        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
               new ApiScope("SherlockShop", "SherlockShop Server"),
               new ApiScope(name: "read", displayName: "Read your data."),
               new ApiScope(name: "write", displayName: "Write your data."),
               new ApiScope(name: "delete", displayName: "Delete your data."),
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                // universal client
                new Client
                {
                    ClientId = "client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "read", "write", "profile" }
                },
                // SherlockShop Web Client
                new Client
                {
                    ClientId = "SherlockShop",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:44339/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:44339/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.Profile,
                        "sherlockshop"
                    }
                },
            };

    }
}
