﻿using berber.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace berber.Controllers
{
    public class IslemController : Controller
    {
        Context c=new Context();
        public IActionResult Index()
        {
            var degerler=c.Islemler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniIslem()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult YeniIslem(Islem islem)
        {
            c.Islemler.Add(islem);
            c.SaveChanges();
            return RedirectToAction("Index");
            

            
        }
        public IActionResult IslemSil(int id)
        {
            var islem=c.Islemler.Find(id); 
            c.Islemler.Remove(islem);
            c.SaveChanges();
            return RedirectToAction("Index");

            return View();
        }
        public IActionResult IslemGetir(int id)
        {
            var islem = c.Islemler.Find(id);
            return View("IslemGetir", islem);
        }
        [HttpGet]
        public IActionResult IslemGuncelle(int id)
        {
            var islem = c.Islemler.Find(id);
            if (islem == null)
            {
                return RedirectToAction("Index");
            }
            return View(islem);
        }

        [HttpPost]
        public IActionResult IslemGuncelle(Islem i)
        {
            var islem = c.Islemler.Find(i.IslemID);
            if (islem != null)
            {
                islem.Ucret = i.Ucret;
                islem.IslemAdi = i.IslemAdi;
                islem.Sure = i.Sure;

                c.Entry(islem).State = EntityState.Modified;
                c.Update(islem);
                c.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}
