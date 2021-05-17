using System;
using Microsoft.AspNetCore.Http;

namespace OrderService.Entity
{
    public class FileUpload
    {
        public IFormFile Document { get; set; }
    }
}
