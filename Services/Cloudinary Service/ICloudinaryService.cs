using CloudinaryDotNet.Actions;

namespace Movies.Services.Cloudinary_Service
{
    public interface ICloudinaryService
    {
        Task<ImageUploadResult> UploadMovieImageAsync(IFormFile imageFile, string MovieName, int MovieGenreId);
        Task<DeletionResult> DeleteImageAsync(string fullImagePath);
    }
}
