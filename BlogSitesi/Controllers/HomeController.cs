﻿using BlogSitesi.Data;
using BlogSitesi.Entities;
using BlogSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogSitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Posts.Take(4).ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("hakkimda")]
        public IActionResult About()
        {
            return View();
        }

        [Route("iletisim")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [Route("iletisim"), HttpPost]
        public IActionResult ContactUs(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                TempData["Message"] = "<div class='alert alert-success'>Mesajınız Başarıyla Gönderildi </div>";
                return RedirectToAction("ContactUs");
            }
            catch (Exception)
            {

                ModelState.AddModelError("", "Hata Oluştu");
            }
            return View(contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}