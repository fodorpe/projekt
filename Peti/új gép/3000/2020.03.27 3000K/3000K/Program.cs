using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3000K
{
    class Program
    {
        class Eredmény
        {
            public int sorszám;
            public string ország;
            public int helyezés;
            public int vbév;
            public string vbhely;
        }
        class OrszágÉsSzám
        {
            public string ország;
            public int szám;
            public int év;
        }
        static void Feladat(int szám, string feladat)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0}) ", szám);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", feladat);
        }
        static void Kiválogatás<T>(List<Eredmény> eredménylista, Func<Eredmény, bool> predikátum, Func<Eredmény, T> projekció1, Func<Eredmény, T> projekció2, Func<Eredmény, T> projekció3)
        {
            for (int i = 0; i < eredménylista.Count; i++)
            {
                if (predikátum(eredménylista[i]))
                {
                    Console.WriteLine("{0}\t{1}\t{2}", projekció1(eredménylista[i]), projekció2(eredménylista[i]), projekció3(eredménylista[i]));
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
        static void MAXMIN(List<Eredmény> eredménylista, Func<Eredmény, bool> predikátum, Func<Eredmény, int> projekció, string maxmin)
        {
            int max = 0; //itt feltételezek
            int min = 2147483647; //itt feltételezek
            if (maxmin == "max")
            {
                for (int i = 0; i < eredménylista.Count; i++)
                {
                    if (predikátum(eredménylista[i]) && projekció(eredménylista[i]) > max)
                    {
                        max = projekció(eredménylista[i]);
                    }
                }
                Console.WriteLine("{0}", max);
            }
            if (maxmin == "min")
            {
                for (int i = 0; i < eredménylista.Count; i++)
                {
                    if (predikátum(eredménylista[i]) && projekció(eredménylista[i]) < min)
                    {
                        min = projekció(eredménylista[i]);
                    }
                }
                Console.WriteLine("{0}", min);
            }
        }
        static void Legelső(List<Eredmény> eredménylista, Func<Eredmény, int> projekció)
        {
            int min = eredménylista[0].vbév;
            for (int i = 0; i < eredménylista.Count; i++)
            {
                if (projekció(eredménylista[i]) < min)
                {
                    min = projekció(eredménylista[i]);
                }
            }
            Console.WriteLine("{0}", min);
        }
        static bool BenneVanE(List<List<string>> lista, int év, string hely)
        {
            int i = 0;
            bool megvan = false;
            while (!megvan && i < lista.Count)
            {
                if (lista[i][0] == év.ToString() && lista[i][1] == hely)
                {
                    megvan = true;
                }
                i++;
            }
            return megvan;
        }
        static int BenneVanE(List<OrszágÉsSzám> lista, string ország)
        {
            bool megvan = false;
            int i = 0;
            int j = -1;
            while (i < lista.Count && !megvan)
            {
                if (lista[i].ország == ország)
                {
                    megvan = true;
                    j = i;
                }
                i++;
            }
            return j;
        }
        static int BenneVanE(List<OrszágÉsSzám> lista, OrszágÉsSzám ez)
        {
            bool megvan = false;
            int i = 0;
            int j = -1;
            while (i < lista.Count && !megvan)
            {
                if (lista[i].ország == ez.ország && lista[i].év == ez.év)
                {
                    megvan = true;
                    j = i;
                }
                i++;
            }
            return j;
        }
        static void Döntőtjátszott(List<Eredmény> lista, string ország)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].ország == ország && (lista[i].helyezés == 1 || lista[i].helyezés == 2))
                {
                    for (int j = 0; j < lista.Count; j++)
                    {
                        if (i != j && lista[j].vbhely == lista[i].vbhely && lista[j].vbév == lista[i].vbév && (lista[j].helyezés == 1 || lista[j].helyezés == 2))
                        {
                            Console.WriteLine("{0}\t{1}", lista[j].ország, lista[j].vbév);                            
                        }
                    }
                }
            }
        }
        static void DobogósHelyVbNyertes(List<Eredmény> lista, string ország)
        {
            bool megvan = false;
            int j = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                megvan = false;
                j = 0;
                if (lista[i].ország == ország && (lista[i].helyezés == 1 || lista[i].helyezés == 2 || lista[i].helyezés == 3))
                {
                    while (!megvan && j < lista.Count)
                    {
                        if (i != j && lista[j].ország != ország && lista[j].vbhely == lista[i].vbhely && lista[j].vbév == lista[i].vbév && lista[j].helyezés == 1)
                        {
                            megvan = true;
                            Console.WriteLine("{0}\t{1}", lista[j].vbév, lista[j].ország);
                        }
                        j++;
                    }
                }
            }
        }
        static void TöbbszörNyert(List<Eredmény> lista)
        {
            List<OrszágÉsSzám> kimenet = new List<OrszágÉsSzám>();
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].helyezés == 1 && BenneVanE(kimenet, lista[i].ország) == -1)
                {
                    kimenet.Add(new OrszágÉsSzám { ország = lista[i].ország, szám = 1 });
                }
                else if (lista[i].helyezés == 1)
                {
                    kimenet[BenneVanE(kimenet, lista[i].ország)].szám++;
                }
            }
            for (int i = 0; i < kimenet.Count; i++)
            {
                if (kimenet[i].szám == 1)
                {
                    kimenet.RemoveAt(i);
                }
            }
            for (int i = 0; i < kimenet.Count; i++)
            {
                Console.WriteLine(kimenet[i].ország);
            }
        }
        static void TöbbszörRendezettVbt(List<Eredmény> lista)
        {
            List<OrszágÉsSzám> kimenet = new List<OrszágÉsSzám>();
            for (int i = 0; i < lista.Count; i++)
            {
                if (BenneVanE(kimenet, lista[i].vbhely) == -1)
                {
                    kimenet.Add(new OrszágÉsSzám { ország = lista[i].vbhely, szám = 1 });
                }
                else
                {
                    kimenet[BenneVanE(kimenet, lista[i].vbhely)].szám++;
                }
            }
            for (int i = 0; i < kimenet.Count; i++)
            {
                if (kimenet[i].szám == 1)
                {
                    kimenet.RemoveAt(i);
                }
            }
            for (int i = 0; i < kimenet.Count; i++)
            {
                Console.WriteLine(kimenet[i].ország);
            }
        }
        static void Feladat60_62(List<Eredmény> lista, string mi)
        {
            List<OrszágÉsSzám> kimenet = new List<OrszágÉsSzám>();
            int legtöbb = 0;
            bool igaze = false;
            bool kész = false;
            int i0 = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                if (mi == "nyert")
                {
                    if (lista[i].helyezés == 1 && BenneVanE(kimenet, lista[i].ország) == -1)
                    {
                        kimenet.Add(new OrszágÉsSzám { ország = lista[i].ország, szám = 1 });
                    }
                    else if (lista[i].helyezés == 1)
                    {
                        kimenet[BenneVanE(kimenet, lista[i].ország)].szám++;
                    }
                }
                if (mi == "rendezett")
                {
                    if (BenneVanE(kimenet, new OrszágÉsSzám { ország = lista[i].ország, év = lista[i].vbév }) == -1)
                    {
                        kimenet.Add(new OrszágÉsSzám { ország = lista[i].vbhely, év = lista[i].vbév, szám = 1 });
                    }
                    else
                    {
                        kimenet[BenneVanE(kimenet, lista[i].vbhely)].szám++;
                    }
                }
                if (mi == "vesztett")
                {
                    if (lista[i].helyezés == 2 && BenneVanE(kimenet, lista[i].ország) == -1)
                    {
                        kimenet.Add(new OrszágÉsSzám { ország = lista[i].ország, szám = 1 });
                    }
                    else if (lista[i].helyezés == 2)
                    {
                        kimenet[BenneVanE(kimenet, lista[i].ország)].szám++;
                    }
                }
            }
            for (int i = 0; i < kimenet.Count; i++)
            {
                if (legtöbb < kimenet[i].szám)
                {
                    legtöbb = kimenet[i].szám;
                }
            }

            for (int i = 0; i < kimenet.Count; i++)
            {
                if (igaze == false && kimenet[i].szám < legtöbb)
                {
                    igaze = true;
                }
            }
            if (igaze == true)
            {
                while (!kész)
                {
                    kész = true;
                    while (i0 < kimenet.Count)
                    {
                        if (kimenet[i0].szám < legtöbb)
                        {
                            kimenet.RemoveAt(i0);
                        }
                        else
                        {
                            i0++;
                        }
                    }
                }
            }
            for (int i = 0; i < kimenet.Count; i++)
            {
                Console.WriteLine("{0}\t{1}", kimenet[i].ország, kimenet[i].szám);
            }
        }
        static void Main(string[] args)
        {
            #region Beolvasás
            StreamReader f = new StreamReader("focivb.txt", Encoding.Default);
            List<Eredmény> eredménylista = new List<Eredmény>();
            while (!f.EndOfStream)
            {
                string[] sor = f.ReadLine().Split('\t');
                eredménylista.Add(new Eredmény
                {
                    sorszám = int.Parse(sor[0]),
                    ország = sor[1],
                    helyezés = int.Parse(sor[2]),
                    vbév = int.Parse(sor[3]),
                    vbhely = sor[4]
                });
            }
            #endregion

            #region Feladatok
            #region 1-6) Feladat
            Feladat(1, "Írja ki Magyarország által elért helyezéseket. A kiírásban jelenjen meg a vb éve és helyszíne is.");
            Kiválogatás(eredménylista, x => x.ország == "Magyarország", x => x.vbhely, x => x.vbév.ToString(), x => x.vbhely);
            Console.WriteLine();

            Feladat(2, "Írja ki Anglia által elért helyezéseket. A kiírásban jelenjen meg a vb éve és helyszíne is.");
            Kiválogatás(eredménylista, x => x.ország == "Anglia", x => x.vbhely, x => x.vbév.ToString(), x => x.vbhely);
            Console.WriteLine();

            Feladat(3, "Írja ki Chile által elért helyezéseket. A kiírásban jelenjen meg a vb éve és helyszíne is.");
            Kiválogatás(eredménylista, x => x.ország == "Chile", x => x.vbhely, x => x.vbév.ToString(), x => x.vbhely);
            Console.WriteLine();

            Feladat(4, "Írja ki Peru által elért helyezéseket. A kiírásban jelenjen meg a vb éve és helyszíne is.");
            Kiválogatás(eredménylista, x => x.ország == "Peru", x => x.vbhely, x => x.vbév.ToString(), x => x.vbhely);
            Console.WriteLine();

            Feladat(5, "Írja ki Mongólia által elért helyezéseket. A kiírásban jelenjen meg a vb éve és helyszíne is.");
            Kiválogatás(eredménylista, x => x.ország == "Mongólia", x => x.vbhely, x => x.vbév.ToString(), x => x.vbhely);
            Console.WriteLine();

            Feladat(6, "A program olvasson be egy csapat nevet és írja ki a csapat álta elért helyezéseket. A kiírásban jelenjen meg a vb éve és helyszíne is.");
            string cr1 = Console.ReadLine();
            Kiválogatás(eredménylista, x => x.ország == cr1, x => x.vbhely, x => x.vbév.ToString(), x => x.vbhely);
            Console.WriteLine();
            #endregion

            #region 7-12) Feladat
            Feladat(7, "A program írja ki, hogy az '30-es években kik lettek a világbajnokok! Az ország neve mellett szerepeljen az évszám is.");
            Kiválogatás(eredménylista, x => x.vbév <= 1939 && x.vbév >= 1930, x => x.ország, x => x.vbév.ToString(), x => "");
            Console.WriteLine();

            Feladat(8, "A program írja ki, hogy az '40-es években kik lettek a világbajnokok! Az ország neve mellett szerepeljen az évszám is.");
            Kiválogatás(eredménylista, x => x.vbév <= 1949 && x.vbév >= 1940, x => x.ország, x => x.vbév.ToString(), x => "");
            Console.WriteLine();

            Feladat(9, "A program írja ki, hogy az '50-es években kik lettek a világbajnokok! Az ország neve mellett szerepeljen az évszám is.");
            Kiválogatás(eredménylista, x => x.vbév <= 1959 && x.vbév >= 1950, x => x.ország, x => x.vbév.ToString(), x => "");
            Console.WriteLine();

            Feladat(10, "A program írja ki, hogy az '60-es években kik lettek a világbajnokok! Az ország neve mellett szerepeljen az évszám is.");
            Kiválogatás(eredménylista, x => x.vbév <= 1969 && x.vbév >= 1960, x => x.ország, x => x.vbév.ToString(), x => "");
            Console.WriteLine();

            Feladat(11, "A program írja ki, hogy az '70-es években kik lettek a világbajnokok! Az ország neve mellett szerepeljen az évszám is.");
            Kiválogatás(eredménylista, x => x.vbév <= 1979 && x.vbév >= 1970, x => x.ország, x => x.vbév.ToString(), x => "");
            Console.WriteLine();

            Feladat(12, "A program írja ki, hogy az '80-es években kik lettek a világbajnokok! Az ország neve mellett szerepeljen az évszám is.");
            Kiválogatás(eredménylista, x => x.vbév <= 1989 && x.vbév >= 1980, x => x.ország, x => x.vbév.ToString(), x => "");
            Console.WriteLine();
            #endregion

            #region 13-18) Feladat
            Feladat(13, "Írja ki Magyarország hányszor jutott ki a vb-re a fájl által tartalmazott időszakban!");
            Összeg(eredménylista, x => x.ország == "Magyarország", x => 1);
            Console.WriteLine();

            Feladat(14, "Írja ki Anglia hányszor jutott ki a vb-re a fájl által tartalmazott időszakban!");
            Összeg(eredménylista, x => x.ország == "Anglia", x => 1);
            Console.WriteLine();

            Feladat(15, "Írja ki Chile hányszor jutott ki a vb-re a fájl által tartalmazott időszakban!");
            Összeg(eredménylista, x => x.ország == "Chile", x => 1);
            Console.WriteLine();

            Feladat(16, "Írja ki Peru hányszor jutott ki a vb-re a fájl által tartalmazott időszakban!");
            Összeg(eredménylista, x => x.ország == "Peru", x => 1);
            Console.WriteLine();

            Feladat(17, "Írja ki Mongólia hányszor jutott ki a vb-re a fájl által tartalmazott időszakban!");
            Összeg(eredménylista, x => x.ország == "Mongólia", x => 1);
            Console.WriteLine();

            Feladat(18, "A program olvasson be egy csapat nevet és írja ki, a csapat hányszor jutott ki a vb-re a fájl által tartalmazott időszakban!");
            string cr2 = Console.ReadLine();
            Összeg(eredménylista, x => x.ország == cr2, x => 1);
            Console.WriteLine();
            #endregion

            #region 19-23) Feladat
            Feladat(19, "Melyik csapat nyert 1930-ban?");
            MAXMIN(eredménylista, x => x.vbév == 1930, x => x.helyezés, "min");
            Console.WriteLine();

            Feladat(20, "Melyik csapat nyert 1940-ben?");
            MAXMIN(eredménylista, x => x.vbév == 1940, x => x.helyezés, "min");
            Console.WriteLine();

            Feladat(21, "Melyik csapat nyert 1950-ben?");
            MAXMIN(eredménylista, x => x.vbév == 1950, x => x.helyezés, "min");
            Console.WriteLine();

            Feladat(22, "Melyik csapat nyert 1960-ban?");
            MAXMIN(eredménylista, x => x.vbév == 1960, x => x.helyezés, "min");
            Console.WriteLine();

            Feladat(23, "Melyik csapat nyert 1970-ben?");
            MAXMIN(eredménylista, x => x.vbév == 1970, x => x.helyezés, "min");
            Console.WriteLine();
            #endregion

            #region 24-29) Feladat
            Feladat(24, "Hányszor kapott ki a döntőben Magyarország?");
            Összeg(eredménylista, x => x.ország == "Magyarország" && x.helyezés == 2, x => 1);
            Console.WriteLine();

            Feladat(25, "Hányszor kapott ki a döntőben Mongólia?");
            Összeg(eredménylista, x => x.ország == "Mongólia" && x.helyezés == 2, x => 1);
            Console.WriteLine();

            Feladat(26, "Hányszor kapott ki a döntőben Svájc?");
            Összeg(eredménylista, x => x.ország == "Svájc" && x.helyezés == 2, x => 1);
            Console.WriteLine();

            Feladat(27, "Hányszor kapott ki a döntőben Brazília?");
            Összeg(eredménylista, x => x.ország == "Brazília" && x.helyezés == 2, x => 1);
            Console.WriteLine();

            Feladat(28, "Hányszor kapott ki a döntőben Németország?");
            Összeg(eredménylista, x => x.ország == "Németország" && x.helyezés == 2, x => 1);
            Console.WriteLine();

            Feladat(29, "Hányszor kapott ki a döntőben Argentína?");
            Összeg(eredménylista, x => x.ország == "Argentína" && x.helyezés == 2, x => 1);
            Console.WriteLine();
            #endregion

            #region 30) Feladat
            Feladat(30, "A programm olvasson be évszámot és írja ki, hogy melyik csapat nyert az adott évben?");
            string cr3 = Console.ReadLine();
            MAXMIN(eredménylista, x => x.vbév == int.Parse(cr3), x => x.helyezés, "min");
            Console.WriteLine();
            #endregion

            #region 31) Feladat
            Feladat(31, "Az adatfájl szerint mikor volt a legkorábbi vb?");
            Legelső(eredménylista, x => x.vbév);
            Console.WriteLine();
            #endregion

            #region 32-36) Feladat
            Feladat(32, "Magyarország hányszor nyert vb-t?");
            Összeg(eredménylista, x => x.ország == "Magyarország" && x.helyezés == 1, x => 1);
            Console.WriteLine();

            Feladat(33, "Anglia hányszor nyert vb-t?");            
            Összeg(eredménylista, x => x.ország == "Anglia" && x.helyezés == 1, x => 1);
            Console.WriteLine();

            Feladat(34, "Chile hányszor nyert vb-t?");
            Összeg(eredménylista, x => x.ország == "Chile" && x.helyezés == 1, x => 1);
            Console.WriteLine();

            Feladat(35, "Peru hányszor nyert vb-t?");
            Összeg(eredménylista, x => x.ország == "Peru" && x.helyezés == 1, x => 1);
            Console.WriteLine();

            Feladat(36, "Mongólia hányszor nyert vb-t?");
            Összeg(eredménylista, x => x.ország == "Mongólia" && x.helyezés == 1, x => 1);
            Console.WriteLine();
            #endregion

            #region 37-42) Feladat
            Feladat(37, "Írd ki Magyarország vb-n elért legjobb helyezését!");
            MAXMIN(eredménylista, x => x.ország == "Magyarország", x => x.helyezés, "min");
            Console.WriteLine();

            Feladat(38, "Írd ki Anglia vb-n elért legjobb helyezését!");
            MAXMIN(eredménylista, x => x.ország == "Anglia", x => x.helyezés, "min");
            Console.WriteLine();

            Feladat(39, "Írd ki Chile vb-n elért legjobb helyezését!");
            MAXMIN(eredménylista, x => x.ország == "Chile", x => x.helyezés, "min");
            Console.WriteLine();

            Feladat(40, "Írd ki Peru vb-n elért legjobb helyezését!");
            MAXMIN(eredménylista, x => x.ország == "Peru", x => x.helyezés, "min");
            Console.WriteLine();

            Feladat(41, "Írd ki Mongólia vb-n elért legjobb helyezését!");
            MAXMIN(eredménylista, x => x.ország == "Mongólia", x => x.helyezés, "min");
            Console.WriteLine();

            Feladat(42, "A program olvasson be egy csapat nevet és írja ki, a csapat vb-n elért legjobb helyezését!");
            string cr4 = Console.ReadLine();
            MAXMIN(eredménylista, x => x.ország == cr4, x => x.helyezés, "min");
            Console.WriteLine();
            #endregion

            #region 43) Feladat
            Feladat(43, "A program olvasson be egy csapat nevet és írja ki, a csapat hányszor nyert vb-t!");
            string cr5 = Console.ReadLine();
            Összeg(eredménylista, x => x.ország == cr5 && x.helyezés == 1, x => 1);
            Console.WriteLine();
            #endregion

            #region 44-49) Feladat
            Feladat(44, "Melyik csapatok nyertek az Angiában rendezett vb-ken? A csapatok neve mellett az évszámot is írja ki!");
            Kiválogatás(eredménylista, x => x.vbhely == "Angia", x => x.vbhely, x => x.ország, x => x.vbév.ToString());
            Console.WriteLine();

            Feladat(45, "Melyik csapatok nyertek a Magyarországon rendezett vb-ken? A csapatok neve mellett az évszámot is írja ki!");
            Kiválogatás(eredménylista, x => x.vbhely == "Magyarország", x => x.vbhely, x => x.ország, x => x.vbév.ToString());
            Console.WriteLine();

            Feladat(46, "Melyik csapatok nyertek a Németországban rendezett vb-ken? A csapatok neve mellett az évszámot is írja ki!");
            Kiválogatás(eredménylista, x => x.vbhely == "Németország", x => x.vbhely, x => x.ország, x => x.vbév.ToString());
            Console.WriteLine();

            Feladat(47, "Melyik csapatok nyertek az Brazíliában rendezett vb-ken? A csapatok neve mellett az évszámot is írja ki!");
            Kiválogatás(eredménylista, x => x.vbhely == "Brazília", x => x.vbhely, x => x.ország, x => x.vbév.ToString());
            Console.WriteLine();

            Feladat(48, "Melyik csapatok nyertek az Egyesült Államok rendezett vb-ken? A csapatok neve mellett az évszámot is írja ki!");
            Kiválogatás(eredménylista, x => x.vbhely == "USA", x => x.vbhely, x => x.ország, x => x.vbév.ToString());
            Console.WriteLine();

            Feladat(49, "A program olvasson be egy ország nevet és írja ki, melyik csapatok nyertek az adott helyszínen! A csapatok neve mellett az évszámot is írja ki!");
            string cr6 = Console.ReadLine();
            Kiválogatás(eredménylista, x => x.vbhely == cr6, x => x.vbhely, x => x.ország, x => x.vbév.ToString());
            Console.WriteLine();
            #endregion

            #region 50-52) Feladat
            Feladat(50, "Melyik csapat nyerte a vb-t, amikor Magyarország dobogós helyzést ért el? A győzetes csapatok neve mellett az évszámot is írja ki!");
            //Kiválogatás(eredménylista, x => x.ország == "Magyarország" && (x.helyezés == 1 || x.helyezés == 2 || x.helyezés == 3), x => x.ország, x => x.vbév.ToString(), x => "");
            DobogósHelyVbNyertes(eredménylista, "Magyarország");
            Console.WriteLine();

            Feladat(51, "Melyik csapat nyerte a vb-t, amikor Brazília dobogós helyzést ért el? A győzetes csapatok neve mellett az évszámot is írja ki!");
            //Kiválogatás(eredménylista, x => x.ország == "Brazília" && (x.helyezés == 1 || x.helyezés == 2 || x.helyezés == 3), x => x.ország, x => x.vbév.ToString(), x => "");
            DobogósHelyVbNyertes(eredménylista, "Brazília");
            Console.WriteLine();

            Feladat(52, "Melyik csapat nyerte a vb-t, amikor Argentína dobogós helyzést ért el? A győzetes csapatok neve mellett az évszámot is írja ki!");
            //Kiválogatás(eredménylista, x => x.ország == "Argentína" && (x.helyezés == 1 || x.helyezés == 2 || x.helyezés == 3), x => x.ország, x => x.vbév.ToString(), x => "");
            DobogósHelyVbNyertes(eredménylista, "Argentína");
            Console.WriteLine();
            #endregion

            #region 53-57) Feladat
            Feladat(53, "Kikkel játszott döntőt Magyarország? Az ellenfél csapat neve mellett az évszámot is írja ki!");
            Döntőtjátszott(eredménylista, "Magyarország");
            Console.WriteLine();

            Feladat(54, "Kikkel játszott döntőt Mongólia? Az ellenfél csapat neve mellett az évszámot is írja ki!");
            Döntőtjátszott(eredménylista, "Mongólia");
            Console.WriteLine();

            Feladat(55, "Kikkel játszott döntőt Svájc? Az ellenfél csapat neve mellett az évszámot is írja ki!");
            Döntőtjátszott(eredménylista, "Svájc");
            Console.WriteLine();

            Feladat(56, "Kikkel játszott döntőt Barzília? Az ellenfél csapat neve mellett az évszámot is írja ki!");
            Döntőtjátszott(eredménylista, "Barzília");
            Console.WriteLine();

            Feladat(57, "A program olvasson be egy ország nevet és írja ki, kikkel játszott döntőt az illető csapat? Az ellenfél csapat neve mellett az évszámot is írja ki!");
            string cr7 = Console.ReadLine();
            Döntőtjátszott(eredménylista, cr7);
            Console.WriteLine();
            #endregion

            #region 58) Feladat
            Feladat(58, "Melyik csapat nyert többször is vb-t?");
            TöbbszörNyert(eredménylista);
            Console.WriteLine();
            #endregion

            #region 59) Feladat
            Feladat(59, "Melyik országban rendeztek többször is vb-t?");
            TöbbszörRendezettVbt(eredménylista);
            Console.WriteLine();
            #endregion

            #region 60) Feladat
            Feladat(60, "Melyik csapat(ok) nyert a legtöbbször vb-t? A csapat neve mellett a vb gyözelmmek számát is írja ki! ");
            Feladat60_62(eredménylista, "nyert");
            Console.WriteLine();
            #endregion
            #region 61) Feladat
            Feladat(61, "Melyik ország(ok) rendezett legtöbbször vb-t? A csapat neve mellett a vb-k számát is írja ki! ");
            Feladat60_62(eredménylista, "rendezett");
            Console.WriteLine();
            #endregion
            #region 62) Feladat
            Feladat(62, "Melyik csapat(ok) kapott ki a legtöbbször a döntőben? A csapat neve mellett a vereségek számát is írja ki!");
            Feladat60_62(eredménylista, "vesztett");
            Console.WriteLine();
            #endregion
            #endregion

            #region 61) Feladat
            Feladat(61, "Melyik ország(ok) rendezett legtöbbször vb-t? A csapat neve mellett a vb-k számát is írja ki! ");

            List<List<string>> év_ország = new List<List<string>>();

            List<string> ujlista;
            for (int i = 0; i < eredménylista.Count; i++)
            {
                if (!BenneVanE(év_ország, eredménylista[i].vbév, eredménylista[i].vbhely))
                {
                    ujlista = new List<string>();
                    ujlista.Add(eredménylista[i].vbév.ToString());
                    ujlista.Add(eredménylista[i].vbhely);
                    év_ország.Add(ujlista);
                }
            }

            for (int i = 0; i < év_ország.Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(év_ország[i][j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            #endregion
            //kuka

            
        }
    }
}
