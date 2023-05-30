using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace YakıtTakip
{
    public partial class FrmMain : Form
    {
        MySqlDataAdapter da_depo,da_arac,da_arac2,da_personel,da_ikmal;
        DataTable dt_ikmal;
        MySqlConnection conn;
        int[] plaka;
        public FrmMain()
        {
            InitializeComponent();
            MySqlConnectionStringBuilder bag = new MySqlConnectionStringBuilder();
            bag.Server = "localhost";
            bag.UserID = "root";
            bag.Password = "";
            bag.Database = "YTakip";
            conn = new MySqlConnection(bag.ToString());
            MySqlCommand cmd_depo_sel = new MySqlCommand("Select * from depo", conn);
           
            /*
            MySqlCommand cmd_depo_upd = new MySqlCommand("Update depo set Y1=@Y1, Y2=@Y2,Y3=@Y3 where DId=1",conn);
            cmd_depo_upd.Parameters.Add("@Y1", MySqlDbType.Int32, 11, "Y1");
            cmd_depo_upd.Parameters.Add("@Y2", MySqlDbType.Int32, 11, "Y2");
            cmd_depo_upd.Parameters.Add("@Y3", MySqlDbType.Int32, 11, "Y3");
            */
            da_depo = new MySqlDataAdapter();
            da_depo.SelectCommand = cmd_depo_sel;
           // da_depo.UpdateCommand = cmd_depo_upd;
            MySqlCommand cmd_arac_sel = new MySqlCommand("Select * from arac", conn);
            da_arac = new MySqlDataAdapter();
            da_arac.SelectCommand = cmd_arac_sel;

            MySqlCommand cmd_arac2_sel = new MySqlCommand("Select DISTINCT AracT, AracT from arac", conn);
            da_arac2 = new MySqlDataAdapter();
            da_arac2.SelectCommand = cmd_arac2_sel;

            MySqlCommand cmd_arac_ins = new MySqlCommand("insert into arac(AracP,AracT,CSaati) values(@plaka,@turu,@saati);",conn);
            cmd_arac_ins.Parameters.Add("@plaka",MySqlDbType.VarChar,50,"AracP");
            cmd_arac_ins.Parameters.Add("@turu",MySqlDbType.VarChar,50,"AracT");
            cmd_arac_ins.Parameters.Add("@saati",MySqlDbType.Int32,11,"CSaati");
            MySqlCommand cmd_arac_del = new MySqlCommand("delete from arac where AracId=@AracId",conn);
            cmd_arac_del.Parameters.Add("@AracId", MySqlDbType.Int32, 11, "AracId");
            MySqlCommand cmd_arac_upt = new MySqlCommand("Update arac set AracP=@AracP, AracT=@AracT, Csaati=@CSaati where AracId=@AracId", conn);
            cmd_arac_upt.Parameters.Add("@AracP", MySqlDbType.VarChar, 50, "AracP");
            cmd_arac_upt.Parameters.Add("@AracT", MySqlDbType.VarChar, 50, "AracT");
            cmd_arac_upt.Parameters.Add("@CSaati", MySqlDbType.Int32, 11, "CSaati");
            cmd_arac_upt.Parameters.Add("@AracId", MySqlDbType.Int32, 11, "AracId");

            da_arac.UpdateCommand = cmd_arac_upt;
            da_arac.DeleteCommand = cmd_arac_del;
            da_arac.InsertCommand = cmd_arac_ins;

            //*********************************************************
            MySqlCommand cmd_pers_sel = new MySqlCommand("Select * from personel",conn);
            MySqlCommand cmd_pers_ins = new MySqlCommand("insert into personel(PId,PAd) values(@PId,@PAd)",conn);
            cmd_pers_ins.Parameters.Add("@PId", MySqlDbType.Int32, 11, "PId");
            cmd_pers_ins.Parameters.Add("@PAd", MySqlDbType.VarChar, 50, "PAd");
            MySqlCommand cmd_pers_del = new MySqlCommand("delete from personel where PId=@PId", conn);
            cmd_pers_del.Parameters.Add("@PId", MySqlDbType.Int32, 11, "PId");
            //MySqlCommand cmd_pers_upt = new MySqlCommand("Update personel set PId=@PId, PAd=@PAd where PId=@PId", conn);

            da_personel = new MySqlDataAdapter();

            da_personel.SelectCommand = cmd_pers_sel;
            da_personel.InsertCommand = cmd_pers_ins;
            da_personel.DeleteCommand = cmd_pers_del;
           
            //*********************************************************

            MySqlCommand cmd_ikmal_sel = new MySqlCommand("Select IkmalId,ikmal.AracId, AracP,YTuru,Miktar,Mevcut,ikmal.CSaati, Tarih, PAd, ikmal.PId from ikmal,arac,personel where ikmal.PId=personel.PId and ikmal.AracId=arac.AracId",conn);
            da_ikmal=new MySqlDataAdapter();
            da_ikmal.SelectCommand = cmd_ikmal_sel;

            MySqlCommand cmd_ikmal_ins = new MySqlCommand("Insert into ikmal(AracId,YTuru,Miktar,Mevcut,CSaati,Tarih,PId) values(@AracId,@YTuru,@Miktar,@Mevcut,@CSaati,@Tarih,@PId)",conn);
            cmd_ikmal_ins.Parameters.Add("@AracId",MySqlDbType.Int32,11,"AracId");
            cmd_ikmal_ins.Parameters.Add("@YTuru",MySqlDbType.VarChar,50,"YTuru");
            cmd_ikmal_ins.Parameters.Add("@Miktar",MySqlDbType.Int32,11,"Miktar");
            cmd_ikmal_ins.Parameters.Add("@Mevcut",MySqlDbType.Int32,11,"Mevcut");
            cmd_ikmal_ins.Parameters.Add("@CSaati",MySqlDbType.Int32,11,"CSaati");
            cmd_ikmal_ins.Parameters.Add("@Tarih", MySqlDbType.VarChar, 50, "Tarih");
            cmd_ikmal_ins.Parameters.Add("@PId",MySqlDbType.Int32,11,"PId");
            da_ikmal.InsertCommand = cmd_ikmal_ins;

            dt_ikmal = new DataTable();
            da_ikmal.Fill(dt_ikmal);

            ikmal();
            conn.Open();
            combodoldur();
            depo();
        }
        public void ikmal()
        {
           
            dataGridView1.DataSource = dt_ikmal;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[8].Visible = false;
        }
        DataTable dt_arac;
        public void combodoldur()
        {
            dt_arac = new DataTable();
            da_arac2.Fill(dt_arac);
            for (int s = 0; s < dt_arac.Rows.Count; s++)
            {
                caract.Items.Add(dt_arac.Rows[s].ItemArray[1].ToString());
               
            }
            
        }
        public void depo()
        {
            DataTable dt = new DataTable();
            da_depo.Fill(dt);
            for (int satir = 0; satir < dt.Rows.Count; satir++)
            {
                lyakit.Text = dt.Rows[satir].ItemArray[1].ToString();
                lyag1.Text = dt.Rows[satir].ItemArray[2].ToString();
                lyag2.Text = dt.Rows[satir].ItemArray[3].ToString();
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void araçTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            arac arc = new arac(da_arac);
            arc.ShowDialog();
        }

        private void personelTanımlaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personel prsnl = new Personel(da_personel);
            prsnl.ShowDialog();
        }

        private void depoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Depo dp = new Depo(da_depo, conn);
            dp.ShowDialog();
            depo();
        }

        private void raporlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Raporlama rpr = new Raporlama(da_arac2,conn);
            rpr.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
            
        }

        private void caract_SelectedIndexChanged(object sender, EventArgs e)
        {
            caracp.Items.Clear();
            MySqlCommand cmd_suz = new MySqlCommand("Select * from arac with(nolock) where AracT='"+caract.Text+"'",conn);
            MySqlDataAdapter da_suz = new MySqlDataAdapter();
            da_suz.SelectCommand = cmd_suz;
            dt_arac = new DataTable();
            da_suz.Fill(dt_arac);
            plaka = new int[dt_arac.Rows.Count];
            for (int s = 0; s < dt_arac.Rows.Count; s++)
            {
                caracp.Items.Add(dt_arac.Rows[s].ItemArray[1].ToString());
                plaka[s] = Convert.ToInt32(dt_arac.Rows[s].ItemArray[0].ToString());
                

            }
            
        }

        private void label16_Click(object sender, EventArgs e)
        {
            if (tpsicil.Text != "")
            {
                try
                {
                    MySqlCommand cmd_per_bul = new MySqlCommand("Select PAd from personel with(nolock) where PId='" + tpsicil.Text + "'", conn);

                    tpisim.Text = cmd_per_bul.ExecuteScalar().ToString();

                }
                catch (Exception)
                {
                }
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "";
            int secilen = caracp.SelectedIndex;
            if (secilen > -1)
            {
                int depo = 0;
                if (cyakit.Text == "") { }
                else if (cyakit.Text == "Yakıt")
                { 
                    depo = Convert.ToInt32(lyakit.Text.ToString());
                    sorgu = "Update depo set Y1=@Y1 where 1=1";
                }
                else if (cyakit.Text == "Motor Yağı")
                {
                    depo = Convert.ToInt32(lyag1.Text.ToString());
                    sorgu = "Update depo set Y2=@Y1 where 1=1";
                }
                else
                {
                    depo = Convert.ToInt32(lyag2.Text.ToString());
                    sorgu = "Update depo set Y3=@Y1 where 1=1";
                }

                if (depo > Convert.ToInt32(tmiktar.Text))
                {
                    DataRow dr = dt_ikmal.NewRow();
                   
                    dr["AracId"] = Convert.ToInt32(plaka[secilen]);
                    dr["YTuru"] = cyakit.Text;
                    dr["Miktar"] = Convert.ToInt32(tmiktar.Text);
                    dr["Mevcut"] = Convert.ToInt32(tmevcut.Text);
                    dr["CSaati"] = Convert.ToInt32(tcsaati.Text);
                    dr["Tarih"] = Convert.ToString(DateTime.Now);
                    dr["PId"] = Convert.ToInt32(tpsicil.Text);
                    dt_ikmal.Rows.Add(dr);
                    da_ikmal.Update(dt_ikmal);
                    ikmal();

                    int yenidepo = depo-Convert.ToInt32(tmiktar.Text);
                    MySqlCommand cmd2 = new MySqlCommand(sorgu, conn);
                    cmd2.Parameters.AddWithValue("@Y1", yenidepo);
                    cmd2.ExecuteNonQuery();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(DateTime.Now));
        }
    }
}
