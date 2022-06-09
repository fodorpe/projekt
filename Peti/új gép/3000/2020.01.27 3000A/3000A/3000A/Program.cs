using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace _3000A
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader r1 = new StreamReader("PT-3000A.txt", Encoding.Default);
            StreamReader r2 = new StreamReader("PT-3000A.txt", Encoding.Default);
            StreamReader r3 = new StreamReader("PT-3000A.txt", Encoding.Default);
            StreamReader r4 = new StreamReader("PT-3000A.txt", Encoding.Default);
            StreamReader r5 = new StreamReader("PT-3000A.txt", Encoding.Default);
            StreamWriter w1 = new StreamWriter("Fodor_Dániel-PT-3000A-1.txt");
            StreamWriter w2 = new StreamWriter("Fodor_Dániel-PT-3000A-2.txt");
            StreamWriter w3 = new StreamWriter("Fodor_Dániel-PT-3000A-3.txt");
            StreamWriter w4 = new StreamWriter("Fodor_Dániel-PT-3000A-4.txt");
            StreamWriter w5 = new StreamWriter("Fodor_Dániel-PT-3000A-5.txt");
            StreamWriter w6 = new StreamWriter("Fodor_Dániel-PT-3000A-6.txt");
            StreamWriter w7 = new StreamWriter("Fodor_Dániel-PT-3000A-7.txt");
            StreamWriter w8 = new StreamWriter("Fodor_Dániel-PT-3000A-8.txt");
            StreamWriter w9 = new StreamWriter("Fodor_Dániel-PT-3000A-9.txt");
            StreamWriter w10 = new StreamWriter("Fodor_Dániel-PT-3000A-10.txt");

            int beolvasottérték1 = 0;
            int i1 = 0;
            bool vanenegatív = false;
            bool nevizsgáldtovább = false;
            int párosdb = 0;
            int legnagyobbszám = int.Parse(r1.ReadLine());
            while (!r1.EndOfStream)
            {
                beolvasottérték1 = int.Parse(r1.ReadLine());

                //1.
                i1++;

                //2.
                if (beolvasottérték1 < 0 && nevizsgáldtovább == false)
                {
                    vanenegatív = true;
                    nevizsgáldtovább = true;
                }

                //3.
                if (beolvasottérték1 % 2 == 0)
                {
                    párosdb++;
                }

                //4.
                if (beolvasottérték1 > legnagyobbszám)
                {
                    legnagyobbszám = beolvasottérték1;
                }
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. Hány eleme van a sorozatnak?");
            Console.WriteLine(i1);
            w1.WriteLine(i1);
            Console.WriteLine("------------------------------");
            Console.WriteLine("2. Van-e a sorozatban negatív szám?");
            Console.WriteLine(vanenegatív ? "Van" : "Nincs");
            w2.WriteLine(vanenegatív);
            Console.WriteLine("------------------------------");
            Console.WriteLine("3. Hány páros szám található a sorozatban?");
            Console.WriteLine(párosdb);
            w3.WriteLine(párosdb);
            Console.WriteLine("------------------------------");
            Console.WriteLine("4. Mennyi a sorozatban található legnagyobb szám?");
            Console.WriteLine(legnagyobbszám);
            w4.WriteLine(legnagyobbszám);
            Console.WriteLine("------------------------------");

            int beolvasottérték2 = 0;
            Console.WriteLine("5. Írjuk ki a sorozatban található 10-zel osztható számokat!");
            while (!r2.EndOfStream)
            {
                beolvasottérték2 = int.Parse(r2.ReadLine());

                //5.
                if (beolvasottérték2 % 10 == 0)
                {
                    Console.Write("{0}, ", beolvasottérték2);
                    w5.WriteLine(beolvasottérték2);
                }
            }
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            
            int beolvasottérték3 = 0;
            bool nevizsgáldtovább2 = false;
            bool nevizsgáldtovább3 = false;
            int index = 0;
            int _29celoszthatóindexe = -1;
            bool mindenpárose = true;
            while (!r3.EndOfStream)
            {
                beolvasottérték3 = int.Parse(r3.ReadLine());

                //6.
                if (beolvasottérték3 % 29 == 0 && nevizsgáldtovább2 == false)
                {
                    _29celoszthatóindexe = index;
                    nevizsgáldtovább2 = true;
                }

                //7.
                if (beolvasottérték3 % 2 == 1 && nevizsgáldtovább3 == false)
                {
                    mindenpárose = false;
                    nevizsgáldtovább3 = true;
                }




                index++;
            }
            Console.WriteLine("6. Írjuk ki az első 29-cel osztható szám indexét!");
            if (_29celoszthatóindexe != -1)
            {
                Console.WriteLine(_29celoszthatóindexe);
                w6.WriteLine(_29celoszthatóindexe);
            }
            else
            {
                Console.WriteLine("Nincs ilyen");
                w6.WriteLine("-1");
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine("7. Igaz-e, hogy minden szám páros?");
            Console.WriteLine(mindenpárose ? "Igaz" : "Nem igaz");
            w7.WriteLine(mindenpárose);
            Console.WriteLine("------------------------------");

            int beolvasottérték4 = 0;
            int össz = 0;
            int i2 = 0;
            Console.WriteLine("8. Mennyi a sorozatban található számok átlaga?");
            while (!r4.EndOfStream)
            {
                beolvasottérték4 = int.Parse(r4.ReadLine());

                //8.
                össz += beolvasottérték4;
                i2++;
            }
            Console.WriteLine(össz/i2);
            w8.WriteLine(össz/i2);
            Console.WriteLine("------------------------------");

            int beolvasottérték5 = 0;
            bool van = false;
            int előző = 1;
            int index2 = 0;
            int _17index = -1;
            while (!r5.EndOfStream)
            {
                beolvasottérték5 = int.Parse(r5.ReadLine());

                //9.
                if (beolvasottérték5 == 0 && előző < 0)
                {
                    van = true;
                }
                előző = beolvasottérték5;

                //10.
                if (beolvasottérték5 % 17 == 0)
                {
                    _17index = index;
                }

                index2++;
            }
            Console.WriteLine("9. Van-e a sorozatban olyan negatív szám, amelyet nulla követ?");
            Console.WriteLine(van ? "Van" : "Nincs");
            w9.WriteLine(van);
            Console.WriteLine("------------------------------");
            Console.WriteLine("10. Írjuk ki az utolsó 17-tel osztható szám indexét!");
            if (_17index != -1)
            {
                Console.WriteLine(_17index);
                w10.WriteLine(_17index);
            }
            else
            {
                Console.WriteLine("Nincs ilyen");
                w10.WriteLine("-1");
            }
            Console.WriteLine("------------------------------");

            r1.Close();
            r2.Close();
            r3.Close();
            r4.Close();
            r5.Close();
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


            
