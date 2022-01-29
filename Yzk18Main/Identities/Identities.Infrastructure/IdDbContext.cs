using Identities.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identities.Infrastructure;
public class IdDbContext : IdentityDbContext<User, Role, Guid>
{
	public IdDbContext(DbContextOptions<IdDbContext> options)
	: base(options)
	{
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
	}
}