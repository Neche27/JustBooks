using JustBooks.Model;
using JustBooks.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Debug = System.Diagnostics.Debug;

namespace JustBooks.ViewModel
{
    public partial class BooksViewModel : BaseViewModel
    {
        BookService bookService;
        public ObservableCollection<Book> Books { get;} = new();

        public BooksViewModel(BookService bookService) 
        {
            Title = "JustBooks";
            this.bookService = bookService;
        }

        [RelayCommand]
        async Task GetBooksAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy= true;
                var books = await bookService.GetBooks();

                if (Books.Count != 0)
                    Books.Clear();

                foreach(var book in books)
                    Books.Add(book);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!!", 
                    $"Unable to get Books: {ex.Message}", "Ok");
            }
            finally 
            {
                IsBusy = false;
            }
        }
    }
}
