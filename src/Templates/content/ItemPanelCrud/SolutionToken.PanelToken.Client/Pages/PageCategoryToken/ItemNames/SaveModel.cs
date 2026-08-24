using SolutionToken.PanelToken.Services.ServiceCategoryToken;

namespace SolutionToken.PanelToken.Pages.PageCategoryToken.ItemNames;

public sealed class SaveModel
{
    // TODO(ai): Add validation attributes and editable properties.

    public void Load(ItemNameDto dto)
    {
        // TODO(ai): Copy editable and display-only values from the DTO.
    }

    public AddItemNameRequest ToAddRequest() => new();
    public UpdateItemNameRequest ToUpdateRequest() => new();
}
