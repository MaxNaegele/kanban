using _02.kanban.Application.Interfaces.Application;
using _02.kanban.Application.Interfaces.Services;
using _02.kanban.Application.Interfaces.UnityOfWork;
using _04.kanban.Core.ModelView.Board;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Implementation
{
    public class BoardApplication : IBoardApplication
    {
        private readonly IUnityOfWork _IUnityOfWork;
        private readonly IDataUserLogged _IDataUserLogged;
        private readonly IMapper _IMapper;
        public BoardApplication(IUnityOfWork iUnityOfWork, IDataUserLogged iDataUserLogged, IMapper iMapper)
        {
            _IUnityOfWork = iUnityOfWork;
            _IDataUserLogged = iDataUserLogged;
            _IMapper = iMapper;
        }

        public async Task<Board> Create(BoardView model)
        {
            var entity = _IMapper.Map<Board>(model);
            var board = await _IUnityOfWork.iBoardRepository.InsertAsync(entity);
            await _IUnityOfWork.CommitAsync();
            return board;
        }

        public async Task<IEnumerable<Board>> FindAll()
        {
            return await _IUnityOfWork.iBoardRepository.FindAsync(x => x.UseId == _IDataUserLogged.GetId());
        }
    }
}