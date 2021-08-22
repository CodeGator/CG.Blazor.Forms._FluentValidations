using CG.Blazor.Forms._FluentValidations.QuickStart.ViewModels;
using FluentValidation;

namespace CG.Blazor.Forms._FluentValidations.QuickStart.Validators
{
    /// <summary>
    /// This class is a validator for the <see cref="HtmlVM"/> class.
    /// </summary>
    public class VMValidator : AbstractValidator<ValidatorVM>
    {
        public VMValidator()
        {
            RuleFor(x => x.A1)
                .NotEmpty()
                .WithMessage("Woah, dude, good thing I stopped you. Hey, did you know the A1 field is empty??");
        }
    }
}
