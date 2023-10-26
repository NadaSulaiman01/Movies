using CloudinaryDotNet.Actions;

namespace Movies.Services.Cloudinary_Service
{
    public interface ICloudinaryService
    {
        Task<ImageUploadResult> UploadMovieImageAsync(IFormFile imageFile, string MovieName, string MovieGenre);
        Task<DeletionResult> DeleteImageAsync(string fullImagePath);
    }
}
