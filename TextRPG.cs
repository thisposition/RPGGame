using System;
using System.Threading;

// This class defines what attributes characters have
//Randyy wasn't here
public class Character 
{
    // Determine character name, health, attack, heal
    public string Name {get; set;}
    public int Health {get;set;}
    public int AttackPower {get;set;}
    public int Defense { get; set; }
    public int Intelligence { get; set; }
    public int Mana { get;set;}

    // Get the random library
    private static Random random = new Random();


    // Constructor
    public Character(string name, int health, int attack, int defense, int intelligence, int mana)
    {
        Name = name;
        Health = health;
        AttackPower = attack;
        Defense = defense;
        Intelligence = intelligence;
        Mana = mana;
        
    }

// Function to attack
public void Attack(Character attacker, Character target)
    {
        
        int damage = random.Next(5 + attacker.AttackPower, 10 + attacker.AttackPower);
        damage -= target.Defense;
        target.Health -= damage;
        Console.WriteLine($"{attacker.Name} deals {damage} to {target.Name}: Remaining health = {target.Health}\n");
    }

public void Low_Heal (Character target)
    {

        int hp =  random.Next(5 + target.Intelligence, 10 + target.Intelligence);
        int mp = 5;
        target.Health += hp;
        target.Mana -= mp;
        Console.WriteLine($"{target.Name} heals for {hp} : Total Health = {target.Health}\n{target.Name} loses {mp} mp : Total MP = {target.Mana}\n");
        
    }

}
public class Enemy : Character
{
    public int EXP { get; set; }

    // Updated the constructor to call the base class constructor
    public Enemy(string name, int health, int attack, int defense, int intelligence, int mana, int exp)
        : base (name, health, attack, defense, intelligence, mana)
    {
        EXP = exp;
    }
}


// ----------------------   
// Main body of the script
class RPG
{
    static void Eepy(string info, int time)
        {  

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(info);
                Thread.Sleep(time);
            }   
        }

    static void Main(string[] args)
    {
        // Check if the game should keep running
        bool isRunning = true;

        string player_name;

        Console.WriteLine($"Hey you! What's your name?");
        player_name = Console.ReadLine();

        // Take user input
        string input;

        // Create characters
        Character player = new Character($"{player_name}",100,12,3,5,50);
        Enemy enemy = new Enemy("Goblin",100,10,3,0,0,25);
        
        Eepy(".",300);

        Console.WriteLine($"Hello {player_name}, prepare to die idiot baka");
        Console.WriteLine($"Loading...");
        Eepy(".",200);


        Console.WriteLine($"{enemy.Name} approaches... Fight!");

        // Run Game
        while (isRunning)
        {
            Console.WriteLine("Choose an option");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Cast Low Heal (5 MP)");
            Console.WriteLine("3. Quit");
            // User input
            Console.Write("Choose:");
            input = Console.ReadLine();
            switch(input)
            {
                case "1":
                    player.Attack(player,enemy);
                    break;
                case "2":
                    player.Low_Heal(player);
                    break;  
                case "3":
                    isRunning = false;
                    continue;
                default:
                    Console.WriteLine($"{input} - Not an valid option");
                    break;
                    

            }
            
            // If Enemy dies you win, else the enemy will attack back.
            if (enemy.Health <= 0)
            {
                Console.WriteLine($"You win! You gained {enemy.EXP} exp");
                isRunning = false;

            }

            if (player.Health <= 0)
            {
                Console.WriteLine($"You LOSE {player.Name}");
                isRunning = false;
            }

            if (enemy.Health >= 1)
            {
                enemy.Attack(enemy, player);
            }
        }



    }
}


// Davin - Unity
// Brian -
// Yovin - 
// 