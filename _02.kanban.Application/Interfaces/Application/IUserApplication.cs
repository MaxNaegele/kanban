using _04.kanban.Core.ModelView.User;
using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application
{
    public interface IUserApplication
    {
        Task<User> ExecuteLogin(string email, string password);
        Task<User> GetUser();
        Task<User> Create(UserView model);    
    }
}