using FluentValidation;

namespace Movies.Validators.Review_Validators
{
    public class EditReviewValidator : AbstractValidator<EditReviewDTO>
    {
        public EditReviewValidator()
        {
            RuleFor(r => r.Content)
                .NotNull().WithMessage("Review body is null")
                .NotEmpty().WithMessage("Review body is empty");
        }
    }
}
