using Berk.CQRS.CQRS.Queries;
using Berk.CQRS.CQRS.Result;
using Berk.CQRS.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Berk.CQRS.CQRS.Handlers
{
	public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery,GetStudentByIdQueryResult>  //bana bir request vereceksin ve benim geriye bir şey dönmem lazım.iLKİ requestim diğeri responsum
	{
		private readonly StudentContext _context;

		public GetStudentByIdQueryHandler(StudentContext context)
		{
			_context = context;
		}

		public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
		{
			var student = await _context.Set<Student>().FindAsync(request.Id);

			return new GetStudentByIdQueryResult
			{
				Age = student.Age,
				Name = student.Name,
				Surname = student.Surname

			};
		}


		//public GetStudentByIdQueryResult Handle(GetStudentByIdQuery query)
		//{
		//	var student = _context.Set<Student>().Find(query.Id);

		//	return new GetStudentByIdQueryResult
		//	{
		//		Age = student.Age,
		//		Name = student.Name,
		//		Surname = student.Surname

		//	};
		//}

	}
}
