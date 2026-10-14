using System;

namespace Lab04_PRODUCT_MANAGER
{
    public class Product : IEntity
    {
        private decimal price;
        private int quantity;

        public string MaSP { get; set; }
        public string TenSP { get; set; }

        // gia khong duoc am
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Don gia khong duoc am!");
                }
                price = value;
            }
        }

        // sluog khong duoc am
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("So luong khong duoc am!");
                }
                quantity = value;
            }
        }

        // cai dat ientity id chinh la MaSP
        public string Id
        {
            get { return MaSP; }
        }

        public Product(string maSP, string tenSP, decimal price, int quantity)
        {
            MaSP = maSP;
            TenSP = tenSP;
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Ma: {MaSP} | Ten: {TenSP} | Gia: {Price:N0} | So luong: {Quantity}";
        }
    }
}