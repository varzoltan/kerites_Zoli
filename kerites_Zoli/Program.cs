using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kerites_Zoli
{
    class Program
    {
        struct Adat
        {
            public int paros_paratlan;
            public int szelesseg;
            public string k_szin;
            public int hazszam;
        }
        static void Main(string[] args)
        {
            //példányosítás
            Adat[] adatok = new Adat[1000];
            StreamReader olvas = new StreamReader(@"C:\Users\Rendszergazda\Desktop\2018-oktober\kerites.txt");
            int n = 0;
            int paros = 0;
            int paratlan = -1;
            while (!olvas.EndOfStream)
            {
                string sor = olvas.ReadLine();
                string[] db = sor.Split();
                adatok[n].paros_paratlan = int.Parse(db[0]);
                adatok[n].szelesseg = int.Parse(db[1]);
                adatok[n].k_szin = db[2];
                if (int.Parse(db[0]) == 0)
                {
                    paros += 2;
                    adatok[n].hazszam = paros;
                }
                else
                {
                    paratlan += 2;
                    adatok[n].hazszam = paratlan;
                }
                n++;
            }

            //2.feladat
            Console.WriteLine("2.feladat\nAz eladott telkek száma: {0}", n);

            //3.a feladat
            if (adatok[n-1].paros_paratlan == 0)
            {
                Console.WriteLine("3.feladat\nA páros oldalon adták el az utolsó telket.");
            }
            else
            {
                Console.WriteLine("3.feladat\nA páratlan oldalon adták el az utolsó telket.");
            }

            //3.b feladat
            Console.WriteLine("Az utolsó telek házszáma: {0}",adatok[n-1].hazszam);

            //4.feladat
            string szin1 = null;
            string szin2 = null;
            int szamlalo = 0;
            int k = 0;
            for (int i = 0;i<n;i++)
            {
                if (adatok[i].paros_paratlan == 1)
                {
                    szamlalo++;
                    if (adatok[i].k_szin != ":" && adatok[i].k_szin != "#" && szamlalo == 1)
                    {
                        szin1 = adatok[i].k_szin;
                    }
                    if (adatok[i].k_szin != ":" && adatok[i].k_szin != "#" && szamlalo == 2)
                    {
                        szin2 = adatok[i].k_szin;
                        if (szin1 == szin2)
                        {
                            Console.WriteLine("4.feladat\nA szomszédossal egyezik a kerítés színe: {0}", adatok[k].hazszam);
                            break;
                        }
                        szin1 = szin2;                       
                    }                   
                }
                szamlalo = 1;
                k = i;
            }

            //5.a feladat
            Console.Write("5.feladat:\nAdjon meg egy házszámot!  ");
            int adott_hsz =int.Parse(Console.ReadLine());
            string hazszin = null;
            for (int i =0; i<n;i++)
            {
                if (adott_hsz == adatok[i].hazszam)
                {
                    if (adatok[i].k_szin !=":" && adatok[i].k_szin != "#")
                    {
                        Console.WriteLine("A kerítés színe: {0}", adatok[i].k_szin);
                        hazszin = adatok[i].k_szin;
                    }
                    else
                    {
                        Console.WriteLine("A kerítés állapota: {0}", adatok[i].k_szin);
                        hazszin = adatok[i].k_szin;
                    }
                }
            }

            //5.b feladat
            for (int i ='A';i<='Z';i++)
            {
                for (int j = 0;j<n;j++)
                {
                    if (adatok[j].hazszam == adott_hsz - 2)
                    {
                        szin1 = adatok[j].k_szin;
                    }
                    if (adatok[j].hazszam == adott_hsz + 2)
                    {
                        szin2 = adatok[j].k_szin;
                    }
                }
                if (Convert.ToChar(szin1) != Convert.ToChar(i) && Convert.ToChar(szin2) != Convert.ToChar(i) && Convert.ToChar(hazszin) != Convert.ToChar(i))
                {
                    Console.WriteLine("Egy lehetséges festési szín: {0}", Convert.ToChar(i));
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
