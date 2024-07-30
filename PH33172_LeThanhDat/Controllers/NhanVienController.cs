using AppData;
using AppData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace App_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase 
    {
        AppDbContext context = new AppDbContext();
        [HttpGet("get-all-nhan-vien")]
        public IActionResult GetAll()
        {
            return Ok(context.nhanViens.ToList());
        }
        [HttpGet("get-by-id")]
        public IActionResult GetById(Guid Id)
        {
            return Ok(context.nhanViens.Find(Id));
        }
        [HttpPost("create-nhan-vien")]
        public IActionResult Create(NhanVien nv)
        {
            try
            {
                nv.Id = Guid.NewGuid();
                context.nhanViens.Add(nv);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok("Lỗi:" + ex.Message);
            }
        }
        [HttpPut("update-nhan-vien")]
        public IActionResult Update(NhanVien nhanVien)
        {
            try
            {
                var data = context.nhanViens.Find(nhanVien.Id);
                data.Ten = nhanVien.Ten;
                data.Tuoi = nhanVien.Tuoi;
                data.Role = nhanVien.Role;
                data.Luong = nhanVien.Luong;
                data.Email = nhanVien.Email;
                data.TrangThai = nhanVien.TrangThai;
                context.nhanViens.Update(data);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {

                return Ok("Lỗi: " + ex.Message);
            }
        }
        [HttpDelete("delete-nhan-vien")]
        public IActionResult Delete(Guid Id)
        {
            try
            {
                var data = context.nhanViens.Find(Id);
                context.nhanViens.Remove(data);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok("Lỗi: " + ex.Message);
            }
        }
    }
}
