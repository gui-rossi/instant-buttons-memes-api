using AutoMapper;
using Domains.Entities;
using Domains.VM;

namespace WebAPI.Configs
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            // Create your mappings here
            CreateMap<Button, ButtonVM>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => SplitName(src.Name)))
            ;
        }

        private string SplitName(string soundName)
        {
            return Path.GetFileNameWithoutExtension(soundName);
        }
    }
}
