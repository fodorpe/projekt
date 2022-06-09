using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace _3000N
{
    class Ajánlat
    {
        public string tájegység;
        public int éjszakák;
        public bool családos;
        public string hónap;
        public int maxlétszám;
        public int eddigjelentkezők;
        public int ár;
    }
    class Program
    {
        static int Hányajánlat(List<Ajánlat> lista, Func<Ajánlat, bool> predikátum)
        {
            int ennyi = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                if (predikátum(lista[i]))
                {
                    ennyi++;
                }
            }
            return ennyi;
        }
        static void Kiválogatás(List<Ajánlat> lista, Func<Ajánlat, bool> predikátum, Func<Ajánlat, int> projekció, string noname)
        {
            int min = lista[0].ár;
            int max = 0;
            string legjobb = "asd";
            string legrosszabb = "asd";
            if (noname == "Legjobb")
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    if (predikátum(lista[i]) && projekció(lista[i]) > max)
                    {
                        legjobb = lista[i].tájegység + ", " + lista[i].éjszakák + " ," + lista[i].családos + ", " + lista[i].hónap + ", " + lista[i].maxlétszám + ", " + lista[i].eddigjelentkezők + " ," + lista[i].ár;
                    }
                }
                Console.WriteLine(legjobb);
            }
            else
            {
                if (noname == "Legrosszabb")
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (predikátum(lista[i]) && projekció(lista[i]) < min)
                        {
                            legrosszabb = lista[i].tájegység + ", " + lista[i].éjszakák + " ," + lista[i].családos + ", " + lista[i].hónap + ", " + lista[i].maxlétszám + ", " + lista[i].eddigjelentkezők + " ," + lista[i].ár;
                        }
                    }
                    Console.WriteLine(legrosszabb);
                }
                else
                {
                    for (int i = 0; i < lista.Count; i++)
                    {
                        if (predikátum(lista[i]))
                        {
                            Console.WriteLine(lista[i].tájegység + ", " + lista[i].éjszakák + " ," + lista[i].családos + ", " + lista[i].hónap + ", " + lista[i].maxlétszám + ", " + lista[i].eddigjelentkezők + " ," + lista[i].ár);
                        }
                    }
                }
            }
        }
        static void Van_e(List<Ajánlat> lista, Func<Ajánlat, bool> predikátum)
        {
            bool van = false;
            int k = 0;
            while (k < lista.Count && !van)
            {
                if (predikátum(lista[k]))
                {
                    van = true;
                }
                k++;
            }
            Console.WriteLine(van ? "Van!" : "Nincs!");
        }
        static void Igaz_e(List<Ajánlat> lista, Func<Ajánlat, bool> predikátum)
        {
            int k = 0;
            bool nemigaz = false;
            while (!nemigaz && k < lista.Count)
            {
                if (predikátum(lista[k]))
                {
                    nemigaz = true;
                }
                k++;
            }
            Console.WriteLine(nemigaz ? "Nem igaz!" : "Igaz!");
        }
        static int Hány_Valami(List<Ajánlat> lista, Func<Ajánlat, bool> predikátum, Func<Ajánlat, int> projekció, string legnagyobb_v_legkisebb)
        {
            int max = 0;
            int min = lista[0].ár;
            if (legnagyobb_v_legkisebb == "legnagyobb")
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    if (predikátum(lista[i]) && projekció(lista[i]) > max)
                    {
                        max = projekció(lista[i]);
                    }
                }
                return max;
            }
            else
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    if (predikátum(lista[i]) && projekció(lista[i]) < min)
                    {
                        min = projekció(lista[i]);
                    }
                }
                return min;
            }
        }
        static void Main(string[] args)
        {
            #region Beolvasás
            List<Ajánlat> ajánlatok = new List<Ajánlat>();
            StreamReader r = new StreamReader("ajanlatok.txt", Encoding.Default);
            while (!r.EndOfStream)
            {
                string[] sor = r.ReadLine().Split('\t');
                ajánlatok.Add(new Ajánlat
                {
                    tájegység = sor[0],
                    éjszakák = int.Parse(sor[1]),
                    családos = (sor[2] == "True"),
                    hónap = sor[3],
                    maxlétszám = int.Parse(sor[4]),
                    eddigjelentkezők = int.Parse(sor[5]),
                    ár = int.Parse(sor[6])
                });
            }
            #endregion

            Console.WriteLine("1)	Hány ajánlat található az input fájlban?");
            Console.WriteLine(ajánlatok.Count);

            #region 2-21
            Console.WriteLine("2)	Hány mátrai tájegységre vonatozó ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Mátra"));

            Console.WriteLine("3)	Hány mecseki tájegységre vonatozó ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Mecsek"));

            Console.WriteLine("4)	Hány bakonyi tájegységre vonatozó ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Bakony"));

            Console.WriteLine("5)	Hány hortobágyi tájegységre vonatozó ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Hortobágy"));

            Console.WriteLine("6)	Hány őrségi tájegységre vonatozó ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Őrség"));

            Console.WriteLine("7)	Hány mátrai tájegységre vonatozó, családos ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Mátra" && x.családos == true));

            Console.WriteLine("8)	Hány mecseki tájegységre vonatozó, egyéni ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Mecsek" && x.családos == false));

            Console.WriteLine("9)	Hány bakonyi tájegységre vonatozó, májusi ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Bakony" && x.hónap == "Május"));

            Console.WriteLine("10)	Hány hortobágyi tájegységre vonatozó, júliusi ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Hortobágy" && x.hónap == "Július"));

            Console.WriteLine("11)	Hány őrségi tájegységre vonatozó, októberi ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Őrség" && x.hónap == "Október"));

            Console.WriteLine("12)	Hány mátrai tájegységre vonatozó, családos, öt napnál hosszabb ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Mátra" && x.családos == true && x.éjszakák >= 5));

            Console.WriteLine("13)	Hány mecseki tájegységre vonatozó, egyéni, 3 napnál rövidebb ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Mecsek" && x.családos == false && x.éjszakák <= 2));

            Console.WriteLine("14)	Hány bakonyi tájegységre vonatozó, májusi, egy hétnél hosszabb ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Bakony" && x.hónap == "Május" && x.éjszakák >= 7));

            Console.WriteLine("15)	Hány hortobágyi tájegységre vonatozó, júliusi, egy hetes ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Hortobágy" && x.hónap == "Július" && x.éjszakák == 6));

            Console.WriteLine("16)	Hány őrségi tájegységre vonatozó, októberi, öt napos ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Őrség" && x.hónap == "Október" && x.éjszakák == 4));

            Console.WriteLine("17)	Hány mátrai tájegységre vonatozó, családos, még szabad hellyel rendelkező ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Mátra" && x.családos == true && (x.maxlétszám - x.eddigjelentkezők) > 0));

            Console.WriteLine("18)	Hány mecseki tájegységre vonatozó, egyéni, még szabad hellyel rendelkező ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Mecsek" && x.családos == false && (x.maxlétszám - x.eddigjelentkezők) > 0));

            Console.WriteLine("19)	Hány bakonyi tájegységre vonatozó, májusi, még szabad hellyel rendelkező ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Bakony" && x.hónap == "Május" && (x.maxlétszám - x.eddigjelentkezők) > 0));

            Console.WriteLine("20)	Hány hortobágyi tájegységre vonatozó, júliusi, még szabad hellyel rendelkező ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Hortobágy" && x.hónap == "Július" && (x.maxlétszám - x.eddigjelentkezők) > 0));

            Console.WriteLine("21)	Hány őrségi tájegységre vonatozó, októberi, még szabad hellyel rendelkező ajánlat található az input fájlban?");
            Console.WriteLine(Hányajánlat(ajánlatok, x => x.tájegység == "Őrség" && x.hónap == "Október" && (x.maxlétszám - x.eddigjelentkezők) > 0));
            #endregion

            #region 22-36
            Console.WriteLine("22)	Válogassuk ki a mátrai tájegységre vonatozó, családos, még szabad hellyel rendelkező ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Mátra" && x.családos == true && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Mindegy");

            Console.WriteLine("23)	Válogassuk ki a bükki tájegységre vonatozó, májusi, még szabad hellyel rendelkező ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Bükk" && x.hónap == "Május" && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Mindegy");

            Console.WriteLine("24)	Válogassuk ki a zempléni tájegységre vonatozó, egyéni, még szabad hellyel rendelkező ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Zemplés" && x.családos == false && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Mindegy");

            Console.WriteLine("25)	Válogassuk ki a mecseki tájegységre vonatozó, júniusi, még szabad hellyel rendelkező ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Mecsek" && x.hónap == "Június" && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Mindegy");

            Console.WriteLine("26)	Válogassuk ki a balatoni tájegységre vonatozó, augusztusi, még szabad hellyel rendelkező ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Balaton" && x.hónap == "Augusztus" && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Mindegy");

            Console.WriteLine("27)	Válogassuk ki a mátrai tájegységre vonatozó, családos, még szabad hellyel rendelkező, 20000 Ft alatti ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Mátra" && x.családos == true && (x.maxlétszám - x.eddigjelentkezők > 0) && x.ár < 20000, x => x.ár, "Mindegy");

            Console.WriteLine("28)	Válogassuk ki a bükki tájegységre vonatozó, májusi, még szabad hellyel rendelkező, 50000 Ft alatti ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Bükk" && x.hónap == "Május" && (x.maxlétszám - x.eddigjelentkezők > 0) && x.ár < 50000, x => x.ár, "Mindegy");

            Console.WriteLine("29)	Válogassuk ki a zempléni tájegységre vonatozó, egyéni, még szabad hellyel rendelkező, 60000 Ft alatti ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Zemplén" && x.családos == false && (x.maxlétszám - x.eddigjelentkezők > 0) && x.ár < 60000, x => x.ár, "Mindegy");

            Console.WriteLine("30)	Válogassuk ki a mecseki tájegységre vonatozó, júniusi, még szabad hellyel rendelkező, 30000 Ft alatti ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Mecsek" && x.hónap == "Június" && (x.maxlétszám - x.eddigjelentkezők > 0) && x.ár < 30000, x => x.ár, "Mindegy");

            Console.WriteLine("31)	Válogassuk ki a balatoni tájegységre vonatozó, augusztusi, még szabad hellyel rendelkező, 40000 Ft alatti ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Balaton" && x.hónap == "Augusztus" && (x.maxlétszám - x.eddigjelentkezők > 0) && x.ár < 40000, x => x.ár, "Mindegy");

            Console.WriteLine("32)	Válogassuk ki a mátrai tájegységre vonatozó, nyári, még szabad hellyel rendelkező ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Mátra" && (x.hónap == "Június" || x.hónap == "Július" || x.hónap == "Augusztus") && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Mindegy");

            Console.WriteLine("33)	Válogassuk ki a bükki tájegységre vonatozó, nyári, még szabad hellyel rendelkező ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Bükk" && (x.hónap == "Június" || x.hónap == "Július" || x.hónap == "Augusztus") && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Mindegy");

            Console.WriteLine("34)	Válogassuk ki a zempléni tájegységre vonatozó, téli, még szabad hellyel rendelkező!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Zemplén" && (x.hónap == "December" || x.hónap == "Január" || x.hónap == "Február") && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Mindegy");

            Console.WriteLine("35)	Válogassuk ki a mecseki tájegységre vonatozó, tavaszi, még szabad hellyel rendelkező ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Mecsek" && (x.hónap == "Március" || x.hónap == "Április" || x.hónap == "Május") && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Mindegy");

            Console.WriteLine("36)	Válogassuk ki a balatoni tájegységre vonatozó, őszi, még szabad hellyel rendelkező ajánlatokat!");
            Kiválogatás(ajánlatok, x => x.tájegység == "Balaton" && (x.hónap == "Szeptember" || x.hónap == "Október" || x.hónap == "November") && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Mindegy");
            #endregion

            #region 37-43
            Console.WriteLine("37)	Van-e az irodának téli, balatoni ajánlata?");
            Van_e(ajánlatok, x => x.tájegység == "Balaton" && (x.hónap == "December" || x.hónap == "Január" || x.hónap == "Február"));

            Console.WriteLine("38)	Van-e az irodának őszi, balatoni ajánlata?");
            Van_e(ajánlatok, x => x.tájegység == "Balaton" && (x.hónap == "Szemptember" || x.hónap == "Október" || x.hónap == "November"));

            Console.WriteLine("39)	Van-e az irodának tavaszi, hortobágyi ajánlata?");
            Van_e(ajánlatok, x => x.tájegység == "Hortobágy" && (x.hónap == "Március" || x.hónap == "Április" || x.hónap == "Május"));

            Console.WriteLine("40)	Van-e az irodának téli, bakonyi ajánlata?");
            Van_e(ajánlatok, x => x.tájegység == "Bakony" && (x.hónap == "December" || x.hónap == "Január" || x.hónap == "Február"));

            Console.WriteLine("41)	Van-e az irodának őszi, bükki ajánlata?");
            Van_e(ajánlatok, x => x.tájegység == "Bükk" && (x.hónap == "Szemptember" || x.hónap == "Október" || x.hónap == "November"));

            Console.WriteLine("42)	Van-e az irodának nyári, pilisi ajánlata?");
            Van_e(ajánlatok, x => x.tájegység == "Pilis" && (x.hónap == "Június" || x.hónap == "Július" || x.hónap == "Augusztus"));

            Console.WriteLine("43)	Van-e az irodának téli, őrségi ajánlata?");
            Van_e(ajánlatok, x => x.tájegység == "Őrség" && (x.hónap == "December" || x.hónap == "Január" || x.hónap == "Február"));
            #endregion

            #region 44-53
            Console.WriteLine("44)	Igaz-e, hogy az minden ajánlat legalább 3 napos?");
            Igaz_e(ajánlatok, x => x.éjszakák <= 1);

            Console.WriteLine("45)	Igaz-e, hogy az minden ajánlat legalább 5 napos?");
            Igaz_e(ajánlatok, x => x.éjszakák <= 3);

            Console.WriteLine("46)	Igaz-e, hogy az minden ajánlat legalább 2 napos?");
            Igaz_e(ajánlatok, x => x.éjszakák <= 0);

            Console.WriteLine("47)	Igaz-e, hogy az minden ajánlat legalább 10000 Ft-ba kerül?");
            Igaz_e(ajánlatok, x => x.ár <= 9999);

            Console.WriteLine("48)	Igaz-e, hogy az minden ajánlat legalább 5000 Ft-ba kerül?");
            Igaz_e(ajánlatok, x => x.ár <= 4999);

            Console.WriteLine("49)	Igaz-e, hogy az minden ajánlat legalább 1000 Ft-ba kerül?");
            Igaz_e(ajánlatok, x => x.ár <= 999);

            Console.WriteLine("50)	Igaz-e, hogy az minden ajánlat tavaszi, és maximális létszáma legalább 20 fő?");
            Igaz_e(ajánlatok, x => x.hónap == "Június" || x.maxlétszám <= 19);

            Console.WriteLine("51)	Igaz-e, hogy az minden ajánlat nyári, és maximális létszáma legalább 5 fő?");
            Igaz_e(ajánlatok, x => x.hónap == "Szeptember" || x.maxlétszám <= 4);

            Console.WriteLine("52)	Igaz-e, hogy az minden ajánlat téli, és maximális létszáma legalább 30 fő?");
            Igaz_e(ajánlatok, x => x.hónap == "Március" || x.maxlétszám <= 29);

            Console.WriteLine("53)	Igaz-e, hogy az minden ajánlat őszi, és maximális létszáma legalább 15 fő?");
            Igaz_e(ajánlatok, x => x.hónap == "December" || x.maxlétszám <= 14);
            #endregion

            #region 54-61 
            //Az egészben feltételezem , hogy mindegyik ajánlat drágább 1 Forintnál
            Console.WriteLine("54)	Hány forintba kerül a legdrágább ajánlat?");
            Console.WriteLine(Hány_Valami(ajánlatok, x => x.ár > 1, x => x.ár, "legnagyobb"));

            Console.WriteLine("55)	Hány forintba kerül a legolcsóbb ajánlat?");
            Console.WriteLine(Hány_Valami(ajánlatok, x => x.ár > 1, x => x.ár, "legkisebb"));

            Console.WriteLine("56)	Hány napos a leghosszabb ajánlat?");
            Console.WriteLine(Hány_Valami(ajánlatok, x => x.ár > 1, x => x.éjszakák + 1, "legnagyobb")); //hozzá adok egyet az éjszakákhoz mert egyel kevesebb éjszakát maradnak mint napot

            Console.WriteLine("57)	Hány napos a legrövidebb ajánlat?");
            Console.WriteLine(Hány_Valami(ajánlatok, x => x.ár > 1, x => x.éjszakák + 1, "legkisebb"));//hozzá adok egyet az éjszakákhoz mert egyel kevesebb éjszakát maradnak mint napot

            Console.WriteLine("58)	Hány fős a legnagyobb maximális létszámú ajánlat?");
            Console.WriteLine(Hány_Valami(ajánlatok, x => x.ár > 1, x => x.maxlétszám, "legnagyobb"));

            Console.WriteLine("59)	Hány fős a legkisebb maximális létszámú ajánlat?");
            Console.WriteLine(Hány_Valami(ajánlatok, x => x.ár > 1, x => x.maxlétszám, "legkisebb"));

            Console.WriteLine("60)	Hány fős a legtöbb jelentkezéssel bíró ajánlat?");
            Console.WriteLine(Hány_Valami(ajánlatok, x => x.ár > 1, x => x.eddigjelentkezők, "legnagyobb"));

            Console.WriteLine("61)	Hány fős a legkisebb jelentkezéssel bíró ajánlat?");
            Console.WriteLine(Hány_Valami(ajánlatok, x => x.ár > 1, x => x.eddigjelentkezők, "legkisebb"));
            #endregion

            #region 62-84
            Console.WriteLine("62)	Válogassuk ki a mecseki utak közül azokat, melyekre minden hely elkelt.");
            Kiválogatás(ajánlatok, x => x.tájegység == "Mecsek" && (x.maxlétszám - x.eddigjelentkezők == 0), x => x.ár, "Mindegy");

            Console.WriteLine("63)	Válogassuk ki a zempléni utak közül azokat, melyekre minden hely elkelt.");
            Kiválogatás(ajánlatok, x => x.tájegység == "Zemplén" && (x.maxlétszám - x.eddigjelentkezők == 0), x => x.ár, "Mindegy");

            Console.WriteLine("64)	Válogassuk ki az őrségi utak közül azokat, melyekre minden hely elkelt.");
            Kiválogatás(ajánlatok, x => x.tájegység == "Őrség" && (x.maxlétszám - x.eddigjelentkezők == 0), x => x.ár, "Mindegy");

            Console.WriteLine("65)	Válogassuk ki a balatoni utak közül azokat, melyekre minden hely elkelt.");
            Kiválogatás(ajánlatok, x => x.tájegység == "Balaton" && (x.maxlétszám - x.eddigjelentkezők == 0), x => x.ár, "Mindegy");

            //--------------------------------------------------------------------------------------

            Console.WriteLine("66)	Válogassuk ki a legdrágább ajánlatokat?");
            Kiválogatás(ajánlatok, x => x.ár > 0, x => x.ár, "Legjobb");

            Console.WriteLine("67)	Válogassuk ki a legolcsóbb ajánlatokat?");
            Kiválogatás(ajánlatok, x => x.ár > 0, x => x.ár, "Legrosszabb");

            Console.WriteLine("68)	Válogassuk ki a leghosszabb ajánlatokat?");
            Kiválogatás(ajánlatok, x => x.ár > 0, x => x.éjszakák, "Legjobb");

            Console.WriteLine("69)	Válogassuk ki a legrövidebb ajánlatokat?");
            Kiválogatás(ajánlatok, x => x.ár > 0, x => x.éjszakák, "Legrosszabb");

            Console.WriteLine("70)	Válogassuk ki a legnagyobb maximális létszámú ajánlatokat?");
            Kiválogatás(ajánlatok, x => x.ár > 0, x => x.maxlétszám, "Legjobb");

            Console.WriteLine("71)	Válogassuk ki a legkisebb maximális létszámú ajánlatokat?");
            Kiválogatás(ajánlatok, x => x.ár > 0, x => x.maxlétszám, "Legrosszabb");

            Console.WriteLine("72)	Válogassuk ki a legtöbb jelentkezéssel bíró ajánlatokat?");
            Kiválogatás(ajánlatok, x => x.ár > 0, x => x.eddigjelentkezők, "Legjobb");

            Console.WriteLine("73)	Válogassuk ki a legkisebb jelentkezéssel bíró ajánlatokat?");
            Kiválogatás(ajánlatok, x => x.ár > 0, x => x.eddigjelentkezők, "Legrosszabb");

            Console.WriteLine("74)	Válogassuk ki a nyári, legalább 5 napos ajánlatok közül a legolcsóbbakat!");
            Kiválogatás(ajánlatok, x => (x.hónap == "Június" || x.hónap == "Július" || x.hónap == "Július") && x.éjszakák >= 4, x => x.ár, "Legrosszabb");

            Console.WriteLine("75)	Válogassuk ki az őszi, legfeljebb 5 napos ajánlatok közül a legdrágábbakat!");
            Kiválogatás(ajánlatok, x => (x.hónap == "Szeptember" || x.hónap == "Október" || x.hónap == "November") && x.éjszakák <= 4, x => x.ár, "Legjobb");

            Console.WriteLine("76)	Válogassuk ki a tavaszi, legalább 2 napos ajánlatok közül a legolcsóbbakat!");
            Kiválogatás(ajánlatok, x => (x.hónap == "Március" || x.hónap == "Április" || x.hónap == "Május") && x.éjszakák >= 1, x => x.ár, "Legrosszabb");

            Console.WriteLine("77)	Válogassuk ki a nyári, legfeljebb egy hetes ajánlatok közül a legdrágábbakat!");
            Kiválogatás(ajánlatok, x => (x.hónap == "Június" || x.hónap == "Július" || x.hónap == "Július") && x.éjszakák <= 6, x => x.ár, "Legjobb");

            Console.WriteLine("78)	Válogassuk ki az őszi, legalább egy hetes ajánlatok közül a legolcsóbbakat!");
            Kiválogatás(ajánlatok, x => (x.hónap == "Szeptember" || x.hónap == "Október" || x.hónap == "November") && x.éjszakák >= 6, x => x.ár, "Legrosszabb");

            Console.WriteLine("79)	Válogassuk ki a téli, legfeljebb 5 napos ajánlatok közül a legdrágábbakat!");
            Kiválogatás(ajánlatok, x => (x.hónap == "December" || x.hónap == "Január" || x.hónap == "Február") && x.éjszakák <= 4, x => x.ár, "Legjobb");

            Console.WriteLine("80)	Válogassuk ki az őszi, legalább egy hetes, szabad hellyel rendelkező ajánlatok közül a legolcsóbbakat!");
            Kiválogatás(ajánlatok, x => (x.hónap == "Szeptember" || x.hónap == "Október" || x.hónap == "November") && x.éjszakák >= 6 && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Legrosszabb");

            Console.WriteLine("81)	Válogassuk ki az mátrai, legalább 3 napos, szabad hellyel rendelkező ajánlatok közül a legolcsóbbakat!");
            Kiválogatás(ajánlatok, x => (x.tájegység == "Mátra") && x.éjszakák >= 2 && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Legrosszabb");

            Console.WriteLine("82)	Válogassuk ki az őszi, legfeljebb egy hetes, szabad hellyel rendelkező ajánlatok közül a legolcsóbbakat!");
            Kiválogatás(ajánlatok, x => (x.hónap == "Szeptember" || x.hónap == "Október" || x.hónap == "November") && x.éjszakák >= 6 && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Legrosszabb");

            Console.WriteLine("83)	Válogassuk ki az mátrai, vagy bükki, legalább egy hetes, szabad hellyel rendelkező ajánlatok közül a legolcsóbbakat!");
            Kiválogatás(ajánlatok, x => (x.tájegység == "Bükk") && x.éjszakák >= 6 && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Legrosszabb");

            Console.WriteLine("84)	Válogassuk ki az nyári, legfeljebb egy hetes, szabad hellyel rendelkező ajánlatok közül a legdrágábbakat!");
            Kiválogatás(ajánlatok, x => (x.hónap == "Június" || x.hónap == "Július" || x.hónap == "Augusztus") && x.éjszakák <= 6 && (x.maxlétszám - x.eddigjelentkezők > 0), x => x.ár, "Legjobb");
            #endregion
        }
    }
}
