using Microsoft.AspNetCore.Http;

namespace E_commerceAPI.Application.Abstractions.Services
{
    public interface IFileHelper
    {
        Task<List<(string fileName, string path)>> UploadFileAsync(string pathName, IFormFileCollection files);
        List<string> GetFiles(string pathName);
        bool HasFile(string fileName, string pathName);
        void DeleteFile(string fileName, string pathName);
    }
}
