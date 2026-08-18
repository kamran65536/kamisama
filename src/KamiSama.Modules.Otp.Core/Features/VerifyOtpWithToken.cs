namespace KamiSama.Modules.Otp.Features;

/// <summary>
/// Verifies a previously issued OTP verification token for an identity.
/// </summary>
/// <remarks>
/// A record found by token is treated as already verified: a match that has since expired is marked
/// <see cref="OtpRecordStatus.Expired"/> and rejected, otherwise the same token is returned as confirmation.
/// </remarks>
[AutoInjectScoped<IVerifyOtpWithToken>]
internal class VerifyOtpWithToken(IOtpRecordRepository repository) : IVerifyOtpWithToken
{
	public async Task<OtpVerificationResult> VerifyWithTokenAsync(VerifyOtpWithTokenRequest request, CancellationToken cancellationToken)
	{
		var record = await repository.FindOtpByVerificationTokenAsync(request.Identity, request.Token.ToLower(), cancellationToken);

		if (record == null)
			return new(request.Identity, OtpVerificationStatus.InvalidCode, null);

		if (record.ExpirationDate < DateTime.UtcNow)
		{
			record.Status = OtpRecordStatus.Expired;

			await repository.UpdateAsync(record, cancellationToken);

			return new(request.Identity, OtpVerificationStatus.Expired, null);
		}
		else
			return new(request.Identity, OtpVerificationStatus.Success, record.VerificationToken);
	}
}
