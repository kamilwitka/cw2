using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad3
{
    class Osoba
    {
        protected string imie;
        protected string nazwisko;
        protected string dataUrodzenia;

        public Osoba(string imie, string nazwisko, string dataUrodzenia)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.dataUrodzenia = dataUrodzenia;
        }

        public void WypiszInfo()
        {
            Console.WriteLine("{0} {1} {2}", imie, nazwisko, dataUrodzenia);
        }
    }

    class Pilkarz : Osoba
    {
        private string pozycja;
        private string klub;
        private int liczbaGoli = 0;

        public Pilkarz(string imie, string nazwisko, string dataUrodzenia, string pozycja, string klub, int liczbaGoli) : base(imie, nazwisko, dataUrodzenia)
        {
            this.pozycja = pozycja;
            this.klub = klub;
            this.liczbaGoli = liczbaGoli;
        }

        public new void WypiszInfo()
        {
            base.WypiszInfo();
            Console.WriteLine("Pozycja: {0}, klub {1}, liczba goli: {2}", pozycja, klub, liczbaGoli);
        }

        public void StrzelGola()
        {
            Console.WriteLine("\nGol !!! Strzelcem jest: {0} {1}\n", imie, nazwisko);
        }
    }

    class Student : Osoba
    {
        private int rok;
        private int grupa;
        private int nrIndeksu;
        private List<Ocena> oceny;

        public Student(string imie, string nazwisko, string dataUrodzenia, int rok, int grupa, int nrIndeksu) : base(imie, nazwisko, dataUrodzenia)
        {
            this.rok = rok;
            this.grupa = grupa;
            this.nrIndeksu = nrIndeksu;
            oceny = new List<Ocena>();
        }

        public new void WypiszInfo()
        {
            base.WypiszInfo();
            Console.WriteLine("Rok studiów: {0}, grupa: {1}, nr indeksu: {2}\n", rok, grupa, nrIndeksu);
        }

        public void DodajOcene(string nazwaPrzedmiotu, string data, double wartosc)
        {
            oceny.Add(new Ocena(nazwaPrzedmiotu, data, wartosc));
        }

        public void WypiszOceny()
        {
            foreach (var ocena in oceny)
                ocena.WypiszInfo();
        }

        public void WypiszOceny(string nazwaPrzedmiotu)
        {
            foreach (var ocena in oceny)
                if (ocena.NazwaPrzedmiotu == nazwaPrzedmiotu)
                    ocena.WypiszInfo();
        }

        public void UsunOcene(string nazwaPrzedmiotu, string data, double wartosc)
        {
            Ocena doUsuniecia = oceny.Find(x => x.NazwaPrzedmiotu == nazwaPrzedmiotu && x.Data == data && x.Wartosc == wartosc);

            if (doUsuniecia != null)
                oceny.Remove(doUsuniecia);
        }

        public void UsunOceny()
        {
            oceny = new List<Ocena>();
        }

        public void UsunOceny(string nazwaPrzedmiotu)
        {
            oceny.RemoveAll(x => x.NazwaPrzedmiotu == nazwaPrzedmiotu);
        }
    }

    class PilkarzReczny : Pilkarz
    {
        public PilkarzReczny(string imie, string nazwisko, string dataUrodzenia, string pozycja, string klub, int liczbaGoli) : base(imie, nazwisko, dataUrodzenia, pozycja, klub, liczbaGoli)
        {
        }

        public new void StrzelGola()
        {
            Console.WriteLine("\nGol !!! Strzelcem jest: {0} {1}\n", imie, nazwisko);
        }
    }

    class PilkarzNozny : Pilkarz
    {
        public PilkarzNozny(string imie, string nazwisko, string dataUrodzenia, string pozycja, string klub, int liczbaGoli) : base(imie, nazwisko, dataUrodzenia, pozycja, klub, liczbaGoli)
        {
        }

        public new void StrzelGola()
        {
            Console.WriteLine("\nGol !!! Strzelcem jest: {0} {1}\n", imie, nazwisko);
        }
    }

    class Ocena
    {
        public string NazwaPrzedmiotu { get { return nazwaPrzedmiotu; } }
        public string Data { get { return data; } }
        public double Wartosc { get { return wartosc; } }
        private string nazwaPrzedmiotu;
        private string data;
        private double wartosc;

        public Ocena(string nazwaPrzedmiotu, string data, double wartosc)
        {
            this.nazwaPrzedmiotu = nazwaPrzedmiotu;
            this.data = data;
            this.wartosc = wartosc;
        }

        public void WypiszInfo()
        {
            Console.WriteLine("Przedmiot: {0}, ocena: {1:0.0}, data: {2}", nazwaPrzedmiotu, wartosc, data);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Kamil", "Lewalski", "1977/02/01", 2, 4, 122112);
            student.DodajOcene("ZPrOb", "2017/03/12", 5.0);
            student.DodajOcene("ZPrOb", "2017/03/14", 4.0);
            student.DodajOcene("SR", "2017/02/10", 3.0);
            student.DodajOcene("SR", "2017/03/09", 2.0);
            student.DodajOcene("PSI", "2017/03/10", 5.0);
            student.DodajOcene("SI", "2017/03/10", 4.0);
            student.DodajOcene("AiOK", "2017/03/10", 3.0);

            student.WypiszInfo();
            student.WypiszOceny();

            Console.WriteLine();

            Console.WriteLine("usun ocene SR 2017/03/09 2.0");
            student.UsunOcene("SR", "2017/03/09", 2.0);
            Console.WriteLine("usun ocene ZPrOb 2017/03/12 5.0");
            student.UsunOcene("ZPrOb", "2017/03/12", 5.0);
            student.WypiszOceny();

            Console.WriteLine();

            Console.WriteLine("usun wszystkie oceny z ZPrOb");
            student.UsunOceny("ZPrOb");
            student.WypiszOceny();

            Console.WriteLine();

            Console.WriteLine("usun wszystkie oceny");
            student.UsunOceny();
            student.WypiszOceny();

            Console.WriteLine("\n---------------------------\n");

            Pilkarz pilkarz = new Pilkarz("Michał", "Polny", "1994/11/12", "Napastnik", "Orły", 7);
            PilkarzReczny pilkarzReczny = new PilkarzReczny("Adam", "Góra", "1987/01/15", "Obrotowy", "Mistrzowie", 15);
            PilkarzNozny pilkarzNozny = new PilkarzNozny("Paweł", "Pielec", "1999/12/01", "Obrońca", "Orły2", 6);

            pilkarz.WypiszInfo();
            pilkarz.StrzelGola();
            pilkarzReczny.WypiszInfo();
            pilkarzReczny.StrzelGola();
            pilkarzNozny.WypiszInfo();
            pilkarzNozny.StrzelGola();

            Console.ReadKey();
        }
    }
}
