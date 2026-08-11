namespace Suma.AdminPanel.Attributes;
public class MobileNumberExAttribute : RegularExpressionAttribute
{
	public MobileNumberExAttribute()
		: base("^09[0-9]{9}$")
	{
		ErrorMessageResourceName = nameof(Resources.Validation_InvalidMobileNumber);
		ErrorMessageResourceType = typeof(Resources);
	}
	public override string FormatErrorMessage(string name)
	{
		name = Resources.ResourceManager.GetString(name) ?? name;

		return base.FormatErrorMessage(name);
	}
}
