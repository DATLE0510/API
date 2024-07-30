 using AppView.Models;

namespace AppView.iServices
{
    public interface INhanVienServices
    {
        List<NhanVien> GetAll();
        NhanVien GetById(Guid id);
        bool Create(NhanVien nv);
        bool Update(NhanVien nv);
        bool Delete(Guid Id);
    }
}
