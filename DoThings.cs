using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tombala
{
    class DoThings
    {
        public static List<Oyuncu> oyuncu = new List<Oyuncu>();
        public static List<int> KartNo = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

        public static int[,,] Kartlar = new int[15, 3, 5]
        { 
        { { 3, 20, 43, 60, 71 }, { 13, 33, 55, 79, 81 }, { 7, 25, 49, 68, 88 } },//Kart1
        { { 5, 22, 46, 62, 72 }, { 15, 34, 56, 76, 86 }, { 7, 26, 48, 63, 89 } },//Kart2
        { { 7, 23, 44, 61, 73 }, { 16, 37, 54, 79, 83 }, { 9, 24, 46, 67, 90 } },//Kart3
        { { 2, 10, 36, 50, 71 }, { 15, 21, 40, 60, 83 }, { 8, 26, 39, 56, 74 } },//Kart4
        { { 6, 13, 33, 52, 72 }, { 18, 22, 46, 65, 85 }, { 8, 29, 37, 57, 76 } },//Kart5
        { { 1, 21, 42, 66, 70 }, { 17, 38, 55, 75, 81 }, { 6, 25, 44, 67, 83 } },//Kart6
        { { 7, 12, 34, 54, 70 }, { 19, 24, 44, 66, 84 }, { 9, 26, 35, 59, 73 } },//Kart7
        { { 3, 12, 30, 53, 70 }, { 16, 21, 41, 61, 87 }, { 9, 24, 35, 57, 73 } },//Kart8
        { { 2, 20, 43, 60, 74 }, { 12, 32, 53, 79, 80 }, { 5, 23, 49, 69, 84 } },//Kart9
        { { 1, 20, 40, 64, 76 }, { 10, 30, 56, 79, 87 }, { 2, 23, 46, 68, 88 } },//Kart10
        { { 1, 24, 43, 62, 70 }, { 14, 33, 54, 75, 81 }, { 4, 29, 45, 69, 85 } },//Kart11
        { { 1, 11, 31, 51, 75 }, { 18, 20, 43, 63, 88 }, { 7, 28, 39, 55, 78 } },//Kart12
        { { 1, 21, 45, 62, 70 }, { 17, 39, 50, 73, 81 }, { 4, 28, 48, 65, 90 } },//Kart13
        { { 6, 11, 35, 50, 72 }, { 15, 27, 44, 63, 82 }, { 8, 28, 37, 59, 77 } },//Kart14
        { { 3, 22, 42, 61, 72 }, { 13, 31, 52, 79, 83 }, { 6, 27, 47, 65, 90 } },//Kart15
        };

        public static int[] Torba = new int[90];
        public static int maxOyuncu = 0;
        public static int sayac = 0;
        public static int torbaSayac = 0;
        public int torbaSayi;

        public string surum = "1.2";

        public static bool genelBirKontrol = false;
        public static bool genelIkiKontrol = false;
        public static bool genelTombalaKontrol = false;
        public static bool duyuru = false;

        Random rnd = new Random();
        public void oyuncuOlustur(string name, int kartno)
        {
            maxOyuncu++;
            oyuncu.Add(new Oyuncu() {oyuncuNo= maxOyuncu ,isim = name, kartNo = kartno, tombalaCount=0, cinkoBirCount=0, cinkoIkiCount=0, totalPoint=0});
        }

        public void kartOlustur()
        {
           Kartlar = new int[15, 3, 5]
        {
        { { 3, 20, 43, 60, 71 }, { 13, 33, 55, 79, 81 }, { 7, 25, 49, 68, 88 } },//Kart1
        { { 5, 22, 46, 62, 72 }, { 15, 34, 56, 76, 86 }, { 7, 26, 48, 63, 89 } },//Kart2
        { { 7, 23, 44, 61, 73 }, { 16, 37, 54, 79, 83 }, { 9, 24, 46, 67, 90 } },//Kart3
        { { 2, 10, 36, 50, 71 }, { 15, 21, 40, 60, 83 }, { 8, 26, 39, 56, 74 } },//Kart4
        { { 6, 13, 33, 52, 72 }, { 18, 22, 46, 65, 85 }, { 8, 29, 37, 57, 76 } },//Kart5
        { { 1, 21, 42, 66, 70 }, { 17, 38, 55, 75, 81 }, { 6, 25, 44, 67, 83 } },//Kart6
        { { 7, 12, 34, 54, 70 }, { 19, 24, 44, 66, 84 }, { 9, 26, 35, 59, 73 } },//Kart7
        { { 3, 12, 30, 53, 70 }, { 16, 21, 41, 61, 87 }, { 9, 24, 35, 57, 73 } },//Kart8
        { { 2, 20, 43, 60, 74 }, { 12, 32, 53, 79, 80 }, { 5, 23, 49, 69, 84 } },//Kart9
        { { 1, 20, 40, 64, 76 }, { 10, 30, 56, 79, 87 }, { 2, 23, 46, 68, 88 } },//Kart10
        { { 1, 24, 43, 62, 70 }, { 14, 33, 54, 75, 81 }, { 4, 29, 45, 69, 85 } },//Kart11
        { { 1, 11, 31, 51, 75 }, { 18, 20, 43, 63, 88 }, { 7, 28, 39, 55, 78 } },//Kart12
        { { 1, 21, 45, 62, 70 }, { 17, 39, 50, 73, 81 }, { 4, 28, 48, 65, 90 } },//Kart13
        { { 6, 11, 35, 50, 72 }, { 15, 27, 44, 63, 82 }, { 8, 28, 37, 59, 77 } },//Kart14
        { { 3, 22, 42, 61, 72 }, { 13, 31, 52, 79, 83 }, { 6, 27, 47, 65, 90 } },//Kart15
        };
        }

        public void oyuncuİlkCinkoKazandi(int oyuncuno)
        {
            for(int i=0;i<maxOyuncu;i++)
            {
                if (oyuncu[i].oyuncuNo == oyuncuno)
                {
                    oyuncu[i].cinkoBirCount++;
                    oyuncu[i].totalPoint++;
                }
            }
        }
        public void oyuncuİkinciCinkoKazandi(int oyuncuno)
        {
            for (int i = 0; i < maxOyuncu; i++)
            {
                if (oyuncu[i].oyuncuNo == oyuncuno)
                {
                    oyuncu[i].cinkoIkiCount++;
                    oyuncu[i].totalPoint+=2;
                }
            }
        }

        public void oyuncuTombalaKazandi(int oyuncuno)
        {
            for (int i = 0; i < maxOyuncu; i++)
            {
                if (oyuncu[i].oyuncuNo == oyuncuno)
                {
                    oyuncu[i].tombalaCount++;
                    oyuncu[i].totalPoint+=5;
                }
            }
        }

        public void kartDegistir(int oyuncuno,int kartno)
        {
            for (int i = 0; i < maxOyuncu; i++)
            {
                if (oyuncu[i].oyuncuNo == oyuncuno)
                {
                    oyuncu[i].kartNo = kartno;
                }
            }
        }

        public void torbadanCek()
        {
            while(true)
            {
                torbaSayi = rnd.Next(1, 91);
                if (!Torba.Contains(torbaSayi))
                {
                    Torba[torbaSayac] = torbaSayi;
                    torbaSayac++;
                    break;
                }
            }
        }

        public void torbaTemizle()
        {
            Array.Clear(Torba, 0, Torba.Length);
        }

        public void sayiEsle()
        {
            for(int i=0;i<maxOyuncu;i++)
            {
                for(int j=0;j<15;j++)
                {
                    if(j==oyuncu[i].kartNo-1)
                    {
                        for(int s1=0;s1<3;s1++)
                        {
                            for(int s2=0;s2<5;s2++)
                            {
                                if (Kartlar[j, s1, s2] == Torba[torbaSayac-1])
                                {
                                    Kartlar[j, s1, s2] = 0;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void cinkoKontrol()
        {
            int sifirsayac = 0;
            int ikincisayac = 0;
            if(genelBirKontrol==false)
            {
                for (int i = 0; i < maxOyuncu; i++)
                {
                    for (int j = 0; j < 15; j++)
                    {
                        if (j == oyuncu[i].kartNo-1)
                        {
                            for (int s1 = 0; s1 < 3; s1++)
                            {
                                sifirsayac = 0;
                                for (int s2 = 0; s2 < 5; s2++)
                                {
                                    if (Kartlar[j, s1, s2] == 0)
                                    {
                                        sifirsayac++;
                                        if (sifirsayac == 5 && oyuncu[i].cinkoBirKontrol != true)
                                        {
                                            oyuncuİlkCinkoKazandi(oyuncu[i].oyuncuNo);
                                            oyuncu[i].cinkoBirKontrol = true;
                                            genelBirKontrol = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if(genelIkiKontrol==false)
            {
                for (int i = 0; i < maxOyuncu; i++)
                {
                    ikincisayac = 0;
                    for (int j = 0; j < 15; j++)
                    {
                        if (j == oyuncu[i].kartNo-1)
                        {
                            for (int s1 = 0; s1 < 3; s1++)
                            {
                                sifirsayac = 0;
                                for (int s2 = 0; s2 < 5; s2++)
                                {
                                    if (Kartlar[j, s1, s2] == 0)
                                    {
                                        sifirsayac++;
                                        if(sifirsayac==5)
                                        {
                                            ikincisayac++;
                                        }
                                        if (ikincisayac == 2 && oyuncu[i].cinkoIkiKontrol != true)
                                        {
                                            oyuncuİkinciCinkoKazandi(oyuncu[i].oyuncuNo);
                                            oyuncu[i].cinkoIkiKontrol = true;
                                            genelIkiKontrol = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if(genelTombalaKontrol==false)
            {
                for (int i = 0; i < maxOyuncu; i++)
                {
                    sifirsayac = 0;
                    for (int j = 0; j < 15; j++)
                    {
                        if (j == oyuncu[i].kartNo-1)
                        {
                            for (int s1 = 0; s1 < 3; s1++)
                            {
                                
                                for (int s2 = 0; s2 < 5; s2++)
                                {
                                    if (Kartlar[j, s1, s2] == 0)
                                    {
                                        sifirsayac++;
                                        if (sifirsayac == 15 && oyuncu[i].tombalaKontrol != true)
                                        {
                                            oyuncuTombalaKazandi(oyuncu[i].oyuncuNo);
                                            oyuncu[i].tombalaKontrol = true;
                                            genelTombalaKontrol = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void turSonu()
        {
            for(int i=0;i<maxOyuncu;i++)
            {
                oyuncu[i].cinkoBirKontrol = false;
                oyuncu[i].cinkoIkiKontrol = false;
                oyuncu[i].tombalaKontrol = false;
            }
            kartOlustur();
            genelBirKontrol = false;
            genelIkiKontrol = false;
            genelTombalaKontrol = false;
        }
        public void yenidenBaslat()
        {
            turSonu();
            maxOyuncu = 0;
            sayac = 0;
            oyuncu.Clear();
            KartNo.Clear();
            torbaSayac = 0;
            for(int i=1;i<=15;i++)
            {
                KartNo.Add(i);
            }
        }
    }
}