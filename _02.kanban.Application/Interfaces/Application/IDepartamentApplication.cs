using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application
{
    public interface IDepartamentApplication
    {
        Task<IEnumerable<Departament>> FindAll();
        Task<Departament> Create(Departament entity);
        Task<Departament> Update(Departament entity);
    }
}