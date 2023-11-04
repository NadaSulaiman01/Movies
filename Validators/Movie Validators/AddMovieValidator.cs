namespace Movies.Validators.Movie_Validators
{
    public class AddMovieValidator : AbstractValidator<AddMovieDTO>
    {
        public AddMovieValidator() {


            RuleFor(m => m.Title)
                .NotNull().WithMessage("Review body is null")
                .NotEmpty().WithMessage("Review body is empty")
                .MinimumLength(1).WithMessage("Min length is 1 character.")
                .MaximumLength(100).WithMessage("Max length is 100 character.");

            RuleFor(m => m.GenreId)
                .NotNull().WithMessage("Genre Id is null")
                .NotEmpty().WithMessage("Genre Id is empty")
                .Must(m => m > 0).WithMessage("Genre Id must be greater than 0");

            RuleFor(m => m.Description)
                .NotNull().WithMessage("Review body is null")
                .NotEmpty().WithMessage("Review body is empty")
                .MinimumLength(1).WithMessage("Min length is 1 character.");

            RuleFor(m => m.Rating)
                .NotNull().WithMessage("Rating is null")
                .NotEmpty().WithMessage("Rating is empty")
                .Must(m => m > 0 && m <= 5).WithMessage("Rating must be 1-5");

            RuleFor(m => m.ReleaseDate)
                .NotNull().WithMessage("Year is null")
                .NotEmpty().WithMessage("Year is empty")
                .Must(m => m >= 1800).WithMessage("Year must be after 1800");


        }
    }
}
