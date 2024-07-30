using AppView.iServices;
using AppView.Models;
using System.Diagnostics.CodeAnalysis;
using System.Net.WebSockets;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System;

namespace AppView.Services
{
    public class NhanVienServices : INhanVienServices
    {
        HttpClient client;
        public NhanVienServices()
        {
            client = new HttpClient();
        }
        public bool Create(NhanVien nv)
        {
            string Url = "https://localhost:7260/api/NhanVien/create-nhan-vien";
            var response = client.PostAsJsonAsync(Url, nv).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public bool Delete(Guid id)
        {
            string url = $"https://localhost:7260/api/NhanVien/delete-nhan-vien?Id={id}";
            var response = client.DeleteAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public List<NhanVien> GetAll()
        {
            string url = "https://localhost:7260/api/NhanVien/get-all-nhan-vien";
            var response = client.GetStringAsync(url).Result;
            List<NhanVien> result = JsonConvert.DeserializeObject<List<NhanVien>>(response);
            return result;
        }

        public NhanVien GetById(Guid id)
        {
            string url = $"https://localhost:7260/api/NhanVien/get-by-id?id={id}";
            var response = client.GetStringAsync($"{url}").Result;
            NhanVien result = JsonConvert.DeserializeObject<NhanVien>(response);
            return result;
        }

        public bool Update(NhanVien nv)
        {
            string url = "https://localhost:7260/api/NhanVien/update-nhan-vien";
            var response = client.PutAsJsonAsync(url, nv).Result;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
