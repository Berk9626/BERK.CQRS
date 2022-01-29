using Berk.CQRS.CQRS.Result;
using MediatR;

namespace Berk.CQRS.CQRS.Queries
{
	public class GetStudentByIdQuery: IRequest<GetStudentByIdQueryResult> //media. Bununla geri dönenen nesneyi verebiliyorum
	{
		public int Id { get; set; }

		public GetStudentByIdQuery(int id)
		{
			Id = id;
		}
	}
}
