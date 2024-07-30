using AppView.iServices;
using AppView.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppView.Controllers
{
    public class NhanVienController : Controller
    {
        INhanVienServices _services;
        public NhanVienController(INhanVienServices services)
        {
            _services = services;
        }
        public IActionResult GetAll()
        {
            List<NhanVien> nhanViens = _services.GetAll();
            return View(nhanViens);
        }
        public IActionResult Details(Guid Id)
        {
            var data = _services.GetById(Id);
            return View(data);
        }
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NhanVien nv)
        {
            if (nv.TrangThai != true)
            {
                TempData["true"] = "Trạng thái phải là true";
                return View(nv);
            }    
            _services.Create(nv);
            return RedirectToAction("GetAll");
        }
        public IActionResult Edit(Guid Id)
        {
            var data = _services.GetById(Id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(NhanVien nv)
        {
            _services.Update(nv);
            return RedirectToAction("GetAll");
        }
        public IActionResult Delete(Guid Id)
        {
            var data = _services.GetById(Id);
            _services.Delete(Id);
            return RedirectToAction("GetAll");
        }
    }
}
