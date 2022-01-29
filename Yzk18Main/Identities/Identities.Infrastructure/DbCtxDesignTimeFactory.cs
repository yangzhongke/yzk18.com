using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identities.Infrastructure
{
	internal class DbCtxDesignTimeFactory : IDesignTimeDbContextFactory<IdDbContext>
	{
		public IdDbContext CreateDbContext(string[] args)
		{
			var connStr = "Server=127.0.0.1;database=yzk18;uid=root;pwd=adfa3_ioz09_08nljo";
			var optionsBuilder = new DbContextOptionsBuilder<IdDbContext>();
			optionsBuilder.UseMySql(connStr, ServerVersion.Parse("5.6.16"));
			return new IdDbContext(optionsBuilder.Options);
		}
	}
}
