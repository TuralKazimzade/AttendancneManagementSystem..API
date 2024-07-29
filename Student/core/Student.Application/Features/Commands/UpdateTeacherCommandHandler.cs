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
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, TeacherViewDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTeacherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TeacherViewDto> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var updateTeacher = await _unitOfWork.TeacherRepository.GetByIdAsync(request.Id);
            if (updateTeacher == null)
            {
                throw new NotFoundException($"Student with ID {request.Id} not found");
            }

            updateTeacher.Name = request.Name;
            updateTeacher.Address = request.Address;
            updateTeacher.Email = request.Email;
            updateTeacher.UserName = request.UserName;
            updateTeacher.Password = request.Password;

            try
            {
                _unitOfWork.TeacherRepository.Update(updateTeacher);
                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while updating student", ex);
            }

            return _mapper.Map<TeacherViewDto>(updateTeacher);
        }
    }
}
