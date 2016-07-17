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
        public ActionResult List()
        {
            var books = Session["books"] as List<BookInfo>;
            if (books == null)
            {
                books = new List<BookInfo>();
            }
            Session["books"] = books;
            return View();
        }

        [HttpGet]
        public JsonResult GetBooks()
        {
            return Json(Session["books"], JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddBook(BookInfo book)
        {        
            var books = Session["books"] as List<BookInfo>;

            book.Id = books.Count() == 0 ? 1 : books.LastOrDefault().Id + 1;
            if (book.Cover == null)
                book.Cover = GetDefaultCover();
            if (book.Publisher == null)
                book.Publisher = "No publisher";

            books.Add(book);
            Session["books"] = books;

            return Json("OK");
        }

        public string GetDefaultCover()
        {
            var path = Server.MapPath("~/Content/img/nocover.jpg");
            var bytes = System.IO.File.ReadAllBytes(path);
            return "data:image/jpg;base64," + Convert.ToBase64String(bytes);
        }

        [HttpPost]
        public JsonResult DeleteBook(int id)
        {
            var books = Session["books"] as List<BookInfo>;
            books.Remove(books.Single(a => a.Id == id));
            Session["books"] = books;

            return Json("OK");
        }

        [HttpPost]
        public JsonResult EditBook(int id)
        {
            return Json((Session["books"] as List<BookInfo>).FirstOrDefault(a=>a.Id == id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ChangeBook(BookInfo newValues)
        {
            var books = Session["books"] as List<BookInfo>;
            var oldValues = books.FirstOrDefault(a => a.Id == newValues.Id);

            if (newValues.Cover == null)
                newValues.Cover = GetDefaultCover();

            int index = books.IndexOf(oldValues);
            if (index != -1)
                books[index] = newValues;

            Session["books"] = books;
            return Json("OK");
        }
    }
}