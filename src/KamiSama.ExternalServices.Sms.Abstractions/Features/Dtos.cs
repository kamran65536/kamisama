namespace KamiSama.ExternalServices.Sms.Features;

/// <summary>
/// Represents a request to send an SMS message.
/// </summary>
/// <param name="PhoneNumber"> Gets or sets the phone number associated with the entity. </param>
/// <param name="Message"> Gets or sets the message to be sent via SMS. </param>
public record SendSmsRequest(string PhoneNumber, string Message);
