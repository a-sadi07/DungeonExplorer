using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public interface IDamageable
    {
        void TakeDamage(int amount);
    }

    public interface ICollectible
    {
        string Name { get; }
        void Use(Player player);
    }

    public abstract class Creature : IDamageable
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }

        public Creature(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public virtual void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 0) Health = 0;
        }
    }

    public abstract class Monster : Creature
    {
        public int Damage { get; protected set; }

        public Monster(string name, int health, int damage) : base(name, health)
        {
            Damage = damage;
        }

        public virtual void Attack(Player player)
        {
            Console.WriteLine($"{Name} attacks {player.Name} for {Damage} damage!");
            player.TakeDamage(Damage);
        }
    }

    public class Dragon : Monster
    {
        public Dragon(string name, int health, int damage) : base(name, health, damage) { }

        public override void Attack(Player player)
        {
            Console.WriteLine($"{Name} breathes fire on {player.Name}!");
            base.Attack(player);
        }
    }

    public class Goblin : Monster
    {
        public Goblin(string name, int health, int damage) : base(name, health, damage) { }

        public override void Attack(Player player)
        {
            Console.WriteLine($"{Name} slashes at {player.Name} with a dagger!");
            base.Attack(player);
        }
    }

    public class Weapon : ICollectible
    {
        public string Name { get; }
        public int Damage { get; }

        public Weapon(string name, int damage)
        {
            Name = name;
            Damage = damage;
        }

        public void Use(Player player)
        {
            Console.WriteLine("You can't use a weapon like that directly.");
        }
    }

    public class Potion : ICollectible
    {
        public string Name { get; }
        public int HealAmount { get; }

        public Potion(string name, int healAmount)
        {
            Name = name;
            HealAmount = healAmount;
        }

        public void Use(Player player)
        {
            player.Heal(HealAmount);
            Console.WriteLine($"You used a {Name} and healed {HealAmount} HP!");
        }
    }

    public class Player : Creature
    {
        public List<ICollectible> Inventory { get; private set; }

        public Player(string name, int health) : base(name, health)
        {
            Inventory = new List<ICollectible>();
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"Player: {Name} | Health: {Health} | Inventory: {string.Join(", ", Inventory.Select(i => i.Name))}");
        }

        public void Heal(int amount)
        {
            Health += amount;
        }

        public void Attack(Monster monster)
        {
            Weapon weapon = Inventory.OfType<Weapon>().OrderByDescending(w => w.Damage).FirstOrDefault();
            int damage = weapon?.Damage ?? 5;
            Console.WriteLine($"You attack the {monster.Name} with {(weapon != null ? weapon.Name : "your fists")} for {damage} damage!");
            monster.TakeDamage(damage);
        }

        public void UseItem(string itemName)
        {
            ICollectible item = Inventory.FirstOrDefault(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }
            item.Use(this);
            if (item is Potion) Inventory.Remove(item);
        }
    }
}

