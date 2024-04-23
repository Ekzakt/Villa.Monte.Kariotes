using FluentValidation;
using Vmk.Application.Models;

namespace Vmk.Application.Validators;

public class ContactModelValidator : AbstractValidator<ContactModel>
{
    public ContactModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(x => x.Subject)
           .NotEmpty()
           .MaximumLength(200);

        RuleFor(x => x.Message)
           .NotEmpty()
           .MaximumLength(500);
    }
}
