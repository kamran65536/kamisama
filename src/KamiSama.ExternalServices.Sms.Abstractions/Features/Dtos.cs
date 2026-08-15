namespace KamiSama.ExternalServices.Sms.Features;

/// <summary>
/// Contains the provider-neutral destination and message text for one SMS request.
/// Pass it to <see cref="ISendSms.SendSmsAsync"/>; delivery behavior belongs to the selected provider implementation.
/// </summary>
/// <param name="PhoneNumber">The destination phone number in the format expected by the provider.</param>
/// <param name="Message">The text to send.</param>
public record SendSmsRequest(string PhoneNumber, string Message);
