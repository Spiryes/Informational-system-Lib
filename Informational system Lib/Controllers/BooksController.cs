using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Informational_system_Lib.Models;

namespace Informational_system_Lib.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookContext _context;

        public BooksController(BookContext context)
        {
            _context = context;
        }

        // Връща изглед към главната страница на книгите
        public async Task<IActionResult> Index()
        {
            return View(await _context.Books.ToListAsync());
        }

        // връща изглед към детайлите на избрана книга.(Или ако не съществува книгата връща  ненамерена страница)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.IdBook == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
        [HttpGet]

        public async Task<IActionResult> Index(string BooksSearch)
        {
            ViewData["Getbooksdetails"] = BooksSearch;
            var booksquery = from x in _context.Books select x;
            if (!String.IsNullOrEmpty(BooksSearch))
            {
                booksquery = booksquery.Where(x => x.Zaglavie.Contains(BooksSearch)  || x.Avtor.Contains(BooksSearch) || x.Janr.Contains(BooksSearch));
            }
            return View(await booksquery.AsNoTracking().ToListAsync());
        }

        // Връща изглед към страницата за създаване на книги
        public IActionResult Create()
        {
            return View();
        }

        
        // Въвеждане на книга в базата данни.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBook,Zaglavie,Avtor,Janr,Kolichestvo")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // връща изглед за редактиране на книга.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

     
        // Редактиране на книга и връщане в базата данни.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBook,Zaglavie,Avtor,Janr,Kolichestvo")] Book book)
        {
            if (id != book.IdBook)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.IdBook))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // връщане изглед за изтриване на книга.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.IdBook == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // Изтриване на книга от базата данни.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.IdBook == id);
        }
    }
}
