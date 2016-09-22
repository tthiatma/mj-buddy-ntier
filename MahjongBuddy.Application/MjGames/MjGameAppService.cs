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
        private readonly IMjGameSessionRepository _mjGameSessionRepository;
        private readonly IOnlineClientManager _onlineClientmanager;
        private readonly IRepository<User, long> _userRepository;
        public IAbpSession AbpSession { get; set; }

        public MjGameAppService(IMjGameRepository mjGameRepository, 
            IRepository<User, long> userRepository, 
            IOnlineClientManager onlineClientmanager,
            IMjGameSessionRepository mjGameSessionRepository)
        {
            _userRepository = userRepository;
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

        public void UpdateMjGame(MjGame input)
        {
            _mjGameRepository.Update(input);
        }

        public MjGameSession CreateMjGameSession(CreateMjGameSessionInput input)
        {
            List<User> users = new List<User>();

            foreach (var userId in input.UsersId)
            {
                users.Add(_userRepository.Get(userId));
            }

            var session = new MjGameSession() {
                GameNo = input.GameNo,
                MjGameId = input.MjGameId,
                Wind = input.Wind,
                Users = users,                
            };
            var newSession = _mjGameSessionRepository.Insert(session);

            return newSession;
        }

        public void AddUserToSession(AddUserToSessionInput input)
        {
            var session = _mjGameSessionRepository.Get(input.GameSessionId);
            var user = _userRepository.Get(input.UserId);
            session.Users.Add(user);
        }

        public void RemoveUserFromSession(RemoveUserFromSessionInput input)
        {
            var session = _mjGameSessionRepository.Get(input.GameSessionId);
            session.Users.Remove(input.User);
        }

        //TODO probably make this function async
        public GetMjGamesOutput GetMjGameSessions(GetMjGamesInput input)
        {
            //TODO need to limit game query
            var games = _mjGameSessionRepository.GetAllWithUsers().ToList();

            return new GetMjGamesOutput
            {
                Items = games != null ? games.MapTo<List<MjGameDto>>() : null
            };
        }


        //TODO probably make this function async
        public GetMjGamesOutput GetMjGames(GetMjGamesInput input)
        {
            //TODO need to limit game query
            var games = _mjGameRepository.GetAll();
                       
            return new GetMjGamesOutput
            {
                Items = games != null ? games.MapTo<List<MjGameDto>>() : null
            };
        }
    }
}
