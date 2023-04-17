using CustomerRelaManag.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CustomerRelaManag.ModelVM;

namespace CustomerRelaManag.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<BDE> BDEs { get; set; }
		public DbSet<Clients> Clients { get; set; }
		public DbSet<ProcessManager> ProcessManagers { get; set; }
		public DbSet<Projects> Projects { get; set; }
		public DbSet<Teams> Teams { get; set; }
		public DbSet<Status> Statuss { get; set; }
		public DbSet<CustomerRelaManag.ModelVM.ProjectVM> ProjectVM { get; set; } = default!;

	}
}