using BlogSitesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSitesi.Controllers
{
    public class PostsController : Controller
    {
        private readonly DatabaseContext _context;

        public PostsController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _context.Posts.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> SearchAsync(string word)
        {
            var model = await _context.Posts.Where(p=>p.Name.Contains(word)).ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var model = await _context.Posts.FindAsync(id);
            return View(model);
        }
    }
}
