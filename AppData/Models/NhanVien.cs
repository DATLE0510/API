using System.ComponentModel.DataAnnotations;

namespace AppData.Models
{
    public class NhanVien
    {
        [Key]
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public int Tuoi { get; set; }
        public int Role { get; set; }
        public string Email { get; set; }
        public string Luong { get; set; }
        public bool TrangThai { get; set; }

    }
}
