using AutoMapper;
using EFCoreUtils.Business.Abstract;
using EFCoreUtils.Business.DTO.MusicianDtos;
using EFCoreUtils.DataAccess.Abstract;
using EFCoreUtils.Entities;

namespace EFCoreUtils.Business.Concrete
{
    public class MusicianManager : IMusicianService
    {
        private readonly IMusicianRepository _musicianRepository;
        private readonly IMapper _mapper;

        public MusicianManager(IMusicianRepository musicianRepository, IMapper mapper)
        {
            _musicianRepository = musicianRepository;
            _mapper = mapper;
        }

        public async Task<List<MusicianToListDto>> GetAllMusicians()
        {
            var musicians = await _musicianRepository.GetAllMusicians();
            return _mapper.Map<List<MusicianToListDto>>(musicians);
        }

        public async Task<MusicianToListDto> GetMusicianById(int musicianId)
        {
            var musician = await _musicianRepository.GetMusicianById(musicianId);
            return _mapper.Map<MusicianToListDto>(musician);
        }

        public async Task<MusicianToAddDto> CreateMusician(MusicianToAddDto musician)
        {
            var musicianEntity = _mapper.Map<Musician>(musician);
            var createdMusician = await _musicianRepository.CreateMusician(musicianEntity);
            return _mapper.Map<MusicianToAddDto>(createdMusician);
        }

        public async Task<MusicianToUpdateDto> UpdateMusician(int musicianId, MusicianToUpdateDto musician)
        {
            var existingMusician = await _musicianRepository.GetMusicianById(musicianId);
            _mapper.Map(musician, existingMusician);

            var updatedMusician = await _musicianRepository.UpdateMusician(existingMusician);
            return _mapper.Map<MusicianToUpdateDto>(updatedMusician);
        }

        public async Task DeleteMusicianById(int musicianId)
        {
            await _musicianRepository.DeleteMusicianById(musicianId);
        }

        public async Task<List<MusicianToListDto>> GetMusicBandByMusicianId(int musicianId)
        {
            var musicians = await _musicianRepository.GetMusicBandByMusicianId(musicianId);
            return _mapper.Map<List<MusicianToListDto>>(musicians);
        }

        //IQueryable
        public IQueryable<MusicianToListDto> GetAllMusiciansQuery()
        {
            return _musicianRepository.GetAllMusiciansQuery().Select(m => _mapper.Map<MusicianToListDto>(m));
        }

        public IQueryable<MusicianToListDto> GetMusicBandByMusicianIdQuery(int musicianId)
        {
            return _musicianRepository.GetMusicBandByMusicianIdQuery(musicianId).Select(m => _mapper.Map<MusicianToListDto>(m));
        }
    }
}
