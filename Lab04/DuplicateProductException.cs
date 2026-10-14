using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_PRODUCT_MANAGER
{
    public class DuplicateProductException : Exception
    {
        public string MaSP { get; }
        public DuplicateProductException(string maSP)
            : base($"San pham co ma '{maSP}' da ton tai!")
        {
            MaSP = maSP;
        }
    }
}
