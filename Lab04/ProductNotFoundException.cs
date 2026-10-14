using System;
using System.Collections.Generic;
using System.Text;

namespace Lab04_PRODUCT_MANAGER
{
    public class ProductNotFoundException : Exception
    {
        public string MaSP { get;  }
        public ProductNotFoundException(string maSP)
            : base($"Khong tim thay san pham co ma '{maSP}'!")
        {
            MaSP = maSP;
        }
    }
}
