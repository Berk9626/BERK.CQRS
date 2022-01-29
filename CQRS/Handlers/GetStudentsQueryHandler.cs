﻿using Berk.CQRS.CQRS.Queries;
using Berk.CQRS.CQRS.Result;
using Berk.CQRS.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
//AsNoTracking()= ef core ilgili kayıtları izlemesin
namespace Berk.CQRS.CQRS.Handlers
{
	public class GetStudentsQueryHandler: IRequestHandler<GetStudentsQuery, IEnumerable<GetStudentsQueryResult>>
	{
		private readonly StudentContext _context;

		public GetStudentsQueryHandler(StudentContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
		{
			return await _context.Students.Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname }).AsNoTracking().ToListAsync();
		}



		//public IEnumerable<GetStudentsQueryResult> Handle(GetStudentsQuery query)
		//{
		//	return _context.Students.Select(x => new GetStudentsQueryResult { Name = x.Name, Surname = x.Surname }).AsNoTracking().AsEnumerable();
		//}
	}
}
