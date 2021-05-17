using System;
using Microsoft.AspNetCore.Http;
namespace Model
{
    public class FileUpload 
    {
        //public IFormFile FormFile { get; set; }
        public byte[] FileByte { get; set; }
        public string FileName { get; set; }
    }
}
