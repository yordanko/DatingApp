using API.Helpers;
using API.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        public CloudinaryService(CloudinarySettings config)
        {
            var acc = new Account() { ApiKey = config.ApiKey, ApiSecret = config.ApiSecret, Cloud = config.CloudName };
            _cloudinary = new Cloudinary(acc);
        }
       

        public async Task<DeletionResult> DeleteFileAsync(string publicId)
        {
            var deletion = new DeletionParams(publicId);
            return await _cloudinary.DestroyAsync(deletion);
        }

        public async Task<ImageUploadResult> UploadFileAsync(IFileInfo file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.CreateReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.PhysicalPath, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            

            return uploadResult;
        }
    }
}
