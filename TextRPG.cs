using System;
using System.Threading;

// This class defines what attributes characters have
//Randyy wasn't here
public class Character 
{
    // Determine character name, health, attack, heal
    public string Name {get; private set;}
    public int Health {get;set;}
    public int AttackPower {get;set;}
    public int Defense {get;set}
    public int HealPower {get;set;}

    // Get the random library
    private static Random random = new Random();


    // Constructor
    public Character(string name, int health, int attack, int defense, int heal)
    {
        Name = name;
        Health = health;
        AttackPower = attack;
        Defense = defense;
        HealPower = heal;
    }


// Function to attack
public void Attack(Character attacker, Character target)
    {
        
        int damage = random.Next(5 + attacker.AttackPower, 10 + attacker.AttackPower);
        damage -= target.Defense;
        target.Health -= damage;
        Console.WriteLine($"{attacker.Name} deals {damage} to {target.Name}: Remaining health = {target.Health}\n");
    }

    public void Heal(Character target)
    {
        int hp =  random.Next(5 + target.HealPower, 10 + target.HealPower);
        target.Health += hp;
        Console.WriteLine($"{target.Name} heals for {hp} : Total Health = {target.Health}\n");
        
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
        // Take user input
        string input;

        // Create characters
        Character player = new Character("Nick",100,12,3,13);
        Character enemy = new Character("Goblin",100,10,3,0);
        
        Eepy(".",300);
        Console.WriteLine($"Hello {player.Name}, prepare to die idiot baka");
        Console.WriteLine($"Loading...");
        Eepy(".",200);
        Console.WriteLine($"{enemy.Name} approaches... Fight!");

        // Run Game
        while (isRunning)
        {
            Console.WriteLine("Choose an option");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Heal");
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
                    player.Heal(player);
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
                Console.WriteLine($"Game Over! You win {player.Name}");
                isRunning = false;

            }

            if (player.Health <= 0)
            {
                Console.WriteLine($"You LOSE {player.Name}");
                isRunning = false;
            }

            enemy.Attack(enemy,player);

        }



    }
}


// Davin - Unity
// Brian -
// Yovin - 
// 