using AspNetSandbox;
using AspNetSandbox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class BooksServiceTests
    {
        [Fact]
        public void ConvertResponseToWeatherForecastTest()
        {
            // Assume
            var booksService= new BooksService();


            // Act
            booksService.Post(new Book
            {
                Title = "Added book",
                Author = "Someone",
                Language = "English"
            });
            booksService.Delete(2);
            booksService.Post(new Book
            {
                Title = "Added book 2",
                Author = "Someone 2",
                Language = "English 2"
            });



            // Assert
            Assert.Equal("Added book 2", booksService.Get(3).Title);
        }
    }
}
