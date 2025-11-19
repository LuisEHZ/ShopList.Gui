using ShopList.Gui.ViewModels;

namespace ShopList.Gui.Views;

public partial class shopListPage : ContentPage
{
	public shopListPage()
	{
		InitializeComponent();
		BindingContext = new ShopListViewModel();
	}
}