using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.RealTime;
using Abp.Runtime.Session;
using AutoMapper;
using MahjongBuddy.Game;
using MahjongBuddy.MjGames.Dto;
using MahjongBuddy.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MahjongBuddy.Games
{
    public class MjGameAppService : IMjGameAppService
    {
        private readonly IRepository<MjGame, long> _mjGameRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IOnlineClientManager _onlineClientmanager;
        public IAbpSession AbpSession { get; set; }

        public MjGameAppService(IRepository<MjGame, long> mjGameRepository, IRepository<User, long> userRepository, IOnlineClientManager onlineClientmanager)
        {
            _mjGameRepository = mjGameRepository;
            _userRepository = userRepository;
            _onlineClientmanager = onlineClientmanager;
            AbpSession = NullAbpSession.Instance;
        }

        public void CreateMjGame(CreateMjGameInput input)
        {
            var game = input.MapTo<MjGame>();
            game.CreatorUserId = AbpSession.UserId;
            _mjGameRepository.Insert(game);
        }

        public void JoinMjGame(JoinMjGameInput input)
        {

        }

        public GetMjGamesOutput GetMjGames(GetMjGamesInput input)
        {
            var games = _mjGameRepository.GetAllList();
            
            var rawr = Mapper.Map<IEnumerable<MjGame>, IEnumerable<MjGameDto>>(games);
            var asd = games.MapTo<List<MjGameDto>>();

            return new GetMjGamesOutput
            {                
                Games = games.MapTo<List<MjGameDto>>()
            };
        }
    }
}
