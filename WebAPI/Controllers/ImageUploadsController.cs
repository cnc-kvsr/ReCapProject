using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Images;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadsController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        public ImageUploadsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

       

        [HttpPost]
        public string Post([FromForm]ImageUpload objectFile)
        {
            try
            {
                if (objectFile.images.Length>0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                   
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream=System.IO.File.Create(path + objectFile.images.FileName))
                    {
                        objectFile.images.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Uploaded.";
                    }
                    
                }
                else
                {
                    return "Not Uploaded";
                }
            }
            catch (Exception)
            {
                return Messages.ImageNotAdded;
            }
        }
    }
}
