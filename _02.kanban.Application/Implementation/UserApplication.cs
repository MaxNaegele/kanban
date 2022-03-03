using System.Text;
using _02.kanban.Application.Interfaces.Application;
using _02.kanban.Application.Interfaces.Services;
using _02.kanban.Application.Interfaces.UnityOfWork;
using _04.kanban.Core.Model;
using _04.kanban.Core.ModelView.User;
using AutoMapper;
using kanban.Core.Entities;
using System.Security.Cryptography;

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
        public async Task<string> Create(UserView model)
        {
            var entity = _IMapper.Map<User>(model);
            entity.UsePassword = ContertPasswordHash(model.UsePassword);
            var user = await _IUnityOfWork.iUserRepository.InsertAsync(entity);
            await _IUnityOfWork.CommitAsync();
            var dataUser = _IMapper.Map<DataUser>(user);
            return _ITokenService.GenerateToken(dataUser);

        }

        public async Task<string> ExecuteLogin(string email, string password)
        {
            var userConsult = await _IUnityOfWork.iUserRepository.FindAsync(x => x.UseEmail == email && x.UsePassword == ContertPasswordHash(password));
            if (userConsult.Count() == 0)
            {
                return null;
            }

            var dataUser = _IMapper.Map<DataUser>(userConsult.Single());
            return _ITokenService.GenerateToken(dataUser);
        }

        public async Task<User> GetUser()
        {
            return await _IUnityOfWork.iUserRepository.GetByIdAsync(_IDataUserLogged.GetId());
        }

        private string ContertPasswordHash(string value)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                return BitConverter.ToString(sha1.ComputeHash(Encoding.UTF8.GetBytes(value))).Replace("-", "");
            }
        }
    }
}