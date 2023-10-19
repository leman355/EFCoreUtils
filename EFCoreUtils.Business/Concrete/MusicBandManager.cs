using AutoMapper;
using EFCoreUtils.Business.Abstract;
using EFCoreUtils.Business.DTO.MusicBandDtos;
using EFCoreUtils.Business.DTO.MusicianDtos;
using EFCoreUtils.DataAccess.Abstract;
using EFCoreUtils.Entities;

namespace EFCoreUtils.Business.Concrete
{
    public class MusicBandManager : IMusicBandService
    {
        private readonly IMusicBandRepository _musicBandRepository;
        private readonly IMapper _mapper;

        public MusicBandManager(IMusicBandRepository musicBandRepository, IMapper mapper)
        {
            _musicBandRepository = musicBandRepository;
            _mapper = mapper;
        }

        public async Task<List<MusicBandToListDto>> GetAllMusicBands()
        {
            var musicBands = await _musicBandRepository.GetAllMusicBands();
            return _mapper.Map<List<MusicBandToListDto>>(musicBands);
        }

        public async Task<MusicBandToListDto> GetMusicBandById(int musicBandId)
        {
            var musicBand = await _musicBandRepository.GetMusicBandById(musicBandId);
            return _mapper.Map<MusicBandToListDto>(musicBand);
        }

        public async Task<MusicBandToAddDto> CreateMusicBand(MusicBandToAddDto musicBand)
        {
            var musicBandEntity = _mapper.Map<MusicBand>(musicBand);
            var createdMusicBand = await _musicBandRepository.CreateMusicBand(musicBandEntity);
            return _mapper.Map<MusicBandToAddDto>(createdMusicBand);
        }

        public async Task<MusicBandToUpdateDto> UpdateMusicBand(MusicBandToUpdateDto musicBand)
        {
            var musicBandEntity = _mapper.Map<MusicBand>(musicBand);
            var updatedMusicBand = await _musicBandRepository.UpdateMusicBand(musicBandEntity);
            return _mapper.Map<MusicBandToUpdateDto>(updatedMusicBand);
        }

        public async Task DeleteMusicBandById(int musicBandId)
        {
            await _musicBandRepository.DeleteMusicBandById(musicBandId);
        }

        public async Task<MusicBandToListDto> GetMusiciansByMusicBandId(int musicBandId)
        {
            var musician = await _musicBandRepository.GetMusiciansByMusicBandId(musicBandId);
            return _mapper.Map<MusicBandToListDto>(musician);
        }
    }
}
