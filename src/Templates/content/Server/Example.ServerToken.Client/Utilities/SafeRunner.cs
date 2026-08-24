using BlazorBootstrap;
using KamiSama.Chassis.HttpExceptions;
using KamiSama.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace Example.ServerToken.Client.Utilities;

[AutoInjectScoped<SafeRunner>]
public sealed class SafeRunner(
    ToastService toastService,
    IStringLocalizer<ClientAssemblyMarker> localizer)
{
    public async Task<bool> RunSafeAsync(Func<Task> action, string? errorMessage = null)
    {
        try
        {
            await action();
            return true;
        }
        catch (Exception exception)
        {
            toastService.Notify(new()
            {
                AutoHide = true,
                IconName = IconName.ExclamationTriangleFill,
                Title = localizer["Error"],
                Message = GetLocalizedMessage(exception, errorMessage),
                Type = ToastType.Danger,
            });
            return false;
        }
    }

    private string GetLocalizedMessage(Exception exception, string? errorMessage)
    {
        if (!string.IsNullOrWhiteSpace(errorMessage))
        {
            return localizer[errorMessage];
        }

        if (exception is not HttpExceptionBase httpException)
        {
            return localizer[exception.Message];
        }

        var arguments = httpException.ExceptionLocalizationArguments
            .Select(argument => (object)localizer[argument?.ToString() ?? string.Empty].Value)
            .ToArray();
        return localizer[httpException.ExceptionLocalizationKey, arguments];
    }
}
