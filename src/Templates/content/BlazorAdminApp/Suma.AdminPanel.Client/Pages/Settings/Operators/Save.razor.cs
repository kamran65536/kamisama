using BlazorBootstrap;
using Suma.AdminPanel.Client.Utilities;
using Suma.AdminPanel.Services.Operators;
using Microsoft.AspNetCore.Components;

namespace Suma.AdminPanel.Client.Pages.Settings.Operators;

public partial class Save
{
	[Parameter]
	public Guid? OperatorId { get; set; }

	private bool InsertMode => OperatorId is null;
	private bool EditMode => OperatorId is not null;
	private OperatorDto? operatorDto;
	private readonly SaveModel model = new();
	private Modal? resetPasswordModal;

	protected override async Task OnInitializedAsync()
	{
		if (!EditMode)
			return;

		await SafeRunner.RunSafeAsync(async () =>
		{
			await LoadOperatorDto(CancellationToken.None);
		});
	}

	private async Task LoadOperatorDto(CancellationToken cancellationToken)
	{
		if (OperatorId is null)
			return;

		operatorDto = await FindOperatorByIdService.FindByIdAsync(OperatorId.Value, cancellationToken);
		model.Username = operatorDto.Username;
		model.Email = operatorDto.Email;
		model.IsEnabled = operatorDto.IsEnabled;
	}

	private async Task OnSubmitAsync()
	{
		var isSuccess = InsertMode
			? await SafeRunner.RunSafeAsync(AddOperatorAsync)
			: await SafeRunner.RunSafeAsync(UpdateOperatorAsync);

		if (isSuccess)
			NavigationManager.NavigateTo("/settings/operators", false);
	}

	private Task AddOperatorAsync()
	{
		return AddOperatorService.AddAsync(
			new AddOperatorRequest(
				model.Username,
				model.Email,
				model.Password,
				model.IsEnabled),
			CancellationToken.None);
	}

	private Task UpdateOperatorAsync()
	{
		return UpdateOperatorService.UpdateAsync(
			OperatorId!.Value,
			new UpdateOperatorRequest(
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

	private async Task EnableOperatorClicked()
	{
		if (OperatorId is null)
			return;

		var isSuccess = await SafeRunner.RunSafeAsync(async () =>
		{
			await EnableOperatorService.EnableAsync(OperatorId.Value, CancellationToken.None);
			await LoadOperatorDto(CancellationToken.None);
		});

		if (isSuccess)
			StateHasChanged();
	}

	private async Task DisableOperatorClicked()
	{
		if (OperatorId is null)
			return;

		var isSuccess = await SafeRunner.RunSafeAsync(async () =>
		{
			await DisableOperatorService.DisableAsync(OperatorId.Value, CancellationToken.None);
			await LoadOperatorDto(CancellationToken.None);
		});

		if (isSuccess)
			StateHasChanged();
	}

	private async Task ResetOperatorPassword_ResetClicked(ResetOperatorPasswordRequest request)
	{
		var isSuccess = await SafeRunner.RunSafeAsync(async () =>
		{
			await ResetOperatorPasswordService.ResetPasswordAsync(request, CancellationToken.None);
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
