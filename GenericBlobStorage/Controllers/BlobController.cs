using GenericBlobStorage.IServices;
using GenericBlobStorage.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenericBlobStorage.Controllers
{
    public class BlobController : Controller
    {
        private readonly IUploadService _uploadService;

        public BlobController(IUploadService uploadService)
        {
            this._uploadService = uploadService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(UploadContentResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UploadContentResponse), StatusCodes.Status400BadRequest)]
        [Route("Section/Lecture/UploadContent")]
        public async Task<IActionResult> UploadContentAsync([FromForm] UploadContentRequest request, CancellationToken Token)
        {
            UploadContentResponse result = await this._uploadService.UploadContent(request, Token);
            return new OkObjectResult(result);
        }
    }
}
