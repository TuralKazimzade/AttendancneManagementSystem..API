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
    internal class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, StudentViewDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddStudentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<StudentViewDto> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var addedStudent = new Student
            {
                Name = request.Name,
                Course = request.Course,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
            };
            try
            {
              
                await _unitOfWork.StudentRepository.AddAsync(addedStudent);
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }

            return _mapper.Map<StudentViewDto>(addedStudent);
        }
    }
}
