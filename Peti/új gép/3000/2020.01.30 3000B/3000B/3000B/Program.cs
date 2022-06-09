using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3000B
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader("PT-3000B.txt", Encoding.Default);
            StreamWriter w1 = new StreamWriter("Fodor_Dániel-PT-3000B-1.txt");
            StreamWriter w2 = new StreamWriter("Fodor_Dániel-PT-3000B-2.txt");
            StreamWriter w3 = new StreamWriter("Fodor_Dániel-PT-3000B-3.txt");
            StreamWriter w4 = new StreamWriter("Fodor_Dániel-PT-3000B-4.txt");
            StreamWriter w5 = new StreamWriter("Fodor_Dániel-PT-3000B-5.txt");
            StreamWriter w6 = new StreamWriter("Fodor_Dániel-PT-3000B-6.txt");
            StreamWriter w7 = new StreamWriter("Fodor_Dániel-PT-3000B-7.txt");
            StreamWriter w8 = new StreamWriter("Fodor_Dániel-PT-3000B-8.txt");
            StreamWriter w9 = new StreamWriter("Fodor_Dániel-PT-3000B-9.txt");
            StreamWriter w10 = new StreamWriter("Fodor_Dániel-PT-3000B-10.txt");

            int beolvasottérték = int.Parse(r.ReadLine());
            int i1 = 0;
            bool vanepozitív = false;
            bool nevizsgáldtovább1 = true;
            int oszth33 = -1;
            int legkisebb = int.Parse(r.ReadLine());
            int sum = 0;
            int db = 0;
            bool mindenpozitíve = true;
            int páratlandb = 0;
            int előző = 0;
            bool negutánneg = false;
            int ut19ix = -1;
            int index = 0;
            List<int> _5teloszthatólista = new List<int>();

            while (!r.EndOfStream)
            {
                beolvasottérték = int.Parse(r.ReadLine());

                //1.
                if (beolvasottérték > 0)
                {
                    vanepozitív = true;
                }

                //2.
                i1++;

                //3.
                if (beolvasottérték < legkisebb)
                {
                    legkisebb = beolvasottérték;
                }

                //4.
                if (beolvasottérték % 33 == 0 && nevizsgáldtovább1)
                {
                    oszth33 = beolvasottérték;
                    nevizsgáldtovább1 = false;
                }

                //5.
                sum += beolvasottérték;
                db++;

                //6.
                if (beolvasottérték % 2 == 1)
                {
                    mindenpozitíve = false;
                }

                //7.
                if (beolvasottérték % 2 == 1)
                {
                    páratlandb++;
                }

                //8.
                if (előző < 0 && beolvasottérték < 0)
                {
                    negutánneg = true;
                }
                előző = beolvasottérték;

                //9.
                if (beolvasottérték % 19 == 0)
                {
                    ut19ix = index;
                }
                index++;

                //10.
                if (beolvasottérték % 5 == 0)
                {
                    _5teloszthatólista.Add(beolvasottérték);
                    w10.WriteLine(beolvasottérték);
                }
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. Van-e a sorozatban pozitív szám?");
            Console.WriteLine(vanepozitív ? "Van" : "Nincs");
            w1.WriteLine(vanepozitív);
            Console.WriteLine("------------------------------");
            Console.WriteLine("2. Hány eleme van a sorozatnak?");
            Console.WriteLine(i1);
            w2.WriteLine(i1);
            Console.WriteLine("------------------------------");
            Console.WriteLine("3. Mennyi a sorozatban található legkisebb szám?");
            Console.WriteLine(legkisebb);
            w3.WriteLine(legkisebb);
            Console.WriteLine("------------------------------");
            Console.WriteLine("4. Írjuk ki az első 33-mal osztható szám indexét!");
            if (oszth33 != -1)
            {
                Console.WriteLine(oszth33);
                w4.WriteLine(oszth33);
            }
            else
            {
                Console.WriteLine("Nincs ilyen");
                w4.WriteLine("False");
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine("5. Mennyi a sorozatban található számok átlagának a fele?");
            Console.WriteLine((sum*1.0 / db) / 2);
            w5.WriteLine((sum / db) / 2);
            Console.WriteLine("------------------------------");
            Console.WriteLine("6. Igaz-e, hogy minden szám pozitív?");
            Console.WriteLine(mindenpozitíve? "Igaz" : "Nem igaz");
            w6.WriteLine(mindenpozitíve);
            Console.WriteLine("------------------------------");
            Console.WriteLine("7. Hány páratlan szám található a sorozatban?");
            Console.WriteLine(páratlandb);
            w7.WriteLine(páratlandb);
            Console.WriteLine("------------------------------");
            Console.WriteLine("8. Van-e a sorozatban olyan negatív szám, amelyet újabb negatív követ?");
            Console.WriteLine(negutánneg ? "Van" : "Nincs");
            w8.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("9. Írjuk ki az utolsó 19-cel osztható szám indexét!");
            Console.WriteLine(ut19ix);
            w9.WriteLine(ut19ix);
            Console.WriteLine("------------------------------");
            Console.WriteLine("10. Írjuk ki a sorozatban található 5-tel osztható számokat!");
            for (int i = 0; i < _5teloszthatólista.Count; i++)
            {
                Console.WriteLine(_5teloszthatólista[i]);
            }
            Console.WriteLine("------------------------------");


            r.Close();
            w1.Close();
            w2.Close();
            w3.Close();
            w4.Close();
            w5.Close();
            w6.Close();
            w7.Close();
            w8.Close();
            w9.Close();
            w10.Close();
        }
    }
}