using FluentValidation;
using Movies.DTOs.AuthDTOs;

namespace Movies.Validators.Auth_Validators
{
    public class LoginValidator : AbstractValidator<LoginRequestDTO>
    {
        public LoginValidator()
        {

            RuleFor(u => u.Email)
                .NotNull().WithMessage("Email is null")
                .NotEmpty().WithMessage("Email is empty.")
                .Must(email => email != null && email.Contains("@") && email.Contains("."))
                .WithMessage("Invalid email format. Email must contain '@' and '.'");


            RuleFor(u => u.Password)
                .NotNull().WithMessage("Email is null")
                .NotEmpty().WithMessage("Email is empty");



        }
    }
}
