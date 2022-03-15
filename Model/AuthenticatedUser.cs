using System.Security.Claims;

namespace Squad_Manager.Model
{
    public class AuthenticatedUser
    {
		private readonly IHttpContextAccessor _accessor;

		public AuthenticatedUser(IHttpContextAccessor accessor)
		{
			_accessor = accessor;
		}

		public string Email => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Email)?.Value;
		public string Id => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value;
		public string Name => GetClaimsIdentity().FirstOrDefault(a => a.Type == ClaimTypes.Name)?.Value;

		public IEnumerable<Claim> GetClaimsIdentity()
		{
			return _accessor.HttpContext.User.Claims;
		}
	}
}
