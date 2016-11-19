using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var roller = new DiceRoller();

            var craps = new DieRoll(6, 2);

            Console.WriteLine(roller.Roll(craps));

            var attack = new List<DieRoll>();

            attack.Add(new ConsoleApp.DieRoll(20, 1));
            attack.Add(new ConsoleApp.DieRoll(4, 1));
            attack.Add(new ConsoleApp.DieRoll(8, 1));

            var attackResult = roller.Roll(attack) + 11;

            Console.WriteLine("Your attack is: " + attackResult);
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }


    public class DieRoll
    {

        public int DieMax { get; private set; }
        public int NumberOfRolls { get; private set; }

        public DieRoll(int dieMax, int numberOfRolls)
        {
            DieMax = dieMax;
            NumberOfRolls = numberOfRolls;
        }
    }
    public class DiceRoller
    {

        private Random _rand;
        private int _max;


        public DiceRoller()
        {
            _rand = new Random();
            _max = 6;
        }

        public DiceRoller(int max)
        {
            _rand = new Random();
            _max = max;
        }

        public int Roll(int max, int numberOfRolls)
        {
            int total = 0;//Non-cheeky 3.0
            for (int i = 0; i < numberOfRolls; i++)
            {
                total += _rand.Next(max) + 1;
            }
            return total;
        }


        public int Roll(DieRoll dieRoll)
        {
            int total = Roll(dieRoll.DieMax, dieRoll.NumberOfRolls);
            return total;
            //I need max2 for _rand.Next(max2) >>> _rand.Next(dieRoll.DieMax)

        }

        public int Roll(List<DieRoll> dieRolls)
        {
            var total = 0;
            foreach (var dieRoll in dieRolls)
            {
                total += Roll(dieRoll);
            }
            return total;

        }

    }

}
