using CloudinaryDotNet.Actions;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface ICloudinaryService
    {
        Task<ImageUploadResult> UploadFileAsync(IFileInfo file);
        Task<DeletionResult> DeleteFileAsync(string publicId);
    }
}
