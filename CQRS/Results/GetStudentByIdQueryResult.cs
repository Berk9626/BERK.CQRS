using MediatR;

namespace Berk.CQRS.CQRS.Result
{
	public class GetStudentByIdQueryResult 
	{ //bir tane data gelecek(GetStudentByIdQuery) ile ve gelecek datada bu bilgiler olacak
		public string Name { get; set; }
		public string Surname { get; set; }
		public int Age { get; set; }
	}
}
