using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        ITrackService _trackService;
        public TracksController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet("getalltracks")]
        public IActionResult GetAllTracks()
        {
            var result = _trackService.GetAllTracks();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("gettrackbyid")]
        public IActionResult GetTracksById(int id)
        {
            var result = _trackService.GetByTrackId(id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("gettrackbyms")]
        public IActionResult GetTracksByMiliseconds(int min, int max)
        {
            var result = _trackService.GetTracksByMiliseconds(min, max);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult AddTrack(Track track)
        {
            var result = _trackService.AddTrack(track);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult UpdateTrack(Track track)
        {
            var result = _trackService.UpdateTrack(track);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete]
        public IActionResult DeleteTrack(int id)
        {
            var result = _trackService.DeleteTrack(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
