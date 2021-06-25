using Lab03.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab03.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListBook()
        {
            Model1 context = new Model1();
            var listBook = context.Book.ToList();
            return View(listBook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            Model1 context = new Model1();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult Create()
        {
            
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try {
                Model1 context = new Model1();
                context.Book.AddOrUpdate(book);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                var a = "Anh Tuan";
            }
            

            return RedirectToAction("ListBook");
        }
        
        public ActionResult Edit(int id)
        {
            Model1 context = new Model1();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            Model1 context = new Model1();
            Book bookupdate = context.Book.SingleOrDefault(p => p.ID == book.ID);
            if (bookupdate != null)
            {
                context.Book.AddOrUpdate(book);
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }
        public ActionResult Delete(int id)
        {
            Model1 context = new Model1();
            Book book = context.Book.SingleOrDefault(p => p.ID==id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [Authorize]
        [HttpPost]
        //public ActionResult DeleteBook(int id)
        //{
        //    Model1 context = new Model1();
        //    Book book = context.Book.SingleOrDefault(p => p.ID == id);
        //    if (book != null)
        //    {
        //        context.Book.AddOrUpdate(book);
        //        context.SaveChanges();
        //    }
        //    return RedirectToAction("ListBook");
        //}
        public ActionResult DeleteBook(int id)
        {
            Model1 context = new Model1();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if (book != null)
            {
                context.Book.Remove(book);
                context.SaveChanges();

            }
            return RedirectToAction("ListBook");
        }
    }
}
    
