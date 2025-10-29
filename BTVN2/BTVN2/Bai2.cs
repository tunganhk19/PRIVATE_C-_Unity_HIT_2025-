namespace BTVN2;

public class Bai2
{
    static void Main(string[] args)
    {
        Console.WriteLine(" ~~May tinh hinh hoc mini~~");
        Console.WriteLine("Chon hinh can tinh dien tich:");
        Console.WriteLine("1. Hinh tron");
        Console.WriteLine("2. Hinh chu nhat");
        Console.WriteLine("3. Hinh tam giac");
        Console.Write("Nhap lua chon: ");
        int chon = int.Parse(Console.ReadLine());
        switch (chon)
        {
            case 1:
                Console.Write("nhap ban kinh r = ");
                int r = int.Parse(Console.ReadLine());
                Console.WriteLine("Dien tich hinh tron la: " + (Math.PI * r * r));
                break;
            case 2:
                Console.Write("nhap chieu dai a = ");
                int a = int.Parse(Console.ReadLine());
                Console.Write("nhap chieu rong b = ");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine("Dien tich hinh chu nhat la: " + (a * b));
                break;
            case 3:
                Console.Write("nhap chieu dai day d = ");
                int d = int.Parse(Console.ReadLine());
                Console.Write("nhap chieu cao h = ");
                int h = int.Parse(Console.ReadLine());
                Console.WriteLine("Dien tich hinh tam giac la: " + (d * h) / 2);
                break;
            default:
                Console.WriteLine("Lua chon khong hop le.");
                break;
        }
    }
}