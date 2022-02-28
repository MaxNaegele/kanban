using _02.kanban.Application.Interfaces.Repository;

namespace _02.kanban.Application.Interfaces.UnityOfWork
{
    public interface IUnityOfWork
    {
        IBoardRepository iBoardRepository { get; }
        ICardRepository iCardRepository { get; }
        IDepartamentRepository iDepartamentRepository{ get; }
        IGroupRepository iGroupRepository{ get; }
        IStatusRepository iStatusRepository{ get; }
        IUserRepository iUserRepository{ get; }
        Task CommitAsync();
    }
}