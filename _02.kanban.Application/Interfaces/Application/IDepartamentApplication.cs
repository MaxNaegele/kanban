using _04.kanban.Core.ModelView.Departament;
using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application
{
    public interface IDepartamentApplication
    {
        Task<IEnumerable<Departament>> FindAll();
        Task<Departament> Create(DepartamentView model);
    }
}