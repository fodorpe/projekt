using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3000M
{
    class Program
    {
        class Település
        {
            public int id;
            public string név;
            public string rang;
            public string kistérség;
            public int terület;
            public int népesség;
            public int lakásszám;
        }
        class Kistérség_Szám
        {
            public string kistérség;
            public int szám;
            public Kistérség_Szám(string kt, int sz)
            {
                kistérség = kt;
                szám = sz;
            }
        }
        class Lakáshelyzet
        {
            public string név;
            public double fő_per_lakás;
            public Lakáshelyzet(string n, double fl)
            {
                név = n;
                fő_per_lakás = fl;
            }
        }
        class Kistérség_Lakosság
        {
            public string kistérség;
            public int lakosság;
            public Kistérség_Lakosság(string kt, int l)
            {
                kistérség = kt;
                lakosság = l;
            }
        }
        class Kistérség_Terület
        {
            public string kistérség;
            public int terület;
            public Kistérség_Terület(string kt, int t)
            {
                kistérség = kt;
                terület = t;
            }
        }
        static void Feladat_színnel(int szám, string feladat)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("{0}) ", szám);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}", feladat);
        }
        static void FájlbaKiír(string kiírandó, string fájlnév)
        {
            StreamWriter w = new StreamWriter(fájlnév);
            w.WriteLine(kiírandó);
            w.Close();
        }
        static void FájlbaKiír2(string kiírandó1, string kiírandó2, string fájlnév)
        {
            StreamWriter w = new StreamWriter(fájlnév);
            w.WriteLine(kiírandó1);
            w.WriteLine(kiírandó2);
            w.Close();
        }
        static void X_rangú_települések_száma(List<Település> települések, string fájlnév, string rang)
        {
            int sum = 0;
            for (int i = 0; i < települések.Count; i++)
            {
                if (települések[i].rang == rang)
                {
                    sum++;
                }
            }
            Console.WriteLine(sum);
            FájlbaKiír(sum.ToString(), fájlnév);
        }
        static void Vane_X_rangú_település(List<Település> települések, string fájlnév, string rang)
        {
            bool meglett = false;
            int k = 0;

            while (!meglett && k < települések.Count)
            {
                if (települések[k].rang == "falu")
                {
                    meglett = true;
                }
                k++;
            }
            Console.WriteLine(meglett ? "Van" : "Nincs");
            FájlbaKiír(meglett.ToString(), fájlnév);
        }
        static void X_rangú_települések_száma_kistérség(List<Település> települések, string fájlnév, string rang, string kistérség)
        {
            int sum = 0;
            for (int i = 0; i < települések.Count; i++)
            {
                if (települések[i].rang == rang && települések[i].kistérség == kistérség)
                {
                    sum++;
                }
            }
            Console.WriteLine(sum);
            FájlbaKiír(sum.ToString(), fájlnév);
        }
        static void X_rangú_települések_neve_népessége_x_fő_fölött_vagy_alatt(List<Település> települések, string fájlnév, string rang, int fő, string nagyobbVkisebb)
        {
            for (int i = 0; i < települések.Count; i++)
            {
                if (nagyobbVkisebb == "nagyobb")
                {
                    if (települések[i].rang == rang && települések[i].népesség > fő)
                    {
                        Console.WriteLine("{0}\t{1}", települések[i].név, települések[i].népesség);
                        FájlbaKiír2(települések[i].név, települések[i].népesség.ToString(), fájlnév);
                    }
                    else if (nagyobbVkisebb == "kisebb")
                    {
                        if (települések[i].rang == rang && települések[i].népesség < fő)
                        {
                            Console.WriteLine("{0}\t{1}", települések[i].név, települések[i].népesség);
                            FájlbaKiír2(települések[i].név, települések[i].népesség.ToString(), fájlnév);
                        }
                    }
                }
            }
        }
        static void NépességMAX_népesség(List<Település> települések, string fájlnév)
        {
            int max = települések[0].népesség;
            for (int i = 0; i < települések.Count; i++)
            {
                if (települések[i].népesség > max)
                {
                    max = települések[i].népesség;
                }
            }
            Console.WriteLine(max);
            FájlbaKiír(max.ToString(), fájlnév);
        }
        static void NépességMIN_népesség(List<Település> települések, string fájlnév)
        {
            int min = települések[0].népesség;
            for (int i = 0; i < települések.Count; i++)
            {
                if (települések[i].népesség > min)
                {
                    min = települések[i].népesség;
                }
            }
            Console.WriteLine(min);
            FájlbaKiír(min.ToString(), fájlnév);
        }
        static void NépességMAX_név_népesség(List<Település> települések, string fájlnév)
        {
            int max = települések[0].népesség;
            string maxnév = települések[0].név;
            for (int i = 0; i < települések.Count; i++)
            {
                if (települések[i].népesség > max)
                {
                    max = települések[i].népesség;
                    maxnév = települések[i].név;
                }
            }
            Console.WriteLine("{0}\t{1}", maxnév, max);
            FájlbaKiír2(maxnév, max.ToString(), fájlnév);
        }
        static void NépességMIN_név_népesség(List<Település> települések, string fájlnév)
        {
            int min = települések[0].népesség;
            string minnév = települések[0].név;
            for (int i = 0; i < települések.Count; i++)
            {
                if (települések[i].népesség > min)
                {
                    min = települések[i].népesség;
                    minnév = települések[i].név;
                }
            }
            Console.WriteLine("{0}\t{1}", minnév, min);
            FájlbaKiír2(minnév, min.ToString(), fájlnév);
        }
        static void X_kistérség_legkisebb_területű_települése(List<Település> települések, string fájlnév, string kistérség)
        {
            int min = 50000; //48322 a legtöbb így ideiglenesen jó, amíg nem találom ki, hogyan lehetne jól megcsinálni
            string minnév = "";
            for (int i = 0; i < települések.Count; i++)
            {
                if (települések[i].terület < min)
                {
                    min = települések[i].terület;
                    minnév = települések[i].név;
                }
            }
            Console.WriteLine("{0}", minnév);
            FájlbaKiír(minnév, fájlnév);
        }
        static void NépességMAX_név_kistérség(List<Település> települések, string fájlnév, string kistérség)
        {
            int max = települések[0].népesség;
            string maxnév = települések[0].név;
            for (int i = 0; i < települések.Count; i++)
            {
                if (települések[i].népesség > max && települések[i].kistérség == kistérség)
                {
                    max = települések[i].népesség;
                    maxnév = települések[i].név;
                }
            }
            Console.WriteLine(maxnév);
            FájlbaKiír(maxnév, fájlnév);
        }
        static void Népsűrűség_kistérség(List<Település> települések, string fájlnév, string kistérség)
        {
            for (int i = 0; i < települések.Count; i++)
            {
                if (települések[i].kistérség == kistérség)
                {
                    Console.WriteLine((double)települések[i].népesség / (double)(települések[i].terület/100) + " fő/km²");
                    FájlbaKiír(((double)települések[i].népesség / (double)(települések[i].terület / 100)).ToString(), fájlnév);
                }
            }
        }
        static void Igaz_e_hogy_minden_település_népessége_x_fő_fölött_vagy_alatt_van_kistérség(List<Település> települések, string fájlnév, string kistérség, int fő, string nagyobbVkisebb)
        {
            bool megvan = true;
            int k = 0;
            while (megvan && k < települések.Count)
            {
                if (kistérség == települések[k].kistérség)
                {
                    if (nagyobbVkisebb == "nagyobb")
                    {
                        if (települések[k].népesség < fő)
                        {
                            megvan = false;
                        }
                    }
                    else if(nagyobbVkisebb == "kisebb")
                    {
                        if (települések[k].népesség > fő)
                        {
                            megvan = false;
                        }
                    }
                }
                k++;
            }
            Console.WriteLine(megvan ? "Igaz!" : "Nem igaz!");
            FájlbaKiír(megvan.ToString(), fájlnév);
        }
        static void Egy_lakásra_jutó_népesség_kistérség(List<Település> települések, string fájlnév, string kistérség)
        {
            double össznépesség = 0;
            double összlakásszám = 0;
            for (int i = 0; i < települések.Count; i++)
            {
                if (települések[i].kistérség == kistérség)
                {
                    össznépesség += települések[i].népesség;
                    összlakásszám += települések[i].lakásszám;
                }
            }
            Console.WriteLine("{0} fő/lakás", össznépesség / összlakásszám);
            FájlbaKiír((össznépesség / összlakásszám).ToString(), fájlnév);

        }
        static void Legrosszabb_lakáshelyzet(List<Település> települések, string fájlnév)
        {
            List<Lakáshelyzet> kimutatás = new List<Lakáshelyzet>();
            for (int i = 0; i < települések.Count; i++)
            {
                kimutatás.Add(new Lakáshelyzet(települések[i].név, (double.Parse(települések[i].népesség.ToString()) / double.Parse(települések[i].lakásszám.ToString()))));
            }
            double max = 0;
            int maxix = 0;
            for (int i = 0; i < kimutatás.Count; i++)
            {
                if (kimutatás[i].fő_per_lakás > max)
                {
                    max = kimutatás[i].fő_per_lakás;
                    maxix = i;
                }
            }
            Console.WriteLine("{0}\t{1} fő/lakás", kimutatás[maxix].név, kimutatás[maxix].fő_per_lakás);
        }
        static void Kistérségek_településeinek_száma(List<Település> települések, string fájlnév)
        {
            List<Kistérség_Szám> kimutatás = new List<Kistérség_Szám>(); // új classra volt szükség, mivel a kimutatáslista elemei változó típusúak
            int k;
            bool meglett;
            for (int i = 0; i < települések.Count; i++)  // végig kell nézni mindent a régi listában, mivel mindet be kell sorolni valahova
            {
                k = 0;
                meglett = false;
                while (k < kimutatás.Count && !meglett) // keressük az elemet, hogy szerepelt-e már
                {
                    if (kimutatás[k].kistérség == települések[i].kistérség) // ha szerepelt,...
                    {
                        meglett = true;
                        kimutatás[k].szám++;            // akkor a mellette lévő számot növeljük eggyel.
                    }
                    k++;
                }
                if (!meglett)        // ha végül nem találtuk meg, akkor felvesszük a listába 1-es számmal.
                {
                    kimutatás.Add(new Kistérség_Szám(települések[i].kistérség, 1));
                }
            }

            // kiírjuk a megoldást.

            for (int i = 0; i < kimutatás.Count; i++)
            {
                Console.WriteLine("{0}\t{1}", kimutatás[i].kistérség, kimutatás[i].szám);
                FájlbaKiír2(kimutatás[i].kistérség, kimutatás[i].szám.ToString(), fájlnév);
            }
        }
        static void Kistérségek_összlakosságának_száma(List<Település> települések, string fájlnév)
        {
            List<Kistérség_Lakosság> kimutatás = new List<Kistérség_Lakosság>(); // új classra volt szükség, mivel a kimutatáslista elemei változó típusúak
            int k;
            bool meglett;
            for (int i = 0; i < települések.Count; i++)  // végig kell nézni mindent a régi listában, mivel mindet be kell sorolni valahova
            {
                k = 0;
                meglett = false;
                while (k < kimutatás.Count && !meglett) // keressük az elemet, hogy szerepelt-e már
                {
                    if (kimutatás[k].kistérség == települések[i].kistérség) // ha szerepelt,...
                    {
                        meglett = true;
                        kimutatás[k].lakosság += települések[i].népesség;            // akkor a mellette lévő számot növeljük eggyel.
                    }
                    k++;
                }
                if (!meglett)        // ha végül nem találtuk meg, akkor felvesszük a listába népességgel.
                {
                    kimutatás.Add(new Kistérség_Lakosság(települések[i].kistérség, települések[i].népesség));
                }
            }

            // kiírjuk a megoldást.

            for (int i = 0; i < kimutatás.Count; i++)
            {
                Console.WriteLine("{0}\t{1}", kimutatás[i].kistérség, kimutatás[i].lakosság);
                FájlbaKiír2(kimutatás[i].kistérség, kimutatás[i].lakosság.ToString(), fájlnév);
            }
        }
        static void Kistérségek_összterületének_nagysága(List<Település> települések, string fájlnév)
        {
            List<Kistérség_Terület> kimutatás = new List<Kistérség_Terület>(); // új classra volt szükség, mivel a kimutatáslista elemei változó típusúak
            int k;
            bool meglett;
            for (int i = 0; i < települések.Count; i++)  // végig kell nézni mindent a régi listában, mivel mindet be kell sorolni valahova
            {
                k = 0;
                meglett = false;
                while (k < kimutatás.Count && !meglett) // keressük az elemet, hogy szerepelt-e már
                {
                    if (kimutatás[k].kistérség == települések[i].kistérség) // ha szerepelt,...
                    {
                        meglett = true;
                        kimutatás[k].terület += települések[i].terület;            // akkor a mellette lévő számot növeljük eggyel.
                    }
                    k++;
                }
                if (!meglett)        // ha végül nem találtuk meg, akkor felvesszük a listába népességgel.
                {
                    kimutatás.Add(new Kistérség_Terület(települések[i].kistérség, települések[i].népesség));
                }
            }

            // kiírjuk a megoldást.

            for (int i = 0; i < kimutatás.Count; i++)
            {
                Console.WriteLine("{0}\t{1}", kimutatás[i].kistérség, kimutatás[i].terület);
                FájlbaKiír2(kimutatás[i].kistérség, kimutatás[i].terület.ToString(), fájlnév);
            }
        }
        static void Main(string[] args)
        {
            #region Beolvasás
            List<Település> települések = new List<Település>();
            using (StreamReader f = new StreamReader("telepules.txt", Encoding.Default))
            {
                while (!f.EndOfStream)
                {
                    string[] sor = f.ReadLine().Split('\t');
                    települések.Add(new Település
                    {
                        id = int.Parse(sor[0]),
                        név = sor[1],
                        rang = sor[2],
                        kistérség = sor[3],
                        terület = int.Parse(sor[4]),
                        népesség = int.Parse(sor[5]),
                        lakásszám = int.Parse(sor[6])
                    });
                }
            }
            #endregion

            #region Feladatok
            #region 1) Feladat
            Feladat_színnel(1, "Hány település található az input fájlban?");
            Console.WriteLine(települések.Count);
            FájlbaKiír(települések.Count.ToString(), "output_1.txt");
            Console.WriteLine();
            #endregion

            #region 2-3) Feladat
            Feladat_színnel(2, "Hány község rangú település található?");
            X_rangú_települések_száma(települések, "output_2.txt", "község");
            Console.WriteLine();

            Feladat_színnel(3, "Hány város rangú település található?");
            X_rangú_települések_száma(települések, "output_3.txt", "város");
            Console.WriteLine();
            #endregion

            #region 4) Feladat
            Feladat_színnel(4, "Van-e falu rangú település?");
            Vane_X_rangú_település(települések, "output_4.txt", "falu");
            Console.WriteLine();
            #endregion

            #region 5-10) Feladat
            Feladat_színnel(5, "Hány község rangú település található a Makói kistérségben?");
            X_rangú_települések_száma_kistérség(települések, "output_5.txt", "község", "Makói");
            Console.WriteLine();

            Feladat_színnel(6, "Hány község rangú település található a Szegedi kistérségben?");
            X_rangú_települések_száma_kistérség(települések, "output_6.txt", "község", "Szegedi");
            Console.WriteLine();

            Feladat_színnel(7, "Hány község rangú település található a Szentesi kistérségben?");
            X_rangú_települések_száma_kistérség(települések, "output_7.txt", "község", "Szentesi");
            Console.WriteLine();

            Feladat_színnel(8, "Hány város rangú település található a Makói kistérségben?");
            X_rangú_települések_száma_kistérség(települések, "output_8.txt", "város", "Makói");
            Console.WriteLine();

            Feladat_színnel(9, "Hány város rangú település található a Szegedi kistérségben?");
            X_rangú_települések_száma_kistérség(települések, "output_9.txt", "város", "Szegedi");
            Console.WriteLine();

            Feladat_színnel(10, "Hány város rangú település található a Szentesi kistérségben?");
            X_rangú_települések_száma_kistérség(települések, "output_10.txt", "város", "Szentesi");
            Console.WriteLine();
            #endregion

            #region 11-14) Feladat
            Feladat_színnel(11, "Írja ki a község rangú települések közül az 1000 főnél népesebb települések nevét és népességét!");
            X_rangú_települések_neve_népessége_x_fő_fölött_vagy_alatt(települések, "output_11.txt", "község", 1000, "nagyobb");
            Console.WriteLine();

            Feladat_színnel(12, "Írja ki a város rangú települések közül az 10000 főnél népesebb települések nevét és népességét!");
            X_rangú_települések_neve_népessége_x_fő_fölött_vagy_alatt(települések, "output_12.txt", "város", 10000, "nagyobb");
            Console.WriteLine();

            Feladat_színnel(13, "Írja ki a község rangú települések közül az 1000 főnél alacsonyabb népességű települések nevét és népességét!");
            X_rangú_települések_neve_népessége_x_fő_fölött_vagy_alatt(települések, "output_13.txt", "község", 1000, "kisebb");
            Console.WriteLine();

            Feladat_színnel(14, "Írja ki a város rangú települések közül az 5000 főnél alacsonyabb népességű települések nevét és népességét!");
            X_rangú_települések_neve_népessége_x_fő_fölött_vagy_alatt(települések, "output_14.txt", "város", 5000, "kisebb");
            Console.WriteLine();
            #endregion

            #region 15) Feladat
            Feladat_színnel(15, "Mennyi a legnépesebb település lélekszáma?");
            NépességMAX_népesség(települések, "output_15.txt");
            Console.WriteLine();
            #endregion

            #region 16) Feladat
            Feladat_színnel(16, "Mennyi a legalacsonyabb népességű település lélekszáma?");
            NépességMIN_népesség(települések, "output_16.txt");
            Console.WriteLine();
            #endregion

            #region 17) Feladat
            Feladat_színnel(17, "Melyik a legnépesebb település? Írja ki a település nevét és lélekszámát!");
            NépességMAX_név_népesség(települések, "output_17.txt");
            Console.WriteLine();
            #endregion

            #region 18) Feladat
            Feladat_színnel(18, "Melyik a legalacsonyabb népességű település? Írja ki a település nevét és lélekszámát!");
            NépességMIN_név_népesség(települések, "output_18.txt");
            Console.WriteLine();
            #endregion

            #region 19-21) Feladat
            Feladat_színnel(19, "Melyik a Makói kistérség legkisebb területű települése(i)?");
            X_kistérség_legkisebb_területű_települése(települések, "output_19.txt", "Makói");
            Console.WriteLine();

            Feladat_színnel(20, "Melyik a Szegedi kistérség legkisebb területű települése(i)?");
            X_kistérség_legkisebb_területű_települése(települések, "output_20.txt", "Szegedi");
            Console.WriteLine();

            Feladat_színnel(21, "Melyik a Szentesi kistérség legkisebb területű települése(i)?");
            X_kistérség_legkisebb_területű_települése(települések, "output_21.txt", "Szentesi");
            Console.WriteLine();
            #endregion

            #region 22-24) Feladat
            Feladat_színnel(22, "Melyik a Makói kistérség legnépesebb települése(i)?");
            NépességMAX_név_kistérség(települések, "output_22.txt", "Makói");
            Console.WriteLine();

            Feladat_színnel(23, "Melyik a Szegedi kistérség legnépesebb települése(i)?");
            NépességMAX_név_kistérség(települések, "output_23.txt", "Szegedi");
            Console.WriteLine();

            Feladat_színnel(24, "Melyik a Szentesi kistérség legnépesebb települése(i)?");
            NépességMAX_név_kistérség(települések, "output_24.txt", "Szentesi");
            Console.WriteLine();
            #endregion

            #region 25-28) Feladat
            Feladat_színnel(25, "Írja ki a Makói kistérség településeinek népsűrűségét!");
            Népsűrűség_kistérség(települések, "output_25.txt", "Makói");
            Console.WriteLine();

            Feladat_színnel(26, "Írja ki a Szegedi kistérség településeinek népsűrűségét!");
            Népsűrűség_kistérség(települések, "output_26.txt", "Szegedi");
            Console.WriteLine();

            Feladat_színnel(27, "Írja ki a Szentesi kistérség településeinek népsűrűségét!");
            Népsűrűség_kistérség(települések, "output_27.txt", "Szentesi");
            Console.WriteLine();

            Feladat_színnel(28, "Írja ki a Kisteleki kistérség településeinek népsűrűségét!");
            Népsűrűség_kistérség(települések, "output_28.txt", "Kisteleki");
            Console.WriteLine();
            #endregion

            #region 29-32) Feladat
            Feladat_színnel(29, "Igaz-e, hogy minden Makói kistérségű település lélekszáma nagyobb, mint 1000?");
            Igaz_e_hogy_minden_település_népessége_x_fő_fölött_vagy_alatt_van_kistérség(települések, "output_29.txt", "Makói", 1000, "nagyobb");
            Console.WriteLine();

            Feladat_színnel(30, "Igaz-e, hogy minden Szentesi kistérségű település lélekszáma kisebb, mint 10000?");
            Igaz_e_hogy_minden_település_népessége_x_fő_fölött_vagy_alatt_van_kistérség(települések, "output_30.txt", "Szentesi", 10000, "kisebb");
            Console.WriteLine();

            Feladat_színnel(31, "Igaz-e, hogy minden Szegedi kistérségű település lélekszáma nagyobb, mint 2000?");
            Igaz_e_hogy_minden_település_népessége_x_fő_fölött_vagy_alatt_van_kistérség(települések, "output_31.txt", "Szegedi", 2000, "nagyobb");
            Console.WriteLine();

            Feladat_színnel(32, "Igaz-e, hogy minden Kisteleki kistérségű település lélekszáma kisebb, mint 10000?");
            Igaz_e_hogy_minden_település_népessége_x_fő_fölött_vagy_alatt_van_kistérség(települések, "output_32.txt", "Kisteleki", 10000, "kisebb");
            Console.WriteLine();
            #endregion

            #region 33-36) Feladat
            Feladat_színnel(33, "Írja ki a Makói kistérség településeinek egy lakásra jutó népesség számát!");
            Egy_lakásra_jutó_népesség_kistérség(települések, "output_33.txt", "Makói");
            Console.WriteLine();

            Feladat_színnel(34, "Írja ki a Szentesi kistérség településeinek egy lakásra jutó népesség számát!");
            Egy_lakásra_jutó_népesség_kistérség(települések, "output_34.txt", "Szentesi");
            Console.WriteLine();

            Feladat_színnel(35, "Írja ki a Szegedi kistérség településeinek egy lakásra jutó népesség számát!");
            Egy_lakásra_jutó_népesség_kistérség(települések, "output_35.txt", "Szegedi");
            Console.WriteLine();

            Feladat_színnel(36, "Írja ki a Kisteleki kistérség településeinek egy lakásra jutó népesség számát!");
            Egy_lakásra_jutó_népesség_kistérség(települések, "output_36.txt", "Kisteleki");
            Console.WriteLine();
            #endregion

            #region 37) Feladat
            Feladat_színnel(37, "Melyik településen a legrosszabb a lakáshelyzet? (Egy lakásra a legtöbb lakos jut.)");
            Legrosszabb_lakáshelyzet(települések, "output_37.txt");
            Console.WriteLine();
            #endregion

            #region 38) Feladat
            Feladat_színnel(38, "Készítsen kimutatást kistérségi bontásban, amelyben megadja az egyes kistérségek településeinek a számát!");
            Kistérségek_településeinek_száma(települések, "output_38.txt");
            Console.WriteLine();
            #endregion

            #region 39) Feladat
            Feladat_színnel(39, "Készítsen kimutatást kistérségi bontásban, amelyben megadja az egyes kistérségek összlakosságának a számát!");
            Kistérségek_összlakosságának_száma(települések, "output_39.txt");
            Console.WriteLine();
            #endregion

            #region 40) Feladat
            Feladat_színnel(40, "Készítsen kimutatást kistérségi bontásban, amelyben megadja az egyes kistérségek összterületének a nagyságát!");
            Kistérségek_összterületének_nagysága(települések, "output_40.txt");
            Console.WriteLine();
            #endregion
            #endregion
        }
    }
}