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
        }
    }
}
