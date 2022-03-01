using _02.kanban.Application.Interfaces.Application;
using _02.kanban.Application.Interfaces.Services;
using _02.kanban.Application.Interfaces.UnityOfWork;
using _04.kanban.Core.ModelView.User;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Implementation
{
    public class UserApplication : IUserApplication
    {
        private readonly IUnityOfWork _IUnityOfWork;
        private readonly IDataUserLogged _IDataUserLogged;
        private readonly IMapper _IMapper;
        private readonly ITokenService _ITokenService;
        public UserApplication(IUnityOfWork iUnityOfWork, IDataUserLogged iDataUserLogged, IMapper iMapper, ITokenService iTokenService)
        {
            _IUnityOfWork = iUnityOfWork;
            _IDataUserLogged = iDataUserLogged;
            _IMapper = iMapper;
            _ITokenService = iTokenService;
        }
        public async Task<User> Create(UserView model)
        {
            var entity = _IMapper.Map<User>(model);
            var user = await _IUnityOfWork.iUserRepository.InsertAsync(entity);
            await _IUnityOfWork.CommitAsync();
            user.UsePassword = null;
            return user;
        }

        public Task<User> ExecuteLogin(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser()
        {
            return await _IUnityOfWork.iUserRepository.GetByIdAsync(_IDataUserLogged.GetId());
        }
    }
}