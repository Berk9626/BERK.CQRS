using Berk.CQRS.CQRS.Commands;
using Berk.CQRS.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Berk.CQRS.CQRS.Handlers
{
	public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
	{
		private readonly StudentContext _context;

		public UpdateStudentCommandHandler(StudentContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
		{
			var updatedstudent =  _context.Students.Find(request.Id);
			updatedstudent.Id = request.Id;
			updatedstudent.Age = request.Age;
			updatedstudent.Name = request.Name;
			updatedstudent.Surname = request.Surname;
			 await _context.SaveChangesAsync();

			return Unit.Value;
		}

		//public void Handle(UpdateStudentCommand command)
		//{
		//	var updatedstudent = _context.Students.Find(command.Id);
		//	updatedstudent.Id = command.Id;
		//	updatedstudent.Age = command.Age;
		//	updatedstudent.Name = command.Name;
		//	updatedstudent.Surname = command.Surname;
		//	_context.SaveChanges();

		//}
	}
}
