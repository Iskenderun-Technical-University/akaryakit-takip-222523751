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
    public partial class Arac : Form
    {
        MySqlDataAdapter da_arac;
        DataTable dt;
        public Arac(MySqlDataAdapter da)
        {
            InitializeComponent();
            da_arac = da;
            dt = new DataTable();
            da_arac.Fill(dt);
            
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            da_arac.Update(dt);
        }
    }
}
