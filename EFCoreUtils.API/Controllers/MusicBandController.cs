using EFCoreUtils.Business.Abstract;
using EFCoreUtils.Business.DTO.MusicBandDtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EFCoreUtils.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicBandController : Controller
    {
        private readonly IMusicBandService   _musicBandService;

        public MusicBandController(IMusicBandService musicBandService)
        {
            _musicBandService = musicBandService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all music bands")]
        public async Task<IActionResult> GetAllMusicBands()
        {
            var musicBands = await _musicBandService.GetAllMusicBands();
            return Ok(musicBands);
        }

        [HttpGet("{musicBandId}")]
        [SwaggerOperation(Summary = "Get a music band by ID")]
        public async Task<IActionResult> GetMusicBandById(int musicBandId)
        {
            var musicBand = await _musicBandService.GetMusicBandById(musicBandId);
            if (musicBand == null)
            {
                return NotFound();
            }

            return Ok(musicBand);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new music band")]
        public async Task<IActionResult> CreateMusicBand([FromBody] MusicBandToAddDto dto)
        {
            var musicBand = await _musicBandService.CreateMusicBand(dto);
            if (musicBand != null)
            {
                return Ok(musicBand);
            }
            else
            {
                return BadRequest("Failed to create music band");
            }
        }

        [HttpPut("{musicBandId}")]
        [SwaggerOperation(Summary = "Update a music band")]
        public async Task<IActionResult> UpdateMusicBand(int musicBandId, [FromBody] MusicBandToUpdateDto dto)
        {
            var updatedMusicBand = await _musicBandService.UpdateMusicBand(dto);
            if (updatedMusicBand == null)
            {
                return NotFound();
            }

            return Ok(updatedMusicBand);
        }

        [HttpDelete("{musicBandId}")]
        [SwaggerOperation(Summary = "Delete a music band by ID")]
        public async Task<IActionResult> DeleteMusicBandById(int musicBandId)
        {
            await _musicBandService.DeleteMusicBandById(musicBandId);
            return NoContent();
        }

        [HttpGet("{musicBandId}/musicians")]
        [SwaggerOperation(Summary = "Get musicians by music band ID")]
        public async Task<IActionResult> GetMusiciansByMusicBandId(int musicBandId)
        {
            var musicians = await _musicBandService.GetMusiciansByMusicBandId(musicBandId);
            return Ok(musicians);
        }
    }
}
