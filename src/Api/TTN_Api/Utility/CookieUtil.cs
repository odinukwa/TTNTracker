using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TTN_Tracker.Utility
{
    public class CookieUtil : ICookieUtil
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieUtil(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public UserData GetUserData()
        {
            UserData userData = null;

            var claims = _httpContextAccessor.HttpContext.User.Claims.ToList();

            if (claims.Count() > 0)
            {
                int userId = int.Parse(claims.First(d => d.Type == "UserId").Value);
                var email = claims.First(d => d.Type == "Email").Value;
                userData = new UserData()
                {
                    UserId = userId,
                    Email = email,
                };
            }
            return userData;
        }
    }
    public interface ICookieUtil
    {
        UserData GetUserData();
    }
    public class UserData
    {
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}