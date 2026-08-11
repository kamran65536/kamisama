using Polareum.Identity.DataTypes;
using Polareum.Identity.Features.Users;

namespace Suma.AdminPanel.Services.Operators;

[AutoInjectScoped<IAddOperator>]
internal class AddOperator(
	ILogger<AddOperator> logger,
	IAddUser addUser) : IAddOperator
{
	public async Task AddAsync(AddOperatorRequest request, CancellationToken cancellationToken)
	{
		logger.LogMethodEntry();

		try
		{
			await addUser.AddAsync(
				new Polareum.Identity.Features.Users.AddUserRequest(
					request.Username,
					request.Email,
					string.Empty,
					request.Password,
					request.IsEnabled,
					[KnownRoles.Operator]),
				cancellationToken);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Failed to add operator {Username}.", request.Username);
			throw;
		}
	}
}
