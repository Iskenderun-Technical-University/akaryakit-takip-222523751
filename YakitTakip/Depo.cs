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
    public partial class Depo : Form
    {
        MySqlDataAdapter da_form2;
        MySqlConnection conn_form2;
        public Depo(MySqlDataAdapter da, MySqlConnection conn)
        {
            InitializeComponent();
            da_form2 = da;
            conn_form2 = conn;
            depo();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") { }
            else if (comboBox1.Text == "Yakıt")
            {
                MySqlCommand cmd = new MySqlCommand("Select Y1 from Depo",conn_form2);
                //conn_form2.Open();
                double sonuc = Convert.ToDouble(cmd.ExecuteScalar()) + Convert.ToDouble(textBox1.Text);
                        
                MySqlCommand cmd2 = new MySqlCommand("Update depo set Y1=@Y1 where 1=1", conn_form2);
                cmd2.Parameters.AddWithValue("@Y1", sonuc);
                cmd2.ExecuteNonQuery();

            }
            else if (comboBox1.Text == "Motor Yağı")
            {
                MySqlCommand cmd = new MySqlCommand("Select Y2 from Depo", conn_form2);
                //conn_form2.Open();
                double sonuc = Convert.ToDouble(cmd.ExecuteScalar()) + Convert.ToDouble(textBox1.Text);

                MySqlCommand cmd2 = new MySqlCommand("Update depo set Y2=@Y1 where 1=1", conn_form2);
                cmd2.Parameters.AddWithValue("@Y1", sonuc);
                cmd2.ExecuteNonQuery();

            }
            else
            {
                MySqlCommand cmd = new MySqlCommand("Select Y3 from Depo", conn_form2);
                //conn_form2.Open();
                double sonuc = Convert.ToDouble(cmd.ExecuteScalar()) + Convert.ToDouble(textBox1.Text);

                MySqlCommand cmd2 = new MySqlCommand("Update depo set Y3=@Y1 where 1=1", conn_form2);
                cmd2.Parameters.AddWithValue("@Y1", sonuc);
                cmd2.ExecuteNonQuery();
            }
            depo();
        }
        public void depo()
        {
            DataTable dt = new DataTable();
            da_form2.Fill(dt);
            for (int satir = 0; satir < dt.Rows.Count; satir++)
            {
                lyakit.Text = dt.Rows[satir].ItemArray[1].ToString();
                lyag1.Text = dt.Rows[satir].ItemArray[2].ToString();
                lyag2.Text = dt.Rows[satir].ItemArray[3].ToString();
            }

        }


        private void Depo_Load(object sender, EventArgs e)
        {
            this.Text = "DEPO";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
