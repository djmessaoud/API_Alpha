using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    public class VideoController : Controller
    {
        private readonly VideoService _videoGenerationService;

        public VideoController(VideoService videoGenerationService)
        {
            _videoGenerationService = videoGenerationService;
        }

        [HttpGet("generate/{guid}")]
        public IActionResult GenerateVideo(string guid)
        {
            string videoFilePath = _videoGenerationService.GenerateVideo(guid);

            if (videoFilePath != null)
            {
                string downloadLink = $"{Request.Scheme}://{Request.Host}/api/video/download/{guid}";
                string sentence = $"{videoFilePath}";
                return Ok(new { DownloadLink = downloadLink,
                Sentence = sentence,
                Result="Success"});
            }
            else
            {
                return BadRequest("Failed to generate video.");
            }
        }

        [HttpGet("download/{guid}")]
        public IActionResult DownloadVideo(string guid)
        {
            string videoFilePath = _videoGenerationService.GenerateVideo(guid);

            if (videoFilePath != null)
            {
                return PhysicalFile(videoFilePath, "application/octet-stream", enableRangeProcessing: true);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
