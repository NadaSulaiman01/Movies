using FluentValidation;


namespace Movies.Validators.Review_Validators
{
    public class AddReviewValidator : AbstractValidator<AddReviewDTO>
    {
        public AddReviewValidator()
        {
            RuleFor(r => r.Content)
                .NotNull().WithMessage("Review body is null")
                .NotEmpty().WithMessage("Review body is empty");

            RuleFor(r => r.MovieId)
                .NotNull().WithMessage("Movie Id is null")
                .NotEmpty().WithMessage("Movie Id is empty")
                .Must(m => m > 0).WithMessage("Movie Id must be greater than 0");

        }
    }
}
