using Microsoft.AspNetCore.Identity;

namespace Identities.Domain;
public class User : IdentityUser<Guid>
{
	public DateTime CreationTime { get; set; }
}
