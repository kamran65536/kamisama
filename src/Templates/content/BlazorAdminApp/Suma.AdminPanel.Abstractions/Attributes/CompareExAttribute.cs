namespace Suma.AdminPanel.Attributes;

public class CompareExAttribute : CompareAttribute
{
	public CompareExAttribute(string otherProperty, string resourceKey = nameof(Resources.Validation_Compare)) : base(otherProperty)
	{
		ErrorMessageResourceName = resourceKey;
		ErrorMessageResourceType = typeof(Resources);
	}
}
