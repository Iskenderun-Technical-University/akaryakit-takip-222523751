using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace YakıtTakip
{
    public partial class Personel : Form
    {
        MySqlDataAdapter da_pers;
        DataTable dt;
        public Personel(MySqlDataAdapter da)
        {
            InitializeComponent();
            da_pers = da;
            dt = new DataTable();
            da_pers.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns[2].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            da_pers.Update(dt);
        }

        private void Personel_Load(object sender, EventArgs e)
        {
            this.Text = "PERSONEL";
        }
    }
}
