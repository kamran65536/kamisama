namespace Suma.AdminPanel.Services.Operators;

public interface IListOperators : IListFeature<OperatorListItemDto, OperatorSearchModel>;
public interface IAddOperator
{
	Task AddAsync(AddOperatorRequest request, CancellationToken cancellationToken);
}
public interface IUpdateOperator
{
	Task UpdateAsync(Guid operatorId, UpdateOperatorRequest request, CancellationToken cancellationToken);
}
public interface IFindOperatorById
{
	Task<OperatorDto> FindByIdAsync(Guid operatorId, CancellationToken cancellationToken);
}
public interface IEnableOperator
{
	Task EnableAsync(Guid operatorId, CancellationToken cancellationToken);
}
public interface IDisableOperator
{
	Task DisableAsync(Guid operatorId, CancellationToken cancellationToken);
}
public interface IResetOperatorPassword
{
	Task ResetPasswordAsync(ResetOperatorPasswordRequest request, CancellationToken cancellationToken);
}
