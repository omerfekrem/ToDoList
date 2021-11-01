using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        int yid,vid;
        public Form1()
        {
            InitializeComponent();

            dgFill();
            gridColl(dgYapilacaklar);
            gridColl(dgYapilanlar);
        }

        public void dgFill()
        {
            dgYapilacaklar.DataSource = new Data.DatHes().getFalse();
            this.dgYapilacaklar.Columns["id"].Visible = false;
            dgYapilanlar.DataSource = new Data.DatHes().getTrue();
            this.dgYapilanlar.Columns["id"].Visible = false;
        }

        private void gridColl(DataGridView dg)
        {
            dg.RowHeadersVisible = false;
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg.AllowUserToAddRows = false;
        }

        private void dgYapilacaklar_SelectionChanged(object sender, EventArgs e)
        {
            yid = Convert.ToInt32(dgYapilacaklar.CurrentRow.Cells[0].Value.ToString());
        }

        private void yap_Click(object sender, EventArgs e)
        {
            new Data.DatHes().updateRow(yid);
            dgFill();
        }

        private void dgYapilanlar_SelectionChanged(object sender, EventArgs e)
        {
            vid = Convert.ToInt32(dgYapilanlar.CurrentRow.Cells[0].Value.ToString());
        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            new Data.DatHes().postRow(textBox1.Text);
            textBox1.Text = "";
            dgFill();
            MessageBox.Show("Başarıyla eklendi!", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void yapma_Click(object sender, EventArgs e)
        {
            new Data.DatHes().updateNotRow(vid);
            dgFill();
        }
    }
}
