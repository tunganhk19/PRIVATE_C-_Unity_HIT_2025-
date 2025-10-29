namespace BTVN2;

public class Bai5
{
    static double diemTbLop(double[] a)
    {
        double t = 0;
        foreach(double i in a) t += i;
        return t/a.Length;
    }
    static double diemMax(double[] a)
    {
        double max = a[0];
        foreach(double i in a) if (i > max) max = i;
        return max;
    }
    static double diemMin(double[] a)
    {
        double min = a[0];
        foreach (double i in a) if (i < min) min = i;
        return min;
    }
    static double tiLeDat(double[] a)
    {
        int dat = 0;
        foreach (double i in a) if (i >= 5.0) dat++;
        return (double)dat / a.Length * 100;
    }
    static double diemGioi(double[] a)
    {
        int gioi=0; 
        foreach(int i in a) if(i >= 8.0) gioi++;
        return gioi;
    }
    static double diemKha(double[] a)
    {
        int kha = 0;
        foreach (int i in a) if (8 > i && i >= 6.5) kha++;
        return kha;
    }
    static double diemTB(double[] a)
    {
        int tb = 0;
        foreach (int i in a) if (6.5 > i && i >= 5.0) tb++;
        return tb;
    }
    static double diemYeu(double[] a)
    {
        int yeu = 0;
        foreach (int i in a) if (i < 5.0) yeu++;
        return yeu;
    }

    static void Main(string[] args)
    {
        Console.Write("Nhap so hoc sinh = ");
        int n = int.Parse(Console.ReadLine());
        double[] a = new double[n];
        Console.WriteLine("Nhap diem: ");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Sinh viên "+(i+1)+": ");
            a[i] = int.Parse(Console.ReadLine());
            if (a[i] < 0 || a[i] > 10)
            {
                Console.WriteLine("Điểm không hợp lệ");
                return;
            }
        }
        Console.WriteLine("~~Thống kê điểm lớp học~~");
        Console.WriteLine("Trung binh lop : " + diemTbLop(a));
        Console.WriteLine("Diem cao nhat : " + diemMax(a));
        Console.WriteLine("Diem thap nhat : " + diemMin(a));
        Console.WriteLine("Ti le dat : " + tiLeDat(a) + "%");
        Console.WriteLine("Phan loai : ");
        Console.WriteLine("Gioi : " + diemGioi(a) + " hoc sinh");
        Console.WriteLine("Kha : " + diemKha(a) + " hoc sinh");
        Console.WriteLine("Trung binh : " + diemTB(a) + " hoc sinh");
        Console.WriteLine("Yeu : " + diemYeu(a) + " hoc sinh");
    }
}