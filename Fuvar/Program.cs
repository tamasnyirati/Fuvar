using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvar
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sorok = File.ReadAllLines("fuvar.csv");
            List<Fuvar> fuvarok = new List<Fuvar>();

            foreach (string sor in sorok.Skip(1))
            {
                fuvarok.Add(new Fuvar(sor));
            }
            int N = fuvarok.Count;
            Console.WriteLine($"3. feladat: {N} fuvar");
            //4 6185 id bevételeösszesen és hány fuvarból áll
            int fuvarDb = 0;
            double bevetel = 0;
            foreach (Fuvar fuvar in fuvarok)
            {
                if(fuvar.id == 6185)
                {
                    fuvarDb++;
                    bevetel  += fuvar.Viteldij;
                }
            }

            Console.WriteLine($"4. feladat: {fuvarDb} fuvar alatt: {bevetel}$");

            //5
            Console.WriteLine("5. feladat: ");
            Dictionary<string, int> fizModDb = new Dictionary<string, int>();
            foreach (Fuvar fuvar in fuvarok)
            {
                string kulcs = fuvar.FizeteseiMod;
                if (fizModDb.ContainsKey(kulcs))
                {
                    fizModDb[kulcs]++;
                }
                else
                {
                    fizModDb.Add(kulcs, 1);
                }
            }
            foreach (KeyValuePair<string, int> item in fizModDb)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            //6
            double osszMerfold = 0;
            foreach (Fuvar fuvar in fuvarok)
            {
                osszMerfold += fuvar.Tavolsag;
            }

            Console.WriteLine($"6. feladat: {osszMerfold*1.6:N2} km");

            //7


            Console.WriteLine($"7. feladat: leghosszabb fuvar: ");
            int maxTavolsagInd = 0;
            for (int i = 1; i < N; i++)
            {
                if (fuvarok[i].Idotartam > fuvarok[maxTavolsagInd].Idotartam)
                {
                    maxTavolsagInd = i;
                }
            }
            Console.WriteLine($"\tfuvar hossza: {fuvarok[maxTavolsagInd].Idotartam} másodperc");
            Console.WriteLine($"\ttaxi ID: {fuvarok[maxTavolsagInd].id} ID");
            Console.WriteLine($"\tmegtett távolság: {fuvarok[maxTavolsagInd].id} km");
            Console.WriteLine($"\tviteldíj: {fuvarok[maxTavolsagInd].Viteldij} $");


            //8
            Console.WriteLine("8. feladat: \"hibak.txt\"");
            List<string> hibasSorok = new List<string>();
            hibasSorok.Add(sorok[0]);
            foreach (Fuvar fuvar in fuvarok)
            {
                if(fuvar.Idotartam >0 && fuvar.Viteldij>0 && fuvar.Tavolsag ==0)
                {
                    string sor = fuvar.id + "";
                    hibasSorok.Add(fuvar.ToString());
                }
            }
            File.WriteAllText("hibak.txt", hibasSorok.ToString(), Encoding.UTF8);
            Console.ReadLine();
        }
    }
}
