using FluentValidation;
using Movies.DTOs.AuthDTOs;

namespace Movies.Validators.Auth_Validators
{
    public class SignUpValidator : AbstractValidator<SignUpRequestDTO>
    {
        public SignUpValidator()
        {

            RuleFor(u => u.Email)
                .NotNull().WithMessage("Email is null")
                .NotEmpty().WithMessage("Email is empty.")
                .Must(email => email != null && email.Contains("@") && email.Contains("."))
                .WithMessage("Invalid email format. Email must contain '@' and '.'");


            RuleFor(u => u.Password)
                .NotNull().WithMessage("Password is null")
                .NotEmpty().WithMessage("Password is empty")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long");


            RuleFor(u => u.Username)
                .NotNull().WithMessage("Username is null")
                .NotEmpty().WithMessage("Username is empty")
                .MinimumLength(3).WithMessage("Minimum username length is 3 characters")
                .MaximumLength(20).WithMessage("Maximum maximum length is 20 characters");


            RuleFor(u => u.Gender)
                .NotNull().WithMessage("Gender is null")
                .NotEmpty().WithMessage("Gender is empty")
                .Must(gender => gender == "Male" || gender == "Female")
                 .WithMessage("Gender must be either 'Male' or 'Female'");



        }
    }
}
