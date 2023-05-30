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
    public partial class Raporlama : Form
    {
        MySqlDataAdapter da_rapor;
        MySqlConnection conn;
        DataTable dt;
        public Raporlama(MySqlDataAdapter da, MySqlConnection _conn)
        {
            InitializeComponent();
            da_rapor = da;
            conn = _conn;
            combodoldur();
        }

        DataTable dt_arac;
        public void combodoldur()
        {
            dt_arac = new DataTable();
            da_rapor.Fill(dt_arac);
            for (int s = 0; s < dt_arac.Rows.Count; s++)
            {
                caract.Items.Add(dt_arac.Rows[s].ItemArray[1].ToString());

            }

        }
        int[] plaka;
        //int[] csaati;
        private void caract_SelectedIndexChanged(object sender, EventArgs e)
        {
            caracp.Items.Clear();
            MySqlCommand cmd_suz = new MySqlCommand("Select * from arac where AracT='" + caract.Text + "'", conn);
            MySqlDataAdapter da_suz = new MySqlDataAdapter();
            da_suz.SelectCommand = cmd_suz;
            dt_arac = new DataTable();
            da_suz.Fill(dt_arac);
            plaka = new int[dt_arac.Rows.Count];
            for (int s = 0; s < dt_arac.Rows.Count; s++)
            {
                caracp.Items.Add(dt_arac.Rows[s].ItemArray[1].ToString());
                plaka[s] = Convert.ToInt32(dt_arac.Rows[s].ItemArray[0].ToString());
               // csaati[s] = Convert.ToInt32(dt_arac.Rows[s].ItemArray[3].ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                int sec = caracp.SelectedIndex;
                MySqlCommand cmd_rpr = new MySqlCommand("Select * from ikmal where AracId='" + plaka[sec] + "'", conn);
                MySqlDataAdapter da_rpr = new MySqlDataAdapter();
                da_rpr.SelectCommand = cmd_rpr;
                DataTable dt_rpr = new DataTable();
                da_rpr.Fill(dt_rpr);


                DataTable table = new DataTable();
                table.Columns.Add("Araç", typeof(int));
                table.Columns.Add("Çalıştığı Süre", typeof(int));
                table.Columns.Add("Yaktığı Miktar", typeof(int));
                table.Columns.Add("Birim Yakıtı", typeof(double));
                table.Columns.Add("Tarih", typeof(string));
                for (int s = 0; s < dt_rpr.Rows.Count; s++)
                {
                    if (dt_rpr.Rows.Count != 1 && s != 0)
                    {
                        int csaati = Convert.ToInt32(dt_rpr.Rows[s].ItemArray[5].ToString()) - Convert.ToInt32(dt_rpr.Rows[s - 1].ItemArray[5].ToString());
                        int mevcuts = Convert.ToInt32(dt_rpr.Rows[s].ItemArray[4].ToString());
                        int mevcuto = Convert.ToInt32(dt_rpr.Rows[s - 1].ItemArray[4].ToString());
                        int miktaro = Convert.ToInt32(dt_rpr.Rows[s - 1].ItemArray[3].ToString());
                        double sonuc = (double)(mevcuto + miktaro - mevcuts) / csaati;
                        string tarih = dt_rpr.Rows[s].ItemArray[6].ToString();
                        //MessageBox.Show(sonuc.ToString()); MessageBox.Show(csaati.ToString());
                        table.Rows.Add(1, csaati, mevcuto + miktaro - mevcuts, sonuc, tarih);

                    }
                }

                dataGridView1.DataSource = table;
                dataGridView1.Columns[0].Visible = false;
            }
            catch { }
        }
    }
}
