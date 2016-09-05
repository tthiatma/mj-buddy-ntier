using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.RealTime;
using Abp.Runtime.Session;
using MahjongBuddy.Game;
using MahjongBuddy.MjGames.Dto;
using MahjongBuddy.Users;
using System.Collections.Generic;

namespace MahjongBuddy.Games
{
    public class MjGameAppService : IMjGameAppService
    {
        private readonly IMjGameRepository _mjGameRepository;
        private readonly IOnlineClientManager _onlineClientmanager;
        public IAbpSession AbpSession { get; set; }

        public MjGameAppService(IMjGameRepository mjGameRepository, IRepository<User, long> userRepository, IOnlineClientManager onlineClientmanager)
        {
            _mjGameRepository = mjGameRepository;
            _onlineClientmanager = onlineClientmanager;
            AbpSession = NullAbpSession.Instance;
        }

        public void CreateMjGame(CreateMjGameInput input)
        {
            var game = input.MapTo<MjGame>();
            game.CreatorId = AbpSession.UserId;
            _mjGameRepository.Insert(game);
        }

        public void JoinMjGame(JoinMjGameInput input)
        {

        }

        //TODO probably make this function async
        public GetMjGamesOutput GetMjGames(GetMjGamesInput input)
        {
            var games = _mjGameRepository.GetAllWithUsers();
            return new GetMjGamesOutput
            {
                Items = games.MapTo<List<MjGameDto>>()
            };
        }
    }
}
