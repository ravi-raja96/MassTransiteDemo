using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using OrderService.Entity;
using Model;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IPublishEndpoint _ipublishEndpoint;

        public FileUploadController(IPublishEndpoint ipublishEndpoint)
        {
            _ipublishEndpoint = ipublishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var Datas = new FileUpload();
            Datas.FileByte = ms.ToArray();
            Datas.FileName = file.FileName;
            //Datas.FormFile = file.CopyToAsync(Data/files);
            await _ipublishEndpoint.Publish(Datas);
            return Ok();
        }
    }
}