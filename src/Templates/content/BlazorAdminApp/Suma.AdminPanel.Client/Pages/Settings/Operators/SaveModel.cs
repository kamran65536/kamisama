using System.ComponentModel.DataAnnotations;
using Suma.AdminPanel.Properties;

namespace Suma.AdminPanel.Client.Pages.Settings.Operators;

public class SaveModel
{
	[Required]
	public string Username { get; set; } = string.Empty;

	[Required]
	[EmailAddress]
	public string Email { get; set; } = string.Empty;

	[Required]
	public bool IsEnabled { get; set; } = true;

	public string Password { get; set; } = string.Empty;

	[Compare(nameof(Password), ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = nameof(Resources.Validation_PasswordDoesNotMatch))]
	public string ConfirmPassword { get; set; } = string.Empty;
}
