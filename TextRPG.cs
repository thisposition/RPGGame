using System;
using System.IO;
using System.Threading;


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
        Character player = new Character($"{player_name}",100,12,3,5,50,1);
        Enemy enemy = new Enemy("Goblin",10,10,3,0,0,0,25);

        player.LoadCharacterEXP();

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
                enemy.drop_exp(player,enemy);
                isRunning = false;

            }

            if (player.Health <=0 & enemy.Health <=0)
            {
                Console.WriteLine($"You LOSE {player.Name}");
                isRunning = false;
            }

            if (enemy.Health >= 1 & player.Health >=1)
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