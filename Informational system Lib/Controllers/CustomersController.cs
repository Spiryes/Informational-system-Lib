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
    public class CustomersController : Controller
    {
        private readonly CustomerContext _context;

        public CustomersController(CustomerContext context)
        {
            _context = context;
        }

        // Връща изглед към главната страница на клиентите.
        public async Task<IActionResult> Index()
        {
            return View(await _context.Customer.ToListAsync());
        }

        // връща изглед към детайлите на избран клиент.(Или ако не съществува книгата връща  ненамерена страница)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        [HttpGet]
        public async Task<IActionResult> Index(string CustomerSearch)
        {
            ViewData["Getcustomersdetails"] = CustomerSearch;
            var customerquary = from x in _context.Customer select x;
            if (!String.IsNullOrEmpty(CustomerSearch))
            {
                customerquary = customerquary.Where(x => x.EGN.Contains(CustomerSearch));

            }
            return View(await customerquary.AsNoTracking().ToListAsync());
        }

        // Връща изглед към страницата за вписване на клиенти
        public IActionResult Create()
        {
            return View();
        }

        // Въвеждане на клинти в базата данни.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,FirstName,SecondName,ThirdName,Addres,PhoneNumber,EGN,NameOfBook,DateOfRecord,DateOfDeregistration")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // връща изглед за редактиране на клиент.
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // Редактиране на клиент и връщане в базата данни.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,FirstName,SecondName,ThirdName,Addres,PhoneNumber,EGN,NameOfBook,DateOfRecord,DateOfDeregistration")] Customer customer)
        {
            if (id != customer.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.id))
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
            return View(customer);
        }

        // връщане изглед за изтриване на клиент.
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // Изтриване на клиент от базата данни.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.id == id);
        }
    }
}
