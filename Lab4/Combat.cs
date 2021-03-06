﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4
{
    public class Combat
    {
        private const string WRONGINPUT = "Wrong Input";

        public static void CombatSystem(MonsterRoom enemy)
        {

            while (enemy.isAlive && Player.isAlive)
            {
                Console.WriteLine($"Your health is {Player.playerHealthPoints}");
                Console.WriteLine($"The {enemy.Name}s health is {enemy.EnemyHealthPoints}");
                Console.WriteLine("Press on '1' to attack");

                var fight = Console.ReadKey();
                Console.Clear();
                Random enemyHit = new Random();
                int randomEnemyHit = enemyHit.Next(1, enemy.EnemyAttack);

                // If-else statement with random generators to our combat system
                if (fight.Key == ConsoleKey.NumPad1 || fight.Key == ConsoleKey.D1)
                {
                    Random meleeDamage = new Random();
                    int randomMeleeDamage = meleeDamage.Next(1, Player.playerAttack);

                    if (randomMeleeDamage < 10)
                    {
                        Console.WriteLine($"The {enemy.Name} hit you for {randomEnemyHit} damage!");
                        Player.playerHealthPoints -= randomEnemyHit;
                        Console.WriteLine($"You hit the {enemy.Name} for {randomMeleeDamage} damage!");
                        enemy.EnemyHealthPoints -= randomMeleeDamage;
                    }
                    else
                    {
                        Console.WriteLine($"The {enemy.Name} hit you for {randomEnemyHit} damage!");
                        Player.playerHealthPoints -= randomEnemyHit;
                        Console.WriteLine($"You critically hit {enemy.Name} for {randomMeleeDamage} damage!");
                        enemy.EnemyHealthPoints -= randomMeleeDamage;
                    }

                }
                // A failure statement in case of pressing the wrong button.
                else if (fight.Key != ConsoleKey.NumPad1 && fight.Key != ConsoleKey.D1)
                    Console.WriteLine(WRONGINPUT);

                // else-if statements of Player or enemy death
                if (Player.playerHealthPoints <= 0)
                {
                    Player.isAlive = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You died!");
                    Console.WriteLine("GAME OVER");
                    Console.ReadKey();
                }

                else if (enemy.EnemyHealthPoints <= 0)
                {
                    Console.WriteLine($"You have killed the {enemy.Name}");
                    Player.score += enemy.ScoreGained;
                    if (Player.hasSword)
                    {
                        Program.sword.Durability -= 1;
                        Program.sword.CheckDurability();
                    }
                    if (Player.hasShield)
                    {
                        Program.shield.Durability -= 1;
                        Program.shield.CheckDurability();  
                    }
                    enemy.isAlive = false;
                }
               
            }
        }
    }
}
