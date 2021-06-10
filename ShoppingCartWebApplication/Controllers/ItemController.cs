using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingCartWebApplication.Data;
using ShoppingCartWebApplication.Models;

namespace ShoppingCartWebApplication.Controllers
{
    [Authorize]
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Item
        public async Task<IActionResult> Index()
        {
            var loggedInUserId = GetLoggedInUserId();

            var itemIds = await _context.UserItems
                .Where(m => m.UserId == loggedInUserId)
                .Select(m => m.ItemId)
                .ToListAsync();

            var shoppingCartItemsForUser = await _context.Items
                .Where(m => itemIds.Contains(m.Id))
                .ToListAsync();

            return View(shoppingCartItemsForUser);
        }

        // GET: Item/Create
        public IActionResult CreateOrModify(int id = 0)
        {
            if (id == 0)
                return View(new Item());
            else
                return View(_context.Items.Find(id));
        }

        // POST: Item/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrModify([Bind("Id,Name,Description,Price,Quantity,DateAdded,DateModified")] Item item)
        {
            if (ModelState.IsValid)
            {
                if (item.Id == 0)
                {
                    item.DateAdded = DateTime.Now;
                    item.DateModified = DateTime.Now;
                    _context.Items.Add(item);
                }
                else
                {
                    item.DateModified = DateTime.Now;
                    _context.Items.Update(item);
                }
                await _context.SaveChangesAsync();

                AddItemsToShoppingCartByLoggedInUser(item);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Item/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public void AddItemsToShoppingCartByLoggedInUser(Item item)
        {

            _context.UserItems.Add(new UserItem
            {
                UserId = GetLoggedInUserId(),
                ItemId = item.Id
            });
        }

        public string GetLoggedInUserId()
        {
           return this.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
