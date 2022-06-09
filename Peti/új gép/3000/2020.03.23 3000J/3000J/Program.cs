using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3000J
{
    class Program
    {
        class Tanuló
        {
            public int tanulokod;
            public string név;
            public string matinfcsop;
            public string angolcsop;
            public string mnyelv;
            public string nem;
            public int együttlakók;
            public int testvérszám;

            // Tanuló konstruktor-metódusa
            // metódusnak nevezzük azon függvényeket amelyek valamely classhoz tartoznak.

            public Tanuló(string[] sor)
            {
                tanulokod = int.Parse(sor[0]); // pontosvesszőkkel kell tagolni!
                név = sor[1];
                matinfcsop = sor[2];
                angolcsop = sor[3];
                mnyelv = sor[4];
                nem = sor[5];
                együttlakók = int.Parse(sor[6]);
                testvérszám = int.Parse(sor[7]);
            }
            public Tanuló() { } // üres konstruktor ahhoz hogy bejövő paraméter nélkül is létre lehessen hozni tanulót
        }
        static void FájlbaKiír(string kiírandó, string fájlnév)
        {
            StreamWriter w = new StreamWriter(fájlnév);
            w.WriteLine(kiírandó);
            w.Close();
        }
        static void FájlbaKiírListát(List<string> kiírandó, string fájlnév)
        {
            StreamWriter w = new StreamWriter(fájlnév);
            for (int i = 0; i < kiírandó.Count; i++)
            {
                w.WriteLine(kiírandó[i]);
            }
            w.Close();
        }
        static void BeolvasásGyalogos(List<Tanuló> osztály, string fájlnév)
        {
            using (StreamReader f = new StreamReader(fájlnév, Encoding.Default))
            {
                Tanuló t;
                while (!f.EndOfStream)
                {
                    string[] sor = f.ReadLine().Split(';');
                    t = new Tanuló();
                    t.tanulokod = int.Parse(sor[0]);
                    t.név = sor[1];
                    t.matinfcsop = sor[2];
                    t.angolcsop = sor[3];
                    t.mnyelv = sor[4];
                    t.nem = sor[5];
                    t.együttlakók = int.Parse(sor[6]);
                    t.testvérszám = int.Parse(sor[7]);
                    osztály.Add(t);
                }
            }
        }
        static void BeolvasásNemGyalogos(List<Tanuló> osztály, string fájlnév)
        {
            using (StreamReader f = new StreamReader(fájlnév, Encoding.Default))
            {
                while (!f.EndOfStream)
                {
                    string[] sor = f.ReadLine().Split(';');
                    osztály.Add(new Tanuló
                    {
                        tanulokod = int.Parse(sor[0]), // vesszőkkel kell tagolni!
                        név = sor[1],
                        matinfcsop = sor[2],
                        angolcsop = sor[3],
                        mnyelv = sor[4],
                        nem = sor[5],
                        együttlakók = int.Parse(sor[6]),
                        testvérszám = int.Parse(sor[7]) // utolsó helyre vessző sem kell!
                    });
                }
            }
        }
        static void BeolvasásElegánsOOP(List<Tanuló> osztály, string fájlnév)
        {
            using (StreamReader f = new StreamReader(fájlnév, Encoding.Default))
            {
                while (!f.EndOfStream)
                {
                    osztály.Add(new Tanuló(f.ReadLine().Split(';')));
                }
            }
        }
        static int TanulóIndexénekMegkeresése(string név, List<Tanuló> osztály)
        {
            bool megvan = false;
            int i = 0;
            while (!megvan && i < osztály.Count)
            {
                if (osztály[i].név == név)
                {
                    megvan = true;
                }
                i++;
            }
            return i - 1;
        }

        static List<Tanuló> Csoporttársai(int index, List<Tanuló> osztály)
        {
            List<Tanuló> csoporttársai = new List<Tanuló>();
            string keresettcsoport = osztály[index].angolcsop;
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].angolcsop == keresettcsoport && i != index)
                {
                    csoporttársai.Add(osztály[i]);
                }
            }
            return csoporttársai;
        }

        static void CsoporttársaiNévAlapján(string név, List<Tanuló> osztály, string fájlnév)
        {
            List<string> CsoporttársaiNévAlapjánLista = new List<string>();
            int ix = TanulóIndexénekMegkeresése(név, osztály);
            if (osztály[ix].név != név)
            {
                Console.WriteLine("Nincs is ilyen diák az osztályban.");
            }
            else
            {
                List<Tanuló> csoporttársak = Csoporttársai(ix, osztály);

                for (int k = 0; k < csoporttársak.Count; k++)
                {
                    Console.WriteLine(csoporttársak[k].név);
                    CsoporttársaiNévAlapjánLista.Add(csoporttársak[k].név);
                }
                Console.WriteLine();
            }
            FájlbaKiírListát(CsoporttársaiNévAlapjánLista, fájlnév);
        }
        static void Main(string[] args)
        {
            List<Tanuló> osztály = new List<Tanuló>();
            //BeolvasásGyalogos(osztály, "input.txt");
            //BeolvasásNemGyalogos(osztály, "input.txt");
            BeolvasásElegánsOOP(osztály, "03_000-J.txt");

            #region Feladatok
            #region 1) Feladat
            Console.WriteLine("1) Hány diák tanul az osztályban?");
            Console.WriteLine(osztály.Count);
            FájlbaKiír(osztály.Count.ToString(), "output_1.txt");
            Console.WriteLine();
            #endregion
            #region 2-3) Feladat
            int fsum = 0;
            int lsum = 0;
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].nem == "F")
                {
                    fsum++;
                }
                else
                {
                    lsum++;
                }
            }
            Console.WriteLine("2) Hány fiú tanul az osztályban?");
            Console.WriteLine(fsum);
            FájlbaKiír(fsum.ToString(), "output_2.txt");
            Console.WriteLine();
            Console.WriteLine("3) Hány lány tanul az osztályban?");
            Console.WriteLine(lsum);
            FájlbaKiír(lsum.ToString(), "output_3.txt");
            Console.WriteLine();
            #endregion
            #region 4-5) Feladat
            List<string> többtestvéresek_nevei = new List<string>();
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].testvérszám > 1)
                {
                    többtestvéresek_nevei.Add(osztály[i].név);
                }
            }
            Console.WriteLine("4) Hány olyan diák van, akiknek több mint 1 testvére van!");
            Console.WriteLine(többtestvéresek_nevei.Count);
            FájlbaKiír(többtestvéresek_nevei.Count.ToString(), "output_4.txt");
            Console.WriteLine();
            Console.WriteLine("5) Gyűjtse ki azon diákok nevét, akiknek több mint 1 testvérük van!");
            for (int i = 0; i < többtestvéresek_nevei.Count; i++)
            {
                Console.WriteLine(többtestvéresek_nevei[i]);
            }
            Console.WriteLine();
            FájlbaKiírListát(többtestvéresek_nevei, "output_5.txt");
            #endregion
            #region 6-7) Feladat
            List<string> többmint2testvéresek_nevei = new List<string>();
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].testvérszám > 2)
                {
                    többmint2testvéresek_nevei.Add(osztály[i].név);
                }
            }
            Console.WriteLine("6) Hány olyan diák van, akiknek több mint 2 testvére van!");
            Console.WriteLine(többmint2testvéresek_nevei.Count);
            FájlbaKiír(többmint2testvéresek_nevei.Count.ToString(), "output_6.txt");
            Console.WriteLine();
            Console.WriteLine("7) Gyűjtse ki azon diákok nevét, akiknek több mint 2 testvérük van!");
            for (int i = 0; i < többmint2testvéresek_nevei.Count; i++)
            {
                Console.WriteLine(többmint2testvéresek_nevei[i]);
            }
            Console.WriteLine();
            FájlbaKiírListát(többmint2testvéresek_nevei, "output_7.txt");
            #endregion
            #region 8-9) Feladat
            int németmnyelvsum = 0;
            List<string> németet_tanuló_fiúk_nevei = new List<string>();
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].mnyelv == "német")
                {
                    németmnyelvsum++;

                    if (osztály[i].nem == "F")
                    {
                        németet_tanuló_fiúk_nevei.Add(osztály[i].név);
                    }
                }
            }
            Console.WriteLine("8) Hány olyan diák van, akik a 2. idegen nyelvként a németet tanulják!");
            Console.WriteLine(németmnyelvsum);
            FájlbaKiír(németmnyelvsum.ToString(), "output_8.txt");
            Console.WriteLine();
            Console.WriteLine("9) Gyűjtse ki azon fiú diákok nevét, akik a 2. idegen nyelvként a németet tanulják!");
            for (int i = 0; i < németet_tanuló_fiúk_nevei.Count; i++)
            {
                Console.WriteLine(németet_tanuló_fiúk_nevei[i]);
            }
            FájlbaKiírListát(németet_tanuló_fiúk_nevei, "output_9.txt");
            Console.WriteLine();
            #endregion
            #region 10-11) Feladat
            int angol1sum = 0;
            int angol2sum = 0;
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].angolcsop.Split('.')[0] == "1")
                {
                    angol1sum++;
                }
                else if (osztály[i].angolcsop.Split('.')[0] == "2")
                {
                    angol2sum++;
                }
            }
            Console.WriteLine("10) Hány diák tanul, az egyes angol csoportban?");
            Console.WriteLine(angol1sum);
            FájlbaKiír(angol1sum.ToString(), "output_10.txt");
            Console.WriteLine();
            Console.WriteLine("11) Hány diák tanul, a kettes angol csoportban?");
            Console.WriteLine(angol2sum);
            FájlbaKiír(angol2sum.ToString(), "output_11.txt");
            Console.WriteLine();
            #endregion
            #region 12-13) Feladat
            int alfasum = 0;
            int betasum = 0;
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].matinfcsop == "alfa")
                {
                    alfasum++;
                }
                else if (osztály[i].matinfcsop == "beta")
                {
                    betasum++;
                }
            }
            Console.WriteLine("12) Hány diák tanul, az alfa matematika csoportban?");
            Console.WriteLine(alfasum);
            FájlbaKiír(alfasum.ToString(), "output_12.txt");
            Console.WriteLine();
            Console.WriteLine("13) Hány diák tanul, az beta matematika csoportban?");
            Console.WriteLine(betasum);
            FájlbaKiír(betasum.ToString(), "output_13.txt");
            Console.WriteLine();
            #endregion
            #region 14-15) Feladat
            int alfalanysum = 0;
            int betalanysum = 0;
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].matinfcsop == "alfa" && osztály[i].nem == "L")
                {
                    alfalanysum++;
                }
                else if (osztály[i].matinfcsop == "beta" && osztály[i].nem == "L")
                {
                    betalanysum++;
                }
            }
            Console.WriteLine("14) Hány lány diák tanul, az alfa matematika csoportban?");
            Console.WriteLine(alfalanysum);
            FájlbaKiír(alfalanysum.ToString(), "output_14.txt");
            Console.WriteLine();
            Console.WriteLine("15) Hány lány diák tanul, a beta matematika csoportban?");
            Console.WriteLine(betalanysum);
            FájlbaKiír(betalanysum.ToString(), "output_15.txt");
            Console.WriteLine();
            #endregion
            #region 16-17) Feladat
            int alfafiusum = 0;
            int betafiusum = 0;
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].matinfcsop == "alfa" && osztály[i].nem == "F")
                {
                    alfafiusum++;
                }
                else if (osztály[i].matinfcsop == "beta" && osztály[i].nem == "F")
                {
                    betafiusum++;
                }
            }
            Console.WriteLine("16) Hány fiú diák tanul, az alfa matematika csoportban?");
            Console.WriteLine(alfafiusum);
            FájlbaKiír(alfafiusum.ToString(), "output_16.txt");
            Console.WriteLine();
            Console.WriteLine("17) Hány fiú diák tanul, a beta matematika csoportban?");
            Console.WriteLine(betafiusum);
            FájlbaKiír(betafiusum.ToString(), "output_17.txt");
            Console.WriteLine();
            #endregion
            #region 18-20) Feladat
            bool orosze = false;
            bool olasze = false;
            bool spanyole = false;
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].mnyelv == "orosz")
                {
                    orosze = true;
                }
                else if (osztály[i].mnyelv == "olasz")
                {
                    olasze = true;
                }
                else if (osztály[i].mnyelv == "spanyol")
                {
                    spanyole = true;
                }
            }
            Console.WriteLine("18) Van-e olyan diák, aki a 2. idegen nyelvként oroszt tanul?");
            Console.WriteLine(orosze ? "Van" : "Nincs");
            FájlbaKiír(orosze.ToString(), "output_18.txt");
            Console.WriteLine();
            Console.WriteLine("19) Van-e olyan diák, aki a 2. idegen nyelvként olaszt tanul?");
            Console.WriteLine(olasze ? "Van" : "Nincs");
            FájlbaKiír(olasze.ToString(), "output_19.txt");
            Console.WriteLine();
            Console.WriteLine("20) Van-e olyan diák, aki a 2. idegen nyelvként spanyolt tanul?");
            Console.WriteLine(spanyole ? "Van" : "Nincs");
            FájlbaKiír(spanyole.ToString(), "output_20.txt");
            Console.WriteLine();
            #endregion
            #region 21) Feladat
            int legnagyobb_család = 0;
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].együttlakók > legnagyobb_család)
                {
                    legnagyobb_család = osztály[i].együttlakók;
                }
            }
            Console.WriteLine("21) Mekkora a legnagyobb család az osztályban?");
            Console.WriteLine(legnagyobb_család);
            FájlbaKiír(legnagyobb_család.ToString(), "output_21.txt");
            Console.WriteLine();
            #endregion
            #region 22) Feladat
            int legtöbb_testvér = 0;
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].testvérszám > legtöbb_testvér)
                {
                    legtöbb_testvér = osztály[i].testvérszám;
                }
            }
            Console.WriteLine("22) Írjuk ki az egyik olyan diák nevét akinek e legtöbb testvére van!");
            Console.WriteLine(legtöbb_testvér);
            FájlbaKiír(legtöbb_testvér.ToString(), "output_22.txt");
            Console.WriteLine();
            #endregion
            #region 23-24) Feladat
            List<string> _1es_2es_lanyok = new List<string>();
            List<string> _3as_4es_0_2_fiuk = new List<string>();
            for (int i = 0; i < osztály.Count; i++)
            {
                if ((osztály[i].angolcsop.Split('.')[0] == "1" || osztály[i].angolcsop.Split('.')[0] == "2") && osztály[i].nem == "L")
                {
                    _1es_2es_lanyok.Add(osztály[i].név);
                }
                else if ((osztály[i].angolcsop.Split('.')[0] == "3" || osztály[i].angolcsop.Split('.')[0] == "4") && osztály[i].nem == "F" && (osztály[i].testvérszám == 0 || osztály[i].testvérszám == 2))
                {
                    _3as_4es_0_2_fiuk.Add(osztály[i].név);
                }
            }
            Console.WriteLine("23) Gyűjtse ki azon lány diákok nevét, akik az egyes vagy kettes angol csoportban vannak!");
            for (int i = 0; i < _1es_2es_lanyok.Count; i++)
            {
                Console.WriteLine(_1es_2es_lanyok[i]);
            }
            FájlbaKiírListát(_1es_2es_lanyok, "output_23.txt");
            Console.WriteLine();
            Console.WriteLine("24) Gyűjtse ki azon fiú diákok nevét, akik a hármas vagy négyes angol csoportban vannak és 0 vagy 2 testvérük van!");
            for (int i = 0; i < _3as_4es_0_2_fiuk.Count; i++)
            {
                Console.WriteLine(_3as_4es_0_2_fiuk[i]);
            }
            FájlbaKiírListát(_3as_4es_0_2_fiuk, "output_24.txt");
            Console.WriteLine();
            #endregion
            #region 25) Feladat
            List<string> nem3akülönbség = new List<string>();
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].együttlakók - osztály[i].testvérszám != 3)
                {
                    nem3akülönbség.Add(osztály[i].név);
                }
            }
            Console.WriteLine("25) Viszonylag kevés azon családok száma, ahol az együttlakók száma és a testvérek száma között nem három a különbség.Adja meg a számukat!");
            for (int i = 0; i < nem3akülönbség.Count; i++)
            {
                Console.WriteLine(nem3akülönbség[i]);
            }
            FájlbaKiírListát(nem3akülönbség, "output_25.txt");
            Console.WriteLine();
            #endregion
            #region 26-30) Feladat
            Console.WriteLine("26) Dári Dóra hiányzott a legutóbbi angol órán, szeretné bepótolni a hiányzást. Adja meg azon tanulók nevét, akik vele azonos angol csoportba járnak.");
            CsoporttársaiNévAlapján("Dári Dóra", osztály, "output_26.txt");            
            Console.WriteLine("27) Avon Mór hiányzott a legutóbbi angol órán, szeretné bepótolni a hiányzást. Adja meg azon tanulók nevét, akik vele azonos angol csoportba járnak. ");
            CsoporttársaiNévAlapján("Avon Mór", osztály, "output_27.txt");
            Console.WriteLine("28) Zúz Mara hiányzott a legutóbbi angol órán, szeretné bepótolni a hiányzást. Adja meg azon tanulók nevét, akik vele azonos angol csoportba járnak. ");
            CsoporttársaiNévAlapján("Zúz Mara", osztály, "output_28.txt");
            Console.WriteLine("29) Citad Ella hiányzott a legutóbbi angol órán, szeretné bepótolni a hiányzást. Adja meg azon tanulók nevét, akik vele azonos angol csoportba járnak. ");
            CsoporttársaiNévAlapján("Citad Ella", osztály, "output_29.txt");
            Console.WriteLine("30) Hát Izsák hiányzott a legutóbbi angol órán, szeretné bepótolni a hiányzást. Adja meg azon tanulók nevét, akik vele azonos angol csoportba járnak.");
            CsoporttársaiNévAlapján("Hát Izsák", osztály, "output_30.txt");
            #endregion
            #region 31) Feladat
            int ssum = 0;
            int nsum = 0;
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].mnyelv == "spanyol")
                {
                    ssum++;
                }
                else if (osztály[i].mnyelv == "német")
                {
                    nsum++;
                }
            }
            Console.WriteLine("31) A spanyol vagy a német nyelvet tanulják-e többben az osztályban?");
            if (ssum > nsum)
            {
                Console.WriteLine("spanyol");
                FájlbaKiír("spanyol", "output_31.txt");
            }
            else if (ssum < nsum)
            {
                Console.WriteLine("német");
                FájlbaKiír("német", "output_31.txt");
            }
            else if (ssum == nsum)
            {
                Console.WriteLine("ugyanannyian");
                FájlbaKiír("ugyanannyian", "output_31.txt");
            }
            Console.WriteLine();
            #endregion
            #region 32) Feladat
            Console.WriteLine("32) Kérjen be a felhasználótól egy nyelvet és írja ki, az adott nyelvet tanulók névsorát!");
            string bekértnyelv = Console.ReadLine();
            List<string> bekértnyelvettanulók_nevei = new List<string>();
            for (int i = 0; i < osztály.Count; i++)
            {
                if (osztály[i].mnyelv == bekértnyelv)
                {
                    bekértnyelvettanulók_nevei.Add(osztály[i].név);
                }
            }
            for (int i = 0; i < bekértnyelvettanulók_nevei.Count; i++)
            {
                Console.WriteLine(bekértnyelvettanulók_nevei[i]);
            }
            FájlbaKiírListát(bekértnyelvettanulók_nevei, "output_32.txt");
            #endregion
            #endregion
        }
    }
}
