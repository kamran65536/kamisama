namespace Suma.AdminPanel.Attributes;

public class StringLengthExAttribute : StringLengthAttribute
{
	public StringLengthExAttribute(int maximumLength, string? messageKey = nameof(Resources.Validation_StringLengthAttribute)) : base(maximumLength)
	{
		ErrorMessageResourceType = typeof(Resources);
		ErrorMessageResourceName = messageKey;
	}
	public StringLengthExAttribute(int minimumLength, int maximumLength, string? messageKey = nameof(Resources.Validation_StringLengthAttribute_IncludingMinimum))
		: base(maximumLength)
	{
		ErrorMessageResourceType = typeof(Resources);
		ErrorMessageResourceName = messageKey;
		MinimumLength = minimumLength;
	}
}
