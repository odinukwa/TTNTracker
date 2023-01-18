using AutoMapper;
using TTN_DDOI.Model;
using TTN_Tracker.Features.Dto;

namespace TTN_Tracker.Profiles
{
    public class UserProfileProfile : Profile
    {
        public UserProfileProfile()
        {
            //CreateMap<AcpAchOffsetAccountExt, AchOffsetAccountReadDto>();
            // CreateMap<UplinkMessageCreateDto, UplinkMessageCreateDto>();
            CreateMap<UserProfileGetDto, UserProfile>().ReverseMap();

        }

    }
}