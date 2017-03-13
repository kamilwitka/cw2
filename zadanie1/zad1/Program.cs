using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad1
{
    interface ISamochod
    {
        void WypiszMarke(string marka);

        void WypiszSalon(string NazwaSalonu);

    }

    class AstonMartin : ISamochod
    {
        public string marka;
        public string NazwaSalonu;
        public AstonMartin(string marka, string NazwaSalonu)
        {
            this.marka = marka;
            this.NazwaSalonu = NazwaSalonu;
        }
        public void WypiszMarke(string marka)
        {
            Console.WriteLine("Marka astona to: " + marka);
        }
        public void WypiszSalon(string NazwaSalonu)
        {
            Console.WriteLine("Salon astona to: " + NazwaSalonu);
        }
    }

    class RangeRover : ISamochod
    {
        public string marka;
        public string NazwaSalonu;
        public RangeRover(string marka, string NazwaSalonu)
        {
            this.marka = marka;
            this.NazwaSalonu = NazwaSalonu;
        }
        public void WypiszMarke(string marka)
        {
            Console.WriteLine("Marka RangeRover to: " + marka);
        }
        public void WypiszSalon(string NazwaSalonu)
        {
            Console.WriteLine("Salon RangeRover to: " + NazwaSalonu);
        }
    }
    class RollsRoyce : ISamochod
    {
        public string marka;
        public string NazwaSalonu;
        public RollsRoyce(string marka, string NazwaSalonu)
        {
            this.marka = marka;
            this.NazwaSalonu = NazwaSalonu;
        }
        public void WypiszMarke(string marka)
        {
            Console.WriteLine("Marka RollsRoyce to: " + marka);
        }
        public void WypiszSalon(string NazwaSalonu)
        {
            Console.WriteLine("Salon RollsRoyce to: " + NazwaSalonu);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            AstonMartin aston = new AstonMartin("aston","salon1");
            aston.WypiszMarke(aston.marka);
            aston.WypiszSalon(aston.NazwaSalonu);
            RangeRover range = new RangeRover("RangeRover", "salon2");
            range.WypiszMarke(range.marka);
            range.WypiszSalon(range.NazwaSalonu);
            RollsRoyce rolls = new RollsRoyce("RollsRoyce", "salon3");
            rolls.WypiszMarke(rolls.marka);
            rolls.WypiszSalon(rolls.NazwaSalonu);
            Console.ReadLine();
        }
    }
}
