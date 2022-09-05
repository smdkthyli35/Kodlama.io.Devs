using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
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

namespace Kodlama.io.Devs.Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeleteLanguageDto>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;
        private readonly LanguageBusinessRules _languageBusinessRules;

        public DeleteLanguageCommandHandler(ILanguageRepository languageRepository, IMapper mapper, LanguageBusinessRules languageBusinessRules)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
            _languageBusinessRules = languageBusinessRules;
        }

        public async Task<DeleteLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
        {
            Language isExistsLanguage = await _languageRepository.GetAsync(l => l.Id == request.Id);
            _languageBusinessRules.LanguageShouldExistWhenRequested(isExistsLanguage);
            Language mappedLanguage = _mapper.Map<Language>(isExistsLanguage);
            Language deletedLanguage = await _languageRepository.DeleteAsync(mappedLanguage);
            DeleteLanguageDto deletedLanguageDto = _mapper.Map<DeleteLanguageDto>(deletedLanguage);
            return deletedLanguageDto;
        }
    }
}
