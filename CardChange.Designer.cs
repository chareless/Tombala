
namespace Tombala
{
    partial class CardChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardChange));
            this.label1 = new System.Windows.Forms.Label();
            this.degistirButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.kartNoComboBox = new System.Windows.Forms.ComboBox();
            this.isimComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(30, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 24);
            this.label1.TabIndex = 10;
            this.label1.Text = "Kart değiştirmek isteyen oyuncunun adı : ";
            // 
            // degistirButton
            // 
            this.degistirButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.degistirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.degistirButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.degistirButton.Location = new System.Drawing.Point(378, 173);
            this.degistirButton.Name = "degistirButton";
            this.degistirButton.Size = new System.Drawing.Size(120, 49);
            this.degistirButton.TabIndex = 3;
            this.degistirButton.Text = "DEĞİŞTİR";
            this.degistirButton.UseVisualStyleBackColor = false;
            this.degistirButton.Click += new System.EventHandler(this.degistirButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(30, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 24);
            this.label2.TabIndex = 19;
            this.label2.Text = "Yeni kart numarası seçin : ";
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
            this.kartNoComboBox.Location = new System.Drawing.Point(265, 114);
            this.kartNoComboBox.Name = "kartNoComboBox";
            this.kartNoComboBox.Size = new System.Drawing.Size(51, 21);
            this.kartNoComboBox.TabIndex = 2;
            // 
            // isimComboBox
            // 
            this.isimComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.isimComboBox.FormattingEnabled = true;
            this.isimComboBox.Location = new System.Drawing.Point(378, 63);
            this.isimComboBox.Name = "isimComboBox";
            this.isimComboBox.Size = new System.Drawing.Size(120, 21);
            this.isimComboBox.TabIndex = 1;
            // 
            // CardChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(557, 276);
            this.Controls.Add(this.isimComboBox);
            this.Controls.Add(this.kartNoComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.degistirButton);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CardChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kart Değiştir";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button degistirButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox kartNoComboBox;
        private System.Windows.Forms.ComboBox isimComboBox;
    }
}