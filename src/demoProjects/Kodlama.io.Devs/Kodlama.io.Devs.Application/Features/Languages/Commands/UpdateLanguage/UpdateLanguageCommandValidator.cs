using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
    {
        public UpdateLanguageCommandValidator()
        {
            RuleFor(l => l.Name).NotEmpty();
            RuleFor(l => l.Name).NotNull();
            RuleFor(l => l.Name).MaximumLength(100);
            RuleFor(l => l.Name).MinimumLength(2);
        }
    }
}
