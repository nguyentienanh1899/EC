using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace EC.ViewModel.System.User
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is required").MaximumLength(200).
                WithMessage("FirstName can not over 200 characters");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is required").MaximumLength(200).
                WithMessage("LastName can not over 200 characters");
            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-110)).WithMessage("Age too old is not valid ");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required").Matches(@"(84|0[3|5|7|8|9])+([0-9]{8})\b").WithMessage("PhoneNumber format not match");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(6)
                .WithMessage("Password is at least 6 characters");
            RuleFor(x => x).Custom((request, context) => {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("ConfirmPassword is incorrect."); 
                }
            });

        }
    }
}
