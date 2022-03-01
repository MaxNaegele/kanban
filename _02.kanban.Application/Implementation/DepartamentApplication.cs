using _02.kanban.Application.Interfaces.Application;
using _02.kanban.Application.Interfaces.Services;
using _02.kanban.Application.Interfaces.UnityOfWork;
using _04.kanban.Core.ModelView.Departament;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Implementation
{
    public class DepartamentApplication : IDepartamentApplication
    {
        private readonly IUnityOfWork _IUnityOfWork;
        private readonly IDataUserLogged _IDataUserLogged;
        private readonly IMapper _IMapper;
        public DepartamentApplication(IUnityOfWork iUnityOfWork, IDataUserLogged iDataUserLogged, IMapper iMapper)
        {
            _IUnityOfWork = iUnityOfWork;
            _IDataUserLogged = iDataUserLogged;
            _IMapper = iMapper;
        }

        public async Task<Departament> Create(DepartamentView model)
        {
            var entity = _IMapper.Map<Departament>(model);
            var departament = await _IUnityOfWork.iDepartamentRepository.InsertAsync(entity);
            await _IUnityOfWork.CommitAsync();
            return departament;
        }

        public async Task<IEnumerable<Departament>> FindAll()
        {
            return await _IUnityOfWork.iDepartamentRepository.FindAllAsync();
        }
    }
}