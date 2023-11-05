namespace Movies.Services.Reviews_Service
{
    public interface IReviewService
    {
        Task<ServiceResponse<ReviewDTO>> AddReview(AddReviewDTO dto);
        Task<ServiceResponse<ReviewDTO>> EditReview(int reviewId, EditReviewDTO dto);
        Task<ServiceResponseWithoutData> DeleteReview(int reviewId);
        Task<ServiceResponseWithoutData> DeleteReviewByAdmin(int reviewId);

    }
}
