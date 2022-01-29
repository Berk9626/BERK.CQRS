using Berk.CQRS.CQRS.Commands;
using Berk.CQRS.CQRS.Handlers;
using Berk.CQRS.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
//Mediator Patern: Diyelim ki CreateStudentCommand geldi, CreateStudentCommandHandlerı çalıştır diyor. Böylece alttaki kalabalıktan da kurtulacağız.
//bunun pakedini ekledik.

namespace Berk.CQRS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		//private readonly GetStudentByIdQueryHandler _getStudentByIdQueryHandler;
		//private readonly GetStudentsQueryHandler _getStudentsQueryHandler;
		//private readonly CreateStudentCommandHandler _createStudentCommandHandler;
		//private readonly RemoveStudentHandler _removeStudentHandler;
		//private readonly UpdateStudentCommandHandler _updateStudentCommandHandler;
		//public StudentsController(GetStudentByIdQueryHandler getStudentByIdQueryHandler, GetStudentsQueryHandler getStudentsQueryHandler, CreateStudentCommandHandler createStudentCommandHandler, RemoveStudentHandler removeStudentHandler, UpdateStudentCommandHandler updateStudentCommandHandler)
		//{
		//	_getStudentByIdQueryHandler = getStudentByIdQueryHandler;
		//	_getStudentsQueryHandler = getStudentsQueryHandler;
		//	_createStudentCommandHandler = createStudentCommandHandler;
		//	_removeStudentHandler = removeStudentHandler;
		//	_updateStudentCommandHandler = updateStudentCommandHandler;
		//}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _mediator.Send(new GetStudentsQuery());
			return Ok(result);
		}
		private readonly IMediator _mediator;
		public StudentsController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpGet("{id}")]
		public async Task<IActionResult> GetStudent(int id) //new GetStudentByIdQuery().Id == id; //Böyle yapmak yerine bunu gelenelde constructor içine alırız.
		{
			var result = await _mediator.Send(new GetStudentByIdQuery(id));

			return Ok(result);

		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateStudentCommand command)
		{
			await _mediator.Send(command);
			return Created("", command.Name);
		}

		[HttpDelete("{id}")]

		public async Task< IActionResult> Delete(int id)
		{
			await _mediator.Send(new RemoveStudentCommand(id));
			return NoContent();

		}
		[HttpPut]
		public async Task<IActionResult> Edit(UpdateStudentCommand command)
		{
			await _mediator.Send(command);
			return NoContent();

		}
	}
}
