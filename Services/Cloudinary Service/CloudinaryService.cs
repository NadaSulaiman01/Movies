using CloudinaryDotNet.Actions;
using CloudinaryDotNet;
using System.Globalization;

namespace Movies.Services.Cloudinary_Service
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinarySerive;

        #region public methods
        public CloudinaryService()
        {
            _cloudinarySerive = new Cloudinary(new Account
            {
                Cloud = CloudinarySettings.CloudName,
                ApiKey = CloudinarySettings.ApiKey,
                ApiSecret = CloudinarySettings.ApiSecret


            });
            _cloudinarySerive.Api.Secure = true;
        }



        public async Task<ImageUploadResult> UploadMovieImageAsync(IFormFile imageFile, string MovieName, int MovieGenreId)
        {
            var imageUploadResult = new ImageUploadResult();
            if (imageFile.Length > 0)
            {
                string folderName;
                using var imageStream = imageFile.OpenReadStream();
                if (MovieGenreId < 100) {
                    folderName = "Poster";
                } else
                {
                    folderName = "Cast";
                }

                
                var imageUploadParams = new ImageUploadParams
                {
                    
                    File = new FileDescription(MovieName, imageStream),
                    PublicId = GetImagePublicId() + "_" + MovieName.Replace(' ', '_'),
                    Folder = GetFolderPathForMovies(MovieGenreId, folderName),
                    Transformation = new Transformation().Height(155).Width(235).Crop("scale"),

                };
                imageUploadResult = await _cloudinarySerive.UploadAsync(imageUploadParams);
               

            }

            return imageUploadResult;

        }

        public async Task<DeletionResult> DeleteImageAsync(string fullImagePath)
        {
            var imageDeletionParams = new DeletionParams(fullImagePath);
            var deletionResult = await _cloudinarySerive.DestroyAsync(imageDeletionParams);
            return deletionResult;
        }


        #endregion


        #region private methods

        private string GetImagePublicId()
        {
            DateTime current_time = DateTime.Now;
            CultureInfo ci = new CultureInfo("en-US");
            return current_time.ToString("dd_MMMM_yyyy_hh_mm_ss_tt", ci);


        }
        private string GetFolderPathForMovies(int MovieGenreId, string folderName) => $"Movies/{folderName}/" + MovieGenreId;



        #endregion
    }
}
