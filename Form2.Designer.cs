
namespace Tombala
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.oyuncuSayiComboBox = new System.Windows.Forms.ComboBox();
            this.oyuncuSayiLabel = new System.Windows.Forms.Label();
            this.ilerleButton = new System.Windows.Forms.Button();
            this.oyuncuAdiTextBox = new System.Windows.Forms.TextBox();
            this.oyuncuAdiLabel = new System.Windows.Forms.Label();
            this.oyuncuEkleButton = new System.Windows.Forms.Button();
            this.kartNoLabel = new System.Windows.Forms.Label();
            this.kartNoComboBox = new System.Windows.Forms.ComboBox();
            this.kartGosterLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // oyuncuSayiComboBox
            // 
            this.oyuncuSayiComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.oyuncuSayiComboBox.FormatString = "N0";
            this.oyuncuSayiComboBox.FormattingEnabled = true;
            this.oyuncuSayiComboBox.Items.AddRange(new object[] {
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.oyuncuSayiComboBox.Location = new System.Drawing.Point(146, 43);
            this.oyuncuSayiComboBox.Name = "oyuncuSayiComboBox";
            this.oyuncuSayiComboBox.Size = new System.Drawing.Size(51, 21);
            this.oyuncuSayiComboBox.TabIndex = 0;
            // 
            // oyuncuSayiLabel
            // 
            this.oyuncuSayiLabel.AutoSize = true;
            this.oyuncuSayiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.oyuncuSayiLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.oyuncuSayiLabel.Location = new System.Drawing.Point(27, 41);
            this.oyuncuSayiLabel.Name = "oyuncuSayiLabel";
            this.oyuncuSayiLabel.Size = new System.Drawing.Size(116, 20);
            this.oyuncuSayiLabel.TabIndex = 1;
            this.oyuncuSayiLabel.Text = "Oyuncu Sayısı :";
            // 
            // ilerleButton
            // 
            this.ilerleButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ilerleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ilerleButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.ilerleButton.Location = new System.Drawing.Point(236, 35);
            this.ilerleButton.Name = "ilerleButton";
            this.ilerleButton.Size = new System.Drawing.Size(108, 34);
            this.ilerleButton.TabIndex = 1;
            this.ilerleButton.Text = "İLERLE";
            this.ilerleButton.UseVisualStyleBackColor = false;
            this.ilerleButton.Click += new System.EventHandler(this.ilerleButton_Click);
            // 
            // oyuncuAdiTextBox
            // 
            this.oyuncuAdiTextBox.Location = new System.Drawing.Point(258, 105);
            this.oyuncuAdiTextBox.Name = "oyuncuAdiTextBox";
            this.oyuncuAdiTextBox.Size = new System.Drawing.Size(100, 20);
            this.oyuncuAdiTextBox.TabIndex = 2;
            this.oyuncuAdiTextBox.Visible = false;
            this.oyuncuAdiTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_bosluk_giremez_KeyPress);
            // 
            // oyuncuAdiLabel
            // 
            this.oyuncuAdiLabel.AutoSize = true;
            this.oyuncuAdiLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.oyuncuAdiLabel.Location = new System.Drawing.Point(135, 103);
            this.oyuncuAdiLabel.Name = "oyuncuAdiLabel";
            this.oyuncuAdiLabel.Size = new System.Drawing.Size(102, 20);
            this.oyuncuAdiLabel.TabIndex = 5;
            this.oyuncuAdiLabel.Text = " Oyuncu Adı :";
            this.oyuncuAdiLabel.Visible = false;
            // 
            // oyuncuEkleButton
            // 
            this.oyuncuEkleButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.oyuncuEkleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.oyuncuEkleButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.oyuncuEkleButton.Location = new System.Drawing.Point(171, 222);
            this.oyuncuEkleButton.Name = "oyuncuEkleButton";
            this.oyuncuEkleButton.Size = new System.Drawing.Size(108, 34);
            this.oyuncuEkleButton.TabIndex = 5;
            this.oyuncuEkleButton.Text = "EKLE";
            this.oyuncuEkleButton.UseVisualStyleBackColor = false;
            this.oyuncuEkleButton.Visible = false;
            this.oyuncuEkleButton.Click += new System.EventHandler(this.oyuncuEkleButton_Click);
            // 
            // kartNoLabel
            // 
            this.kartNoLabel.AutoSize = true;
            this.kartNoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kartNoLabel.Location = new System.Drawing.Point(134, 146);
            this.kartNoLabel.Name = "kartNoLabel";
            this.kartNoLabel.Size = new System.Drawing.Size(117, 20);
            this.kartNoLabel.TabIndex = 7;
            this.kartNoLabel.Text = "Kart Numarası :";
            this.kartNoLabel.Visible = false;
            // 
            // kartNoComboBox
            // 
            this.kartNoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kartNoComboBox.FormatString = "N0";
            this.kartNoComboBox.FormattingEnabled = true;
            this.kartNoComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.kartNoComboBox.Location = new System.Drawing.Point(258, 148);
            this.kartNoComboBox.Name = "kartNoComboBox";
            this.kartNoComboBox.Size = new System.Drawing.Size(51, 21);
            this.kartNoComboBox.TabIndex = 3;
            this.kartNoComboBox.Visible = false;
            // 
            // kartGosterLabel
            // 
            this.kartGosterLabel.AutoSize = true;
            this.kartGosterLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.kartGosterLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.kartGosterLabel.Location = new System.Drawing.Point(136, 180);
            this.kartGosterLabel.Name = "kartGosterLabel";
            this.kartGosterLabel.Size = new System.Drawing.Size(73, 13);
            this.kartGosterLabel.TabIndex = 4;
            this.kartGosterLabel.Text = "Kartları Göster";
            this.kartGosterLabel.Visible = false;
            this.kartGosterLabel.Click += new System.EventHandler(this.kartGosterLabel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(476, 348);
            this.Controls.Add(this.kartGosterLabel);
            this.Controls.Add(this.kartNoComboBox);
            this.Controls.Add(this.kartNoLabel);
            this.Controls.Add(this.oyuncuEkleButton);
            this.Controls.Add(this.oyuncuAdiLabel);
            this.Controls.Add(this.oyuncuAdiTextBox);
            this.Controls.Add(this.ilerleButton);
            this.Controls.Add(this.oyuncuSayiLabel);
            this.Controls.Add(this.oyuncuSayiComboBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ayarla";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label oyuncuSayiLabel;
        private System.Windows.Forms.Button ilerleButton;
        private System.Windows.Forms.TextBox oyuncuAdiTextBox;
        private System.Windows.Forms.Label oyuncuAdiLabel;
        private System.Windows.Forms.Button oyuncuEkleButton;
        private System.Windows.Forms.Label kartNoLabel;
        private System.Windows.Forms.ComboBox kartNoComboBox;
        private System.Windows.Forms.Label kartGosterLabel;
        private System.Windows.Forms.ComboBox oyuncuSayiComboBox;
    }
}