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
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, StudentViewDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateStudentCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<StudentViewDto> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var updateStudent = await _unitOfWork.StudentRepository.GetByIdAsync(request.Id);
            if (updateStudent == null)
            {
                throw new NotFoundException($"Student with ID {request.Id} not found");
            }

            
            updateStudent.Name = request.Name;
            updateStudent.Course = request.Course;
            updateStudent.Email = request.Email;
            updateStudent.UserName = request.UserName;
            updateStudent.Password = request.Password;

            try
            {            
                _unitOfWork.StudentRepository.Update(updateStudent);

                
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {                              
                throw new Exception("Error occurred while updating student", ex);
            }

           
            return _mapper.Map<StudentViewDto>(updateStudent);
        }
    }
}
