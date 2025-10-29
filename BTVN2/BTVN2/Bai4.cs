namespace BTVN2;

public class Bai4
{
    private static void nhapchuoi(out string nhap, out string tim, out string chen)
    {
        Console.Write("Nhap chuoi ban dau: ");
        nhap = Console.ReadLine();
        Console.Write("Nhap chuoi can tim: ");
        tim = Console.ReadLine();
        Console.Write("Nhap chuoi can chen: ");
        chen = Console.ReadLine();
    }

    private static void ghepTu(string nhap, string tim, string chen)
    {
        int index = nhap.IndexOf(tim);
        if (index != -1)
        {
            string chuoi = nhap.Insert(index, chen + " ");
            Console.WriteLine("Ket qua: " + chuoi);
        } else
        {
            Console.WriteLine("Không thể ghép từ – đoạn không tồn tại!");
        }
    }
    static void Main(string[] args)
    {
        string nhap, tim, chen;
        nhapchuoi(out nhap, out tim, out chen);
        ghepTu(nhap, tim, chen);
    }
}