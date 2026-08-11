namespace Suma.AdminPanel.Attributes;

public class EmailAddressExAttribute : DataTypeAttribute
{
	private readonly EmailAddressAttribute _attribute;
	public EmailAddressExAttribute(string resourceKey = nameof(Resources.Validation_EmailAddress)) : base(DataType.EmailAddress)
	{
		_attribute = new EmailAddressAttribute();

		ErrorMessageResourceName = resourceKey;
		ErrorMessageResourceType = typeof(Resources);
	}

	public override bool IsValid(object? value)
		=> _attribute.IsValid(value);
}
