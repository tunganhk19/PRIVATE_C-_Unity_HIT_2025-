using System;
using System.Collections;
using System.Collections.Generic;

namespace MyGame
{
    class Program
    {
        static char[,] map =  new char[10, 10];
        
        class ViTri
        {
            int hang;
            int cot;

            public int Hang => hang;

            public int Cot => cot;

            public int setHang
            {
                get => hang;
                set => hang = value;
            }

            public int setCot
            {
                get => cot;
                set => cot = value;
            }

            public ViTri(int hang, int cot)
            {
                this.hang = hang;
                this.cot = cot;
            }
        }
        abstract class nvat
        {
            public int mau{get;set;}
            public int tancong{get; set; }
            public int tam{get;set;}
            public int tocdo{get;set;}
            public ViTri vitri{get;set;}
            public Boolean danh(nvat doithu)
            {
                if (kcach(doithu) <= this.tam) return true;
                return false;
            }
            public Boolean bidanh(nvat doithu)
            {
                if (doithu.danh(this))
                {
                    this.mau -= doithu.tancong;
                    return true;
                }
                return false;
            }
            public void dichuyen(Char move, int speed)
            {
                if (move == 'A' && this.vitri.Cot > 0 && map[this.vitri.Hang, this.vitri.Cot - speed] == '.')
                {
                    this.vitri.setCot -= speed;
                }
                else if (move == 'W' && this.vitri.Hang > 0 && map[this.vitri.Hang - speed, this.vitri.Cot] == '.')
                {
                    this.vitri.setHang -= speed;
                }
                else if (move == 'D' && this.vitri.Cot < 10 - 1 && map[this.vitri.Hang, this.vitri.Cot + speed] == '.')
                {
                    this.vitri.setCot += speed;
                }
                else if (move == 'S' && this.vitri.Hang < 10 - 1 && map[this.vitri.Hang + speed, this.vitri.Cot] == '.')
                {
                    this.vitri.setHang += speed;
                }
            }
            public int kcach (nvat doithu)
            {
                return Math.Max(Math.Abs(this.vitri.Hang-doithu.vitri.Hang),Math.Abs(this.vitri.Cot-doithu.vitri.Cot));
            }
        }

        class main : nvat
        {
            public main()
            {
            }

            public main(ViTri vitri, int mau, int tancong, int tam, int tocdo)
            {
                this.vitri = vitri;
                this.mau = mau;
                this.tancong = tancong;
                this.tam = tam;
                this.tocdo = tocdo;
            }

            public void Move()
            {
                Console.WriteLine("Chon AWDS de di chuyen: ");
                char move = char.ToUpper(Console.ReadKey().KeyChar);
                dichuyen(move,this.tocdo);
            }
        }

        class enemy : nvat
        {
            public enemy(ViTri vitri, int mau, int tancong, int tam, int tocdo)
            {
                this.vitri = vitri;
                this.mau = mau;
                this.tancong = tancong;
                this.tam = tam;
                this.tocdo = tocdo;
            }

            public void Move(main x)
            {
                if (this.vitri.Hang < x.vitri.Hang)
                {
                    dichuyen('S',this.tocdo);
                }
                else if (this.vitri.Hang > x.vitri.Hang)
                {
                    dichuyen('W',this.tocdo);
                }
                else if (this.vitri.Cot < x.vitri.Cot)
                {
                    dichuyen('D',this.tocdo);
                }
                else if (this.vitri.Cot > x.vitri.Cot)
                {
                    dichuyen('A',this.tocdo);
                }
            }
        }
        static void Main(string[] args)
        {
            main hero = new main(new ViTri(5,5),1000,150,2,1);
            List<enemy> monsters = new List<enemy>();
            monsters.Add(new enemy(new ViTri(0,0),3000,50,1,1));
            monsters.Add(new enemy(new ViTri(0,9),3000,50,1,1));
            // monsters.Add(new enemy(new ViTri(9,0),2000,50,1,1));
            // monsters.Add(new enemy(new ViTri(9,9),2000,50,1,1));
            int maxHPHero = hero.mau;
            int maxHPMonster = monsters[0].mau;
            int turn = 0;
            do
            { 
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (i == hero.vitri.Hang && j == hero.vitri.Cot)
                        {
                            map[i, j] = 'X';
                        }
                        else
                        {
                            map[i, j] = '.';
                        }
                        foreach (enemy monster in monsters)
                        {
                            if (i==monster.vitri.Hang && j==monster.vitri.Cot) map[i, j] = 'U';
                        }
                        Console.Write(" "+map[i, j]+" ");
                    }
                    Console.WriteLine();
                }
                int chem = 0;
                for (int i = monsters.Count - 1; i >= 0; i--)
                {
                    enemy monster = monsters[i];
                    if (chem == 0)
                    {
                        if (monster.bidanh(hero)) chem++;
                    }
                    hero.bidanh(monster);
                    if (monster.mau <= 0)
                        monsters.RemoveAt(i);
                }
                
                
                Console.WriteLine("\n________________________________");
                Console.WriteLine("\n   *BANG TRANG THAI NHAN VAT*   ");
                Console.WriteLine("\n    Mau      : "+hero.mau+"/"+maxHPHero);
                Console.WriteLine("\n    Tan Cong : "+hero.tancong);
                Console.WriteLine("\n    Tam      : "+hero.tam);
                Console.WriteLine("\n________________________________");
                Console.WriteLine();
                Console.WriteLine("\n         ***   VS   ***         ");
                Console.WriteLine();
                int dem = 0;
                foreach (enemy monster in monsters)
                {
                    dem++;
                    Console.WriteLine("\n    QUAI VAT SO "+dem);
                    Console.WriteLine("\n    Mau      : "+monster.mau+"/"+maxHPMonster);
                    Console.WriteLine("\n    Tan Cong : "+monster.tancong);
                    Console.WriteLine("\n    Tam      : "+monster.tam);
                }
                hero.Move();
                turn++;
                map[hero.vitri.Hang,hero.vitri.Cot] = 'X';
                if (turn%2==0)
                {
                    foreach (enemy monster in monsters)
                    {
                        map[monster.vitri.Hang,monster.vitri.Cot] = 'U';
                        monster.Move(hero);
                        map[monster.vitri.Hang,monster.vitri.Cot] = 'U';
                    }
                }
                Console.WriteLine();
            } while (hero.mau!=0 && monsters.Count>0);
            if (hero.mau == 0)
            {
                Console.WriteLine("\n|***************************|");
                Console.WriteLine("\n|*                         *|");
                Console.WriteLine("\n|*        GAME OVER        *|");
                Console.WriteLine("\n|*                         *|");
                Console.WriteLine("\n|***************************|");
            }
            else if (monsters.Count == 0)
            {
                Console.WriteLine("\n|***************************|");
                Console.WriteLine("\n|*                         *|");
                Console.WriteLine("\n|*         WINNER!         *|");
                Console.WriteLine("\n|*                         *|");
                Console.WriteLine("\n|***************************|");
            }
        }
    }
};

