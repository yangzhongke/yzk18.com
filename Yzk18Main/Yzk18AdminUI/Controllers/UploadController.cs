using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UpYun.NETCore;
using Yzk18AdminUI.Options;
using Zack.Commons;

namespace Yzk18AdminUI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles ="admin")]
    public class UploadController : ControllerBase
    {
        private readonly IOptionsSnapshot<FileServiceOptions> optionFileSerivce;
        private readonly IHttpClientFactory httpClientFactory;

        public UploadController(IOptionsSnapshot<FileServiceOptions> optionFileSerivce, IHttpClientFactory httpClientFactory)
        {
            this.optionFileSerivce = optionFileSerivce;
            this.httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public string AA()
        { 
            return "xxx";
        }

        [HttpPost]
        public async Task<ActionResult<string>> UploadImage(IFormFile file)
        {
            //var a = HttpContext.Request.Body.ToArray();
            //IFormFile file = null;
            string extName = Path.GetExtension(file.FileName).ToLower();
            if (extName != ".jpeg" && extName != ".jpg" && extName != ".png")
            {
                return BadRequest("只允许jpg、png");
            }
            using MemoryStream memStream = new MemoryStream();
            using var srcStream = file.OpenReadStream();
            await srcStream.CopyToAsync(memStream);
            memStream.Position = 0;
            string fileHash = HashHelper.ComputeMd5Hash(memStream);
            memStream.Position = 0;
            string dateDir = DateTime.Today.Year + "/" + DateTime.Today.Month + "/" + DateTime.Today.Day;
            string relativeImgPath = $"/yzk18/images/{dateDir}/{fileHash}{extName}";
            var upyunOpt = optionFileSerivce.Value;
            UpYunClient upyun = new UpYunClient(upyunOpt.BucketName, upyunOpt.UserName,
                upyunOpt.Password, httpClientFactory);
            var r = await upyun.WriteFileAsync(relativeImgPath, await memStream.ToArrayAsync(), true);
            if(!r.IsOK)
            {
                return BadRequest("上传到Upyun失败");
            }
            return upyunOpt.RootUrl + "/" + relativeImgPath;
        }
    }
}
