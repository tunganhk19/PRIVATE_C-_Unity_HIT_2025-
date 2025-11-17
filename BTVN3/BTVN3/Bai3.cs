using System;
using System.Collections.Generic;
using System.Linq;
 
namespace BTVN3
{
    struct Product
    {
        public string Name;
        public double Price;
        public int Quantity;
        public string Category;

        public Product(string name, double price, int quantity, string category)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
        }

        public override string ToString()
        {
            return $"Ten: {Name}, Gia: {Price}, SL ban: {Quantity}, Danh muc: {Category}";
        }
    }

    class Program
    {
        static Dictionary<string, Product> dsSanPham = new Dictionary<string, Product>();

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n==== MENU ====");
                Console.WriteLine("1. Them san pham");
                Console.WriteLine("2. Tra cuu theo ma");
                Console.WriteLine("3. San pham ban chay nhat");
                Console.WriteLine("4. San pham ban chay nhat theo danh muc");
                Console.WriteLine("5.Tinh tong doanh thu theo muc");
                Console.WriteLine("6. Thoat ");
                Console.Write("Chon: ");
                int chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1: ThemSanPham(); break;
                    case 2: TraCuu(); break;
                    case 3: SanPhamBanChayNhat(); break;
                    case 4: SanPhamBanChayTheoDanhMuc(); break;
                    case 5: DoanhThuTheoDanhMuc(); break;
                    case 6: return;
                    default: Console.WriteLine("Lựa chọn không hợp lệ!"); break;
                }
            }
        }

        static void ThemSanPham()
        {
            Console.Write("Nhap ma san pham ");
            string ma = Console.ReadLine();
            Console.Write("Ten san pham: ");
            string ten = Console.ReadLine();
            Console.Write("Gia ban: ");
            double gia = double.Parse(Console.ReadLine());
            Console.Write("So luong ban duoc: ");
            int sl = int.Parse(Console.ReadLine());
            Console.Write("Danh muc: ");
            string dm = Console.ReadLine();

            if (dsSanPham.ContainsKey(ma))
            {
                var sp = dsSanPham[ma];
                sp.Quantity += sl; 
                dsSanPham[ma] = sp;
                Console.WriteLine("Da cap nhat so luong ban");
            }
            else
            {
                dsSanPham.Add(ma, new Product(ten, gia, sl, dm));
                Console.WriteLine("Da them san pham pham moi!");
            }
        }

        static void TraCuu()
        {
            Console.Write("Nhap ma san pham can tim ");
            string ma = Console.ReadLine();
            if (dsSanPham.ContainsKey(ma))
            {
                Console.WriteLine(dsSanPham[ma]);
            }
            else
            {
                Console.WriteLine("Khong tim thay san pham");
            }
        }

        static void SanPhamBanChayNhat()
        {
            if (dsSanPham.Count == 0)
            {
                Console.WriteLine("Khong co du lieu");
                return;
            }

            var sp = dsSanPham.Values.OrderByDescending(p => p.Quantity).First();
            Console.WriteLine("San pham ban chay nhat: " + sp);
        }

        static void SanPhamBanChayTheoDanhMuc()
        {
            Console.Write("Nhap danh muc: ");
            string dm = Console.ReadLine();

            var spTheoDm = dsSanPham.Values.Where(p => p.Category == dm);
            if (!spTheoDm.Any())
            {
                Console.WriteLine("Khong co san pham nao trong danh muc nay!");
                return;
            }

            var sp = spTheoDm.OrderByDescending(p => p.Quantity).First();
            Console.WriteLine("San pham ban chay nhat trong danh muc: '" + dm + "': " + sp);
        }

        static void DoanhThuTheoDanhMuc()
        {
            var doanhThu = dsSanPham.Values
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    DanhMuc = g.Key,
                    TongDoanhThu = g.Sum(p => p.Price * p.Quantity)
                });

            Console.WriteLine("=== Doanh thu theo danh muc ===");
            foreach (var item in doanhThu)
            {
                Console.WriteLine($"Danh muc: {item.DanhMuc} - Tong doanh thu: {item.TongDoanhThu}");
            }
        }
    }
}