namespace BTVN2;
using System;

public class Bai1
{
    private static void nhap(out int a, out int b, out int c)
    {
        Console.Write("\nDo dai canh a = ");
        a = int.Parse(Console.ReadLine());
        Console.Write("\nDo dai canh b = ");
        b = int.Parse(Console.ReadLine());
        Console.Write("\nDo dai canh c = ");
        c = int.Parse(Console.ReadLine());
    }

    private static void checkTamGiac(int a, int b, int c)
    {
        if (a + b > c && a + c > b && b + c > a)
        {
            if (a == b && b == c)
                Console.WriteLine("Tam giac deu");
            else if (a == b || a == c || b == c)
                Console.WriteLine("Tam giac can");
            else
                Console.WriteLine("Tam giac thuong");
        }
        else
        {
            Console.WriteLine("Day khong phai la 3 canh cua tam giac");
        }
    }

    static void Main(string[] args)
    {
        int a, b, c;
        nhap(out a, out b, out c);
        checkTamGiac(a, b, c);
    }
}