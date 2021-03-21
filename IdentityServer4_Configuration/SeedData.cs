using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer4_Configuration
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResources.Address(),
            };


        public static IEnumerable<ApiScope> ApiScopes =>
            new List<ApiScope>
            {
                new ApiScope("my_api1", "My API 1"),
                new ApiScope("my_api2", "My API 2")
            };

        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
                // Client Credentails client
                new Client
                {
                    ClientId = "resource_client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // scopes that client has access to
                    AllowedScopes = { "my_api1" },
                },
                
                // Code flow Client
                new Client
                {
                    ClientId = "mvc_client",
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    
                    // where to redirect to after login
                    RedirectUris = { "https://localhost:5002/home" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:5002/logout" },

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "my_api1"
                    }
                },
                new Client
                {
                    ClientId = "angular_client",                    

                    AllowedGrantTypes = GrantTypes.Implicit,
                    
                    // where to redirect to after login
                    RedirectUris = { "https://localhost:4200/dashboard" },

                    // where to redirect to after logout
                    PostLogoutRedirectUris = { "https://localhost:4200/home" },

                    RequireClientSecret = false, // for implicit clients

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "my_api1",
                        "my_api2"
                    }
                }
            };
    }
}