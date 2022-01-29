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
	public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
	{
		private readonly StudentContext _context;

		public CreateStudentCommandHandler(StudentContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
		{
			_context.Students.Add(new Student { Name = request.Name, Age = request.Age, Surname = request.Surname });
			await  _context.SaveChangesAsync();
			return Unit.Value;
		}
		//public void Handle(CreateStudentCommand command)
		//{
		//	_context.Students.Add(new Student { Name = command.Name, Age = command.Age, Surname = command.Surname });
		//	_context.SaveChanges();
		//}

	}
}
