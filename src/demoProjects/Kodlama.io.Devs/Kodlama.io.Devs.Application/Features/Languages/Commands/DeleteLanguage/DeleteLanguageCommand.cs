using Kodlama.io.Devs.Application.Features.Languages.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommand : IRequest<DeleteLanguageDto>
    {
        public int Id { get; set; }
    }
}
