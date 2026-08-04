using Microsoft.Extensions.Localization;

namespace KamiSama.Modules.Identity.Wrappers;

internal class LocalizedIdentityErrorDescriber(IStringLocalizer<LocalizedIdentityErrorDescriber> localizer) : IdentityErrorDescriber
{
	public override IdentityError PasswordTooShort(int length)
		=> new() { Code = nameof(PasswordTooShort), Description = localizer["PasswordTooShort", length] };

	public override IdentityError PasswordRequiresNonAlphanumeric()
		=> new() { Code = nameof(PasswordRequiresNonAlphanumeric), Description = localizer["PasswordRequiresNonAlphanumeric"] };

	public override IdentityError PasswordRequiresUpper()
		=> new() { Code = nameof(PasswordRequiresUpper), Description = localizer["PasswordRequiresUpper"] };

	public override IdentityError PasswordRequiresLower()
		=> new() { Code = nameof(PasswordRequiresLower), Description = localizer["PasswordRequiresLower"] };

	public override IdentityError PasswordRequiresDigit()
		=> new() { Code = nameof(PasswordRequiresDigit), Description = localizer["PasswordRequiresDigit"] };

	public override IdentityError PasswordRequiresUniqueChars(int uniqueChars)
		=> new() { Code = nameof(PasswordRequiresUniqueChars), Description = localizer["PasswordRequiresUniqueChars", uniqueChars] };
}