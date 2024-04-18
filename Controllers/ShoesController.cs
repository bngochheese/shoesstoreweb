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
using ShoesStoreWebsite.Data;
using ShoesStoreWebsite.Models;

namespace ShoesStoreWebsite.Controllers
{
    public class ShoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ShoesController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        // GET: Shoes
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> Index(string searchString)
        { 
            
            var shoes = from s in _context.Shoes
                        select s;
            // check chuỗi có ?
            if (!string.IsNullOrEmpty(searchString))
            {
                // Lọc
                shoes = shoes.Where(s => s.Name != null && s.Name.Contains(searchString));
            }
            return View(await shoes.ToListAsync());
        }
        // GET: Shoes/NikeAirForce1
        [HttpGet]
        [Route("Shoes/NikeAirForce1")]
        public async Task<IActionResult> NikeAirForce1(string searchString, int page = 1)
        {
            int pageSize = 5; // Số mục trên mỗi trang

            var shoesQuery = _context.Shoes.Where(s => s.Category == "Nike Air Force 1");

            if (!string.IsNullOrEmpty(searchString))
            {
                shoesQuery = shoesQuery.Where(s => s.Name != null && s.Name.Contains(searchString));
            }

            // Tính toán số lượng mục bỏ qua và lấy
            int skip = (page - 1) * pageSize;
            var shoes = await shoesQuery.Skip(skip).Take(pageSize).ToListAsync();

            // Tính tổng số giày Nike Air Force 1
            int totalShoes = await shoesQuery.CountAsync();

            // Truyền thông tin phân trang đến view
            ViewBag.TotalShoes = totalShoes;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;

            return View(shoes);
        }

        // GET: Shoes/NikeAirJordan
        [HttpGet]
        [Route("Shoes/NikeAirJordan")]
        public async Task<IActionResult> NikeAirJordan(string searchString, int page = 1)
        {
            int pageSize = 5; // Số mục trên mỗi trang

            var shoesQuery = _context.Shoes.Where(s => s.Category == "Nike Air Jordan");

            if (!string.IsNullOrEmpty(searchString))
            {
                shoesQuery = shoesQuery.Where(s => s.Name != null && s.Name.Contains(searchString));
            }

            // Tính toán số lượng mục bỏ qua và lấy
            int skip = (page - 1) * pageSize;
            var shoes = await shoesQuery.Skip(skip).Take(pageSize).ToListAsync();

            // Tính tổng số giày Nike Air Force 1
            int totalShoes = await shoesQuery.CountAsync();

            // Truyền thông tin phân trang đến view
            ViewBag.TotalShoes = totalShoes;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;

            return View(shoes);
        }
        // GET: Shoes/NikeAirMax
        [HttpGet]
        [Route("Shoes/NikeAirMax")]
        public async Task<IActionResult> NikeAirMax(string searchString, int page = 1)
        {
            int pageSize = 5; // Số mục trên mỗi trang

            var shoesQuery = _context.Shoes.Where(s => s.Category == "Nike Air Max");

            if (!string.IsNullOrEmpty(searchString))
            {
                shoesQuery = shoesQuery.Where(s => s.Name != null && s.Name.Contains(searchString));
            }

            // Tính toán số lượng mục bỏ qua và lấy
            int skip = (page - 1) * pageSize;
            var shoes = await shoesQuery.Skip(skip).Take(pageSize).ToListAsync();

            // Tính tổng số giày Nike Air Force 1
            int totalShoes = await shoesQuery.CountAsync();

            // Truyền thông tin phân trang đến view
            ViewBag.TotalShoes = totalShoes;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;

            return View(shoes);
        }
        // GET: Shoes/NikeRunning
        [HttpGet]
        [Route("Shoes/NikeRunning")]
        public async Task<IActionResult> NikeRunning(string searchString, int page = 1)
        {
            int pageSize = 5; // Số mục trên mỗi trang

            var shoesQuery = _context.Shoes.Where(s => s.Category == "Nike Running");

            if (!string.IsNullOrEmpty(searchString))
            {
                shoesQuery = shoesQuery.Where(s => s.Name != null && s.Name.Contains(searchString));
            }

            // Tính toán số lượng mục bỏ qua và lấy
            int skip = (page - 1) * pageSize;
            var shoes = await shoesQuery.Skip(skip).Take(pageSize).ToListAsync();

            // Tính tổng số giày Nike Air Force 1
            int totalShoes = await shoesQuery.CountAsync();

            // Truyền thông tin phân trang đến view
            ViewBag.TotalShoes = totalShoes;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;

            return View(shoes);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var shoes = await _context.Shoes.Include(s => s.Comments) // Include comments when retrieving shoe details
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoes == null)
            {
                return NotFound();
            }
            return View(shoes);
        }
        // POST: Shoes/AddComment
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int shoesId, string comment)
        {
            var shoes = await _context.Shoes.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == shoesId);
            if (shoes == null)
            {
                return NotFound();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 

            var newComment = new Comment
            {
                ShoesId = shoesId,
                Content = comment,
                CreatedDate = DateTime.Now,
                UserId = userId 

            };
            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = shoesId });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
            {
                return NotFound();
            }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id = comment.ShoesId });
        }
        // GET: Shoes/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }
        // POST: Shoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Gender,Brand,Color,Material,Size,Price,URLImage")] Shoes shoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoes);
        }
        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoes = await _context.Shoes.FindAsync(id);
            if (shoes == null)
            {
                return NotFound();
            }
            return View(shoes);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Gender,Brand,Color,Material,Size,Price")] Shoes shoes)
        {
            if (id != shoes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoesExists(shoes.Id))
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
            return View(shoes);
        }



        // GET: Shoes/Delete/5
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var shoes = await _context.Shoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoes == null)
            {
                return NotFound();
            }
            return View(shoes);
        }
        // POST: Shoes/Delete/5
        [Authorize(Roles = "Admin")]

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoes = await _context.Shoes.FindAsync(id);
            if (shoes != null)
            {
                _context.Shoes.Remove(shoes);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        //filter data
        public async Task<IActionResult> NikeAirForce1()
        {
            var nikeAirForce1Shoes = await _context.Shoes.Where(s => s.Category == "Nike Air Force 1").ToListAsync();
            return View("NikeAirForce1", nikeAirForce1Shoes); // Trả về view NikeAirForce1.cshtml
        }
        public async Task<IActionResult>NikeAirMax()
        {
            var NikeAirMaxShoes = await _context.Shoes.Where(s => s.Category == "Nike Air Max").ToListAsync();
            return View("NikeAirMax", NikeAirMaxShoes);
        }
        public async Task<IActionResult> NikeAirJordan()
        {
            var NikeAirJordanShoes = await _context.Shoes.Where(s => s.Category == "Nike Air Jordan").ToListAsync();
            return View("NikeAirJordan", NikeAirJordanShoes);
        }
        public async Task<IActionResult> NikeRunning()
        {
            var NikeRunningShoes = await _context.Shoes.Where(s => s.Category == "Nike Running").ToListAsync();
            return View("NikeRunning", NikeRunningShoes);
        }
        private bool ShoesExists(int id)
        {
            return _context.Shoes.Any(e => e.Id == id);
        }
    }
}
