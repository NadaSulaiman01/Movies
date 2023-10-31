using Microsoft.AspNetCore.Identity;
using Movies.DTOs.ReviewsDTOs;
using Movies.Models;
using System.Security.Claims;

namespace Movies.Services.Reviews_Service
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _usermanager;

        public ReviewService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
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
            var user = await _usermanager.FindByIdAsync(GetUserId());

            if (user is null)
            {
                response.Success = false;
                response.Message = "Non Users can't add a review!";
                return response;
            }

            var movie = await _context.Movies.SingleOrDefaultAsync(m => m.MovieId == dto.MovieId);
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

            await _context.AddAsync(review);

            await _context.SaveChangesAsync();

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

            var review = await _context.Reviews.SingleOrDefaultAsync(r => r.ReviewId == reviewId);

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

            await _context.SaveChangesAsync();

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



            var review = await _context.Reviews.SingleOrDefaultAsync(r => r.ReviewId == reviewId);

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

           
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            response.Success = true;
            response.Message = "Review was deleted successfuly!";
            return response;

        }
    }
}
