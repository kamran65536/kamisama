using BlazorBootstrap;

namespace Example.ServerToken.Client.Components;

public class CustomGrid<TItem> : Grid<TItem>
{
    public CustomGrid()
    {
        AllowPaging = true;
        Class = "table table-hover table-striped align-middle mb-0 custom-grid";
        PageSize = 10;
        Responsive = true;
        HeaderRowCssClass = "custom-grid__header-row";
        AutoHidePaging = true;
    }
}
