using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dothings = Tombala.DoThings;

namespace Tombala
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InternetKontrol();       
        }

        DoThings dothings = new DoThings();
        private void InternetKontrol()
        {
            try
            {
                System.Net.Sockets.TcpClient kontrol_client = new System.Net.Sockets.TcpClient("www.google.com.tr", 80);
                kontrol_client.Close();
                guncellemeleriDenetleToolStripMenuItem.Enabled = true;
            }
            catch (Exception e)
            {
                guncellemeleriDenetleToolStripMenuItem.Enabled = true;
            }
        }

        //Ana menü
        private void ayarlaButton_Click(object sender, EventArgs e)
        {
            if(dothings.sayac==0)
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Ayarlamayı zaten yaptınız.");
            }
        }
        private void baslaButton_Click(object sender, EventArgs e)
        {
            if(dothings.sayac!=0)
            {
                ayarlaButton.Visible = false;
                baslaButton.Visible = false;

                skorListView.Columns.Add("Oyuncu No", 85);
                skorListView.Columns.Add("Oyuncu Adı", 95);
                skorListView.Columns.Add("1.Çinko", 65);
                skorListView.Columns.Add("2.Çinko", 65);
                skorListView.Columns.Add("Tombala", 80);
                skorListView.Columns.Add("Toplam Puan", 95);

                string[] satirlar;
                string[] hepsi = new string[dothings.maxOyuncu];
                for(int i=0;i<dothings.maxOyuncu;i++)
                {
                    hepsi[i] = dothings.oyuncu[i].oyuncuNo + " " + dothings.oyuncu[i].isim + " " + dothings.oyuncu[i].cinkoBirCount + " " + dothings.oyuncu[i].cinkoIkiCount + " " + dothings.oyuncu[i].tombalaCount + " " + dothings.oyuncu[i].totalPoint;
                    satirlar = hepsi[i].Split('\n');
                    foreach (string s in satirlar)
                    {
                        string[] kelimeler = s.Split(' ');
                        var listView1Item = new ListViewItem(kelimeler);
                        skorListView.Items.Add(listView1Item);
                    }
                }

                skorListView.Visible = true;
                torbaRichTextBox.Visible = true;
                cekButton.Visible = true;
                sonLabel.Visible = true;
                sonTextBox.Visible = true;
                torbaLabel.Visible = true;
                torbaRichTextBox.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                skorLabel.Visible = true;
                kartlariAc();
                duyuruButton.Visible = true;
                duyuruLabel.Visible = true;
                if (dothings.duyuru == true)
                {
                    duyuruLabel.Text = "Sayı duyuruları açık";
                }
                else
                {
                    duyuruLabel.Text = "Sayı duyuruları kapalı";
                }
            }
            else
            {
                MessageBox.Show("Başlamadan önce oyunu ayarlayınız.");
            }
        }

        //Oyun toolstrip

        private void yeniOyunBaslatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dothings.yenidenBaslat();
            ayarlaButton.Visible = true;
            baslaButton.Visible = true;
            skorListView.Visible = false;
            cekButton.Visible = false;
            sonLabel.Visible = false;
            sonTextBox.Visible = false;
            torbaLabel.Visible = false;
            torbaRichTextBox.Visible = false;
            torbaRichTextBox.Text = "";
            cekButton.Enabled = true;
            sonTextBox.Text = "0";
            listeYenile();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            skorLabel.Visible = false;
            dothings.kartOlustur();
            torbaRichTextBox.Text = "";
            sonTextBox.Text = "0";
            dothings.torbaSayac = 0;
            cekButton.Enabled = true;
            label1.Text = "1. Çinko Yapanlar :";
            label2.Text = "2. Çinko Yapanlar :";
            label3.Text = "Tombala Yapanlar :";
            dothings.torbaTemizle();
            yeniTurButton.Visible = false;
            kartDegisButton.Visible = false;
            kartlariKapat();
            duyuruButton.Visible = false;
            duyuruLabel.Visible = false;
        }

        //Yardım toolstrip
        private void hakkindaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }
        private void guncellemeleriDenetleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update update = new Update();
            update.Show();
        }
        private void geriBildirimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://chareless.github.io/saribayirdeniz/#contact");
        }
        private void versionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://chareless.github.io/saribayirdeniz/etombala.html#version");
        }


        //Oyun içerik

        private void cekButton_Click(object sender, EventArgs e)
        {
            dothings.torbadanCek();
            sonTextBox.Text =dothings.Torba[dothings.torbaSayac-1].ToString();
            torbaRichTextBox.Text = "";
            foreach(int dizi in dothings.Torba)
            {
                if(dizi!=0)
                {
                    torbaRichTextBox.Text += dizi + " - ";
                }
                
            }

            dothings.sayiEsle();
            dothings.cinkoKontrol();
            listeYenile();
            duyuru();
            kartıKontrolEt();

            for (int i = 0; i < dothings.maxOyuncu; i++)
            {
                if (dothings.oyuncu[i].tombalaKontrol == true)
                {
                    cekButton.Enabled = false;
                    MessageBox.Show("TOMBALA!!");
                    MessageBox.Show(label3.Text);
                    dothings.turSonu();
                    kartDegisButton.Visible = true;
                    yeniTurButton.Visible = true;
                }
            }

            if (dothings.torbaSayac==90)
            {
                cekButton.Enabled = false;
                MessageBox.Show("Torba Bitti");
                dothings.turSonu();
                kartDegisButton.Visible = true;
                yeniTurButton.Visible = true;
            }
        }

        private void duyuru()
        {
            label1.Text = "1. Çinko Yapanlar : ";
            for (int i = 0; i < dothings.maxOyuncu; i++)
            {
                if (dothings.oyuncu[i].cinkoBirKontrol == true)
                {
                    label1.Text += dothings.oyuncu[i].isim + " ";
                }
            }
            label2.Text = "2. Çinko Yapanlar : ";
            for (int i = 0; i < dothings.maxOyuncu; i++)
            {
                if (dothings.oyuncu[i].cinkoIkiKontrol == true)
                {
                    label2.Text += dothings.oyuncu[i].isim + " ";
                }
            }
            label3.Text = "Tombala Yapanlar : ";
            for (int i = 0; i < dothings.maxOyuncu; i++)
            {
                if (dothings.oyuncu[i].tombalaKontrol == true)
                {
                    label3.Text += dothings.oyuncu[i].isim + " ";
                }
            }
        }

        private void listeYenile()
        {
            skorListView.Clear();
            skorListView.Columns.Add("Oyuncu No", 85);
            skorListView.Columns.Add("Oyuncu Adı", 95);
            skorListView.Columns.Add("1.Çinko", 65);
            skorListView.Columns.Add("2.Çinko", 65);
            skorListView.Columns.Add("Tombala", 80);
            skorListView.Columns.Add("Toplam Puan", 95);
            string[] satirlar;
            string[] hepsi = new string[dothings.maxOyuncu];
            for (int i = 0; i < dothings.maxOyuncu; i++)
            {
                hepsi[i] = dothings.oyuncu[i].oyuncuNo + " " + dothings.oyuncu[i].isim + " " + dothings.oyuncu[i].cinkoBirCount + " " + dothings.oyuncu[i].cinkoIkiCount + " " + dothings.oyuncu[i].tombalaCount + " " + dothings.oyuncu[i].totalPoint;
                satirlar = hepsi[i].Split('\n');
                foreach (string s in satirlar)
                {
                    string[] kelimeler = s.Split(' ');
                    var listView1Item = new ListViewItem(kelimeler);
                    skorListView.Items.Add(listView1Item);
                }
            }
        }

        private void yeniTurButton_Click(object sender, EventArgs e)
        {
            kartDegisButton.Visible = false;
            yeniTurButton.Visible = false;
            listeYenile();
            dothings.kartOlustur();
            torbaRichTextBox.Text = "";
            sonTextBox.Text = "0";
            dothings.torbaSayac = 0;
            cekButton.Enabled = true;
            label1.Text = "1. Çinko Yapanlar :";
            label2.Text = "2. Çinko Yapanlar :";
            label3.Text = "Tombala Yapanlar :";
            dothings.torbaTemizle();
            kartlariAc();
        }

        private void kartDegisButton_Click(object sender, EventArgs e)
        {
            CardChange Changer = new CardChange();
            Changer.Show();
        }

        private void kartlariAc()
        {
            if(dothings.maxOyuncu==2)
            {
                oyuncuAc1();
                oyuncuAc2();
            }
            else if(dothings.maxOyuncu==3)
            {
                oyuncuAc1();
                oyuncuAc2();
                oyuncuAc3();
            }
            else if (dothings.maxOyuncu == 4)
            {
                oyuncuAc1();
                oyuncuAc2();
                oyuncuAc3();
                oyuncuAc4();
            }
            else if (dothings.maxOyuncu == 5)
            {
                oyuncuAc1();
                oyuncuAc2();
                oyuncuAc3();
                oyuncuAc4();
                oyuncuAc5();
            }
            else if (dothings.maxOyuncu == 6)
            {
                oyuncuAc1();
                oyuncuAc2();
                oyuncuAc3();
                oyuncuAc4();
                oyuncuAc5();
                oyuncuAc6();
            }
            else if (dothings.maxOyuncu == 7)
            {
                oyuncuAc1();
                oyuncuAc2();
                oyuncuAc3();
                oyuncuAc4();
                oyuncuAc5();
                oyuncuAc6();
                oyuncuAc7();
            }
            else if (dothings.maxOyuncu == 8)
            {
                oyuncuAc1();
                oyuncuAc2();
                oyuncuAc3();
                oyuncuAc4();
                oyuncuAc5();
                oyuncuAc6();
                oyuncuAc7();
                oyuncuAc8();
            }
            else if (dothings.maxOyuncu == 9)
            {
                oyuncuAc1();
                oyuncuAc2();
                oyuncuAc3();
                oyuncuAc4();
                oyuncuAc5();
                oyuncuAc6();
                oyuncuAc7();
                oyuncuAc8();
                oyuncuAc9();
            }
            else if (dothings.maxOyuncu == 10)
            {
                oyuncuAc1();
                oyuncuAc2();
                oyuncuAc3();
                oyuncuAc4();
                oyuncuAc5();
                oyuncuAc6();
                oyuncuAc7();
                oyuncuAc8();
                oyuncuAc9();
                oyuncuAc10();
            }
        }

        private void kartlariKapat()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel6.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            oyuncuLabel1.Visible = false;
            oyuncuLabel2.Visible = false;
            oyuncuLabel3.Visible = false;
            oyuncuLabel4.Visible = false;
            oyuncuLabel5.Visible = false;
            oyuncuLabel6.Visible = false;
            oyuncuLabel7.Visible = false;
            oyuncuLabel8.Visible = false;
            oyuncuLabel9.Visible = false;
            oyuncuLabel10.Visible = false;
            oyuncuLabel1.Text = "oyuncuLabel1";
            oyuncuLabel2.Text = "oyuncuLabel2";
            oyuncuLabel3.Text = "oyuncuLabel3";
            oyuncuLabel4.Text = "oyuncuLabel4";
            oyuncuLabel5.Text = "oyuncuLabel5";
            oyuncuLabel6.Text = "oyuncuLabel6";
            oyuncuLabel7.Text = "oyuncuLabel7";
            oyuncuLabel8.Text = "oyuncuLabel8";
            oyuncuLabel9.Text = "oyuncuLabel9";
            oyuncuLabel10.Text = "oyuncuLabel10";
            button111.Visible = false;
            button112.Visible = false;
            button113.Visible = false;
            button114.Visible = false;
            button115.Visible = false;
            button121.Visible = false;
            button122.Visible = false;
            button123.Visible = false;
            button124.Visible = false;
            button125.Visible = false;
            button131.Visible = false;
            button132.Visible = false;
            button133.Visible = false;
            button134.Visible = false;
            button135.Visible = false;
            button211.Visible = false;
            button212.Visible = false;
            button213.Visible = false;
            button214.Visible = false;
            button215.Visible = false;
            button221.Visible = false;
            button222.Visible = false;
            button223.Visible = false;
            button224.Visible = false;
            button225.Visible = false;
            button231.Visible = false;
            button232.Visible = false;
            button233.Visible = false;
            button234.Visible = false;
            button235.Visible = false;
            button311.Visible = false;
            button312.Visible = false;
            button313.Visible = false;
            button314.Visible = false;
            button315.Visible = false;
            button321.Visible = false;
            button322.Visible = false;
            button323.Visible = false;
            button324.Visible = false;
            button325.Visible = false;
            button331.Visible = false;
            button332.Visible = false;
            button333.Visible = false;
            button334.Visible = false;
            button335.Visible = false;
            button411.Visible = false;
            button412.Visible = false;
            button413.Visible = false;
            button414.Visible = false;
            button415.Visible = false;
            button421.Visible = false;
            button422.Visible = false;
            button423.Visible = false;
            button424.Visible = false;
            button425.Visible = false;
            button431.Visible = false;
            button432.Visible = false;
            button433.Visible = false;
            button434.Visible = false;
            button435.Visible = false;
            button511.Visible = false;
            button512.Visible = false;
            button513.Visible = false;
            button514.Visible = false;
            button515.Visible = false;
            button521.Visible = false;
            button522.Visible = false;
            button523.Visible = false;
            button524.Visible = false;
            button525.Visible = false;
            button531.Visible = false;
            button532.Visible = false;
            button533.Visible = false;
            button534.Visible = false;
            button535.Visible = false;
            button611.Visible = false;
            button612.Visible = false;
            button613.Visible = false;
            button614.Visible = false;
            button615.Visible = false;
            button621.Visible = false;
            button622.Visible = false;
            button623.Visible = false;
            button624.Visible = false;
            button625.Visible = false;
            button631.Visible = false;
            button632.Visible = false;
            button633.Visible = false;
            button634.Visible = false;
            button635.Visible = false;
            button711.Visible = false;
            button712.Visible = false;
            button713.Visible = false;
            button714.Visible = false;
            button715.Visible = false;
            button721.Visible = false;
            button722.Visible = false;
            button723.Visible = false;
            button724.Visible = false;
            button725.Visible = false;
            button731.Visible = false;
            button732.Visible = false;
            button733.Visible = false;
            button734.Visible = false;
            button735.Visible = false;
            button811.Visible = false;
            button812.Visible = false;
            button813.Visible = false;
            button814.Visible = false;
            button815.Visible = false;
            button821.Visible = false;
            button822.Visible = false;
            button823.Visible = false;
            button824.Visible = false;
            button825.Visible = false;
            button831.Visible = false;
            button832.Visible = false;
            button833.Visible = false;
            button834.Visible = false;
            button835.Visible = false;
            button911.Visible = false;
            button912.Visible = false;
            button913.Visible = false;
            button914.Visible = false;
            button915.Visible = false;
            button921.Visible = false;
            button922.Visible = false;
            button923.Visible = false;
            button924.Visible = false;
            button925.Visible = false;
            button931.Visible = false;
            button932.Visible = false;
            button933.Visible = false;
            button934.Visible = false;
            button935.Visible = false;
            button1011.Visible = false;
            button1012.Visible = false;
            button1013.Visible = false;
            button1014.Visible = false;
            button1015.Visible = false;
            button1021.Visible = false;
            button1022.Visible = false;
            button1023.Visible = false;
            button1024.Visible = false;
            button1025.Visible = false;
            button1031.Visible = false;
            button1032.Visible = false;
            button1033.Visible = false;
            button1034.Visible = false;
            button1035.Visible = false;
            button111.Text = "";
            button112.Text = "";
            button113.Text = "";
            button114.Text = "";
            button115.Text = "";
            button121.Text = "";
            button122.Text = "";
            button123.Text = "";
            button124.Text = "";
            button125.Text = "";
            button131.Text = "";
            button132.Text = "";
            button133.Text = "";
            button134.Text = "";
            button135.Text = "";
            button211.Text = "";
            button212.Text = "";
            button213.Text = "";
            button214.Text = "";
            button215.Text = "";
            button221.Text = "";
            button222.Text = "";
            button223.Text = "";
            button224.Text = "";
            button225.Text = "";
            button231.Text = "";
            button232.Text = "";
            button233.Text = "";
            button234.Text = "";
            button235.Text = "";
            button311.Text = "";
            button312.Text = "";
            button313.Text = "";
            button314.Text = "";
            button315.Text = "";
            button321.Text = "";
            button322.Text = "";
            button323.Text = "";
            button324.Text = "";
            button325.Text = "";
            button331.Text = "";
            button332.Text = "";
            button333.Text = "";
            button334.Text = "";
            button335.Text = "";
            button411.Text = "";
            button412.Text = "";
            button413.Text = "";
            button414.Text = "";
            button415.Text = "";
            button421.Text = "";
            button422.Text = "";
            button423.Text = "";
            button424.Text = "";
            button425.Text = "";
            button431.Text = "";
            button432.Text = "";
            button433.Text = "";
            button434.Text = "";
            button435.Text = "";
            button511.Text = "";
            button512.Text = "";
            button513.Text = "";
            button514.Text = "";
            button515.Text = "";
            button521.Text = "";
            button522.Text = "";
            button523.Text = "";
            button524.Text = "";
            button525.Text = "";
            button531.Text = "";
            button532.Text = "";
            button533.Text = "";
            button534.Text = "";
            button535.Text = "";
            button611.Text = "";
            button612.Text = "";
            button613.Text = "";
            button614.Text = "";
            button615.Text = "";
            button621.Text = "";
            button622.Text = "";
            button623.Text = "";
            button624.Text = "";
            button625.Text = "";
            button631.Text = "";
            button632.Text = "";
            button633.Text = "";
            button634.Text = "";
            button635.Text = "";
            button711.Text = "";
            button712.Text = "";
            button713.Text = "";
            button714.Text = "";
            button715.Text = "";
            button721.Text = "";
            button722.Text = "";
            button723.Text = "";
            button724.Text = "";
            button725.Text = "";
            button731.Text = "";
            button732.Text = "";
            button733.Text = "";
            button734.Text = "";
            button735.Text = "";
            button811.Text = "";
            button812.Text = "";
            button813.Text = "";
            button814.Text = "";
            button815.Text = "";
            button821.Text = "";
            button822.Text = "";
            button823.Text = "";
            button824.Text = "";
            button825.Text = "";
            button831.Text = "";
            button832.Text = "";
            button833.Text = "";
            button834.Text = "";
            button835.Text = "";
            button911.Text = "";
            button912.Text = "";
            button913.Text = "";
            button914.Text = "";
            button915.Text = "";
            button921.Text = "";
            button922.Text = "";
            button923.Text = "";
            button924.Text = "";
            button925.Text = "";
            button931.Text = "";
            button932.Text = "";
            button933.Text = "";
            button934.Text = "";
            button935.Text = "";
            button1011.Text = "";
            button1012.Text = "";
            button1013.Text = "";
            button1014.Text = "";
            button1015.Text = "";
            button1021.Text = "";
            button1022.Text = "";
            button1023.Text = "";
            button1024.Text = "";
            button1025.Text = "";
            button1031.Text = "";
            button1032.Text = "";
            button1033.Text = "";
            button1034.Text = "";
            button1035.Text = "";

        }

        private void oyuncuAc1()
        {
            button111.Visible = true;
            button112.Visible = true;
            button113.Visible = true;
            button114.Visible = true;
            button115.Visible = true;
            button121.Visible = true;
            button122.Visible = true;
            button123.Visible = true;
            button124.Visible = true;
            button125.Visible = true;
            button131.Visible = true;
            button132.Visible = true;
            button133.Visible = true;
            button134.Visible = true;
            button135.Visible = true;
            panel1.Visible = true;
            oyuncuLabel1.Visible = true;
            oyuncuLabel1.Text = dothings.oyuncu[0].oyuncuNo + ". oyuncu : " + dothings.oyuncu[0].isim + " (Kart " + dothings.oyuncu[0].kartNo + ")";
            button111.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 0, 0].ToString();
            button112.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 0, 1].ToString();
            button113.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 0, 2].ToString();
            button114.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 0, 3].ToString();
            button115.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 0, 4].ToString();
            button121.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 1, 0].ToString();
            button122.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 1, 1].ToString();
            button123.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 1, 2].ToString();
            button124.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 1, 3].ToString();
            button125.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 1, 4].ToString();
            button131.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 2, 0].ToString();
            button132.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 2, 1].ToString();
            button133.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 2, 2].ToString();
            button134.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 2, 3].ToString();
            button135.Text = dothings.Kartlar[dothings.oyuncu[0].kartNo-1, 2, 4].ToString();
        }
        private void oyuncuAc2()
        {
            button211.Visible = true;
            button212.Visible = true;
            button213.Visible = true;
            button214.Visible = true;
            button215.Visible = true;
            button221.Visible = true;
            button222.Visible = true;
            button223.Visible = true;
            button224.Visible = true;
            button225.Visible = true;
            button231.Visible = true;
            button232.Visible = true;
            button233.Visible = true;
            button234.Visible = true;
            button235.Visible = true;
            panel2.Visible = true;
            oyuncuLabel2.Visible = true;
            oyuncuLabel2.Text = dothings.oyuncu[1].oyuncuNo + ". oyuncu : " + dothings.oyuncu[1].isim + " (Kart " + dothings.oyuncu[1].kartNo + ")";
            button211.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 0, 0].ToString();
            button212.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 0, 1].ToString();
            button213.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 0, 2].ToString();
            button214.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 0, 3].ToString();
            button215.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 0, 4].ToString();
            button221.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 1, 0].ToString();
            button222.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 1, 1].ToString();
            button223.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 1, 2].ToString();
            button224.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 1, 3].ToString();
            button225.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 1, 4].ToString();
            button231.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 2, 0].ToString();
            button232.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 2, 1].ToString();
            button233.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 2, 2].ToString();
            button234.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 2, 3].ToString();
            button235.Text = dothings.Kartlar[dothings.oyuncu[1].kartNo-1, 2, 4].ToString();
        }
        private void oyuncuAc3()
        {
            button311.Visible = true;
            button312.Visible = true;
            button313.Visible = true;
            button314.Visible = true;
            button315.Visible = true;
            button321.Visible = true;
            button322.Visible = true;
            button323.Visible = true;
            button324.Visible = true;
            button325.Visible = true;
            button331.Visible = true;
            button332.Visible = true;
            button333.Visible = true;
            button334.Visible = true;
            button335.Visible = true;
            panel3.Visible = true;
            oyuncuLabel3.Visible = true;
            oyuncuLabel3.Text = dothings.oyuncu[2].oyuncuNo + ". oyuncu : " + dothings.oyuncu[2].isim + " (Kart " + dothings.oyuncu[2].kartNo + ")";
            button311.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 0, 0].ToString();
            button312.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 0, 1].ToString();
            button313.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 0, 2].ToString();
            button314.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 0, 3].ToString();
            button315.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 0, 4].ToString();
            button321.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 1, 0].ToString();
            button322.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 1, 1].ToString();
            button323.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 1, 2].ToString();
            button324.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 1, 3].ToString();
            button325.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 1, 4].ToString();
            button331.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 2, 0].ToString();
            button332.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 2, 1].ToString();
            button333.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 2, 2].ToString();
            button334.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 2, 3].ToString();
            button335.Text = dothings.Kartlar[dothings.oyuncu[2].kartNo-1, 2, 4].ToString();
        }
        private void oyuncuAc4()
        {
            button411.Visible = true;
            button412.Visible = true;
            button413.Visible = true;
            button414.Visible = true;
            button415.Visible = true;
            button421.Visible = true;
            button422.Visible = true;
            button423.Visible = true;
            button424.Visible = true;
            button425.Visible = true;
            button431.Visible = true;
            button432.Visible = true;
            button433.Visible = true;
            button434.Visible = true;
            button435.Visible = true;
            panel4.Visible = true;
            oyuncuLabel4.Visible = true;
            oyuncuLabel4.Text = dothings.oyuncu[3].oyuncuNo + ". oyuncu : " + dothings.oyuncu[3].isim + " (Kart " + dothings.oyuncu[3].kartNo + ")";
            button411.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 0, 0].ToString();
            button412.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 0, 1].ToString();
            button413.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 0, 2].ToString();
            button414.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 0, 3].ToString();
            button415.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 0, 4].ToString();
            button421.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 1, 0].ToString();
            button422.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 1, 1].ToString();
            button423.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 1, 2].ToString();
            button424.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 1, 3].ToString();
            button425.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 1, 4].ToString();
            button431.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 2, 0].ToString();
            button432.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 2, 1].ToString();
            button433.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 2, 2].ToString();
            button434.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 2, 3].ToString();
            button435.Text = dothings.Kartlar[dothings.oyuncu[3].kartNo-1, 2, 4].ToString();
        }
        private void oyuncuAc5()
        {
            button511.Visible = true;
            button512.Visible = true;
            button513.Visible = true;
            button514.Visible = true;
            button515.Visible = true;
            button521.Visible = true;
            button522.Visible = true;
            button523.Visible = true;
            button524.Visible = true;
            button525.Visible = true;
            button531.Visible = true;
            button532.Visible = true;
            button533.Visible = true;
            button534.Visible = true;
            button535.Visible = true;
            panel5.Visible = true;
            oyuncuLabel5.Visible = true;
            oyuncuLabel5.Text = dothings.oyuncu[4].oyuncuNo + ". oyuncu : " + dothings.oyuncu[4].isim + " (Kart " + dothings.oyuncu[4].kartNo + ")";
            button511.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 0, 0].ToString();
            button512.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 0, 1].ToString();
            button513.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 0, 2].ToString();
            button514.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 0, 3].ToString();
            button515.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 0, 4].ToString();
            button521.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 1, 0].ToString();
            button522.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 1, 1].ToString();
            button523.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 1, 2].ToString();
            button524.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 1, 3].ToString();
            button525.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 1, 4].ToString();
            button531.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 2, 0].ToString();
            button532.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 2, 1].ToString();
            button533.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 2, 2].ToString();
            button534.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 2, 3].ToString();
            button535.Text = dothings.Kartlar[dothings.oyuncu[4].kartNo-1, 2, 4].ToString();
        }
        private void oyuncuAc6()
        {
            button611.Visible = true;
            button612.Visible = true;
            button613.Visible = true;
            button614.Visible = true;
            button615.Visible = true;
            button621.Visible = true;
            button622.Visible = true;
            button623.Visible = true;
            button624.Visible = true;
            button625.Visible = true;
            button631.Visible = true;
            button632.Visible = true;
            button633.Visible = true;
            button634.Visible = true;
            button635.Visible = true;
            panel6.Visible = true;
            oyuncuLabel6.Visible = true;
            oyuncuLabel6.Text = dothings.oyuncu[5].oyuncuNo + ". oyuncu : " + dothings.oyuncu[5].isim + " (Kart " + dothings.oyuncu[5].kartNo + ")";
            button611.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 0, 0].ToString();
            button612.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 0, 1].ToString();
            button613.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 0, 2].ToString();
            button614.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 0, 3].ToString();
            button615.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 0, 4].ToString();
            button621.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 1, 0].ToString();
            button622.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 1, 1].ToString();
            button623.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 1, 2].ToString();
            button624.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 1, 3].ToString();
            button625.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 1, 4].ToString();
            button631.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 2, 0].ToString();
            button632.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 2, 1].ToString();
            button633.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 2, 2].ToString();
            button634.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 2, 3].ToString();
            button635.Text = dothings.Kartlar[dothings.oyuncu[5].kartNo-1, 2, 4].ToString();
        }
        private void oyuncuAc7()
        {
            button711.Visible = true;
            button712.Visible = true;
            button713.Visible = true;
            button714.Visible = true;
            button715.Visible = true;
            button721.Visible = true;
            button722.Visible = true;
            button723.Visible = true;
            button724.Visible = true;
            button725.Visible = true;
            button731.Visible = true;
            button732.Visible = true;
            button733.Visible = true;
            button734.Visible = true;
            button735.Visible = true;
            panel7.Visible = true;
            oyuncuLabel7.Visible = true;
            oyuncuLabel7.Text = dothings.oyuncu[6].oyuncuNo + ". oyuncu : " + dothings.oyuncu[6].isim + " (Kart " + dothings.oyuncu[6].kartNo + ")";
            button711.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 0, 0].ToString();
            button712.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 0, 1].ToString();
            button713.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 0, 2].ToString();
            button714.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 0, 3].ToString();
            button715.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 0, 4].ToString();
            button721.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 1, 0].ToString();
            button722.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 1, 1].ToString();
            button723.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 1, 2].ToString();
            button724.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 1, 3].ToString();
            button725.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 1, 4].ToString();
            button731.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 2, 0].ToString();
            button732.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 2, 1].ToString();
            button733.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 2, 2].ToString();
            button734.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 2, 3].ToString();
            button735.Text = dothings.Kartlar[dothings.oyuncu[6].kartNo-1, 2, 4].ToString();
        }
        private void oyuncuAc8()
        {
            button811.Visible = true;
            button812.Visible = true;
            button813.Visible = true;
            button814.Visible = true;
            button815.Visible = true;
            button821.Visible = true;
            button822.Visible = true;
            button823.Visible = true;
            button824.Visible = true;
            button825.Visible = true;
            button831.Visible = true;
            button832.Visible = true;
            button833.Visible = true;
            button834.Visible = true;
            button835.Visible = true;
            panel8.Visible = true;
            oyuncuLabel8.Visible = true;
            oyuncuLabel8.Text = dothings.oyuncu[7].oyuncuNo + ". oyuncu : " + dothings.oyuncu[7].isim + " (Kart " + dothings.oyuncu[7].kartNo + ")";
            button811.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 0, 0].ToString();
            button812.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 0, 1].ToString();
            button813.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 0, 2].ToString();
            button814.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 0, 3].ToString();
            button815.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 0, 4].ToString();
            button821.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 1, 0].ToString();
            button822.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 1, 1].ToString();
            button823.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 1, 2].ToString();
            button824.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 1, 3].ToString();
            button825.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 1, 4].ToString();
            button831.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 2, 0].ToString();
            button832.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 2, 1].ToString();
            button833.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 2, 2].ToString();
            button834.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 2, 3].ToString();
            button835.Text = dothings.Kartlar[dothings.oyuncu[7].kartNo-1, 2, 4].ToString();
        }
        private void oyuncuAc9()
        {
            button911.Visible = true;
            button912.Visible = true;
            button913.Visible = true;
            button914.Visible = true;
            button915.Visible = true;
            button921.Visible = true;
            button922.Visible = true;
            button923.Visible = true;
            button924.Visible = true;
            button925.Visible = true;
            button931.Visible = true;
            button932.Visible = true;
            button933.Visible = true;
            button934.Visible = true;
            button935.Visible = true;
            panel9.Visible = true;
            oyuncuLabel9.Visible = true;
            oyuncuLabel9.Text = dothings.oyuncu[8].oyuncuNo + ". oyuncu : " + dothings.oyuncu[8].isim + " (Kart " + dothings.oyuncu[8].kartNo + ")";
            button911.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 0, 0].ToString();
            button912.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 0, 1].ToString();
            button913.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 0, 2].ToString();
            button914.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 0, 3].ToString();
            button915.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 0, 4].ToString();
            button921.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 1, 0].ToString();
            button922.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 1, 1].ToString();
            button923.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 1, 2].ToString();
            button924.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 1, 3].ToString();
            button925.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 1, 4].ToString();
            button931.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 2, 0].ToString();
            button932.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 2, 1].ToString();
            button933.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 2, 2].ToString();
            button934.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 2, 3].ToString();
            button935.Text = dothings.Kartlar[dothings.oyuncu[8].kartNo-1, 2, 4].ToString();
        }
        private void oyuncuAc10()
        {
            button1011.Visible = true;
            button1012.Visible = true;
            button1013.Visible = true;
            button1014.Visible = true;
            button1015.Visible = true;
            button1021.Visible = true;
            button1022.Visible = true;
            button1023.Visible = true;
            button1024.Visible = true;
            button1025.Visible = true;
            button1031.Visible = true;
            button1032.Visible = true;
            button1033.Visible = true;
            button1034.Visible = true;
            button1035.Visible = true;
            panel10.Visible = true;
            oyuncuLabel10.Visible = true;
            oyuncuLabel10.Text = dothings.oyuncu[9].oyuncuNo + ". oyuncu : " + dothings.oyuncu[9].isim + " (Kart " + dothings.oyuncu[9].kartNo + ")";
            button1011.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 0, 0].ToString();
            button1012.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 0, 1].ToString();
            button1013.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 0, 2].ToString();
            button1014.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 0, 3].ToString();
            button1015.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 0, 4].ToString();
            button1021.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 1, 0].ToString();
            button1022.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 1, 1].ToString();
            button1023.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 1, 2].ToString();
            button1024.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 1, 3].ToString();
            button1025.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 1, 4].ToString();
            button1031.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 2, 0].ToString();
            button1032.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 2, 1].ToString();
            button1033.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 2, 2].ToString();
            button1034.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 2, 3].ToString();
            button1035.Text = dothings.Kartlar[dothings.oyuncu[9].kartNo-1, 2, 4].ToString();
        }

        private void kartıKontrolEt()
        {
            if(button111.Text==dothings.Torba[dothings.torbaSayac-1].ToString())
            {
                button111.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button112.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button112.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button113.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button113.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button114.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button114.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button115.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button115.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button121.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button121.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button122.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button122.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button123.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button123.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button124.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button124.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button125.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button125.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button131.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button131.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button132.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button132.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button133.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button133.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button134.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button134.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }
            if (button135.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button135.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[0].isim + "bir sayı buldu.");
            }

            if (button211.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button211.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button212.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button212.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button213.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button213.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button214.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button214.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button215.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button215.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button221.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button221.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button222.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button222.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button223.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button223.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button224.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button224.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button225.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button225.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button231.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button231.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button232.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button232.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button233.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button233.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button234.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button234.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }
            if (button235.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button235.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[1].isim + "bir sayı buldu.");
            }

            if (button311.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button311.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button312.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button312.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button313.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button313.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button314.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button314.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button315.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button315.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button321.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button321.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button322.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button322.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button323.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button323.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button324.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button324.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button325.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button325.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button331.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button331.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button332.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button332.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button333.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button333.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button334.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button334.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }
            if (button335.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button335.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[2].isim + "bir sayı buldu.");
            }

            if (button411.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button411.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button412.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button412.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button413.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button413.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button414.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button414.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button415.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button415.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button421.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button421.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button422.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button422.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button423.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button423.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button424.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button424.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button425.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button425.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button431.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button431.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button432.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button432.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button433.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button433.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button434.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button434.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }
            if (button435.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button435.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[3].isim + "bir sayı buldu.");
            }

            if (button511.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button511.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button512.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button512.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button513.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button513.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button514.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button514.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button515.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button515.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button521.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button521.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button522.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button522.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button523.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button523.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button524.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button524.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button525.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button525.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button531.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button531.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button532.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button532.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button533.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button533.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button534.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button534.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }
            if (button535.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button535.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[4].isim + "bir sayı buldu.");
            }

            if (button611.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button611.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button612.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button612.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button613.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button613.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button614.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button614.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button615.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button615.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button621.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button621.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button622.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button622.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button623.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button623.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button624.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button624.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button625.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button625.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button631.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button631.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button632.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button632.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button633.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button633.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button634.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button634.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }
            if (button635.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button635.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[5].isim + "bir sayı buldu.");
            }

            if (button711.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button711.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button712.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button712.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button713.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button713.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button714.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button714.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button715.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button715.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button721.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button721.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button722.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button722.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button723.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button723.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button724.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button724.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button725.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button725.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button731.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button731.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button732.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button732.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button733.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button733.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button734.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button734.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }
            if (button735.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button735.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[6].isim + "bir sayı buldu.");
            }

            if (button811.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button811.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button812.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button812.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button813.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button813.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button814.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button814.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button815.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button815.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button821.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button821.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button822.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button822.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button823.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button823.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button824.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button824.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button825.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button825.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button831.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button831.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button832.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button832.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button833.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button833.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button834.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button834.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }
            if (button835.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button835.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[7].isim + "bir sayı buldu.");
            }

            if (button911.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button911.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button912.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button912.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button913.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button913.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button914.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button914.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button915.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button915.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button921.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button921.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button922.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button922.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button923.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button923.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button924.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button924.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button925.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button925.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button931.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button931.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button932.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button932.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button933.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button933.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button934.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button934.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }
            if (button935.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button935.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[8].isim + "bir sayı buldu.");
            }

            if (button1011.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1011.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1012.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1012.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1013.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1013.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1014.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1014.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1015.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1015.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1021.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1021.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1022.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1022.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1023.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1023.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1024.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1024.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1025.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1025.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1031.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1031.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1032.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1032.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1033.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1033.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1034.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1034.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
            if (button1035.Text == dothings.Torba[dothings.torbaSayac - 1].ToString())
            {
                button1035.Text = "";
                if (dothings.duyuru == true)
                    MessageBox.Show(dothings.oyuncu[9].isim + "bir sayı buldu.");
            }
        }
        private void mesajAcKapa()
        {
            if(dothings.duyuru==false)
            {
                dothings.duyuru = true;
            }
            else
            {
                dothings.duyuru = false;
            }
            
        }

        private void duyuruButton_Click(object sender, EventArgs e)
        {
            mesajAcKapa();
            if(dothings.duyuru==true)
            {
                duyuruLabel.Text = "Sayı duyuruları açık";
            }
            else
            {
                duyuruLabel.Text = "Sayı duyuruları kapalı";
            }
        }
    }
}