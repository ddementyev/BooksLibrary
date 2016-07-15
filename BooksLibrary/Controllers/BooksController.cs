using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksLibrary.Controllers
{
    public class BooksController : Controller
    {
        // GET: Book
        public ActionResult List()
        {
            var books = new List<BookInfo>();
            books.Add(new BookInfo()
            {
                Id = 1,
                Title = "Книга",
                Authors = new List<Author>()
                {
                   new Author()
                   {
                       Name = "Имя1",
                       Surname = "Фамилия1"
                   },
                   new Author()
                   {
                       Name = "Имя2",
                       Surname = "Фамилия2"
                   },
                   
                   new Author()
                   {
                       Name = "Имя3",
                       Surname = "Фамилия3"
                   }
                },
                Pages = 300,
                Year = "1907",
                Publisher = "Tmb",
                ISBN = "90906890423423",
                Cover = new byte[0],
            });

            Session["books"] = books;
            return View();
        }

        [HttpGet]
        public JsonResult GetBooks()
        {
            return Json(Session["books"], JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void AddBook(BookInfo book)
        {
            var books = Session["books"] as List<BookInfo>;
            books.Add(book);
        }
    }
}