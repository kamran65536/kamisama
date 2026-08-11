namespace Suma.AdminPanel.Attributes;

public class NumberOnlyExAttribute : RegularExpressionAttribute
{
	private readonly int minLength;
	private readonly int maxLength;
	private readonly int decimals;
	public NumberOnlyExAttribute() : base("^[0-9]*$")
	{
		ErrorMessageResourceName = nameof(Resources.Validation_NumberOnly);
		ErrorMessageResourceType = typeof(Resources);
	}
	public NumberOnlyExAttribute(int exactLength) : base($"^[0-9]{{{exactLength}}}$")
	{
		ErrorMessageResourceName = nameof(Resources.Validation_NumberOnlyExactLength);
		ErrorMessageResourceType = typeof(Resources);
		minLength = exactLength;
		maxLength = exactLength;
		decimals = 0;
	}
	public NumberOnlyExAttribute(int minLength, int maxLength) : base($"^[0-9]{{{minLength},{maxLength}}}$")
	{
		ErrorMessageResourceName = nameof(Resources.Validation_NumberOnlyMinMax);
		ErrorMessageResourceType = typeof(Resources);
		this.minLength = minLength;
		this.maxLength = maxLength;
	}
	public NumberOnlyExAttribute(int minLength, int maxLength, int decimals) : base($"^[0-9]{{{minLength},{maxLength}}}(\\.[0-9]{{1,{decimals}}})?$")
	{
		ErrorMessageResourceName = nameof(Resources.Validation_NumberOnlyMinMaxDecimals);
		ErrorMessageResourceType = typeof(Resources);
		this.minLength = minLength;
		this.maxLength = maxLength;
		this.decimals = decimals;
	}
	public override string FormatErrorMessage(string name)
	{
		name = Resources.ResourceManager.GetString(name, Resources.Culture) ?? name;
		return string.Format(Resources.Culture, ErrorMessageString, name, minLength, maxLength, decimals);
	}
}
