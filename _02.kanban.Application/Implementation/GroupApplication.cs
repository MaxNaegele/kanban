using _02.kanban.Application.Interfaces.Application;
using _02.kanban.Application.Interfaces.Services;
using _02.kanban.Application.Interfaces.UnityOfWork;
using _04.kanban.Core.ModelView.Group;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Implementation
{
    public class GroupApplication : IGroupApplication
    {
        private readonly IUnityOfWork _IUnityOfWork;
        private readonly IDataUserLogged _IDataUserLogged;
        private readonly IMapper _IMapper;
        public GroupApplication(IUnityOfWork iUnityOfWork, IDataUserLogged iDataUserLogged, IMapper iMapper)
        {
            _IUnityOfWork = iUnityOfWork;
            _IDataUserLogged = iDataUserLogged;
            _IMapper = iMapper;
        }

        public async Task<Group> Create(GroupView model)
        {
            var entity = _IMapper.Map<Group>(model);
            var group = await _IUnityOfWork.iGroupRepository.InsertAsync(entity);
            await _IUnityOfWork.CommitAsync();
            return group;
        }

        public async Task Delete(long id)
        {
            await _IUnityOfWork.iGroupRepository.DeleteAsync(id);
            await _IUnityOfWork.CommitAsync();
        }

        public async Task<Group> Update(GroupUpdateView model)
        {
            var cardResult = await _IUnityOfWork.iGroupRepository.FindAsync(x => x.GrpId == model.GrpId);
            if (cardResult is null)
                return null;

            var entity = _IMapper.Map<Group>(model);
            var card = _IUnityOfWork.iGroupRepository.UpdateAsync(entity);
            await _IUnityOfWork.CommitAsync();
            return card;
        }

        public async Task<IEnumerable<Group>> FindAll(long BrdId)
        {
            return await _IUnityOfWork.iGroupRepository.FindAsync(x=> x.BrdId == BrdId);
        }
    }
}