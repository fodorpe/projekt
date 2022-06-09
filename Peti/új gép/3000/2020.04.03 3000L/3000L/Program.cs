using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace _3000L
{
    class Program
    {
        class Színész
        {
            public string név;
            public bool férfi;
            public DateTime szüldátum;
            public string szülhely;
            public string szülország;
            public int filmszám;
            public string Születésnap()
            {
                return szüldátum.Month.ToString() + ";" + szüldátum.Day.ToString();
            }
        }
        class Legtöbbfilmév
        {
            public int év;
            public int szám;
            public Legtöbbfilmév(int y, int sz)
            {
                év = y;
                szám = sz;
            }
        }
        class Legtöbbfilmország
        {
            public string ország;
            public int szám;
            public Legtöbbfilmország(string o, int sz)
            {
                ország = o;
                szám = sz;
            }
        }
        class Születésnapok
        {
            public string dátum;
            public int szám;
            public Születésnapok(string d, int sz)
            {
                dátum = d;
                szám = sz;
            }
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
        static void Itt_született_színészek_filmszámmal(List<Színész> színészek, string fájlnév, string város)
        {
            for (int i = 0; i < színészek.Count; i++)
            {
                if (színészek[i].szülhely == város)
                {
                    Console.WriteLine("{0}\t{1}", színészek[i].név, színészek[i].filmszám);
                    FájlbaKiír2(színészek[i].név, színészek[i].filmszám.ToString(), fájlnév);
                }
            }
        }
        static void Hányszínész_1város(List<Színész> színészek, string fájlnév, string város)
        {
            int születetthelyen = 0;
            for (int i = 0; i < színészek.Count; i++)
            {
                if (színészek[i].szülhely == város)
                {
                    születetthelyen++;
                }
            }
            Console.WriteLine(születetthelyen);
            FájlbaKiír(születetthelyen.ToString(), fájlnév);
        }
        static void Hányszínész_1ország(List<Színész> színészek, string fájlnév, string ország)
        {
            int db = 0;
            for (int i = 0; i < színészek.Count; i++)
            {
                if (színészek[i].szülország == ország)
                {
                    db++;
                }
            }
            Console.WriteLine(db);
            FájlbaKiír(db.ToString(), fájlnév);
        }
        static void Hányszínész_Nem_1ország(List<Színész> színészek, string fájlnév, bool férfie, string ország)
        {
            int db = 0;
            for (int i = 0; i < színészek.Count; i++)
            {
                if (színészek[i].szülország == ország && színészek[i].férfi == férfie)
                {
                    db++;
                }
            }
            Console.WriteLine(db);
            FájlbaKiír(db.ToString(), fájlnév);
        }
        static void Hányszínész_Nem_2ország(List<Színész> színészek, string fájlnév, bool férfie, string ország1, string ország2)
        {
            int db = 0;
            for (int i = 0; i < színészek.Count; i++)
            {
                if ((színészek[i].szülország == ország1 || színészek[i].szülország == ország2) && színészek[i].férfi == férfie)
                {
                    db++;
                }
            }
            Console.WriteLine(db);
            FájlbaKiír(db.ToString(), fájlnév);
        }
        static void Hányszínész_2év_2ország(List<Színész> színészek, string fájlnév, string év1, string év2, string ország1, string ország2)
        {
            int db = 0;
            for (int i = 0; i < színészek.Count; i++)
            {
                if ((színészek[i].szülország == ország1 || színészek[i].szülország == ország2) && (színészek[i].szüldátum.Year.ToString() == év1 || színészek[i].szüldátum.Year.ToString() == év2))
                {
                    db++;
                }
            }
            Console.WriteLine(db);
            FájlbaKiír(db.ToString(), fájlnév);
        }
        static void Hányszínész_Nem_2év_2ország(List<Színész> színészek, string fájlnév, bool férfie, string év1, string év2, string ország1, string ország2)
        {
            int db = 0;
            for (int i = 0; i < színészek.Count; i++)
            {
                if ((színészek[i].szülország == ország1 || színészek[i].szülország == ország2) && (színészek[i].szüldátum.Year.ToString() == év1 || színészek[i].szüldátum.Year.ToString() == év2) && színészek[i].férfi == férfie)
                {
                    db++;
                }
            }
            Console.WriteLine(db);
            FájlbaKiír(db.ToString(), fájlnév);
        }
        static void Mikor_Született_MAX(List<Színész> színészek, string fájlnév)
        {
            int max = színészek[0].szüldátum.Year;
            for (int i = 0; i < színészek.Count; i++)
            {
                if (színészek[i].szüldátum.Year > max)
                {
                    max = színészek[i].szüldátum.Year;
                }
            }
            Console.WriteLine(max);
            FájlbaKiír(max.ToString(), fájlnév);
        }
        static void Mikor_Született_MIN(List<Színész> színészek, string fájlnév)
        {
            int min = színészek[0].szüldátum.Year;
            for (int i = 0; i < színészek.Count; i++)
            {
                if (színészek[i].szüldátum.Year < min)
                {
                    min = színészek[i].szüldátum.Year;
                }
            }
            Console.WriteLine(min);
            FájlbaKiír(min.ToString(), fájlnév);
        }
        static void Mikor_Született_MAX_Név(List<Színész> színészek, string fájlnév)
        {
            int max = színészek[0].szüldátum.Year;
            string maxnév = színészek[0].név;
            for (int i = 0; i < színészek.Count; i++)
            {
                if (színészek[i].szüldátum.Year > max)
                {
                    max = színészek[i].szüldátum.Year;
                    maxnév = színészek[i].név;
                }
            }
            Console.WriteLine("{0}\t{1}", maxnév, max);
            FájlbaKiír2(maxnév, max.ToString(), fájlnév);
        }
        static void Mikor_Született_MIN_Név(List<Színész> színészek, string fájlnév)
        {
            int min = színészek[0].szüldátum.Year;
            string minnév = színészek[0].név;
            for (int i = 0; i < színészek.Count; i++)
            {
                if (színészek[i].szüldátum.Year < min)
                {
                    min = színészek[i].szüldátum.Year;
                    minnév = színészek[i].név;
                }
            }
            Console.WriteLine("{0}\t{1}", minnév, min);
            FájlbaKiír2(minnév, min.ToString(), fájlnév);
        }
        static void Legtöbbfilmszínész_1ország(List<Színész> színészek, string fájlnév, string ország)
        {
            int max = 0;
            for (int i = 0; i < színészek.Count; i++)
            {
                if (színészek[i].filmszám > max && színészek[i].szülhely == ország)
                {
                    max = színészek[i].filmszám;
                }
            }
            Console.WriteLine(max);
            FájlbaKiír(max.ToString(), fájlnév);
        }
        static void Mikor_legtöbb_színész(List<Színész> színészek, string fájlnév)
        {
            List<Legtöbbfilmév> legtöbbfilm = new List<Legtöbbfilmév>();
            int k;
            bool meglett;
            for (int i = 0; i < színészek.Count; i++)
            {
                k = 0;
                meglett = false;
                while (k < legtöbbfilm.Count && !meglett)
                {
                    if (színészek[i].szüldátum.Year == legtöbbfilm[k].év)
                    {
                        meglett = true;
                        legtöbbfilm[k].szám++;
                    }

                    k++;
                }
                if (!meglett)
                {
                    legtöbbfilm.Add(new Legtöbbfilmév(színészek[i].szüldátum.Year, 1));
                }
            }
            int max = 0;
            int év = 0;
            for (int i = 0; i < legtöbbfilm.Count; i++)
            {
                if (legtöbbfilm[i].szám > max)
                {
                    max = legtöbbfilm[i].szám;
                    év = legtöbbfilm[i].év;
                }
            }
            Console.WriteLine("{0}\t{1}", év, max);
            FájlbaKiír2(év.ToString(), max.ToString(), fájlnév);
        }
        static void Mikor_legkevesebb_színész(List<Színész> színészek, string fájlnév)
        {
            List<Legtöbbfilmév> legtöbbfilm = new List<Legtöbbfilmév>();
            int k;
            bool meglett;
            for (int i = 0; i < színészek.Count; i++)
            {
                k = 0;
                meglett = false;
                while (k < legtöbbfilm.Count && !meglett)
                {
                    if (színészek[i].szüldátum.Year == legtöbbfilm[k].év)
                    {
                        meglett = true;
                        legtöbbfilm[k].szám++;
                    }

                    k++;
                }
                if (!meglett)
                {
                    legtöbbfilm.Add(new Legtöbbfilmév(színészek[i].szüldátum.Year, 1));
                }
            }
            int min = színészek[0].filmszám;
            int év = 0;
            for (int i = 0; i < legtöbbfilm.Count; i++)
            {
                if (legtöbbfilm[i].szám < min)
                {
                    min = legtöbbfilm[i].szám;
                    év = legtöbbfilm[i].év;
                }
            }
            Console.WriteLine("{0}\t{1}", év, min);
            FájlbaKiír2(év.ToString(), min.ToString(), fájlnév);
        }
        static void Hol_legtöbb_színész(List<Színész> színészek, string fájlnév)
        {
            List<Legtöbbfilmország> legtöbbfilm = new List<Legtöbbfilmország>();
            int k;
            bool meglett;
            for (int i = 0; i < színészek.Count; i++)
            {
                k = 0;
                meglett = false;
                while (k < legtöbbfilm.Count && !meglett)
                {
                    if (színészek[i].szülhely == legtöbbfilm[k].ország)
                    {
                        meglett = true;
                        legtöbbfilm[k].szám++;
                    }

                    k++;
                }
                if (!meglett)
                {
                    legtöbbfilm.Add(new Legtöbbfilmország(színészek[i].szülhely, 1));
                }
            }
            int max = 0;
            string ország = "";
            for (int i = 0; i < legtöbbfilm.Count; i++)
            {
                if (legtöbbfilm[i].szám > max)
                {
                    max = legtöbbfilm[i].szám;
                    ország = legtöbbfilm[i].ország;

                }
            }
            Console.WriteLine("{0}\t{1}", ország, max);
            FájlbaKiír2(ország.ToString(), max.ToString(), fájlnév);
        }
        static void Hol_legkevesebb_színész(List<Színész> színészek, string fájlnév)
        {
            List<Legtöbbfilmország> legtöbbfilm = new List<Legtöbbfilmország>();
            int k;
            bool meglett;
            for (int i = 0; i < színészek.Count; i++)
            {
                k = 0;
                meglett = false;
                while (k < legtöbbfilm.Count && !meglett)
                {
                    if (színészek[i].szülhely == legtöbbfilm[k].ország)
                    {
                        meglett = true;
                        legtöbbfilm[k].szám++;
                    }

                    k++;
                }
                if (!meglett)
                {
                    legtöbbfilm.Add(new Legtöbbfilmország(színészek[i].szülhely, 1));
                }
            }
            int min = színészek[0].filmszám;
            string ország = "";
            for (int i = 0; i < legtöbbfilm.Count; i++)
            {
                if (legtöbbfilm[i].szám < min)
                {
                    min = legtöbbfilm[i].szám;
                    ország = legtöbbfilm[i].ország;
                }
            }
            Console.WriteLine("{0}\t{1}", ország, min);
            FájlbaKiír2(ország.ToString(), min.ToString(), fájlnév);
        }
        static void Azonosnap_név_dátum(List<Színész> színészek, string fájlnév)
        {
            List<Születésnapok> születésnapok = new List<Születésnapok>();
            int k;
            bool meglett;
            for (int i = 0; i < színészek.Count; i++)
            {
                k = 0;
                meglett = false;
                while (k < születésnapok.Count && !meglett)
                {
                    if (színészek[i].Születésnap() == születésnapok[k].dátum)
                    {
                        meglett = true;
                        születésnapok[k].szám++;
                    }

                    k++;
                }
                if (!meglett)
                {
                    születésnapok.Add(new Születésnapok(színészek[i].Születésnap(), 1));
                }
            }
            int j;
            bool megvan;
            for (int i = 0; i < színészek.Count; i++)
            {
                j = 0;
                megvan = false;
                while (j < születésnapok.Count && !megvan)
                {
                    if (születésnapok[j].dátum == színészek[i].Születésnap() && születésnapok[j].szám > 1)
                    {
                        Console.WriteLine("{0}\t{1:yyyy.MM.dd}", színészek[i].név, színészek[i].szüldátum);
                        FájlbaKiír2(színészek[i].név, színészek[i].szüldátum.ToString(), fájlnév); //nem működik, csak az utolsó kerül bele, mert még nem írtam rá jó kiirató függvényt
                    }
                    j++;
                }
            }
        }
        static void Main(string[] args)
        {
            #region Beolvasás
            StreamReader f = new StreamReader("szinesz.txt", Encoding.Default);
            List<Színész> színészek = new List<Színész>();
            while (!f.EndOfStream)
            {
                string[] sor = f.ReadLine().Split('\t');
                színészek.Add(new Színész
                {
                    név = sor[0],
                    férfi = sor[1] == "1", //logikai eredményt ad
                    szüldátum = DateTime.Parse(sor[2]),
                    szülhely = sor[3],
                    szülország = sor[4],
                    filmszám = int.Parse(sor[5])
                });
            }
            #endregion

            #region Feladatok
            #region 1-5) Feladat
            Console.WriteLine("1)	Írja ki a Budapesten született színészek nevét és filmjeinek a számát!");
            Itt_született_színészek_filmszámmal(színészek, "output_1.txt", "Budapest");
            Console.WriteLine();

            Console.WriteLine("2)	Írja ki a New Yorkban született színészek nevét és filmjeinek a számát!");
            Itt_született_színészek_filmszámmal(színészek, "output_2.txt", "New York");
            Console.WriteLine();

            Console.WriteLine("3)	Írja ki a Berlinben született színészek nevét és filmjeinek a számát!");
            Itt_született_színészek_filmszámmal(színészek, "output_3.txt", "Berlin");
            Console.WriteLine();

            Console.WriteLine("4)	Írja ki a Párizsban született színészek nevét és filmjeinek a számát!");
            Itt_született_színészek_filmszámmal(színészek, "output_4.txt", "Párizs");
            Console.WriteLine();

            Console.WriteLine("5)	Írja ki a Tokióban született színészek nevét és filmjeinek a számát!");
            Itt_született_színészek_filmszámmal(színészek, "output_5.txt", "Tokió");
            Console.WriteLine();
            #endregion

            #region 6-8) Feladat
            Console.WriteLine("6)	Hány színész született Budapesten?");
            Hányszínész_1város(színészek, "output_6.txt", "Budapest");
            Console.WriteLine();

            Console.WriteLine("7)	Hány színész született Berlinben?");
            Hányszínész_1város(színészek, "output_7.txt", "Berlin");
            Console.WriteLine();

            Console.WriteLine("8)	Hány színész született New Yorkban?");
            Hányszínész_1város(színészek, "output_8.txt", "New York");
            Console.WriteLine();
            #endregion
            #region 9-13) Feladat
            Console.WriteLine("9)	Hány színész született USA-ban?");
            Hányszínész_1ország(színészek, "output_9.txt", "USA");
            Console.WriteLine();

            Console.WriteLine("10)	Hány színész született Magyarországon?");
            Hányszínész_1ország(színészek, "output_10.txt", "Magyarország");
            Console.WriteLine();

            Console.WriteLine("11)	Hány színész született Németországban?");
            Hányszínész_1ország(színészek, "output_11.txt", "Németország");
            Console.WriteLine();

            Console.WriteLine("12)	Hány színész született Mexikóban?");
            Hányszínész_1ország(színészek, "output_12.txt", "Mexikó");
            Console.WriteLine();

            Console.WriteLine("13)	Hány színész született az USA-ban?");
            Hányszínész_1ország(színészek, "output_13.txt", "USA");
            Console.WriteLine();
            #endregion
            #region 14-21 Feladat
            Console.WriteLine("14)	Hány női színész született Magyarországon?");
            Hányszínész_Nem_1ország(színészek, "output_14.txt", false, "Magyarország");
            Console.WriteLine();

            Console.WriteLine("15)	Hány női színész született Angliában?");
            Hányszínész_Nem_1ország(színészek, "output_15.txt", false, "Anglia");
            Console.WriteLine();

            Console.WriteLine("16)	Hány női színész született Skóciában?");
            Hányszínész_Nem_1ország(színészek, "output_16.txt", false, "Skócia");
            Console.WriteLine();

            Console.WriteLine("17)	Hány női színész született Belgiumban?");
            Hányszínész_Nem_1ország(színészek, "output_17.txt", false, "Belgium");
            Console.WriteLine();

            Console.WriteLine("18)	Hány férfi színész született Magyarországon?");
            Hányszínész_Nem_1ország(színészek, "output_18.txt", true, "Magyarország");
            Console.WriteLine();

            Console.WriteLine("19)	Hány férfi színész született Kanadában?");
            Hányszínész_Nem_1ország(színészek, "output_19.txt", true, "Kanada");
            Console.WriteLine();

            Console.WriteLine("20)	Hány férfi színész született USA-ban?");
            Hányszínész_Nem_1ország(színészek, "output_20.txt", true, "USA");
            Console.WriteLine();

            Console.WriteLine("21)	Hány férfi színész született Olaszországban?");
            Hányszínész_Nem_1ország(színészek, "output_21.txt", true, "Olaszország");
            Console.WriteLine();
            #endregion
            #region 22-26) Feladat
            Console.WriteLine("22)	Hány női színész született Olaszországban vagy Spanyolországban?");
            Hányszínész_Nem_2ország(színészek, "output_22.txt", false, "Olaszország", "Spanyolország");
            Console.WriteLine();

            Console.WriteLine("23)	Hány női színész született Magyarországon vagy Romániában?");
            Hányszínész_Nem_2ország(színészek, "output_23.txt", false, "Magyarország", "Románia");
            Console.WriteLine();


            Console.WriteLine("24)	Hány női színész született az USA-ban vagy Mexikóban?");
            Hányszínész_Nem_2ország(színészek, "output_24.txt", false, "USA", "Mexikó");
            Console.WriteLine();


            Console.WriteLine("25)	Hány férfi színész született Skóciában vagy Angliában?");
            Hányszínész_Nem_2ország(színészek, "output_25.txt", false, "Skócia", "Anglia");
            Console.WriteLine();


            Console.WriteLine("26)	Hány férfi színész született Franciaországban vagy Németországban?");
            Hányszínész_Nem_2ország(színészek, "output_26.txt", false, "Franciaország", "Németország");
            Console.WriteLine();
            #endregion
            #region 27-30) Feladat
            Console.WriteLine("27)	Hány színész született 1950-ben vagy 1951-ben, USA-ban vagy Kanadában?");
            Hányszínész_2év_2ország(színészek, "output_27.txt", "1950", "1951", "USA", "Kanada");
            Console.WriteLine();

            Console.WriteLine("28)	Hány színész született 1955-ben vagy 1957-ben, Magyarországon vagy Kanadában?");
            Hányszínész_2év_2ország(színészek, "output_28.txt", "1955", "1957", "Magyarország", "Kanada");
            Console.WriteLine();

            Console.WriteLine("29)	Hány színész született 1961-ben vagy 1962-ben, Angliában vagy Skóciában?");
            Hányszínész_2év_2ország(színészek, "output_29.txt", "1961", "1962", "Anglia", "Skócia");
            Console.WriteLine();

            Console.WriteLine("30)	Hány színész született 1970-ben vagy 1971-ben, USA-ban vagy Angliában?");
            Hányszínész_2év_2ország(színészek, "output_30.txt", "1970", "1971", "USA", "Anglia");
            Console.WriteLine();
            #endregion
            #region 31-34) Feladat
            Console.WriteLine("31)	Hány férfi színész született 1950-ben vagy 1951-ben, USA-ban vagy Kanadában?");
            Hányszínész_Nem_2év_2ország(színészek, "output_31.txt", true, "1950", "1951", "USA", "Kanada");
            Console.WriteLine();

            Console.WriteLine("32)	Hány női színész született 1955-ben vagy 1957-ben, Magyarországon vagy Kanadában?");
            Hányszínész_Nem_2év_2ország(színészek, "output_32.txt", false, "1955", "1957", "Magyarország", "Kanada");
            Console.WriteLine();

            Console.WriteLine("33)	Hány férfi színész született 1961-ben vagy 1962-ben, Angliában vagy Skóciában?");
            Hányszínész_Nem_2év_2ország(színészek, "output_33.txt", true, "1961", "1962", "Anglia", "Skócia");
            Console.WriteLine();

            Console.WriteLine("34)	Hány női színész született 1970-ben vagy 1971-ben, USA-ban vagy Angliában?");
            Hányszínész_Nem_2év_2ország(színészek, "output_34.txt", false, "1970", "1971", "USA", "Anglia");
            Console.WriteLine();
            #endregion

            #region 35) Feladat
            Console.WriteLine("35)	Mikor született a legidősebb színész?");
            Mikor_Született_MAX(színészek, "output_35.txt");
            Console.WriteLine();
            #endregion
            #region 36) Feladat
            Console.WriteLine("36)	Mikor született a legfiatalabb színész?");
            Mikor_Született_MIN(színészek, "output_36.txt");
            Console.WriteLine();
            #endregion

            #region 37) Feladat
            Console.WriteLine("37)	Írja ki a legidősebb színész(ek) nevét és születési évét!");
            Mikor_Született_MAX_Név(színészek, "output_37.txt");
            Console.WriteLine();
            #endregion
            #region 38) Feladat
            Console.WriteLine("38)	Írja ki a legfiatalabb színész(ek) nevét és születési évét!");
            Mikor_Született_MIN_Név(színészek, "output_38.txt");
            Console.WriteLine();
            #endregion

            #region 39) Feladat
            Console.WriteLine("39)	Hány filmben játszott a legtöbb filmben szereplő színész?");
            int max = 0;
            for (int i = 0; i < színészek.Count; i++)
            {
                if (színészek[i].filmszám > max)
                {
                    max = színészek[i].filmszám;
                }
            }
            Console.WriteLine(max);
            FájlbaKiír(max.ToString(), "output_39.txt");
            Console.WriteLine();
            #endregion
            #region 40-44) Feladat
            Console.WriteLine("40)	Hány filmben játszott a legtöbb filmben szereplő, Magyarországon született színész?");
            Legtöbbfilmszínész_1ország(színészek, "output_40.txt", "Magyarország");
            Console.WriteLine();

            Console.WriteLine("41)	Hány filmben játszott a legtöbb filmben szereplő, USA-ban született színész?");
            Legtöbbfilmszínész_1ország(színészek, "output_41.txt", "USA");
            Console.WriteLine();

            Console.WriteLine("42)	Hány filmben játszott a legtöbb filmben szereplő, Angliában született színész?");
            Legtöbbfilmszínész_1ország(színészek, "output_42.txt", "Anglia");
            Console.WriteLine();

            Console.WriteLine("43)	Hány filmben játszott a legtöbb filmben szereplő, Mexikóban született színész?");
            Legtöbbfilmszínész_1ország(színészek, "output_43.txt", "Mexikó");
            Console.WriteLine();

            Console.WriteLine("44)	Hány filmben játszott a legtöbb filmben szereplő, Olaszországban született színész?");
            Legtöbbfilmszínész_1ország(színészek, "output_44.txt", "Olaszország");
            Console.WriteLine();
            #endregion

            #region 45) Feladat
            Console.WriteLine("45)   Melyik évben született a legtöbb színész? Az évet és a színészek számát is írja ki!");
            Mikor_legtöbb_színész(színészek, "output_45.txt");
            Console.WriteLine();
            #endregion
            #region 46) Feladat
            Console.WriteLine("46)	Melyik évben született a legkevesebb színész? Az évet és a színészek számát is írja ki!");
            Mikor_legkevesebb_színész(színészek, "output_46.txt");
            Console.WriteLine();
            #endregion

            #region 47) Feladat
            Console.WriteLine("47)	Melyik országban született a legtöbb színész? Az országot és a színészek számát is írja ki!");
            Hol_legtöbb_színész(színészek, "output_47.txt");
            Console.WriteLine();
            #endregion
            #region 48) Feladat
            Console.WriteLine("48)	Melyik országban született a legkevesebb színész? Az országot és a színészek számát is írja ki!");
            Hol_legkevesebb_színész(színészek, "output_48.txt");
            Console.WriteLine();
            #endregion

            #region 49) Feladat
            Console.WriteLine("49)	Vannak-e olyan színészek, akik azonos napon születtek? Írja ki a színészek nevét és születési dátumát!");
            Azonosnap_név_dátum(színészek, "output_49.txt");
            Console.WriteLine();
            #endregion
            #endregion
        }
    }
}
