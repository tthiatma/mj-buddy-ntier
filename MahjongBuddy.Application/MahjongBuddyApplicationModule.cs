using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using MahjongBuddy.Game;
using MahjongBuddy.MjGames.Dto;

namespace MahjongBuddy
{
    [DependsOn(typeof(MahjongBuddyCoreModule), typeof(AbpAutoMapperModule))]
    public class MahjongBuddyApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()
                mapper.CreateMap<MjGameSession, MjGameSessionDto>()
                .ForMember(dest => dest.TotalPlayers, opt => opt.MapFrom(src => src.Users.Count));

                mapper.CreateMap<MjGame, MjGameDto>()
                .ForMember(dest => dest.TotalPlayers, opt => opt.MapFrom(src => src.Users.Count));
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
