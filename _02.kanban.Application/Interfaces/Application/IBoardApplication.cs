using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application;
public interface IBoardApplication{
  Task<IEnumerable<Board>> FindAll();
  Task<Board> Create(Board entity);
}