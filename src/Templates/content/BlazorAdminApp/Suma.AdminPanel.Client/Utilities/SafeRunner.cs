using BlazorBootstrap;
using Suma.AdminPanel.Properties;
using KamiSama.Chassis.HttpExceptions;
using Microsoft.Extensions.Localization;

namespace Suma.AdminPanel.Client.Utilities;

public class SafeRunner(ToastService toastService, IStringLocalizer<Resources> localizer)
{
	public async Task<bool> RunSafeAsync(Func<Task> action, string? errorMessage = null)
	{
		try
		{
			await action();
			return true;
		}
		catch (Exception ex)
		{
			toastService.Notify(new()
			{
				AutoHide = true,
				IconName = IconName.ExclamationTriangleFill,
				Title = localizer[nameof(Resources.Error)],
				Message = GetLocalizedMessage(ex, errorMessage),
				Type = ToastType.Danger
			});
			return false;
		}
	}

	private string GetLocalizedMessage(Exception ex, string? errorMessage)
	{
		if (errorMessage != null)
			return localizer[errorMessage];

		try
		{
			if (ex is HttpExceptionBase httpException)
			{
				var args = httpException.ExceptionLocalizationArguments?.Select(x => (object)(localizer[x + ""]?.Value ?? string.Empty))?.ToArray();

				if (args != null)
					return string.Format(localizer[httpException.ExceptionLocalizationKey, args]);
				else
					return string.Format(localizer[httpException.ExceptionLocalizationKey]);
			}
			else
				return localizer[ex.Message];
		}
		catch
		{
			return ex.Message;
		}
	}
}
