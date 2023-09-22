using JustBooks.Services;
using JustBooks.View;
using JustBooks.ViewModel;
using Microsoft.Extensions.Logging;

namespace JustBooks;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.Services.AddSingleton<BookService>();

		builder.Services.AddSingleton<BooksViewModel>();

		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
