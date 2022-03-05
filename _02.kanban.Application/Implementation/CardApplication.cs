using _02.kanban.Application.Interfaces.Application;
using _02.kanban.Application.Interfaces.Services;
using _02.kanban.Application.Interfaces.UnityOfWork;
using _04.kanban.Core.ModelView.Card;
using AutoMapper;
using kanban.Core.Entities;

namespace _02.kanban.Application.Implementation
{

    public class CardApplication : ICardApplication
    {
        private readonly IUnityOfWork _IUnityOfWork;
        private readonly IDataUserLogged _IDataUserLogged;
        private readonly IMapper _IMapper;
        public CardApplication(IUnityOfWork iUnityOfWork, IDataUserLogged iDataUserLogged, IMapper iMapper)
        {
            _IUnityOfWork = iUnityOfWork;
            _IDataUserLogged = iDataUserLogged;
            _IMapper = iMapper;
        }
        public async Task<Card> Create(CardView model)
        {
            var entity = _IMapper.Map<Card>(model);
            entity.UseId = _IDataUserLogged.GetId();
            var card = await _IUnityOfWork.iCardRepository.InsertAsync(entity);
            await _IUnityOfWork.CommitAsync();
            return card;
        }

        public async Task<IEnumerable<Card>> FindAll(long grpId)
        {
            return await _IUnityOfWork.iCardRepository.FindAsync(x => x.UseId == _IDataUserLogged.GetId() && x.GrpId == grpId);
        }

        public async Task<Card> Update(CardUpdateView model)
        {
            var cardResult = await _IUnityOfWork.iCardRepository.FindAsync(x => x.UseId == _IDataUserLogged.GetId() && x.CrdId == model.CrdId);
            if (cardResult is null)
                return null;

            var entity = _IMapper.Map<Card>(model);
            var card = _IUnityOfWork.iCardRepository.UpdateAsync(entity);
            await _IUnityOfWork.CommitAsync();
            return card;
        }
    }
}