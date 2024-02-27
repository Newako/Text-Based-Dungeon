using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextDungeon
{
    class Program
    {
        public static Player currentPlayer = new Player();
        public static bool mainLoop = true;
        static void Main(string[] args)
        {
            Start();
            Encounters.FirstEcounter();
            while(mainLoop)
            {
                Encounters.RandomEncounter();
            }
        }

        static void Start()
        {
            Console.WriteLine("Text Dungeon!");
            Console.WriteLine("Name: ");
            currentPlayer.name = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("You awake in a cold room. You feel heavy with every movement.");
            Console.WriteLine("You have a painful headache and feel heavy with every movement.");
            if (currentPlayer.name == "")
                Console.WriteLine("You can't even remember your own name...");
            else
                Console.WriteLine("You know your name is " + currentPlayer.name);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You grope around in the darkness until you find a door handle. You feel some resistance");
            Console.WriteLine("as you turn the door handle, the rusty lock breaks with little effort. You see a prison guard");
            Console.WriteLine("standing with his back facing towards you. He seems to be asleep.");
        }

    }

}