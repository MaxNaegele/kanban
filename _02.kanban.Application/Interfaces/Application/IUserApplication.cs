using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application
{
    public interface IUserApplication
    {
        Task<User> ExecuteLogin(string email, string password);
        Task<User> GetUser();
        Task<User> Create(User entity);
        Task<User> Update(User entity);
    }
}