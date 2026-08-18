using KamiSama.Extensions;

namespace KamiSama.Modules.Otp.Features;

/// <summary>
/// Verifies a submitted OTP code against the identity's most recent available record.
/// </summary>
/// <remarks>
/// An expired record is marked <see cref="OtpRecordStatus.Expired"/> and rejected even if the code matches.
/// A successful match marks the record <see cref="OtpRecordStatus.Used"/> and computes a reusable verification
/// token as the lowercase SHA-1 hex digest of <c>"Exchangeum#{Id}"</c>.
/// </remarks>
[AutoInjectScoped<IVerifyOtp>]
internal class VerifyOtp(IOtpRecordRepository repository) : IVerifyOtp
{
	public async Task<OtpVerificationResult> VerifyAsync(VerifyOtpRequest request, CancellationToken cancellationToken)
	{
		var record = await repository.GetLastAvailableOtpAsync(request.Identity, cancellationToken);

		if (record == null)
			return new(request.Identity, OtpVerificationStatus.InvalidCode, null);

		if (record.ExpirationDate < DateTime.UtcNow)
		{
			record.Status = OtpRecordStatus.Expired;

			await repository.UpdateAsync(record, cancellationToken);

			return new(request.Identity, OtpVerificationStatus.Expired, null);
		}
		else if (record.Code == request.OtpCode)
		{
			record.Status = OtpRecordStatus.Used;
			record.VerificationToken = $"Exchangeum#{record.Id}".GetSha1Hex().ToLower();

			await repository.UpdateAsync(record, cancellationToken);

			return new(request.Identity, OtpVerificationStatus.Success, record.VerificationToken);
		}
		else
			return new(request.Identity, OtpVerificationStatus.InvalidCode, null);
	}
}
