using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using AutoMapper;
using MahjongBuddy.Game;
using MahjongBuddy.MjGames.Dto;

namespace MahjongBuddy
{
    [DependsOn(typeof(MahjongBuddyCoreModule), typeof(AbpAutoMapperModule))]
    public class MahjongBuddyApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public override void PostInitialize()
        {
            base.PostInitialize();
            Mapper.CreateMap<MjGame, MjGameDto>()
                .ForMember(dest => dest.TotalPlayers, opt => opt.MapFrom(src => src.Users.Count));
        }
    }
}
