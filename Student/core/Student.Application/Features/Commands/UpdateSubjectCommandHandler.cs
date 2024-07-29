using AMS.Application.Dtos;
using AMS.Application.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Application.Features.Commands
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, SubjectViewDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSubjectCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SubjectViewDto> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var updateSubject = await _unitOfWork.SubjectRepository.GetByIdAsync(request.Id);
            if (updateSubject == null )
            {
                throw new NotFoundException($"Student with ID {request.Id} not found");
            }
            
            updateSubject.SubjectName = request.SubjectName;
            updateSubject.Course = request.Course;
            updateSubject.Semester = request.Semester;
            updateSubject.AssignedTeacher = request.AssignedTeacher;

            try
            {
                _unitOfWork.SubjectRepository.Update(updateSubject);
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating student", ex);
            }
            return _mapper.Map<SubjectViewDto>(updateSubject);
        }
    }
}
