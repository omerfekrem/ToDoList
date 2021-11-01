namespace ToDoList
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ekleBtn = new System.Windows.Forms.Button();
            this.dgYapilacaklar = new System.Windows.Forms.DataGridView();
            this.dgYapilanlar = new System.Windows.Forms.DataGridView();
            this.yap = new System.Windows.Forms.Button();
            this.yapma = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgYapilacaklar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgYapilanlar)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(397, 20);
            this.textBox1.TabIndex = 1;
            // 
            // ekleBtn
            // 
            this.ekleBtn.Location = new System.Drawing.Point(415, 12);
            this.ekleBtn.Name = "ekleBtn";
            this.ekleBtn.Size = new System.Drawing.Size(67, 20);
            this.ekleBtn.TabIndex = 2;
            this.ekleBtn.Text = "Ekle";
            this.ekleBtn.UseVisualStyleBackColor = true;
            this.ekleBtn.Click += new System.EventHandler(this.ekleBtn_Click);
            // 
            // dgYapilacaklar
            // 
            this.dgYapilacaklar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgYapilacaklar.Location = new System.Drawing.Point(12, 58);
            this.dgYapilacaklar.Name = "dgYapilacaklar";
            this.dgYapilacaklar.ReadOnly = true;
            this.dgYapilacaklar.Size = new System.Drawing.Size(206, 289);
            this.dgYapilacaklar.TabIndex = 3;
            this.dgYapilacaklar.SelectionChanged += new System.EventHandler(this.dgYapilacaklar_SelectionChanged);
            // 
            // dgYapilanlar
            // 
            this.dgYapilanlar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgYapilanlar.Location = new System.Drawing.Point(276, 58);
            this.dgYapilanlar.Name = "dgYapilanlar";
            this.dgYapilanlar.ReadOnly = true;
            this.dgYapilanlar.Size = new System.Drawing.Size(206, 289);
            this.dgYapilanlar.TabIndex = 4;
            this.dgYapilanlar.SelectionChanged += new System.EventHandler(this.dgYapilanlar_SelectionChanged);
            // 
            // yap
            // 
            this.yap.Location = new System.Drawing.Point(224, 206);
            this.yap.Name = "yap";
            this.yap.Size = new System.Drawing.Size(46, 37);
            this.yap.TabIndex = 5;
            this.yap.Text = ">>";
            this.yap.UseVisualStyleBackColor = true;
            this.yap.Click += new System.EventHandler(this.yap_Click);
            // 
            // yapma
            // 
            this.yapma.Location = new System.Drawing.Point(224, 163);
            this.yapma.Name = "yapma";
            this.yapma.Size = new System.Drawing.Size(46, 37);
            this.yapma.TabIndex = 6;
            this.yapma.Text = "<<";
            this.yapma.UseVisualStyleBackColor = true;
            this.yapma.Click += new System.EventHandler(this.yapma_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 359);
            this.Controls.Add(this.yapma);
            this.Controls.Add(this.yap);
            this.Controls.Add(this.dgYapilanlar);
            this.Controls.Add(this.dgYapilacaklar);
            this.Controls.Add(this.ekleBtn);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "ToDoList";
            ((System.ComponentModel.ISupportInitialize)(this.dgYapilacaklar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgYapilanlar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button ekleBtn;
        private System.Windows.Forms.DataGridView dgYapilacaklar;
        private System.Windows.Forms.DataGridView dgYapilanlar;
        private System.Windows.Forms.Button yap;
        private System.Windows.Forms.Button yapma;
    }
}

