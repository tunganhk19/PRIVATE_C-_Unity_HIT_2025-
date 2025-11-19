using System;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public class Wizard
    {
        private string Name;
        private int Damge;
        private int Mana;

        public Wizard()
        {
        }

        public Wizard(string name, int damge, int mana)
        {
            Name = name;
            Damge = damge;
            Mana = mana;
        }

        public string Name1
        {
            get => Name;
            set => Name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Damge1
        {
            get => Damge;
            set => Damge = value;
        }

        public int Mana1
        {
            get => Mana;
            set => Mana = value;
        }

        public void CastSpell()
        {
            Console.WriteLine("Thầy pháp Quang Minh tung chươởng Fireball gây 30 sát thương voới 50 Mana!");
        }
    }
    public abstract class Character
    {
        private string Name;
        private int Health;

        protected Character()
        {
        }

        protected Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public string Name1
        {
            get => Name;
            set => Name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Health1
        {
            get => Health;
            set => Health = value;
        }
        public virtual void UseAbility()
        {}
    }
    public class Warrior : Character
    {
        public Warrior()
        {
        }

        public Warrior(string name, int health) : base(name, health)
        {
        }

        public override void UseAbility()
        { 
            Console.WriteLine($"{Name1} dùng Xoay Búa!");
        }
    }
    public class Mage : Character
    {
        public Mage()
        {
        }

        public Mage(string name, int health) : base(name, health)
        {
        }

        public override void UseAbility()
        { 
            Console.WriteLine($"{Name1} niệm Chú Ngủ!");
        }
    }

    public abstract class GameEntiny
    {
        private string Name;
        private int Health;
        private int Damage;

        protected GameEntiny()
        {
        }

        protected GameEntiny(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public string Name1
        {
            get => Name;
            set => Name = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int Health1
        {
            get => Health;
            set => Health = value;
        }

        public int Damage1
        {
            get => Damage;
            set => Damage = value;
        }

        public abstract void TakeDamage(int damage);

        public virtual Boolean IsAlive()
        {
            return true;
        }
        public abstract void PerformAttack(GameEntiny e);
    }
    public class Player : GameEntiny
    {
        public Player()
        {
        }

        public Player(string name, int health, int damage) : base(name, health, damage)
        {
        }

        public override void TakeDamage(int damage)
        {
            Console.WriteLine($" gây {Damage1} sát thương!");
        }

        public override Boolean IsAlive()
        {
            if (Health1 > 0)Console.WriteLine($"{Name1} còn {Health1}HP.");
            if (Health1 <= 0)
            {
                Console.WriteLine($"{Name1} còn 0HP.");
                return false;
            }
            return true;
        }

        public override void PerformAttack(GameEntiny e)
        {
            Console.Write($"{Name1} tấn công {e.Name1}");
            TakeDamage(Damage1);
            e.Health1 -= Damage1;
        }
    }
    public class Enemy : GameEntiny
    {
        public Enemy()
        {
        }

        public Enemy(string name, int health, int damage) : base(name, health, damage)
        {
        }

        public override void TakeDamage(int damage)
        {
            Console.WriteLine($" gây {Damage1} sát thương!");
        }

        public override Boolean IsAlive()
        {
            if (Health1 > 0)Console.WriteLine($"{Name1} còn {Health1}HP.");
            if (Health1 <= 0)
            {
                Console.WriteLine($"{Name1} còn 0HP.");
                return false;
            }
            return true;
        }

        public override void PerformAttack(GameEntiny e)
        {
            Console.Write($"{Name1} tấn công {e.Name1}");
            TakeDamage(Damage1);
            e.Health1 -= Damage1;
        }
    }

    public static class CombatSystem
    {
        public static void StartCombat(Player p, List<Enemy> listEnemies)
        {
            do
            {
                int turnAttack = 0;
                for (int i = listEnemies.Count - 1; i >= 0; i--)
                {
                    Enemy enemy = listEnemies[i];
                    if (turnAttack == 0)
                    {
                        turnAttack++;
                        p.PerformAttack(enemy);
                        if (!enemy.IsAlive())
                        {
                            Console.WriteLine($"{enemy.Name1} đã bị tiêu diệt! {p.Name1}");
                            if (!p.IsAlive())
                            {
                                Console.WriteLine($"{p.Name1} đã bị tiêu diệt!");
                            }
                        }
                    }
                    if (enemy.IsAlive()) enemy.PerformAttack(p);
                }
            } while (p.IsAlive() && listEnemies.Count != 0 );

            if (p.IsAlive())
            {
                Console.WriteLine($"Người chơi {p.Name1} chiến thắng!");
            }
            else
            {
                Console.WriteLine($"Người chơi {p.Name1} thất bại!");
            }
        }
    }
    
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //BAI 1:
        new Wizard().CastSpell();
        //BAI 2:
        new Warrior("Poppy",5000).UseAbility();
        new Warrior("Darius",3200).UseAbility();
        new Mage("Zoe",2500).UseAbility();
        //BAI 3:
        Player player = new Player("Graves", 650, 98);
        Enemy enemy = new Enemy("Red",1500,40);
        do
        {
            player.PerformAttack(enemy);
            if (!enemy.IsAlive())
            {
                Console.WriteLine($"{enemy.Name1} đã bị tiêu diệt! Người chiến thắng: {player.Name1}");
                break;
            }
            else
            {enemy.PerformAttack(player);}
            if (!player.IsAlive())
            {
                Console.WriteLine($"{player.Name1} đã bị tiêu diệt! Người chiến thắng: {enemy.Name1}");
                break;
            }
        } while (player.IsAlive() && enemy.IsAlive());
        //BAI 3++:
        Player p = new Player("Graves", 2300, 1200);
        List<Enemy> list = new List<Enemy>();
        list.Add(new Enemy("Red",2300,25));
        list.Add(new Enemy("Cóc biến dị",2000,15));
        list.Add(new Enemy("Sói",1000,35));
        list.Add(new Enemy("Chim quỷ biến dị",1000,5));
        list.Add(new Enemy("Blue",2300,25));
        list.Add(new Enemy("Người đá",1500,5));
        CombatSystem.StartCombat(p,list);
    }
}