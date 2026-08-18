using KamiSama.Modules.Otp.Features;

namespace KamiSama.Modules.Otp.Repositories.Abstractions;

/// <summary>
/// Provides OTP-record persistence beyond the generic CRUD and search operations.
/// </summary>
internal interface IOtpRecordRepository : IGenericRepository<OtpRecord, OtpRecordSearchModel>
{
	/// <summary>
	/// Finds an OTP record for the given identity by its verification token.
	/// </summary>
	/// <param name="identity">The identity the token was issued for.</param>
	/// <param name="verificationCode">The verification token to match, compared case-insensitively.</param>
	/// <param name="cancellationToken">A token that can cancel the query.</param>
	/// <returns>The matching record, or <see langword="null"/> if none matches.</returns>
	Task<OtpRecord?> FindOtpByVerificationTokenAsync(string identity, string verificationCode, CancellationToken cancellationToken);

	/// <summary>
	/// Gets the most recently created <see cref="OtpRecordStatus.Available"/> record for the given identity.
	/// </summary>
	/// <param name="identity">The identity to look up.</param>
	/// <param name="cancellationToken">A token that can cancel the query.</param>
	/// <returns>The most recent available record, or <see langword="null"/> if none exists.</returns>
	Task<OtpRecord?> GetLastAvailableOtpAsync(string identity, CancellationToken cancellationToken);
}
