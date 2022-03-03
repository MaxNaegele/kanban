using _04.kanban.Core.Model;

namespace _02.kanban.Application.Interfaces.Services
{
    public interface ITokenService
    {
         string GenerateToken(DataUser user);
    }
}