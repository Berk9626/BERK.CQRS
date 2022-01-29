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
	public class RemoveStudentHandler : IRequestHandler<RemoveStudentCommand>
	{
		private readonly StudentContext _context;
		public RemoveStudentHandler(StudentContext context)
		{
			_context = context;
		}

		public async Task<Unit> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
		{
			var deletedstudent =  _context.Students.Find(request.Id);
			_context.Students.Remove(deletedstudent);
			await _context.SaveChangesAsync(); 
			return Unit.Value;

		}


		//public void Handle(RemoveStudentCommand command)
		//{
		//	var deletedstudent = _context.Students.Find(command.Id);
		//	_context.Students.Remove(deletedstudent);
		//	_context.SaveChanges();



		//}
	}
}
