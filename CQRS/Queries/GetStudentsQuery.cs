using Berk.CQRS.CQRS.Result;
using MediatR;
using System.Collections.Generic;

namespace Berk.CQRS.CQRS.Queries
{
	public class GetStudentsQuery: IRequest<IEnumerable<GetStudentsQueryResult>>
	{
	}
}
