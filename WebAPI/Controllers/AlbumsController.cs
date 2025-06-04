using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        IAlbumService _albumService;
        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        [HttpGet("getallalbums")]
        public IActionResult GetAllAlbums()
        {
            var result = _albumService.GetAllAlbums();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyalbumid")]
        public IActionResult GetByAlbumId(int id)
        {
            var result = _albumService.GetByAlbumId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult AddAlbum(Album album)
        {
            var result = _albumService.AddAlbum(album);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete]
        public IActionResult DeleteAlbum(int id)
        {
            var result = _albumService.DeleteAlbum(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut]
        public IActionResult UpdateAlbum(Album album)
        {
            var result = _albumService.UpdateAlbum(album);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
