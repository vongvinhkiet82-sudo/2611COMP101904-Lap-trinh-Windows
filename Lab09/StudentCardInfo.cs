using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lab09_InTheSinhVien
{
    internal class StudentCardInfo
    {
        public string StudentId { get; set; } = "";
        public string FullName { get; set; } = "";
        public string ClassName { get; set; } = "";
        public string Faculty { get; set; } = "";
        public string Course { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public Image Photo { get; set; }
    }
}
