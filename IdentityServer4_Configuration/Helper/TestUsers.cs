using IdentityModel;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer4_Configuration.Helper
{
    public class TestUsers
    {
        public static List<TestUser> Users
        {
            get
            {                                
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "1",
                        Username = "sample@admin.com",
                        Password = "secret",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Dev User"),
                            new Claim(JwtClaimTypes.GivenName, "Dev"),
                            new Claim(JwtClaimTypes.FamilyName, "User"),
                            new Claim(JwtClaimTypes.Email, "sample@admin.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),                            
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "2",
                        Username = "test@admin.com",
                        Password = "secret",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "Test User"),
                            new Claim(JwtClaimTypes.GivenName, "Test"),
                            new Claim(JwtClaimTypes.FamilyName, "User"),
                            new Claim(JwtClaimTypes.Email, "test@admin.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                        }
                    }
                };
            }
        }
    }
}