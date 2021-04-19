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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            oyuncuSayiComboBox.Text = "2";
            kartNoComboBox.Text = "1";
        }

        DoThings dothings = new DoThings();

        private void ilerleButton_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(oyuncuSayiComboBox.Text)<11 && Convert.ToInt32(oyuncuSayiComboBox.Text)>0 )
            {
                oyuncuAdiLabel.Visible = true;
                kartNoLabel.Visible = true;
                kartGosterLabel.Visible = true;
                kartNoComboBox.Visible = true;
                oyuncuAdiTextBox.Visible = true;
                oyuncuEkleButton.Visible = true;
                oyuncuAdiLabel.Text = dothings.maxOyuncu+1 + ". Oyuncu Adı :";
                ilerleButton.Visible = false;
                oyuncuSayiLabel.Visible = false;
                oyuncuSayiComboBox.Visible = false;
            }
        }
        
        private void oyuncuEkleButton_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(kartNoComboBox.Text)>0 && Convert.ToInt32(kartNoComboBox.Text)<16 && oyuncuAdiTextBox.Text!="")
            {
                dothings.oyuncuOlustur(oyuncuAdiTextBox.Text, Convert.ToInt32(kartNoComboBox.Text));
                oyuncuAdiLabel.Text = dothings.maxOyuncu + 1 + ". Oyuncu Adı :";
                oyuncuAdiTextBox.Text = "";
                dothings.KartNo.Remove(Convert.ToInt32(kartNoComboBox.Text));
                kartNoComboBox.Items.Clear();
                for (int i=0;i<dothings.KartNo.Count;i++)
                {
                    kartNoComboBox.Items.Add(dothings.KartNo[i]);
                    if(i ==0)
                    {
                        kartNoComboBox.Text = dothings.KartNo[i].ToString();
                    }    
                }
            }
            else if(oyuncuAdiTextBox.Text=="")
            {
                MessageBox.Show("Oyuncu adı boş olamaz.");
            }
            else
            {
                MessageBox.Show("Bilinmeyen Hata");
            }

            if (Convert.ToInt32(oyuncuSayiComboBox.Text) == dothings.maxOyuncu)
            {
                dothings.sayac=1;
                this.Close();
            }
        }

        private void kartGosterLabel_Click(object sender, EventArgs e)
        {
            Kartlar kartFormu = new Kartlar();
            kartFormu.Show();
        }

        private void txt_bosluk_giremez_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 32)
            {
                e.Handled = true;
            }
        }
    }
}