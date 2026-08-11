using BlazorBootstrap;

namespace Suma.AdminPanel.Client.Components;

public class CustomGrid<TItem> : Grid<TItem>
{
	public CustomGrid()
	{
		this.AllowPaging = true;
		Class = "table table-hover table-bordered table-striped shadow-sm";
		PageSize = 10;
		Responsive = true;
		HeaderRowCssClass = "thead-dark";
		AutoHidePaging = true;
	}
}
