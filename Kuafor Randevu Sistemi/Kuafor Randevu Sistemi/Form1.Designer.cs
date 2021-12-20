
namespace Kuafor_Randevu_Sistemi
{
    partial class Frm_Giris
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtmail = new System.Windows.Forms.TextBox();
            this.lblmail = new System.Windows.Forms.Label();
            this.lblsifre = new System.Windows.Forms.Label();
            this.txtsifre = new System.Windows.Forms.TextBox();
            this.btngiris = new System.Windows.Forms.Button();
            this.btnkayit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(278, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Giriş Yap";
            // 
            // txtmail
            // 
            this.txtmail.Location = new System.Drawing.Point(318, 90);
            this.txtmail.Name = "txtmail";
            this.txtmail.Size = new System.Drawing.Size(125, 27);
            this.txtmail.TabIndex = 1;
            // 
            // lblmail
            // 
            this.lblmail.AutoSize = true;
            this.lblmail.Location = new System.Drawing.Point(212, 91);
            this.lblmail.Name = "lblmail";
            this.lblmail.Size = new System.Drawing.Size(49, 20);
            this.lblmail.TabIndex = 2;
            this.lblmail.Text = "Email:";
            // 
            // lblsifre
            // 
            this.lblsifre.AutoSize = true;
            this.lblsifre.Location = new System.Drawing.Point(212, 136);
            this.lblsifre.Name = "lblsifre";
            this.lblsifre.Size = new System.Drawing.Size(42, 20);
            this.lblsifre.TabIndex = 3;
            this.lblsifre.Text = "Şifre:";
            // 
            // txtsifre
            // 
            this.txtsifre.Location = new System.Drawing.Point(318, 133);
            this.txtsifre.Name = "txtsifre";
            this.txtsifre.Size = new System.Drawing.Size(125, 27);
            this.txtsifre.TabIndex = 7;
            // 
            // btngiris
            // 
            this.btngiris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btngiris.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btngiris.Location = new System.Drawing.Point(318, 189);
            this.btngiris.Name = "btngiris";
            this.btngiris.Size = new System.Drawing.Size(125, 36);
            this.btngiris.TabIndex = 8;
            this.btngiris.Text = "Giriş";
            this.btngiris.UseVisualStyleBackColor = false;
            this.btngiris.Click += new System.EventHandler(this.btngiris_Click);
            // 
            // btnkayit
            // 
            this.btnkayit.BackColor = System.Drawing.Color.Yellow;
            this.btnkayit.Location = new System.Drawing.Point(212, 265);
            this.btnkayit.Name = "btnkayit";
            this.btnkayit.Size = new System.Drawing.Size(231, 29);
            this.btnkayit.TabIndex = 9;
            this.btnkayit.Text = "Hesabın yok mu? Kaydol";
            this.btnkayit.UseVisualStyleBackColor = false;
            this.btnkayit.Click += new System.EventHandler(this.btnkayit_Click);
            // 
            // Frm_Giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(663, 315);
            this.Controls.Add(this.btnkayit);
            this.Controls.Add(this.btngiris);
            this.Controls.Add(this.txtsifre);
            this.Controls.Add(this.lblsifre);
            this.Controls.Add(this.lblmail);
            this.Controls.Add(this.txtmail);
            this.Controls.Add(this.label1);
            this.Name = "Frm_Giris";
            this.Text = "Frm_Giris";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmail;
        private System.Windows.Forms.Label lblmail;
        private System.Windows.Forms.Label lblsifre;
        private System.Windows.Forms.TextBox txtsifre;
        private System.Windows.Forms.Button btngiris;
        private System.Windows.Forms.Button btnkayit;
    }
}

