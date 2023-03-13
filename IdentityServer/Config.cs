using Duende.IdentityServer;
using Duende.IdentityServer.Models;
using IdentityModel;

namespace IdentityServer;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource(name: "user", userClaims: new[] {JwtClaimTypes.Email})
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("scope1"),
            new ApiScope("scope2"),
            new ApiScope("api1"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "client1", //identyfikator aplikacji klienckiej
                ClientName = "Client for Postman user",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials, //sposób logowania
                ClientSecrets = { new Secret("secret".Sha256()) },
                AllowedScopes = { "api1", "user"},
                AlwaysSendClientClaims = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowAccessTokensViaBrowser = true
            },

            new Client
            {
                ClientId = "swagger",
                ClientName = "Client for Swagger user",
                AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                ClientSecrets = {new Secret("secret".Sha256())},
                //RequireClientSecret = false, //to trzeba właczyć
                AllowedScopes = {"api1", "user", "openid"},
                AlwaysSendClientClaims = true,
                AlwaysIncludeUserClaimsInIdToken = true,
                AllowAccessTokensViaBrowser=true,
                RedirectUris = { "https://localhost:7233/swagger/oauth2-redirect.html" },
                AllowedCorsOrigins = { "https://localhost:7233" }
            },
                //1. Dodanie Scope (z poradnik Duende)
                //2. Dodanie do AllowedScopes tego ostatniego scope co widać na screan
                //3. Dodanie do AllowedCorsOrigins naszego adresu Duende Identy Server
                //PS. Sprawa wygląda tak samo dla Clienta dla swaggera czy innych
               // blazor client
            new Client
            {
                ClientId = "blazor",
                ClientName = "Cient for Blazor use",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("secret".Sha256()) },
                RequirePkce = true,
                RequireClientSecret = false,
                
                // scopes that client has access to
                AllowedScopes = { "api1", "openId", "user", "role", "profile", IdentityServerConstants.LocalApi.ScopeName },
                AllowedCorsOrigins = { "https://localhost:7001", "https://localhost:5001" },
                RedirectUris = { "https://localhost:7001/authentication/login-callback" },
                PostLogoutRedirectUris = { "https://localhost:7001/" }
            },

            // machine to machine client
            new Client
            {
                ClientId = "client",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                // scopes that client has access to
                AllowedScopes = { "api1" }
            },

                // interactive ASP.NET Core Web App
            new Client
            {
                ClientId = "web",
                ClientSecrets = { new Secret("secret".Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,
                    
                // where to redirect to after login
                RedirectUris = { "https://localhost:5002/signin-oidc" },

                // where to redirect to after logout
                PostLogoutRedirectUris = { "https://localhost:5002/signout-callback-oidc" },

                AllowOfflineAccess = true,

                AllowedScopes = new List<string>
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    "api1"
                }
            },

            //// m2m client credentials flow client (klient logujący sie za pomocą credentials)
            //new Client
            //{
            //    ClientId = "m2m.client",
            //    ClientName = "Client Credentials Client",

            //    AllowedGrantTypes = GrantTypes.ClientCredentials,
            //    ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

            //    AllowedScopes = { "scope1" }
            //},

            //// interactive client using code flow + pkce (klient logujący się za pomaca kodu
            //new Client
            //{
            //    ClientId = "interactive",
            //    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

            //    AllowedGrantTypes = GrantTypes.Code,

            //    RedirectUris = { "https://localhost:44300/signin-oidc" },
            //    FrontChannelLogoutUri = "https://localhost:44300/signout-oidc",
            //    PostLogoutRedirectUris = { "https://localhost:44300/signout-callback-oidc" },

            //    AllowOfflineAccess = true,
            //    AllowedScopes = { "openid", "profile", "scope2" }
            //},
        };
}
