using Lab04_PRODUCT_MANAGER;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

ProductService service = new ProductService();

// Dang ky event
service.ProductAdded += p => Console.WriteLine($"[EVENT] Da them san pham: {p.TenSP} ({p.MaSP})");
service.ProductRemoved += p => Console.WriteLine($"[EVENT] Da xoa san pham: {p.TenSP} ({p.MaSP})");

bool running = true;
while (running)
{
    ShowMenu();
    string choice = Console.ReadLine()?.Trim() ?? "";

    try
    {
        switch (choice)
        {
            case "1": AddProduct(); break;
            case "2": ShowAll(); break;
            case "3": FindById(); break;
            case "4": FindByName(); break;
            case "5": FilterByPrice(); break;
            case "6": RemoveProduct(); break;
            case "7": ShowTotalValue(); break;
            case "0":
                running = false;
                Console.WriteLine("Tam biet!");
                break;
            default:
                Console.WriteLine("Lua chon khong hop le!");
                break;
        }
    }
    catch (DuplicateProductException ex)
    {
        Console.WriteLine("Loi: " + ex.Message);
    }
    catch (ProductNotFoundException ex)
    {
        Console.WriteLine("Loi: " + ex.Message);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine("Loi du lieu: " + ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Loi khong xac dinh: " + ex.Message);
    }
}

void ShowMenu()
{
    Console.WriteLine();
    Console.WriteLine("===== PRODUCT MANAGER =====");
    Console.WriteLine("1. Them san pham");
    Console.WriteLine("2. Xuat danh sach");
    Console.WriteLine("3. Tim theo ma");
    Console.WriteLine("4. Tim theo ten");
    Console.WriteLine("5. Loc theo khoang gia");
    Console.WriteLine("6. Xoa san pham");
    Console.WriteLine("7. Tinh tong gia tri kho");
    Console.WriteLine("0. Thoat");
    Console.Write("Chon: ");
}

string ReadString(string message)
{
    Console.Write(message);
    return Console.ReadLine()?.Trim() ?? "";
}

// Nhap so, sai thi bao loi va yeu cau nhap lai (khong de chuong trinh dung)
decimal ReadDecimal(string message)
{
    while (true)
    {
        Console.Write(message);
        if (decimal.TryParse(Console.ReadLine(), out decimal value))
        {
            return value;
        }
        Console.WriteLine("Gia tri khong hop le, vui long nhap so!");
    }
}

int ReadInt(string message)
{
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            return value;
        }
        Console.WriteLine("Gia tri khong hop le, vui long nhap so nguyen!");
    }
}

void PrintProducts(List<Product> products)
{
    if (products.Count == 0)
    {
        Console.WriteLine("Khong co san pham nao.");
        return;
    }
    foreach (Product p in products)
    {
        Console.WriteLine(p);
    }
}

void AddProduct()
{
    string maSP = ReadString("Nhap ma SP: ");
    string tenSP = ReadString("Nhap ten SP: ");
    decimal price = ReadDecimal("Nhap don gia: ");
    int quantity = ReadInt("Nhap so luong: ");

    Product product = new Product(maSP, tenSP, price, quantity);
    service.AddProduct(product);
}

void ShowAll()
{
    List<Product> products = service.GetAll();
    if (products.Count == 0)
    {
        Console.WriteLine("Danh sach san pham rong.");
        return;
    }
    PrintProducts(products);
}

void FindById()
{
    string maSP = ReadString("Nhap ma SP can tim: ");
    Product? product = service.FindById(maSP);
    if (product == null)
    {
        throw new ProductNotFoundException(maSP);
    }
    Console.WriteLine(product);
}

void FindByName()
{
    string keyword = ReadString("Nhap tu khoa: ");
    PrintProducts(service.Search(keyword));
}

void FilterByPrice()
{
    decimal min = ReadDecimal("Nhap gia nho nhat: ");
    decimal max = ReadDecimal("Nhap gia lon nhat: ");
    if (min > max)
    {
        Console.WriteLine("Gia nho nhat phai <= gia lon nhat!");
        return;
    }

    // Func<Product, bool> theo yeu cau de bai
    Func<Product, bool> inRange = p => p.Price >= min && p.Price <= max;
    PrintProducts(service.Filter(inRange));
}

void RemoveProduct()
{
    string maSP = ReadString("Nhap ma SP can xoa: ");
    service.RemoveProduct(maSP);
}

void ShowTotalValue()
{
    Console.WriteLine($"Tong gia tri kho: {service.GetTotalInventoryValue():N0}");
}