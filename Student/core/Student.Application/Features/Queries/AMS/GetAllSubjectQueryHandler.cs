using AMS.Application.Dtos;
using AMS.Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Features.Queries.AMS
{
    public class GetAllSubjectQueryHandler : IRequestHandler<GetAllSubjectQuery, IEnumerable<SubjectViewDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllSubjectQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectViewDto>> Handle(GetAllSubjectQuery request, CancellationToken cancellationToken)
        {
            var subjects = await _unitOfWork.SubjectRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubjectViewDto>>(subjects);

        }
    }
}
