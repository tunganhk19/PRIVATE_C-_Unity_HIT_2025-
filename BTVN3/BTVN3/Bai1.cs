
using System;
using System.Collections.Generic;
namespace BTVN3
{
    class Bai1
    {
        public static bool kiemTraHamHopLe(string s)
        {
            Stack<char> chuoi = new Stack<char>();
            foreach (char c in chuoi)
            {
                if (c == '{' || c == '[' || c == '(')
                {
                    chuoi.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (chuoi.Count==0) return false;
                    char temp = chuoi.Pop();

                    if ((c == '{' && temp != '}') || (c == '[' && temp != ']') || (c == '(' && temp != ')'))
                    {
                        return false;
                    }
                }
            }
            return (chuoi.Count == 0);
        } 
        
        static void Main(string[] args)
        {
            Console.WriteLine("Nhap chuoi dau ngoac: ");
            string input = Console.ReadLine();
            if (kiemTraHamHopLe(input))
            {
                Console.WriteLine("✨ Yes");
            }
            else
            {
                Console.WriteLine("❌ No");
            }
        }
    }
}

