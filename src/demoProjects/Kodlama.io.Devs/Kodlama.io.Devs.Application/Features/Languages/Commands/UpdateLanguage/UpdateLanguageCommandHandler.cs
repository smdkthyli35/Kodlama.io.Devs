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

namespace Kodlama.io.Devs.Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommandHandler : IRequestHandler<UpdateLanguageCommand, UpdateLanguageDto>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        private readonly LanguageBusinessRules _languageBusinessRules;

        public UpdateLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<UpdateLanguageDto> Handle(UpdateLanguageCommand request, CancellationToken cancellationToken)
        {
            var isExistsLanguage = await _languageRepository.GetAsync(l => l.Id == request.Id);

            _languageBusinessRules.LanguageShouldExistWhenRequested(isExistsLanguage);
            await _languageBusinessRules.LanguageNameCanNotBeDuplicatedWhenUpdated(request.Name);

            Language mappedLanguage = _mapper.Map<Language>(isExistsLanguage);
            Language updatedLanguage = await _languageRepository.UpdateAsync(mappedLanguage);
            UpdateLanguageDto updatedLanguageDto = _mapper.Map<UpdateLanguageDto>(updatedLanguage);
            return updatedLanguageDto;
        }
    }
}
