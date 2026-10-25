using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL
{
    /// <summary>
    /// Lớp truy cập dữ liệu: chỉ gọi stored procedure bằng parameter,
    /// không nối chuỗi SQL từ dữ liệu người dùng.
    /// </summary>
    public class KetQuaDAL
    {
        public DataTable GetLop()
        {
            return ExecuteTable("sp_Lop_GetAll");
        }

        public DataTable GetMonHoc()
        {
            return ExecuteTable("sp_MonHoc_GetAll");
        }

        public DataTable GetKetQuaByLopMon(string maLop, string maMon)
        {
            return ExecuteTable("sp_KetQua_GetByLopMon",
                new SqlParameter("@MaLop", SqlDbType.NVarChar, 20) { Value = maLop },
                new SqlParameter("@MaMon", SqlDbType.NVarChar, 20) { Value = maMon });
        }

        /// <summary>
        /// Lưu toàn bộ các dòng trong MỘT transaction.
        /// Tất cả thành công -> Commit. Có bất kỳ dòng lỗi -> Rollback tất cả.
        /// </summary>
        /// <returns>Số dòng đã lưu</returns>
        public int SaveAll(string maMon, DataTable table)
        {
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    string maSVDangLuu = "";
                    try
                    {
                        int count = 0;
                        foreach (DataRow row in table.Rows)
                        {
                            maSVDangLuu = Convert.ToString(row["MaSV"]);

                            using (SqlCommand cmd = new SqlCommand("sp_KetQua_Save", conn, trans))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar, 20).Value = maSVDangLuu;
                                cmd.Parameters.Add("@MaMon", SqlDbType.NVarChar, 20).Value = maMon;
                                cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = Convert.ToDouble(row["Diem"]);
                                cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 255).Value = Convert.ToString(row["GhiChu"]);
                                cmd.ExecuteNonQuery();
                            }
                            count++;
                        }

                        trans.Commit();            // chỉ commit 1 lần, SAU vòng lặp
                        return count;
                    }
                    catch (Exception ex)
                    {
                        try { trans.Rollback(); } catch { /* transaction có thể đã bị hủy */ }
                        throw new Exception("Lỗi khi lưu sinh viên " + maSVDangLuu + ": " + ex.Message, ex);
                    }
                }
            }
        }

        // ---------- hàm dùng chung ----------
        private DataTable ExecuteTable(string procedureName, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(Database.ConnectionString))
            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);           // Fill tự mở/đóng connection
                    return table;
                }
            }
        }
    }
}
