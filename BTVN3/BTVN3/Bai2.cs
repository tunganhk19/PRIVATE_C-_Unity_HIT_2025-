using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.JavaScript;

namespace BTVN3;

public class Bai2
{
    public static void daoNguoc(string s)
    {
        if (s != null)
        {
            string x="";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                x += s[i];
            }
            Console.WriteLine(x);
        }
    }
    static void Main(String[] args)
    {
        Console.WriteLine("Nhap chuoi ban muon dao nguoc: ");
        string input = Console.ReadLine();
        daoNguoc(input);
    }
}