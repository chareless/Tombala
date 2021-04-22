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
    public partial class CardChange : Form
    {
        public CardChange()
        {
            InitializeComponent();
            mevcutKartlar();
        }

        DoThings dothings = new DoThings();
        public static int gecici;
        private void degistirButton_Click(object sender, EventArgs e)
        {
            for(int i=0;i<dothings.maxOyuncu;i++)
            {
                if(isimComboBox.Text==dothings.oyuncu[i].isim)
                {
                    gecici = dothings.oyuncu[i].kartNo;
                    dothings.kartDegistir(dothings.oyuncu[i].oyuncuNo, Convert.ToInt32(kartNoComboBox.Text));
                    MessageBox.Show(isimComboBox.Text + " adlı oyuncunun kart numarası " + kartNoComboBox.Text + " olarak değiştirildi");
                    kartTara();
                    this.Close();
                }
            }
        }

        private void mevcutKartlar()
        {
            kartNoComboBox.Text = "1";
            kartNoComboBox.Items.Clear();
            for (int i = 0; i < dothings.KartNo.Count; i++)
            {
                kartNoComboBox.Items.Add(dothings.KartNo[i]);
                if (i == 0)
                {
                    kartNoComboBox.Text = dothings.KartNo[i].ToString();
                }
            }
            isimComboBox.Text = dothings.oyuncu[0].isim;
            for (int i = 0; i < dothings.maxOyuncu; i++)
            {
                isimComboBox.Items.Add(dothings.oyuncu[i].isim);
                if (i == 0)
                {
                    isimComboBox.Text = dothings.oyuncu[i].isim;
                }
            }
        }

        private void kartTara()
        {
            dothings.KartNo.Remove(Convert.ToInt32(kartNoComboBox.Text));
            kartNoComboBox.Items.Clear();
            for (int i = 0; i < dothings.KartNo.Count; i++)
            {
                kartNoComboBox.Items.Add(dothings.KartNo[i]);
                if (i == 0)
                {
                    kartNoComboBox.Text = dothings.KartNo[i].ToString();
                }
            }
            dothings.KartNo.Add(gecici);
        }
    }
}