using AMS.Application.Dtos;
using AMS.Application.Repositories;
using AMS.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Features.Commands
{
    internal class AddSubjectCommandHandler : IRequestHandler<AddSubjectCommand, SubjectViewDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddSubjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SubjectViewDto> Handle(AddSubjectCommand request, CancellationToken cancellationToken)
        {
            var addedSubject = new Subject
            {           
                SubjectName = request.SubjectName,
                Course = request.Course,
                Semester = request.Semester,
                AssignedTeacher = request.AssignedTeacher,
                TeacherId = request.TeacherId,
            };
            await _unitOfWork.SubjectRepository.AddAsync(addedSubject);
            await _unitOfWork.Commit();

            return _mapper.Map<SubjectViewDto>(addedSubject);
        }
    }
}
