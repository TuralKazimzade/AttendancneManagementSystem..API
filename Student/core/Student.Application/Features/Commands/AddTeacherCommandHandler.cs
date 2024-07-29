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
    internal class AddTeacherCommandHandler : IRequestHandler<AddTeacherCommand, TeacherViewDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddTeacherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TeacherViewDto> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
        {
            var addedTeacher = new Teacher
            {
                Name = request.Name,
                Address = request.Address,
                Email = request.Email,
                UserName = request.UserName,
                Password = request.Password,
            };
            await _unitOfWork.TeacherRepository.AddAsync(addedTeacher);
            await _unitOfWork.Commit();
            
            return _mapper.Map<TeacherViewDto>(addedTeacher);
        }
    }
}
