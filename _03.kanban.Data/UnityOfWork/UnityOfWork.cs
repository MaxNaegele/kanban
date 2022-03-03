using _02.kanban.Application.Interfaces.Repository;
using _02.kanban.Application.Interfaces.UnityOfWork;
using _03.kanban.Data.Context;
using _03.kanban.Data.Repository;

namespace _03.kanban.Data.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private kanbanContext context;
        public IBoardRepository iBoardRepository { get; }

        public ICardRepository iCardRepository { get; }

        public IDepartamentRepository iDepartamentRepository { get; }

        public IGroupRepository iGroupRepository { get; }

        public IStatusRepository iStatusRepository { get; }

        public IUserRepository iUserRepository { get; }

        public UnityOfWork(kanbanContext context)
        {
            this.context = context;
            this.iBoardRepository = new BoardRepository(this.context);
            this.iCardRepository = new CardRepository(this.context);
            this.iDepartamentRepository = new DepartamentRepository(this.context);
            this.iGroupRepository = new GroupRepository(this.context);
            this.iStatusRepository = new StatusRepository(this.context);
            this.iUserRepository = new UserRepository(this.context);
        }
        public async Task CommitAsync()
        {
            await this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}