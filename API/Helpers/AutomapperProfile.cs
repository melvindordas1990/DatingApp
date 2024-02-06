
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace API.Helpers
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<AppUser,MemberDTO>()
             .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
             .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo,PhotoDTO>();
            CreateMap<MemberUpdateDTO,AppUser>();
            CreateMap<RegisterDTO,AppUser>();
            CreateMap<Message,MessageDto>()
              .ForMember(d => d.SenderPhotoUrl, o=> o.MapFrom(s=> s.Sender.Photos
              .FirstOrDefault(x => x.IsMain).Url))
               .ForMember(d => d.RecipientPhotoUrl, o=> o.MapFrom(s=> s.Recipient.Photos
              .FirstOrDefault(x => x.IsMain).Url));
        }
    }
}