namespace QLSinhVienLab12.DAL
{
    /// <summary>
    /// Nơi duy nhất chứa chuỗi kết nối. Đổi server/máy thực hành chỉ cần sửa ở đây.
    /// </summary>
    public static class Database
    {
        // Data Source=.            : SQL Server mặc định trên máy local
        // Máy dùng SQLEXPRESS      : đổi thành  Data Source=.\SQLEXPRESS
        public static string ConnectionString =
            "Data Source=.;Initial Catalog=QLSinhVienLab12;Integrated Security=True;TrustServerCertificate=True";
    }
}
