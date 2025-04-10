using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Company.Service.Helper
{
    public class DocumentSettings
    {
        public static String UploadFile(IFormFile file, string FolderName)
        {
            var FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files", FolderName);

            var FileName = $"{Guid.NewGuid}-{file.FileName}";

            var FilePath = Path.Combine(FolderPath, FileName);

            using var FileStream = new FileStream(FilePath, FileMode.Create);

            file.CopyTo(FileStream);

            return FileName;
        }
    }
}
