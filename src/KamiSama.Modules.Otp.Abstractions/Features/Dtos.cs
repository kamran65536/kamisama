namespace KamiSama.Modules.Otp.Features;

/// <summary>
/// Specifies paging, identity and status filters, and ordering input for OTP record queries.
/// </summary>
/// <param name="Page">The one-based page number; use the paging defaults when set to <see langword="default"/>.</param>
/// <param name="PageSize">The requested page size; use the paging defaults when set to <see langword="default"/>.</param>
/// <param name="Identity">An optional identity (such as a phone number or email address) matched exactly against OTP records.</param>
/// <param name="Statuses">An optional set of record statuses; when supplied, only records whose status is contained in this set are returned.</param>
/// <param name="OrderBy">An optional ordering token. Recognized values are <c>id</c>, <c>identity</c>, and <c>createdat</c>; any other value orders by creation date descending.</param>
public record OtpRecordSearchModel(int Page, int PageSize, string? Identity, OtpRecordStatus[]? Statuses, string? OrderBy) : SearchModel(Page, PageSize, OrderBy)
{
	/// <summary>
	/// Gets an unpaged search model without identity or status filtering.
	/// </summary>
	/// <value>A reusable model whose paging and optional filter values are all defaults.</value>
	public static new OtpRecordSearchModel All { get; } = new(default, default, default, default, default);
}

/// <summary>
/// Requests generation of a new one-time password for the given identity.
/// </summary>
/// <param name="Identity">The identity (such as a phone number or email address) the code is generated for.</param>
public record GenerateOtpRequest(string Identity);

/// <summary>
/// Requests verification of a one-time password code for the given identity.
/// </summary>
/// <param name="Identity">The identity the code was generated for.</param>
/// <param name="OtpCode">The code supplied by the caller for verification.</param>
public record VerifyOtpRequest(string Identity, string OtpCode);

/// <summary>
/// Requests verification of a previously issued OTP verification token for the given identity.
/// </summary>
/// <param name="Identity">The identity the token was issued for.</param>
/// <param name="Token">The verification token returned by a prior successful <see cref="VerifyOtpRequest"/>.</param>
public record VerifyOtpWithTokenRequest(string Identity, string Token);

/// <summary>
/// Represents the outcome of an OTP or token verification attempt.
/// </summary>
/// <param name="Identity">The identity that was verified.</param>
/// <param name="Status">The verification outcome.</param>
/// <param name="OtpVerificationToken">A reusable verification token, set only when <paramref name="Status"/> is <see cref="OtpVerificationStatus.Success"/>.</param>
public record OtpVerificationResult(string Identity, OtpVerificationStatus Status, string? OtpVerificationToken);
