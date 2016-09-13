using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.RealTime;
using Abp.Runtime.Session;
using Castle.Core.Logging;
using MahjongBuddy.Connection;
using MahjongBuddy.Game;
using MahjongBuddy.Games;
using MahjongBuddy.MjGames.Dto;
using MahjongBuddy.Users;
using Microsoft.AspNet.SignalR;
using System;
using System.Threading.Tasks;

namespace MahjongBuddy.Web
{
    public class GameHub : Hub, ITransientDependency
    {
        public IAbpSession AbpSession { get; set; }

        public ILogger Logger { get; set; }
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<MjSignalRConnection, long> _connectionRepository;
        private readonly IOnlineClientManager _onlineClientmanager;
        private readonly IMjGameAppService _mjGameAppService;

        public GameHub(IRepository<User, long> userRepository, IRepository<MjSignalRConnection, long> connectionRepository, IOnlineClientManager onlineClientmanager, IMjGameAppService mjGameAppService)
        {
            _userRepository = userRepository;
            _connectionRepository = connectionRepository;
            AbpSession = NullAbpSession.Instance;
            Logger = NullLogger.Instance;
            _onlineClientmanager = onlineClientmanager;
            _mjGameAppService = mjGameAppService;
        }

        public void CreateMjGame(CreateMjGameInput input)
        {
            //when creating new game
            //1.create game
            var newGame = _mjGameAppService.CreateMjGame(input);

            //2.create initial game session
            var currentUser = _userRepository.Get(AbpSession.GetUserId());
            var session = new CreateMjGameSessionInput
            {
                MjGameId = newGame.Id,
                GameNo = 1,
                Wind = MjGameWind.East,
            };

            //session.Users.Add(currentUser);
            var newSession = _mjGameAppService.CreateMjGameSession(session);

            newGame.ActiveSessionId = newSession.Id;

            //3.if everything worked out, add game creator to this session
            Groups.Add(Context.ConnectionId, newSession.Id.ToString());
        }

        public void SendMessage(string message)
        {
            Clients.All.getMessage(string.Format("User {0}: {1}", AbpSession.UserId, message));
        }

        public void JoinGame(MjGame game)
        {
            var user = _userRepository.Get(AbpSession.GetUserId());
            if (!game.ActiveSessionId.HasValue)
            {
                throw new Exception("Unable to find game session");
            }
            _mjGameAppService.AddUserToSession(new AddUserToSessionInput {
                GameSessionId = game.ActiveSessionId.Value,
                User = user
            });
            Groups.Add(Context.ConnectionId, game.ActiveSessionId.ToString());
        }       

        [UnitOfWork]
        public async override Task OnConnected()
        {
            await base.OnConnected();
            var user = _userRepository.Get(AbpSession.GetUserId());

            if (user != null)
            {
                user.SrConnections.Add(new MjSignalRConnection
                {
                    ConnectionId = Context.ConnectionId,
                    Connected = true,
                    UserAgent = Context.Request.Headers["User-Agent"]
                });

                foreach (var session in user.MjGameSessions)
                {
                    await Groups.Add(Context.ConnectionId, session.Id.ToString());
                }
            }

            _userRepository.Update(user);
            
            Logger.Debug("A client connected to MyChatHub: " + Context.ConnectionId);
        }

        public async override Task OnDisconnected(bool stopCalled)
        {
            var conn = _connectionRepository.Single(c => c.ConnectionId == Context.ConnectionId);
            conn.Connected = false;

            _connectionRepository.Update(conn);

            await base.OnDisconnected(stopCalled);
            Logger.Debug("A client disconnected from MyChatHub: " + Context.ConnectionId);
        }
    }
}
