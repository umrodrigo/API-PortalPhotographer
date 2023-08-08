using Api.Models;

namespace Api.Services
{
    public interface IStorageService
    {
        Task<string> SaveImageAsync(FileData imageFile);
        Task<byte[]> LoadImageAsync(string fileName);
        bool DeleteImage(string fileName);
    }

    public class StorageService : IStorageService
    {
        private readonly string _imageFolderPath;

        public StorageService(IWebHostEnvironment webHostEnvironment)
        {
            _imageFolderPath = Path.Combine(webHostEnvironment.ContentRootPath, "Images");
        }

        public async Task<string> SaveImageAsync(FileData imageFile)
        {
            if (imageFile == null || imageFile.File.Length <= 0)
                throw new ArgumentException("Imagem inválida ou vazia.");

            var fileName = Guid.NewGuid().ToString("N").Substring(0, 10) + "." + imageFile.Extension;

            var imagePath = Path.Combine(_imageFolderPath, fileName);

            // Salve a imagem no disco
            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.File.CopyToAsync(stream);
            }

            return fileName;
        }

        public async Task<byte[]> LoadImageAsync(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("Nome do arquivo inválido.");

            var imagePath = Path.Combine(_imageFolderPath, fileName);

            if (!File.Exists(imagePath))
                throw new FileNotFoundException("Arquivo não encontrado.", imagePath);

            return await File.ReadAllBytesAsync(imagePath);
        }

        public bool DeleteImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("Nome do arquivo inválido.");

            var imagePath = Path.Combine(_imageFolderPath, fileName);

            if (!File.Exists(imagePath))
                return false;
            
            File.Delete(imagePath);

            return true;
        }
    }
}
