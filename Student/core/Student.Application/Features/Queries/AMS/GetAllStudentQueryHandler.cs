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
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQuery, IEnumerable<StudentViewDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllStudentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StudentViewDto>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            var students = await _unitOfWork.StudentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentViewDto>>(students);
            
        }
    }
}
