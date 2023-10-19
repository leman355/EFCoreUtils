using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using EFCoreUtils.Business.Abstract;
using EFCoreUtils.Business.DTO.MusicianDtos;

namespace EFCoreUtils.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicianController : Controller
    {
        private readonly IMusicianService _musicianService;

        public MusicianController(IMusicianService musicianService)
        {
            _musicianService = musicianService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all musicians")]
        public async Task<IActionResult> GetAllMusicians()
        {
            var musicians = await _musicianService.GetAllMusicians();
            return Ok(musicians);
        }

        [HttpGet("{musicianId}")]
        [SwaggerOperation(Summary = "Get a musician by ID")]
        public async Task<IActionResult> GetMusicianById(int musicianId)
        {
            var musician = await _musicianService.GetMusicianById(musicianId);
            if (musician == null)
            {
                return NotFound();
            }

            return Ok(musician);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new musician")]
        public async Task<IActionResult> CreateMusician([FromBody] MusicianToAddDto dto)
        {
            var musician = await _musicianService.CreateMusician(dto);
            if (musician != null)
            {
                return Ok(musician);
            }
            else
            {
                return BadRequest("Failed to create musician");
            }
        }

        [HttpPut("{musicianId}")]
        [SwaggerOperation(Summary = "Update a musician")]
        public async Task<IActionResult> UpdateMusician(int musicianId, [FromBody] MusicianToUpdateDto dto)
        {
            var updatedMusician = await _musicianService.UpdateMusician(musicianId, dto);
            if (updatedMusician == null)
            {
                return NotFound();
            }

            return Ok(updatedMusician);
        }

        [HttpDelete("{musicianId}")]
        [SwaggerOperation(Summary = "Delete a musician by ID")]
        public async Task<IActionResult> DeleteMusicianById(int musicianId)
        {
            await _musicianService.DeleteMusicianById(musicianId);
            return NoContent();
        }

        [HttpGet("{musicianId}/musicbands")]
        [SwaggerOperation(Summary = "Get music bands by musician ID")]
        public async Task<IActionResult> GetMusicBandByMusicianId(int musicianId)
        {
            var musicBands = await _musicianService.GetMusicBandByMusicianId(musicianId);
            return Ok(musicBands);
        }

        //IQueryable
        [HttpGet("query")]
        [SwaggerOperation(Summary = "Get all musicians using IQueryable")]
        public IActionResult GetAllMusiciansQuery()
        {
            var musiciansQuery = _musicianService.GetAllMusiciansQuery();
            var musicians = musiciansQuery.ToList();
            return Ok(musicians);
        }

        [HttpGet("{musicianId}/musicbands/query")]
        [SwaggerOperation(Summary = "Get music bands by musician ID using IQueryable")]
        public IActionResult GetMusicBandByMusicianIdQuery(int musicianId)
        {
            var musicBandsQuery = _musicianService.GetMusicBandByMusicianIdQuery(musicianId);
            var musicBands = musicBandsQuery.ToList();
            return Ok(musicBands);
        }
    }
}
