using _02.kanban.Application.Interfaces.Application;
using _02.kanban.Application.Interfaces.Services;
using _02.kanban.Application.Interfaces.UnityOfWork;
using _04.kanban.Core.ModelView.Status;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Implementation
{
    public class StatusApplication : IStatusApplication
    {
        private readonly IUnityOfWork _IUnityOfWork;
        private readonly IDataUserLogged _IDataUserLogged;
        private readonly IMapper _IMapper;
        public StatusApplication(IUnityOfWork iUnityOfWork, IDataUserLogged iDataUserLogged, IMapper iMapper)
        {
            _IUnityOfWork = iUnityOfWork;
            _IDataUserLogged = iDataUserLogged;
            _IMapper = iMapper;
        }

        public async Task<Status> Create(StatusView model)
        {
            var entity = _IMapper.Map<Status>(model);
            var status = await _IUnityOfWork.iStatusRepository.InsertAsync(entity);
            await _IUnityOfWork.CommitAsync();
            return status;
        }

        public async Task<IEnumerable<Status>> FindAll()
        {
            return await _IUnityOfWork.iStatusRepository.FindAllAsync();
        }
    }
}