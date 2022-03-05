using _04.kanban.Core.Model;
using _04.kanban.Core.ModelView.User;
using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application
{
    public interface IUserApplication
    {
        Task<string> ExecuteLogin(string email, string password);
        Task<DataUser> GetUser();
        Task<IEnumerable<DataUser>> GetAllUser();
        Task<string> Create(UserView model);
    }   
}