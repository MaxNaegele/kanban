using _02.kanban.Application.Interfaces.Application;
using _02.kanban.Application.Interfaces.UnityOfWork;
using kanban.Core.Entities;

namespace _02.kanban.Application.Implementation
{
    public class BoardApplication : IBoardApplication
    {
        public IUnityOfWork _IUnityOfWork { get; }
        public BoardApplication(IUnityOfWork iUnityOfWork)
        {
            _IUnityOfWork = iUnityOfWork;
        }

        public Task<Board> Create(Board entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Board>> FindAll()
        {
            return await _IUnityOfWork.iBoardRepository.FindAsync(x => x.UseId == 1);
        }
    }
}