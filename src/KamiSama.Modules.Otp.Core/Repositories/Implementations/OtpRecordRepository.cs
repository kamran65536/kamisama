using Microsoft.EntityFrameworkCore;
using KamiSama.Modules.Otp.Repositories.Database;
using KamiSama.Modules.Otp.Services;

namespace KamiSama.Modules.Otp.Repositories.Implementations;

[AutoInjectScoped<IOtpRecordRepository>]
internal class OtpRecordRepository(OtpDbContext context) :
	GenericRepository<OtpRecord, OtpRecordSearchModel, OtpDbContext>(context), IOtpRecordRepository
{
	protected override IQueryable<OtpRecord> ApplySearchModel(IQueryable<OtpRecord> query, OtpRecordSearchModel searchModel)
	{
		if (!string.IsNullOrWhiteSpace(searchModel.Identity))
			query = query.Where(x => x.Identity == searchModel.Identity);

		if (searchModel.Statuses != null)
			query = query.Where(x => searchModel.Statuses.Contains(x.Status));

		return (searchModel.OrderBy ?? string.Empty).ToLower() switch
		{
			"id" => query.OrderBy(x => x.Id),
			"identity" => query.OrderBy(x => x.Identity),
			"createdat" => query.OrderByDescending(x => x.CreatedAt),
			_ => query.OrderByDescending(x => x.CreatedAt),
		};
	}

	public Task<OtpRecord?> GetLastAvailableOtpAsync(string identity, CancellationToken cancellationToken)
		=> base
		.Where(x => x.Identity == identity && x.Status == OtpRecordStatus.Available)
		.OrderByDescending(x => x.CreatedAt)
		.FirstOrDefaultAsync(cancellationToken);

	public Task<OtpRecord?> FindOtpByVerificationTokenAsync(string identity, string verificationCode, CancellationToken cancellationToken)
		=> FindAsync(x => x.VerificationToken == verificationCode && x.Identity == identity, cancellationToken);
}
