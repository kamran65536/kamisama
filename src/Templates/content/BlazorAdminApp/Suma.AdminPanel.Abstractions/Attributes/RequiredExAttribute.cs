namespace Suma.AdminPanel.Attributes;

public class RequiredExAttribute : RequiredAttribute
{
	private readonly bool checkGuid;

	public RequiredExAttribute(string resourceKey = nameof(Resources.Validation_Required), bool checkGuid = true)
	{
		this.ErrorMessageResourceName = resourceKey;
		this.ErrorMessageResourceType = typeof(Resources);
		this.checkGuid = checkGuid;
	}
	public override bool IsValid(object? value)
		=> base.IsValid(value) &&
		   !(checkGuid && value is Guid guid && guid == Guid.Empty);
}
