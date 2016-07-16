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
            var books = Session["books"] as List<BookInfo>;

            if (books == null)
            {
                books = new List<BookInfo>();
            }

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
                   },

                   new Author()
                   {
                       Name = "Имя4",
                       Surname = "Фамилия5"
                   }
                },
                Pages = 305345345345345,
                Year = "1904657",
                Publisher = "Thertgsdfgsdgsdfgdgsdgdhertmb",
                ISBN = "90906890425435353453423",
                Cover = null,
            });

            books.Add(new BookInfo()
            {
                Id = 2,
                Title = "Книга2",
                Authors = new List<Author>()
                {
                   new Author()
                   {
                       Name = "Имя2",
                       Surname = "Фамилия2"
                   },
                   new Author()
                   {
                       Name = "Имя3",
                       Surname = "Фамилия3"
                   },
                },
                Pages = 5300534534534534,
                Year = "1645987",
                Publisher = "Mtrhtrgfdsdfgsdgsgsdfgsfdgsfdgsfdehsc",
                ISBN = "456987123",
                Cover = null,
            });

            Session["books"] = books;
            return View();
        }

        [HttpGet]
        public JsonResult GetBooks()
        {
            var res = Session["books"] as List<BookInfo>;
            return Json(Session["books"], JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddBook(BookInfo book)
        {
            var books = Session["books"] as List<BookInfo>;
            books.Add(book);
            Session["books"] = books;
            var vvv = Session["books"] as List<BookInfo>;
            return Json("OK");
        }
    }
}