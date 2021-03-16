using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksControler : ControllerBase
    {
       private static List<Models.Book> books = new List<Models.Book>()
        {
            new Models.Book() {ID=Guid.NewGuid(), Name="Permanent Record", Author="Edward Snowden", FirstEdition= 2019},
            new Models.Book() {ID=Guid.NewGuid(), Name="Mere Christianity", Author="C.S.Lewis", FirstEdition=1952},
            new Models.Book() {ID=Guid.NewGuid(), Name="The Fellowship of the Ring", Author="J.R.R. Tolkien", FirstEdition=1954}
        };

        [HttpGet]
        public Models.Book[] Get()
        {
            return books.ToArray();
        }

        [HttpPost]
        public void Post([FromBody] Models.Book book)
        {
            if (book.ID == Guid.Empty)
                book.ID = Guid.NewGuid();
            books.Add(book);
        }

        [HttpPut]
        public void Put([FromBody] Models.Book book)
        {
            Models.Book book1 = books.FirstOrDefault(x => x.ID == book.ID);
            book1.Name = book.Name;
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            books.RemoveAll(book => book.ID == id);

            //foreach (Models.Duckbill duckbill in duckbills)
            //{
            //    if (duckbill.ID == id)
            //    {
            //        duckbills.Remove(duckbill);
            //    }
            //}
        }
    }
}

