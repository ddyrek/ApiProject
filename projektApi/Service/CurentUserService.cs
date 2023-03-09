using IdentityModel;
using projektApi.Application.Common.Interfaces;
using System.Security.Claims;

namespace projektApi.Service
{
    public class CurentUserService : ICurentUserService
    {
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
        public CurentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var email = httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Email);

            Email = email;
            IsAuthenticated = !string.IsNullOrEmpty(email);
        }
    }
}
