using System;
using System.IO;
using System.Threading;

public class Character
{
    // Determine character name, health, attack, heal
    public string Name { get; set; }
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int Defense { get; set; }
    public int Intelligence { get; set; }
    public int Mana { get; set; }
    public int Drop_EXP { get; set; }
    public int Character_EXP { get; set; }

    // Get the random library
    private static Random random = new Random();

    //Loads Character EXP from local file
    public void LoadCharacterEXP()
    {
        string filePath = Path.Combine(Environment.CurrentDirectory, "CharacterEXP.txt");

        try
        {
            if (File.Exists(filePath))
            {
                string expString = File.ReadAllText(filePath);

                if (int.TryParse(expString, out int expValue))
                {
                    Character_EXP = expValue;
                }
            }
            Console.WriteLine($"Read{filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading character EXP: {ex.Message}");
        }
    }

    public void SaveCharacterEXP()
    {
        string filePath = Path.Combine(Environment.CurrentDirectory, "CharacterEXP.txt");

        try
        {
            File.WriteAllText(filePath, Character_EXP.ToString());
            Console.WriteLine($"W{filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving character EXP: {ex.Message}");
        }
    }

    // Constructor
    public Character(string name, int health, int attack, int defense, int intelligence, int mana, int character_EXP)
    {
        Name = name;
        Health = health;
        AttackPower = attack;
        Defense = defense;
        Intelligence = intelligence;
        Mana = mana;
        Character_EXP = character_EXP;
    }

    // Function to attack
    public void Attack(Character attacker, Character target)
    {

        int damage = random.Next(5 + attacker.AttackPower, 10 + attacker.AttackPower);
        damage -= target.Defense;
        target.Health -= damage;
        Console.WriteLine($"{attacker.Name} deals {damage} to {target.Name}: Remaining health = {target.Health}\n");
    }
    // Function to heal player character. Costs 5 Mana. 
    public void Low_Heal(Character target)
    {

        int hp = random.Next(5 + target.Intelligence, 10 + target.Intelligence);
        int mp = 5;
        target.Health += hp;
        target.Mana -= mp;
        Console.WriteLine($"{target.Name} heals for {hp} : Total Health = {target.Health}\n{target.Name} loses {mp} mp : Total MP = {target.Mana}\n");

    }

}
// Subclass to Character. Defines EXP values for enemies. 
public class Enemy : Character
{
    public int EXP { get; set; }

    // Updated the constructor to call the base class constructor
    public Enemy(string name, int health, int attack, int defense, int intelligence, int mana, int character_exp, int drop_exp)
        : base(name, health, attack, defense, intelligence, mana, character_exp)
    {
        Drop_EXP = drop_exp;
    }
    // experience_gain defines how exp is added from enemies to players. (INCOMPLETE)
    public void drop_exp(Character player, Character enemy)
    {
        int experience_gain = enemy.Drop_EXP;
        player.Character_EXP += experience_gain;
        Console.WriteLine($"You win! You gained {enemy.Drop_EXP} exp. You now have {player.Character_EXP}");

        // Save the Character_EXP after gaining experience
        player.SaveCharacterEXP();
    }



}