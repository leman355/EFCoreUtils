using AutoMapper;
using EFCoreUtils.Business.DTO.MusicBandDtos;
using EFCoreUtils.Business.DTO.MusicianDtos;
using EFCoreUtils.Entities;

namespace EFCoreUtils.Business.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MusicianToAddDto, Musician>();
            CreateMap<Musician, MusicianToAddDto>();
            CreateMap<Musician, MusicianToListDto>();
            CreateMap<MusicianToUpdateDto, Musician>();
            CreateMap<Musician, MusicianToUpdateDto>();
            CreateMap<Musician, ShortMusicianToListDto>();

            CreateMap<MusicBandToAddDto, MusicBand>();
            CreateMap<MusicBand, MusicBandToAddDto>();
            CreateMap<MusicBand, MusicBandToListDto>();
            CreateMap<MusicBandToUpdateDto, MusicBand>();
            CreateMap<MusicBand, MusicBandToUpdateDto>();
            CreateMap<MusicBand, ShortMusicBandToListDto>();
        }
    }
}
