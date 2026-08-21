using Example.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.Server.Controllers.Users;

[ApiController, Authorize, Route("api/users")]
public sealed class UsersController(IListAdminUsers users) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<UserSummary>>> List(CancellationToken cancellationToken)
        => Ok(await users.ListAsync(cancellationToken));
}
