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
    public class GetAllTeacherQueryHandler : IRequestHandler<GetAllTeacherQuery, IEnumerable<TeacherViewDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTeacherQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeacherViewDto>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
        {
            var teachers = await _unitOfWork.TeacherRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeacherViewDto>>(teachers);
        }
    }
}
