using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3000O
{
    class Program
    {
        class Ország
        {
            public string név;
            public string államforma;
            public int terület;
            public int népesség;
            public string földrész;
        }
        static void Feladat(int szám, string feladat)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0}) ", szám);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", feladat);
        }
        static void Kiválogatás(List<Ország> országok, Func<Ország, bool> predikátum)
        {
            for (int i = 0; i < országok.Count; i++)
            {
                if (predikátum(országok[i]))
                {
                    Console.WriteLine(országok[i].név);
                }
            }
        }
        static int Összeg<T>(List<T> lista, Func<T, bool> predikátum, Func<T, int> projekció)
        {
            int sum = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                if (predikátum(lista[i]))
                {
                    sum += projekció(lista[i]);
                }
            }
            return sum;
        }
        static void MAXMIN(List<Ország> országok, Func<Ország, bool> predikátum, Func<Ország, int> projekció, string maxmin, string me)
        {
            int max = 0; //itt feltételezek
            int min = 2147483647; //itt feltételezek
            if (maxmin == "max")
            {
                for (int i = 0; i < országok.Count; i++)
                {
                    if (predikátum(országok[i]) && projekció(országok[i]) > max)
                    {
                        max = projekció(országok[i]);
                    }
                }
                Console.WriteLine("{0}{1}", max, me);
            }
            if (maxmin == "min")
            {
                for (int i = 0; i < országok.Count; i++)
                {
                    if (predikátum(országok[i]) && projekció(országok[i]) < min)
                    {
                        min = projekció(országok[i]);
                    }
                }
                Console.WriteLine("{0}{1}", min, me);
            }
        }

        static void Main(string[] args)
        {
            #region Beolvasás
            List<Ország> országok = new List<Ország>();
            using (StreamReader f = new StreamReader("Orszagadat.txt", Encoding.Default))
            {
                while (!f.EndOfStream)
                {
                    string[] sor = f.ReadLine().Split('\t');
                    országok.Add(new Ország
                    {
                        név = sor[0],
                        államforma = sor[1],
                        terület = int.Parse(sor[2]),
                        népesség = int.Parse(sor[3]),
                        földrész = sor[4]
                    });
                }
            }
            #endregion

            #region Feladatok
            #region 1) Feladat
            Feladat(1, "Hány ország található az input fájlban?");
            Console.WriteLine(országok.Count);
            Console.WriteLine();
            #endregion

            #region 2-11) Feladat
            Feladat(2, "Határozza meg az afrikai földrész népességének a nagyságát ezer főben!");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Afrika", x => x.népesség));
            Console.WriteLine();

            Feladat(3, "Határozza meg a dél-amerikai földrész népességének a nagyságát ezer főben!");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Dél-Amerika", x => x.népesség));
            Console.WriteLine();

            Feladat(4, "Határozza meg a közép-amerikai földrész népességének a nagyságát ezer főben!");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Közép-Amerika", x => x.népesség));
            Console.WriteLine();

            Feladat(5, "Határozza meg a közép-amerikai földrész népességének a nagyságát ezer főben!");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Közép-Amerika", x => x.népesség));
            Console.WriteLine();

            Feladat(6, "Határozza meg az észak-amerikai földrész népességének a nagyságát ezer főben!");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Észak-Amerika", x => x.népesség));
            Console.WriteLine();

            Feladat(7, "Határozza meg az afrikai földrész területének a nagyságát négyzetkilométerben!");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Afrika", x => x.terület));
            Console.WriteLine();

            Feladat(8, "Határozza meg a dél-amerikai földrész területének a nagyságát négyzetkilométerben!");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Dél-Amerika", x => x.terület));
            Console.WriteLine();

            Feladat(9, "Határozza meg a közép-amerikai földrész területének a nagyságát négyzetkilométerben!");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Közép-Amerika", x => x.terület));
            Console.WriteLine();

            Feladat(10, "Határozza meg a közép-amerikai földrész területének a nagyságát négyzetkilométerben!");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Közép-Amerika", x => x.terület));
            Console.WriteLine();

            Feladat(11, "Határozza meg az észak-amerikai földrész területének a nagyságát négyzetkilométerben!");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Észak-Amerika", x => x.terület));
            Console.WriteLine();
            #endregion

            #region 12-15) Feladat
            Feladat(12, "Hány ország található az afrikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Afrika", x => 1));
            Console.WriteLine();

            Feladat(13, "Hány ország található a dél-amerikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Dél-Amerika", x => 1));
            Console.WriteLine();

            Feladat(14, "Hány ország található a közép-amerikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Közép-Amerika", x => 1));
            Console.WriteLine();

            Feladat(15, "Hány ország található az észak-amerikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Észak-Amerika", x => 1));
            Console.WriteLine();
            #endregion

            #region 16-25) Feladat
            Feladat(16, "Hány 5000 négyzetkilométernél nagyobb ország található az afrikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Afrika" && x.terület > 5000, x => 1));
            Console.WriteLine();

            Feladat(17, "Hány 5000 négyzetkilométernél kisebb ország található az afrikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Afrika" && x.terület < 5000, x => 1));
            Console.WriteLine();

            Feladat(18, "Hány 15000 négyzetkilométernél nagyobb ország található az dél-amerikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Dél-Amerika" && x.terület > 15000, x => 1));
            Console.WriteLine();

            Feladat(19, "Hány 7000 négyzetkilométernél kisebb ország található az dél-amerikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Dél-Amerika" && x.terület < 7000, x => 1));
            Console.WriteLine();

            Feladat(20, "Hány 7000 négyzetkilométernél nagyobb ország található az közép-amerikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Közép-Amerika" && x.terület > 7000, x => 1));
            Console.WriteLine();

            Feladat(21, "Hány 8000 négyzetkilométernél kisebb ország található az közép-amerikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => x.földrész == "Közép-Amerika" && x.terület < 8000, x => 1));
            Console.WriteLine();

            Feladat(22, "Hány 8000 négyzetkilométernél kisebb ország található az amerikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => (x.földrész == "Dél-Amerika" || x.földrész == "Közép-Amerika" || x.földrész == "Észak-Amerika") && x.terület < 8000, x => 1));
            Console.WriteLine();

            Feladat(23, "Hány 8000 négyzetkilométernél nagyobb ország található az amerikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => (x.földrész == "Dél-Amerika" || x.földrész == "Közép-Amerika" || x.földrész == "Észak-Amerika") && x.terület < 8000, x => 1));
            Console.WriteLine();

            Feladat(24, "Hány 20 milliónál kisebb népességű ország található az amerikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => (x.földrész == "Dél-Amerika" || x.földrész == "Közép-Amerika" || x.földrész == "Észak-Amerika") && x.népesség < 20000, x => 1));
            Console.WriteLine();

            Feladat(25, "Hány 20 milliónál nagyobb népességű ország található az amerikai földrészen?");
            Console.WriteLine(Összeg<Ország>(országok, x => (x.földrész == "Dél-Amerika" || x.földrész == "Közép-Amerika" || x.földrész == "Észak-Amerika") && x.terület > 20000, x => 1));
            Console.WriteLine();
            #endregion

            #region 26-33) Feladat
            Feladat(26, "Válogassa ki a 20 milliónál népesebb afrikai országokat!");
            Kiválogatás(országok, x => x.népesség > 20000 && x.földrész == "Afrika");
            Console.WriteLine();

            Feladat(27, "Válogassa ki a 20 milliónál népesebb dél-amerikai országokat!");
            Kiválogatás(országok, x => x.népesség > 20000 && x.földrész == "Dél-Amerika");
            Console.WriteLine();

            Feladat(28, "Válogassa ki a 20 milliónál népesebb közép-amerikai országokat!");
            Kiválogatás(országok, x => x.népesség > 20000 && x.földrész == "Közép-Amerika");
            Console.WriteLine();

            Feladat(29, "Válogassa ki a 20 milliónál népesebb észak-amerikai országokat!");
            Kiválogatás(országok, x => x.népesség > 20000 && x.földrész == "Észak-Amerika");
            Console.WriteLine();

            Feladat(30, "Válogassa ki a 20 milliónál népesebb amerikai országokat!");
            Kiválogatás(országok, x => x.népesség > 20000 && (x.földrész == "Dél-Amerika" || x.földrész == "Közép-Amerika" || x.földrész == "Észak-Amerika"));
            Console.WriteLine();

            Feladat(31, "Válogassa ki a 20 milliónál alacsonyabb népességű amerikai országokat!");
            Kiválogatás(országok, x => x.népesség < 20000 && (x.földrész == "Dél-Amerika" || x.földrész == "Közép-Amerika" || x.földrész == "Észak-Amerika"));
            Console.WriteLine();

            Feladat(32, "Válogassa ki a 100000 négyzetkilométernél nagyobb amerikai országokat!");
            Kiválogatás(országok, x => x.terület > 100000 && (x.földrész == "Dél-Amerika" || x.földrész == "Közép-Amerika" || x.földrész == "Észak-Amerika"));
            Console.WriteLine();

            Feladat(33, "Válogassa ki a 100000 négyzetkilométernél kisebb amerikai országokat!");
            //Kiválogatás(országok, x => x.terület > 100000 && x.földrész.EndsWith("Amerika"));
            Kiválogatás(országok, x => x.terület > 100000 && (x.földrész == "Dél-Amerika" || x.földrész == "Közép-Amerika" || x.földrész == "Észak-Amerika"));
            Console.WriteLine();















            #endregion

            #region 34-52) Feladat
            Feladat(34, "Mekkora a területe a fájlban található legnagyobb országnak?");
            MAXMIN(országok, x => x.földrész != "asdasd", x => x.terület, "max", " kmˇ2"); //itt feltételezem hogy nincs asdasd nevű földrész a fájlban
            Console.WriteLine();

            Feladat(35, "Mekkora a területe a fájlban található legkisebb országnak?");
            MAXMIN(országok, x => x.földrész != "asdasd", x => x.terület, "min", " kmˇ2"); //itt feltételezem hogy nincs asdasd nevű földrész a fájlban
            Console.WriteLine();

            Feladat(36, "Mekkora a lakossága a fájlban található legnépesebb országnak?");
            MAXMIN(országok, x => x.földrész != "asdasd", x => x.népesség, "max", "000 fő"); //itt feltételezem hogy nincs asdasd nevű földrész a fájlban
            Console.WriteLine();

            Feladat(37, "Mekkora a lakossága a fájlban található legkisebb népességű országnak?");
            MAXMIN(országok, x => x.földrész != "asdasd", x => x.népesség, "min", "000 fő"); //itt feltételezem hogy nincs asdasd nevű földrész a fájlban
            Console.WriteLine();

            Feladat(38, "Mekkora a területe a legnagyobb afrikai országnak?");
            MAXMIN(országok, x => x.földrész == "Afrika", x => x.terület, "max", " kmˇ2");
            Console.WriteLine();

            Feladat(39, "Mekkora a területe a legnagyobb dél-amerikai országnak?");
            MAXMIN(országok, x => x.földrész == "Dél-Amerika", x => x.terület, "min", " kmˇ2");
            Console.WriteLine();

            Feladat(40, "Mekkora a területe a legnagyobb közép-amerikai országnak?");
            MAXMIN(országok, x => x.földrész == "Közép-Amerika", x => x.terület, "max", " kmˇ2");
            Console.WriteLine();

            Feladat(41, "Mekkora a területe a legnagyobb észak-amerikai országnak?");
            MAXMIN(országok, x => x.földrész == "Észak-Amerika", x => x.terület, "min", " kmˇ2");
            Console.WriteLine();

            Feladat(42, "Mekkora a területe a legnagyobb amerikai országnak?");
            MAXMIN(országok, x => (x.földrész == "Dél-Amerika" || x.földrész == "Közép-Amerika" || x.földrész == "Észak-Amerika"), x => x.terület, "max", " kmˇ2");
            Console.WriteLine();

            Feladat(43, "Mennyi a lakossága a legnépesebb afrikai országnak?");
            MAXMIN(országok, x => x.földrész == "Afrika", x => x.népesség, "max", "000 fő");
            Console.WriteLine();

            Feladat(44, "Mennyi a lakossága a legnépesebb dél-amerikai országnak?");
            MAXMIN(országok, x => x.földrész == "Dél-Amerika", x => x.népesség, "max", "000 fő");
            Console.WriteLine();

            Feladat(45, "Mennyi a lakossága a legnépesebb közép-amerikai országnak?");
            MAXMIN(országok, x => x.földrész == "Közép-Amerika", x => x.népesség, "max", "000 fő");
            Console.WriteLine();

            Feladat(46, "Mennyi a lakossága a legnépesebb észak-amerikai országnak?");
            MAXMIN(országok, x => x.földrész == "Észak-Amerika", x => x.népesség, "max", "000 fő");
            Console.WriteLine();

            Feladat(47, "Mennyi a lakossága a legnépesebb amerikai országnak?");
            MAXMIN(országok, x => (x.földrész == "Dél-Amerika" || x.földrész == "Közép-Amerika" || x.földrész == "Észak-Amerika"), x => x.népesség, "max", "000 fő");
            Console.WriteLine();

            Feladat(48, "Mekkora a népsűrűsége a legsűrűbben lakott afrikai országnak (fő/négyzetkilométer)?");
            MAXMIN(országok, x => x.földrész == "Afrika", x => (x.népesség * 1000) / x.terület, "max", " fő/kmˇ2");
            Console.WriteLine();

            Feladat(49, "Mekkora a népsűrűsége a legsűrűbben lakott dél-amerikai országnak (fő/négyzetkilométer)?");
            MAXMIN(országok, x => x.földrész == "Dél-Amerika", x => (x.népesség * 1000) / x.terület, "max", " fő/kmˇ2");
            Console.WriteLine();

            Feladat(50, "Mekkora a népsűrűsége a legsűrűbben lakott közép-amerikai országnak (fő/négyzetkilométer)?");
            MAXMIN(országok, x => x.földrész == "Közép-Amerika", x => (x.népesség * 1000) / x.terület, "max", " fő/kmˇ2");
            Console.WriteLine();

            Feladat(51, "Mekkora a népsűrűsége a legsűrűbben lakott észak-amerikai országnak (fő/négyzetkilométer)?");
            MAXMIN(országok, x => x.földrész == "Észak-Amerika", x => (x.népesség * 1000) / x.terület, "max", " fő/kmˇ2");
            Console.WriteLine();

            Feladat(52, "Mekkora a népsűrűsége a legsűrűbben lakott amerikai országnak (fő/négyzetkilométer)?");
            MAXMIN(országok, x => (x.földrész == "Dél-Amerika" || x.földrész == "Közép-Amerika" || x.földrész == "Észak-Amerika"), x => (x.népesség * 1000) / x.terület, "max", " fő/kmˇ2");
            Console.WriteLine();
            #endregion
            #endregion
        }
    }
}
