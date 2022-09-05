using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.Languages.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, LanguageListModel>
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public GetListLanguageQueryHandler(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<LanguageListModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Language> languages = await _languageRepository.GetListAsync(
                                                        index: request.PageRequest.Page,
                                                        size: request.PageRequest.PageSize);

            LanguageListModel mappedLanguageListModel = _mapper.Map<LanguageListModel>(languages);
            return mappedLanguageListModel;
        }
    }
}
