using AutoMapper;
using Kodlama.io.Devs.Application.Features.Languages.Dtos;
using Kodlama.io.Devs.Application.Features.Languages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Languages.Commands.CreateLanguage
{
    public class CreateLanguageCommandHandler : IRequestHandler<CreateLanguageCommand, CreateLanguageDto>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        private readonly LanguageBusinessRules _languageBusinessRules;

        public CreateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<CreateLanguageDto> Handle(CreateLanguageCommand request, CancellationToken cancellationToken)
        {
            await _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

            Language mappedLanguage = _mapper.Map<Language>(request);
            Language createdLanguage = await _languageRepository.AddAsync(mappedLanguage);
            CreateLanguageDto createdLanguageDto = _mapper.Map<CreateLanguageDto>(createdLanguage);
            return createdLanguageDto;
        }
    }
}
