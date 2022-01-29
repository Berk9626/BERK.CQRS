using Microsoft.EntityFrameworkCore;

namespace Berk.CQRS.Data
{
	public class StudentContext : DbContext
	{
		public StudentContext(DbContextOptions<StudentContext> options) : base(options)
		{

		}
		public DbSet<Student> Students { get; set; }
		//studentslarla beraber ayağı kalkmasını istiyorum override ettim

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Student>().HasData(new Student[]
				{
				  new Student() {Id=1, Name="Berk", Surname="Berkmen", Age=26},
				  new Student() {Id=2, Name="Sabahattin", Surname="Berkmen", Age=23}
				});

			base.OnModelCreating(modelBuilder);
		}
	}
}
