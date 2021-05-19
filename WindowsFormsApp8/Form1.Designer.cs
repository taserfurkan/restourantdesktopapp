namespace WindowsFormsApp8
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.yonetici = new System.Windows.Forms.RadioButton();
            this.isci = new System.Windows.Forms.RadioButton();
            this.kullanıcıadı = new System.Windows.Forms.TextBox();
            this.sifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // yonetici
            // 
            this.yonetici.AllowDrop = true;
            this.yonetici.AutoSize = true;
            this.yonetici.Location = new System.Drawing.Point(103, 145);
            this.yonetici.Name = "yonetici";
            this.yonetici.Size = new System.Drawing.Size(63, 18);
            this.yonetici.TabIndex = 0;
            this.yonetici.Text = "Yönetici";
            this.yonetici.UseCompatibleTextRendering = true;
            this.yonetici.UseVisualStyleBackColor = true;
            // 
            // isci
            // 
            this.isci.AllowDrop = true;
            this.isci.AutoSize = true;
            this.isci.Location = new System.Drawing.Point(187, 145);
            this.isci.Name = "isci";
            this.isci.Size = new System.Drawing.Size(41, 17);
            this.isci.TabIndex = 1;
            this.isci.Text = "İşçi";
            this.isci.UseVisualStyleBackColor = true;
            // 
            // kullanıcıadı
            // 
            this.kullanıcıadı.Location = new System.Drawing.Point(103, 68);
            this.kullanıcıadı.Name = "kullanıcıadı";
            this.kullanıcıadı.Size = new System.Drawing.Size(125, 20);
            this.kullanıcıadı.TabIndex = 3;
            // 
            // sifre
            // 
            this.sifre.Location = new System.Drawing.Point(103, 102);
            this.sifre.Name = "sifre";
            this.sifre.Size = new System.Drawing.Size(125, 20);
            this.sifre.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Şifre";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 180);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "GİRİŞ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 227);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sifre);
            this.Controls.Add(this.kullanıcıadı);
            this.Controls.Add(this.isci);
            this.Controls.Add(this.yonetici);
            this.Name = "Form1";
            this.Text = "Kullanıcı Girişi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton yonetici;
        private System.Windows.Forms.RadioButton isci;
        private System.Windows.Forms.TextBox kullanıcıadı;
        private System.Windows.Forms.TextBox sifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

