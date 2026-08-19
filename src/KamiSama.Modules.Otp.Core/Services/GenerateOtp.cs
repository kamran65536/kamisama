using KamiSama.Chassis.HttpExceptions;
using Microsoft.Extensions.Options;

namespace KamiSama.Modules.Otp.Services;

/// <summary>
/// Generates a random numeric OTP code and persists it as a new <see cref="OtpRecordStatus.Available"/> record.
/// </summary>
/// <remarks>
/// The first digit is generated in the range 1-9 so the code never has a leading zero; remaining digits are 0-9.
/// A new code is refused with a <see cref="BadRequestException"/> if the configured <see cref="OtpOptions.SendOtpInterval"/>
/// has not yet elapsed since the identity's most recent record.
/// </remarks>
[AutoInjectScoped<IGenerateOtp>]
internal class GenerateOtp(IOtpRecordRepository repository, IOptions<OtpOptions> options) : IGenerateOtp
{
	public async Task<string> GenerateAsync(GenerateOtpRequest request, CancellationToken cancellationToken)
	{
		var code = "";

		for (int i = 0; i < options.Value.NumberOfDigits; i++)
			if (i == 0)
				code += Random.Shared.Next(1, 10);
			else
				code += Random.Shared.Next(0, 10);

		var lastOtp = await repository.GetLastAvailableOtpAsync(request.Identity, cancellationToken);

		var now = DateTime.UtcNow;
		if (lastOtp != null && (now - lastOtp.CreatedAt) < options.Value.SendOtpInterval)
			throw new BadRequestException($"minimum resend OTP interval is {options.Value.SendOtpInterval}");

		var otpRecord = new OtpRecord
		{
			Code = code,
			Identity = request.Identity,
			Status = OtpRecordStatus.Available,
			CreatedAt = DateTime.UtcNow,
			ExpirationDate = DateTime.UtcNow + options.Value.OtpLifetime,
		};

		await repository.AddAsync(otpRecord, cancellationToken);

		return code;
	}
}
