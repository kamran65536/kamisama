using BlazorBootstrap;

namespace Example.ServerToken.Client.Components;

public class CustomGridColumn<TItem> : GridColumn<TItem>
{
    public CustomGridColumn()
    {
        HeaderTextAlignment = Alignment.Center;
        TextAlignment = Alignment.Center;
        Class = "align-middle text-wrap small";
    }
}
