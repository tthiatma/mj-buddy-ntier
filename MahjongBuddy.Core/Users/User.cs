using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using MahjongBuddy.Connection;
using System.Collections.ObjectModel;
using MahjongBuddy.Game;
using System.ComponentModel.DataAnnotations.Schema;

namespace MahjongBuddy.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public virtual bool IsPlaying { get; set; }

        private ICollection<MjSignalRConnection> _srConnections;
        public virtual ICollection<MjSignalRConnection> SrConnections
        {
            get { return _srConnections ?? (_srConnections = new Collection<MjSignalRConnection>()); }
            set { _srConnections = value; }
        }

        private ICollection<MjGame> _mjGames;

        [InverseProperty("Users")]
        public virtual ICollection<MjGame> MjGames
        {
            get { return _mjGames ?? (_mjGames = new Collection<MjGame>()); }
            set { _mjGames = value; }
        }

        private ICollection<MjGameSession> _mjGameSessions;
        public virtual ICollection<MjGameSession> MjGameSessions
        {
            get { return _mjGameSessions ?? (_mjGameSessions = new Collection<MjGameSession>()); }
            set { _mjGameSessions = value; }
        }

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            return new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Password = new PasswordHasher().HashPassword(password)
            };
        }
    }
}