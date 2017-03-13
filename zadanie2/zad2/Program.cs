using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad2
{
    interface IBohater
    {
        void BijWroga(float Atak, string Rasa1, string Rasa2);
        void SprawdzHP(float Hp, string Rasa);
    }

    public abstract class Bohater : IBohater
    {
        public float Hp;
        public float Atak;
        public enum Rasa { Mag, Wojownik, Rzezimieszek, UrukHai }

        public void BijWroga(float Atak, string Rasa1, string Rasa2)
        {
            Console.WriteLine("\n{0} zaatakował {1} i zabrał mu {2} hp ", Rasa1, Rasa2, Atak);
        }

        public void SprawdzHP(float Hp, string Rasa)
        {
            Console.WriteLine("{0} pozostało {1} hp ", Rasa, Hp);
            if (Hp <= 0)
            {
                Console.WriteLine("{0} zginął", Rasa);
                Console.ReadLine();
                Environment.Exit(0);
            }
        }
    }

    class Mag : Bohater
    {
        public static int ObrCzar;
        private int mana;
        public Mag(int mana, float Hp, float Atak)
        {
            this.mana = mana;
            this.Hp = Hp;
            this.Atak = Atak;
        }
        public void RzucCzar()
        {
            ObrCzar = 30;
            mana -= 10;
            Console.WriteLine("\nMag rzucił czar zadając krytyczne obrażenia! Zabrał Uruk-Hai {0} hp i pozostało mu {1} many", ObrCzar, mana);
        }
    }

    public class Wojownik : Bohater
    {
        public static int AtakKrytyczny;
        public Wojownik(float Hp, float Atak)
        {
            this.Hp = Hp;
            this.Atak = Atak;
        }

        public void RzutToporem()
        {
            AtakKrytyczny = 50;
            Console.WriteLine("\nWojownik rzucił toporem zadając krytyczne obrażenia! Zabrał Uruk-Hai {0} hp", AtakKrytyczny);
        }
    }
    class Rzezimieszek : Bohater
    {
        public static float energia = 100;
        public Rzezimieszek(float Hp, float Atak)
        {
            this.Hp = Hp;
            this.Atak = Atak;
        }
    }


    class UrukHai : Bohater
    {
        public UrukHai(float Hp, float Atak)
        {
            this.Hp = Hp;
            this.Atak = Atak;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            #region tworzenie obiektów
            Mag mag = new Mag(100, 60, 8);
            Wojownik wojownik = new Wojownik(300, 12);
            Rzezimieszek rzezimieszek = new Rzezimieszek(100, 10);
            UrukHai uruk = new UrukHai(400, 10);
            #endregion
            #region walka
            Console.WriteLine("Walka się rozpoczyna!");
            Console.ReadLine();
            while (uruk.Hp > 0 && mag.Hp > 0 && wojownik.Hp > 0 && rzezimieszek.Hp > 0)
            {
                mag.BijWroga(mag.Atak, Bohater.Rasa.Mag.ToString(), Bohater.Rasa.UrukHai.ToString());
                uruk.Hp -= mag.Atak;
                uruk.SprawdzHP(uruk.Hp, Bohater.Rasa.UrukHai.ToString());
                Console.ReadLine();

                uruk.BijWroga(uruk.Atak, Bohater.Rasa.UrukHai.ToString(), Bohater.Rasa.Mag.ToString());
                mag.Hp -= uruk.Atak;
                mag.SprawdzHP(mag.Hp, Bohater.Rasa.Mag.ToString());
                Console.ReadLine();

                wojownik.BijWroga(wojownik.Atak, Bohater.Rasa.Wojownik.ToString(), Bohater.Rasa.UrukHai.ToString());
                uruk.Hp -= wojownik.Atak;
                uruk.SprawdzHP(uruk.Hp, Bohater.Rasa.UrukHai.ToString());
                Console.ReadLine();

                uruk.BijWroga(uruk.Atak, Bohater.Rasa.UrukHai.ToString(), Bohater.Rasa.Wojownik.ToString());
                wojownik.Hp -= uruk.Atak;
                wojownik.SprawdzHP(wojownik.Hp, Bohater.Rasa.Wojownik.ToString());
                Console.ReadLine();

                wojownik.RzutToporem();
                uruk.Hp -= Wojownik.AtakKrytyczny;
                uruk.SprawdzHP(uruk.Hp, Bohater.Rasa.UrukHai.ToString());
                Console.ReadLine();

                uruk.BijWroga(uruk.Atak, Bohater.Rasa.UrukHai.ToString(), Bohater.Rasa.Wojownik.ToString());
                wojownik.Hp -= uruk.Atak;
                wojownik.SprawdzHP(wojownik.Hp, Bohater.Rasa.Wojownik.ToString());
                Console.ReadLine();

                if (Rzezimieszek.energia > 0)
                {
                    rzezimieszek.BijWroga((rzezimieszek.Atak + (Rzezimieszek.energia / 50)), Bohater.Rasa.Rzezimieszek.ToString(), Bohater.Rasa.UrukHai.ToString());
                    uruk.Hp -= (rzezimieszek.Atak + (Rzezimieszek.energia / 50));
                    Rzezimieszek.energia -= 10;
                    uruk.SprawdzHP(uruk.Hp, Bohater.Rasa.UrukHai.ToString());
                    Console.ReadLine();
                }
                else
                {
                    rzezimieszek.BijWroga(rzezimieszek.Atak, Bohater.Rasa.Rzezimieszek.ToString(), Bohater.Rasa.UrukHai.ToString());
                    uruk.Hp -= rzezimieszek.Atak;
                    Rzezimieszek.energia -= 10;
                    uruk.SprawdzHP(uruk.Hp, Bohater.Rasa.UrukHai.ToString());
                    Console.ReadLine();
                }

                uruk.BijWroga(uruk.Atak, Bohater.Rasa.UrukHai.ToString(), Bohater.Rasa.Rzezimieszek.ToString());
                rzezimieszek.Hp -= uruk.Atak;
                rzezimieszek.SprawdzHP(rzezimieszek.Hp, Bohater.Rasa.Rzezimieszek.ToString());
                Console.ReadLine();

                mag.RzucCzar();
                uruk.Hp -= Mag.ObrCzar;
                uruk.SprawdzHP(uruk.Hp, Bohater.Rasa.UrukHai.ToString());
                Console.ReadLine();
            }
            Console.ReadLine();
            #endregion
        }
    }
}