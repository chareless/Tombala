
namespace Tombala
{
    partial class Update
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Update));
            this.durumLabel = new System.Windows.Forms.Label();
            this.mevcutLabel = new System.Windows.Forms.Label();
            this.guncelLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.indirButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // durumLabel
            // 
            this.durumLabel.AutoSize = true;
            this.durumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.durumLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.durumLabel.Location = new System.Drawing.Point(32, 134);
            this.durumLabel.Name = "durumLabel";
            this.durumLabel.Size = new System.Drawing.Size(137, 24);
            this.durumLabel.TabIndex = 19;
            this.durumLabel.Text = "Sürüm durumu";
            // 
            // mevcutLabel
            // 
            this.mevcutLabel.AutoSize = true;
            this.mevcutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mevcutLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.mevcutLabel.Location = new System.Drawing.Point(185, 31);
            this.mevcutLabel.Name = "mevcutLabel";
            this.mevcutLabel.Size = new System.Drawing.Size(71, 24);
            this.mevcutLabel.TabIndex = 18;
            this.mevcutLabel.Text = "Mevcut";
            // 
            // guncelLabel
            // 
            this.guncelLabel.AutoSize = true;
            this.guncelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guncelLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.guncelLabel.Location = new System.Drawing.Point(185, 83);
            this.guncelLabel.Name = "guncelLabel";
            this.guncelLabel.Size = new System.Drawing.Size(71, 24);
            this.guncelLabel.TabIndex = 17;
            this.guncelLabel.Text = "Güncel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(32, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 24);
            this.label2.TabIndex = 16;
            this.label2.Text = "Güncel Sürüm : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(32, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Mevcut Sürüm : ";
            // 
            // indirButton
            // 
            this.indirButton.BackColor = System.Drawing.Color.PaleTurquoise;
            this.indirButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.indirButton.ForeColor = System.Drawing.Color.MediumBlue;
            this.indirButton.Location = new System.Drawing.Point(340, 193);
            this.indirButton.Name = "indirButton";
            this.indirButton.Size = new System.Drawing.Size(112, 44);
            this.indirButton.TabIndex = 21;
            this.indirButton.Text = "İndir";
            this.indirButton.UseVisualStyleBackColor = false;
            this.indirButton.Click += new System.EventHandler(this.indirButton_Click);
            // 
            // Update
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(464, 249);
            this.Controls.Add(this.indirButton);
            this.Controls.Add(this.durumLabel);
            this.Controls.Add(this.mevcutLabel);
            this.Controls.Add(this.guncelLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Update";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Güncellemeleri Denetle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label durumLabel;
        private System.Windows.Forms.Label mevcutLabel;
        private System.Windows.Forms.Label guncelLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button indirButton;
    }
}