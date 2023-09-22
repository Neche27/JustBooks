using JustBooks.Model;
using JustBooks.ViewModel;

namespace JustBooks.View;

public partial class MainPage : ContentPage
{

	public MainPage(BooksViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
	
}

