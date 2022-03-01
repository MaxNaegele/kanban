using _04.kanban.Core.ModelView.Board;
using kanban.Core.Entities;

namespace _02.kanban.Application.Interfaces.Application;
public interface IBoardApplication{
  Task<IEnumerable<Board>> FindAll();
  Task<Board> Create(BoardView model);
}