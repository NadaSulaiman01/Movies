using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Movies.DTOs.AuthDTOs;
using Movies.Validators.Auth_Validators;

namespace Movies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IValidator<AddReviewDTO> _addReviewValidator;
        private readonly IValidator<EditReviewDTO> _editReviewValidator;

        public ReviewsController(IReviewService reviewService, IValidator<AddReviewDTO> addReviewValidator, IValidator<EditReviewDTO> editReviewValidator)
        {
            _reviewService = reviewService;
            _addReviewValidator = addReviewValidator;
            _editReviewValidator = editReviewValidator;
        }

        [Authorize(Roles = AppRolesConstants.User)]
        [HttpPost("AddReview")]
        public async Task<ActionResult<ServiceResponse<ReviewDTO>>> AddReview(AddReviewDTO dto)
        {
            //var responseWithoutData = new ServiceResponseWithoutData();
            var validationResult = _addReviewValidator.Validate(dto);

            // Check if the validation failed
            if (!validationResult.IsValid)
            {
                string errorMessage = string.Join(", ", validationResult.Errors);


                var validationResponse = new ServiceResponseWithoutData
                {
                    Success = false,
                    Message = errorMessage
                };

                return Ok(validationResponse);
            }

            var response = await _reviewService.AddReview(dto);
            return Ok(response);

        }

        [Authorize(Roles = AppRolesConstants.User)]
        [HttpPut("EditReview")]
        public async Task<ActionResult<ServiceResponse<ReviewDTO>>> EditReview(int reviewId, [FromBody] EditReviewDTO dto)
        {
            var validationResult = _editReviewValidator.Validate(dto);

            // Check if the validation failed
            if (!validationResult.IsValid)
            {
                string errorMessage = string.Join(", ", validationResult.Errors);


                var validationResponse = new ServiceResponseWithoutData
                {
                    Success = false,
                    Message = errorMessage
                };

                return Ok(validationResponse);
            }

            var response = await _reviewService.EditReview(reviewId,dto);
            return Ok(response);

        }

        [Authorize(Roles = AppRolesConstants.User)]
        [HttpDelete("DeleteReview")]
        public async Task<ActionResult<ServiceResponse<ReviewDTO>>> DeleteReview(int reviewId)
        {

            var response = await _reviewService.DeleteReview(reviewId);
            return Ok(response);

        }
    }
}
