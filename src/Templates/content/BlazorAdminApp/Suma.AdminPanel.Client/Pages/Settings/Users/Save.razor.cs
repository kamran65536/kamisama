using BlazorBootstrap;
using Suma.AdminPanel.Client.Utilities;
using Suma.AdminPanel.Services.Users;
using Microsoft.AspNetCore.Components;

namespace Suma.AdminPanel.Client.Pages.Settings.Users;

public partial class Save
{
	[Parameter]
	public Guid? UserId { get; set; }

	private bool InsertMode => UserId is null;
	private bool EditMode => UserId is not null;
	private UserDto? userDto;
	private readonly SaveModel model = new();
	private Modal? resetPasswordModal;

	protected override async Task OnInitializedAsync()
	{
		if (!EditMode)
			return;

		await SafeRunner.RunSafeAsync(async () =>
		{
			await LoadUserDto(CancellationToken.None);
		});
	}

	private async Task LoadUserDto(CancellationToken cancellationToken)
	{
		if (UserId is null)
			return;

		userDto = await FindUserByIdService.FindByIdAsync(UserId.Value, cancellationToken);
		model.Username = userDto.Username;
		model.Email = userDto.Email;
		model.IsEnabled = userDto.IsEnabled;
	}

	private async Task OnSubmitAsync()
	{
		var isSuccess = InsertMode
			? await SafeRunner.RunSafeAsync(AddUserAsync)
			: await SafeRunner.RunSafeAsync(UpdateUserAsync);

		if (isSuccess)
			NavigationManager.NavigateTo("/settings/users", false);
	}

	private Task AddUserAsync()
	{
		return AddUserService.AddAsync(
			new AddUserRequest(
				model.Username,
				model.Email,
				model.Password,
				model.IsEnabled),
			CancellationToken.None);
	}

	private Task UpdateUserAsync()
	{
		return UpdateUserService.UpdateAsync(
			UserId!.Value,
			new UpdateUserRequest(
				model.Username,
				model.Email,
				model.IsEnabled),
			CancellationToken.None);
	}

	private async Task ResetPasswordClicked()
	{
		if (resetPasswordModal is not null)
			await resetPasswordModal.ShowAsync();
	}

	private async Task EnableUserClicked()
	{
		if (UserId is null)
			return;

		var isSuccess = await SafeRunner.RunSafeAsync(async () =>
		{
			await EnableUserService.EnableAsync(UserId.Value, CancellationToken.None);
			await LoadUserDto(CancellationToken.None);
		});

		if (isSuccess)
			StateHasChanged();
	}

	private async Task DisableUserClicked()
	{
		if (UserId is null)
			return;

		var isSuccess = await SafeRunner.RunSafeAsync(async () =>
		{
			await DisableUserService.DisableAsync(UserId.Value, CancellationToken.None);
			await LoadUserDto(CancellationToken.None);
		});

		if (isSuccess)
			StateHasChanged();
	}

	private async Task ResetUserPassword_ResetClicked(ResetUserPasswordRequest request)
	{
		var isSuccess = await SafeRunner.RunSafeAsync(async () =>
		{
			await ResetUserPasswordService.ResetPasswordAsync(request, CancellationToken.None);
		});

		if (!isSuccess)
			return;

		if (resetPasswordModal is not null)
			await resetPasswordModal.HideAsync();

		ToastService.Notify(new ToastMessage
		{
			AutoHide = true,
			IconName = IconName.CheckCircleFill,
			Message = localizer["Password reset successfully."],
			Title = localizer["ResetPassword"],
			Type = ToastType.Success,
		});
	}
}

