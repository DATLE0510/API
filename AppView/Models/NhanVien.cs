using System.ComponentModel.DataAnnotations;

namespace AppView.Models
{
    public class NhanVien
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Độ dài tối đa là 30 kí tự")]
        public string Ten { get; set; }
        [Required(ErrorMessage = "Không được phép để trống")]
        [Range(18, 50, ErrorMessage = "Tuổi nhập vào tối thiểu phải 18 và tối đa 50")]
        public int Tuoi { get; set; }
        public int Role { get; set; }
        [RegularExpression(@"^[^@\s]+@gmail\.com$", ErrorMessage = "Email phải có đuôi @gmail.com")]
        public string Email { get; set; }
        public string Luong { get; set; }
        public bool TrangThai { get; set; }
    }
}
