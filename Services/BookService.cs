using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using JustBooks.Model;

namespace JustBooks.Services
{
    public class BookService
    {
        HttpClient httpClient;
        public BookService() 
        { 
            httpClient = new HttpClient();
        }

        List<Book> booklist = new();

        public async Task<List<Book>> GetBooks()
        {
            if (booklist?.Count > 0)
                return booklist;

            var url = "https://raw.githubusercontent.com/benoitvallon/100-best-books/master/books.json"; 
            //https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/MonkeysApp/monkeydata.json
            
            var response = await httpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                booklist = await response.Content.ReadFromJsonAsync<List<Book>>();
            }

            return booklist;
        }

    }
}
