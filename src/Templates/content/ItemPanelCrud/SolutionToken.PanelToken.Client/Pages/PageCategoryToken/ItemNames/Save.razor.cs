using Microsoft.AspNetCore.Components;
using SolutionToken.PanelToken.Services.ServiceCategoryToken;

namespace SolutionToken.PanelToken.Pages.PageCategoryToken.ItemNames;

public partial class SaveItemNamePage : ComponentBase, IDisposable
{
    [Inject] private IAddItemName AddItem { get; set; } = default!;
    [Inject] private IUpdateItemName UpdateItem { get; set; } = default!;
    [Inject] private IFindItemNameById FindItem { get; set; } = default!;
    [Inject] private NavigationManager Navigation { get; set; } = default!;

    [Parameter] public KeyTypeToken Id { get; set; } = default!;
    protected SaveModel Model { get; } = new();
    protected bool IsEditMode => !EqualityComparer<KeyTypeToken>.Default.Equals(Id, default!);
    private readonly CancellationTokenSource lifetimeCancellation = new();

    protected override async Task OnParametersSetAsync()
    {
        if (!IsEditMode)
            return;

        var dto = await FindItem.FindByIdAsync(Id, lifetimeCancellation.Token);
        Model.Load(dto);
    }

    protected async Task SaveAsync()
    {
        if (IsEditMode)
        {
            await UpdateItem.UpdateAsync(Id, Model.ToUpdateRequest(), lifetimeCancellation.Token);
            await OnParametersSetAsync();
            return;
        }

        var created = await AddItem.AddAsync(Model.ToAddRequest(), lifetimeCancellation.Token);
        Navigation.NavigateTo($"/PageCategoryToken/ItemNames/save/{created.Id}");
    }

    public void Dispose()
    {
        lifetimeCancellation.Cancel();
        lifetimeCancellation.Dispose();
    }
}
