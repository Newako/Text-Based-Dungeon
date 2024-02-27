using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDungeon
{
    class Encounters
    {
        static Random rand = new Random();

        //Encounter Generic




        //Encounters
        public static void FirstEcounter()
        {
            Console.WriteLine("You try to slowly open the door without making any noise, but because of your heavy movement you accidentally push the door into the wall with a bang.");
            Console.WriteLine("The guard awakes and turns to face you with his weapon drawn...");
            Console.ReadKey();
            Combat(false, "Guard", 1, 4);
        }
        public static void BasicFightEncounter()
        {
            Console.Clear();
            Console.WriteLine("You turn the corner and there is a large beast...");
            Console.ReadKey();
            Combat(true, "", 0, 0);
        }
        public static void WizardEncounter()
        {
            Console.Clear();
            Console.WriteLine("A door creaks open, you peer into the dark room and see a dark robed figure with a tall hat.");
            Console.ReadKey();
            Combat(false, "Wizard", 4, 2);
        }
        public static void BlueSlimeEncounter()
        {
            Console.Clear();
            Console.WriteLine("You take a few steps and hear a squishing sound from under your feet. In the distance you can see a blue slime approaching you.");
            Console.ReadKey();
            Combat(true, "Slime", 2, 6);
        }



        //Encounter tools
        public static void RandomEncounter()
        {
            switch(rand.Next(0, 2))
            {
                case 0:
                    BasicFightEncounter();
                    break;
                case 1:
                    WizardEncounter();
                    break;
                case 2:
                    BlueSlimeEncounter();
                    break;
            }
        }

        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;
            if(random)
            {
                n = GetName();
                p = rand.Next(1, 5);
                h = rand.Next(1, 8);
            }
            else
            {
                n = name;
                p = power;
                h = health;
            }
            while(h > 0)
            {
                Console.Clear();
                Console.WriteLine(n);
                Console.WriteLine(p + "/" + h);
                Console.WriteLine("==========================");
                Console.WriteLine("|    (A)ttack (D)efend   |");
                Console.WriteLine("|     (R)un    (H)eal    |");
                Console.WriteLine("==========================");
                Console.WriteLine(" Potions: "+Program.currentPlayer.potion+"  Health: "+Program.currentPlayer.health);
                string input = Console.ReadLine();
                if(input.ToLower() == "a" || input.ToLower() == "attack")
                {
                    //Attack
                    Console.WriteLine("You throw a punch towards the guard with haste! As you pass, the " + n + " strikes you");
                    int damage = p - Program.currentPlayer.armorValue;
                    if(damage<0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue) + rand.Next(1, 4);
                    Console.WriteLine("You lose " + damage + "health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "d" || input.ToLower() == "defend")
                {
                    //Defend
                    Console.Write("As the " + n + " prepares to strike, you ready yourself to defend");
                    int damage = (p/4) - Program.currentPlayer.armorValue;
                    if(damage<0)
                        damage = 0;
                    int attack = rand.Next(0, Program.currentPlayer.weaponValue)/2;
                    Console.WriteLine("You lose " + damage + "health and deal " + attack + " damage");
                    Program.currentPlayer.health -= damage;
                    h -= attack;
                }
                else if (input.ToLower() == "r" || input.ToLower() == "run")
                {
                    //Run
                    if(rand.Next(0, 2) == 0)
                    {
                        Console.WriteLine("As you sprint away from the " + n + ", its strike catches you in the back sending you flying onto the ground.");
                        int damage  = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose "+ damage + " health and are unable to escape.");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("You're nimble enough to evade "+n+" and you successfully escape!");
                        Console.ReadKey();
                        //go to store
                    }
                }
                else if (input.ToLower() == "h" || input.ToLower() == "heal")
                {
                    //Heal
                    if (Program.currentPlayer.potion==0)
                    {
                        Console.WriteLine("Desperately feeling around your bag for a potion, you mistakenly grab junk that is of no use.");
                        int damage = p - Program.currentPlayer.armorValue;
                        if (damage < 0)
                            damage = 0;
                        Console.WriteLine("The " + n + " Strikes you with a mighty blow, you lose " + damage + " health!");
                    }
                    else 
                    {
                        Console.WriteLine("You reach into your bag and find a glass flask with red liquid inside. You take a long drink.");
                        int potionValue = 5;
                        Console.WriteLine("You gain "+potionValue+" health");
                        Program.currentPlayer.health += potionValue;
                        Console.WriteLine("As you were occupied, the " + n + " advanced and struck.");
                        int damage = (p/2) - Program.currentPlayer.armorValue;
                        if(damage < 0)
                            damage = 0;
                        Console.WriteLine("You lose "+damage+" health.");
                    }
                    Console.ReadKey();
                }
                if(Program.currentPlayer.health <= 0)
                {
                    //Death code
                    Console.WriteLine("As the "+ n +" stands above you, your life withers away from the damage you have taken. You have been slain by " + n);
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                Console.ReadKey();
            }
            int c = rand.Next(10, 50);
            Console.WriteLine("As you stand over the "+ n +", the body dissolves into "+ c +" gold coins!");
            Program.currentPlayer.coins += c;
            Console.ReadKey();
        }
        
        public static string GetName()
        {
            switch (rand.Next(0, 3))
            {
                case 0:
                    return "Skeleton";
                    
                case 1:
                    return "Zombie";
                    
                case 2:
                    return "Grave robber";

                case 3:
                    return "BlueSlime";
                    
            }
            return "Human";
        }
    }
}
