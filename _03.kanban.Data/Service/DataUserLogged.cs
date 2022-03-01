using System.Security.Claims;
using _02.kanban.Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace _03.kanban.Data.Service
{
    public class DataUserLogged : IDataUserLogged
    {
        private readonly IHttpContextAccessor _accessor;

        public DataUserLogged(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        public string GetEmail()
        {
            Claim email = _accessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Email).DefaultIfEmpty(null).FirstOrDefault();
            return email.Value;
        }

        public long GetId()
        {
            Claim id = _accessor.HttpContext.User.Claims.Where(c => c.Type == "Id").DefaultIfEmpty(null).FirstOrDefault();
            return Convert.ToInt64(id.Value);
        }

        public string GetName()
        {
            Claim name = _accessor.HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Name).DefaultIfEmpty(null).FirstOrDefault();
            return name.Value;
        }
    }
}