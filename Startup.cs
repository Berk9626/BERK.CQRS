using Berk.CQRS.CQRS.Handlers;
using Berk.CQRS.Data;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Berk.CQRS
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<StudentContext>(opt =>
			{

				opt.UseSqlServer("server=DESKTOP-LCS594S\\SQLSERVER2019EXP; database=StudentCQRSDB; integrated security=true;");
			});

			services.AddMediatR(typeof(Startup)); //bunu kullandýktan sonra aþaðýdaki tüm kullandýðým handlerlarý yoruma aldým.
			//services.AddScoped<GetStudentByIdQueryHandler>();//Bunu artýk dependencyIncection aracýlýðýyla ele alabileceðim.
			//services.AddScoped<GetStudentsQueryHandler>();
			//services.AddScoped<CreateStudentCommandHandler>();
			//services.AddScoped<RemoveStudentHandler>();
			//services.AddScoped<UpdateStudentCommandHandler>();

			services.AddControllers().AddNewtonsoftJson(opt =>
			{

				opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
