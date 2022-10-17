﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Health_System
{
    internal class Program
    {
        static int score;
        static int health;
        static int armour;
        static int lives;
        static int LeftOverDam;
        static int exp;


        static void Main(string[] args)
        {
            score = 0;
            health = 100;
            armour = 50;
            lives = 3;
            exp = 0;

            showCaseDamage();

            showCaseHealing();

            showCaseIncreaseShield();

            showGameOver();

            Console.ReadKey(true);
        }


        static void showCaseDamage()
        {
            Console.WriteLine("Take damage");
            Console.WriteLine();
            Console.WriteLine();
            // shows takeDamage for sheild without going in the negatives
            // and takes that left over damage to the health
            // if you go below 0 health you will go down a life
            // with all your health and shield goes back
            showhud(score, health, lives);
            Console.WriteLine();
            takeDamage(20, health, armour);
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            takeDamage(40, health, armour); //range checking
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            takeDamage(-5, health, armour); // error checking
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            takeDamage(90, health, armour); // shows lives decreased
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
        }

        static void showCaseHealing()
        {
            // healing health
            Console.WriteLine("Healing");
            Console.WriteLine();
            Console.WriteLine();
            reset();
            showhud(score, health, lives);
            Console.WriteLine();
            takeDamage(100, health, armour);
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            heal(30);
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            Console.WriteLine();
            reset();  // reset for range checking
            Console.WriteLine("Reset for range checking.");
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            takeDamage(100, health, armour);
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            heal(100);
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            Console.WriteLine();
            reset(); //reset for error checking
            Console.WriteLine("Reset for error checking.");
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            takeDamage(100, health, armour);
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine(); 
            heal(-20);
            Console.WriteLine();
            showhud(score, health, lives);
        }

        static void showCaseIncreaseShield()
        {
            reset();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("shield regen.");
            Console.WriteLine();
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            takeDamage(25, health, armour);
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            BluePickUp(50); // range checking
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            takeDamage(25, health, armour);
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            BluePickUp(-15); // error checking
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
        }

        static void showGameOver()
        {
            reset();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Show game over");
            Console.WriteLine();
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            takeDamage(200, health, armour); 
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            takeDamage(150, health, armour);
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            takeDamage(150, health, armour);
            Console.WriteLine();
            showhud(score, health, lives);
            Console.WriteLine();
            takeDamage(150, health, armour); // lives range checking
            Console.WriteLine();
            showhud(score, health, lives);
        }

        static void ShowCaseExp()
        {
            reset();
            Console.WriteLine();
            Console.WriteLine();
        }

        static void showhud(int Score, int hearts, int Lives)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Score: " + Score + "  Lives: " + Lives);
            Console.WriteLine();
            Console.WriteLine("Health: " + hearts + "  Armour: " + armour);

            Console.WriteLine("Exp: " + exp + "/100 ");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            if (hearts == 100)
            {
                Console.WriteLine("I'm healthy!!!");
            }
            else if ((hearts <= 99) && (hearts >= 80))
            {
                Console.WriteLine("I need sleep.");
            }
            else if ((hearts <= 79) && (hearts >= 50))
            {
                Console.WriteLine("I need a doctor");
            }
            else if ((hearts <= 49) && (hearts >= 1))
            {
                Console.WriteLine("HaHa I'm in danger.");
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            

            if ((Lives == 0) && (hearts == 0))
            {
                Console.WriteLine();
                Console.WriteLine(" Game Over.");
                Console.WriteLine();
                Console.WriteLine("You have died. LOL");
            }
        }

        static void takeDamage(int damage, int hp, int shield)
        {
            Console.WriteLine("You have taken " + damage + " damage from an enemy!");

            if (damage < 0)
            {
                Console.WriteLine("Error: you can't take negative damage.");
            }

            if ((shield >= 0) && (damage >= 0))
            {
                armour = shield - damage;

                LeftOverDam = shield - damage;

                if (armour < 0)
                {
                    armour = 0;

                    health = hp + LeftOverDam;

                    if (health < 0)
                    {
                        health = 0;

                       
                    }
                }
            }

            if ((lives <= 0) && (health <= 0))
            {
                lives = 0;
                health = 0;
                armour = 0;
            }
            else if (health == 0)
            {
                armour = 50;
                health = 100;
                lives = lives - 1;
            }
        }

        static void reset()
        {
            score = 0;
            health = 100;
            armour = 50;
            lives = 3;
        }

        static void heal(int potion)
        {
            Console.WriteLine("Error: You drank a potion that healed you for " + potion);

            if (potion < 0)
            {
                Console.WriteLine("You can't heal negative health.");
            }

            if ((potion >= 0) && (health >= 0))
            {
                health = health + potion;
                
                if (health >= 100)
                {
                    health = 100;
                }
            }
        }

        static void BluePickUp(int helmet)
        {
            Console.WriteLine("You picked up a helmet you can take " + helmet + " more damage!");

            if (helmet < 0)
            {
                Console.WriteLine("Error: You can't pick up negative armour.");
            }

            if ((helmet >= 0) && (armour >= 0))
            {
                armour = armour + helmet;

                if (armour >= 50)
                {
                    armour = 50;
                }
            }
        }

        static void defeatedEnemies(int enemies) // enemies are worth 1 exp
        {
            Console.WriteLine("You defeated " + enemies + "enemies");
            Console.WriteLine();
            Console.WriteLine("you gained " + enemies + " exp");

            if (enemies > 0)
            {
                exp = exp + enemies;
            }
        }

    }
}
