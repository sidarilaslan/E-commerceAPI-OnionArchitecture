using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using E_commerceAPI.Application.Abstractions.Services;

namespace E_commerceAPI.Infrastructure.Services
{

    public class FileHelper : IFileHelper
    {
        public IWebHostEnvironment _webHostEnvironment;

        public FileHelper(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public void DeleteFile(string fileName, string pathName)
        => File.Delete($"{pathName}\\{fileName}");

        public List<string> GetFiles(string pathName)
        {
            DirectoryInfo directoryInfo = new(pathName);
            return directoryInfo.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string fileName, string pathName)
       => File.Exists($"{pathName}\\{fileName}");

        public async Task<List<(string fileName, string path)>> UploadFileAsync(string pathName, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, pathName);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<(string fileName, string path)> datas = new();

            foreach (IFormFile file in files)
            {
                string fileNewName = FileRename(file.FileName);
               await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                datas.Add((fileNewName, $"{uploadPath}\\{fileNewName}"));
            }

            return datas;
        }

        private string FileRename(string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string oldName = Path.GetFileNameWithoutExtension(fileName);
            string dateTimeNowUtc = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            string newFileName = $"{dateTimeNowUtc}-{oldName}{extension}";
            return newFileName;
        }
        private async Task<bool> CopyFileAsync(string pathName, IFormFile file)
        {

            await using FileStream fileStream = new(pathName, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
            return true;

        }
    }

}
