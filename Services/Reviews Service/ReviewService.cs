using Microsoft.AspNetCore.Identity;
using Movies.DTOs.ReviewsDTOs;
using Movies.Models;
using System.Security.Claims;

namespace Movies.Services.Reviews_Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _usermanager;

        public ReviewService(IReviewRepository reviewRepository, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> usermanager)
        {
            _reviewRepository = reviewRepository;
            _httpContextAccessor = httpContextAccessor;
            _usermanager = usermanager;
        }

        /*function to get the current userId if it exist */
        private String GetUserId() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

        public async Task<ServiceResponse<ReviewDTO>> AddReview(AddReviewDTO dto)
        {
            //throw new NotImplementedException();
            var response = new ServiceResponse<ReviewDTO>();

            //check if the current user is registered in the database
            //Console.WriteLine(GetUserId());
            var user = await _usermanager.FindByIdAsync(GetUserId());

            if (user is null)
            {
                response.Success = false;
                response.Message = "Non Users can't add a review!";
                return response;
            }

            var movie = await _reviewRepository.Movies.SingleOrDefaultAsync(m => m.MovieId == dto.MovieId);
            if (movie is null)
            {
                response.Success = false;
                response.Message = "No movie was found with this id!";
                return response;
            }


            var review = new Review
            {
                MovieId = dto.MovieId,
                UserId = user.Id,
                Content = dto.Content,
                TimeCreated = DateTime.UtcNow

            };

            await _reviewRepository.AddReviewAsync(review);

            await _reviewRepository.SaveChangesAsync();

            response.Data = new ReviewDTO
            {
                ReviewId = review.ReviewId,
                Content = review.Content,
                TimeCreated = DateExtractor.FormatConverter(review.TimeCreated),
                UserId = review.UserId,
                MovieId = review.MovieId,
                UserName = user.UserName
            };

            response.Success = true;
            response.Message = "Review was added successfully";
            return response;


        }

        public async Task<ServiceResponse<ReviewDTO>> EditReview(int reviewId, EditReviewDTO dto)
        {
            ServiceResponse<ReviewDTO> response = new ServiceResponse<ReviewDTO>();

            //check if the current user is registered in the database
            var user = await _usermanager.FindByIdAsync(GetUserId());

            if (user is null)
            {
                response.Success = false;
                response.Message = "User wasn't found!";
                return response;
            }

            var review = await _reviewRepository.Reviews.SingleOrDefaultAsync(r => r.ReviewId == reviewId);

            if (review == null)
            {
                response.Success = false;
                response.Message = "No Review was found with this id!";
                return response;
            }

            if (review.UserId != user.Id)
            {
                response.Success = false;
                response.Message = "Only the Review writer could edit the review!";
                return response;
            }

            review.Content = dto.Content;

            await _reviewRepository.SaveChangesAsync();

            response.Data = new ReviewDTO
            {
                ReviewId = review.ReviewId,
                Content = review.Content,
                TimeCreated = DateExtractor.FormatConverter(review.TimeCreated),
                UserId = review.UserId,
                MovieId = review.MovieId,
                UserName = user.UserName
            };

            response.Success = true;
            response.Message = "Review was changed successfully";
            return response;
        }

        public async Task<ServiceResponseWithoutData> DeleteReview(int reviewId)
        {
            var response = new ServiceResponseWithoutData();

            //check if the current user is registered in the database
            var user = await _usermanager.FindByIdAsync(GetUserId());
            

            if (user is null)
            {
                response.Success = false;
                response.Message = "user wasn't found!";
                return response;
            }



            var review = await _reviewRepository.Reviews.SingleOrDefaultAsync(r => r.ReviewId == reviewId);

            if (review is null)
            {
                response.Success = false;
                response.Message = "No Review was found with this id!";
                return response;
            }

            if (review.UserId != user.Id)
            {
                response.Success = false;
                response.Message = "Only the Review writer could delete the review!";
                return response;
            }

           
            await _reviewRepository.RemoveReviewAsync(review);
            await _reviewRepository.SaveChangesAsync();

            response.Success = true;
            response.Message = "Review was deleted successfuly!";
            return response;

        }

        public async Task<ServiceResponseWithoutData> DeleteReviewByAdmin(int reviewId)
        {
            //throw new NotImplementedException();
            var response = new ServiceResponseWithoutData();

            //check if the current user is registered in the database
            var user = await _usermanager.FindByIdAsync(GetUserId());


            if (user is null)
            {
                response.Success = false;
                response.Message = "user wasn't found!";
                return response;
            }


            var role = "User";
            var userRole = await _usermanager.IsInRoleAsync(user, AppRolesConstants.Admin);
            if (userRole)
            {
                role = AppRolesConstants.Admin;

            } else
            {
                response.Success = false;
                response.Message = "You are unothorized to do this action";
                return response;

            }



            var review = await _reviewRepository.Reviews.SingleOrDefaultAsync(r => r.ReviewId == reviewId);

            if (review is null)
            {
                response.Success = false;
                response.Message = "No Review was found with this id!";
                return response;
            }


            await _reviewRepository.RemoveReviewAsync(review);
            await _reviewRepository.SaveChangesAsync();

            response.Success = true;
            response.Message = "Review was deleted successfuly!";
            return response;
        }
    }
}
