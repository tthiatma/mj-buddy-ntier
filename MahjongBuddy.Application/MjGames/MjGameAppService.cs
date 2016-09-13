using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.RealTime;
using Abp.Runtime.Session;
using MahjongBuddy.Game;
using MahjongBuddy.MjGames.Dto;
using MahjongBuddy.Users;
using System.Collections.Generic;
using System.Linq;

namespace MahjongBuddy.Games
{
    public class MjGameAppService : IMjGameAppService
    {
        private readonly IMjGameRepository _mjGameRepository;
        private readonly IRepository<MjGameSession, long> _mjGameSessionRepository;
        private readonly IOnlineClientManager _onlineClientmanager;
        public IAbpSession AbpSession { get; set; }

        public MjGameAppService(IMjGameRepository mjGameRepository, 
            IRepository<User, long> userRepository, 
            IOnlineClientManager onlineClientmanager,
            IRepository<MjGameSession, long> mjGameSessionRepository)
        {
            _mjGameRepository = mjGameRepository;
            _onlineClientmanager = onlineClientmanager;
            _mjGameSessionRepository = mjGameSessionRepository;
            AbpSession = NullAbpSession.Instance;
        }

        public MjGame CreateMjGame(CreateMjGameInput input)
        {
            var game = input.MapTo<MjGame>();
            game.CreatorId = AbpSession.UserId;
            return _mjGameRepository.Insert(game);
        }

        public void UpdateMjGame(MjGameDto input)
        {
            var game = input.MapTo<MjGame>();
            _mjGameRepository.Update(game);
        }

        public MjGameSession CreateMjGameSession(CreateMjGameSessionInput input)
        {
            //var session = input.MapTo<MjGameSession>();
            var session = new MjGameSession() {
                GameNo = input.GameNo,
                MjGameId = input.MjGameId,
                Wind = input.Wind
            };

            return _mjGameSessionRepository.Insert(session);
        }

        public void AddUserToSession(AddUserToSessionInput input)
        {
            var session = _mjGameSessionRepository.Get(input.GameSessionId);
            session.Users.Add(input.User);
        }

        public void RemoveUserFromSession(RemoveUserFromSessionInput input)
        {
            var session = _mjGameSessionRepository.Get(input.GameSessionId);
            session.Users.Remove(input.User);
        }

        //TODO probably make this function async
        public GetMjGamesOutput GetMjGames(GetMjGamesInput input)
        {
            //TODO need to limit game query
            var games = _mjGameRepository.GetAllWithUsers().ToList();
                       
            return new GetMjGamesOutput
            {
                Items = games != null ? games.MapTo<List<MjGameDto>>() : null
            };
        }
    }
}
