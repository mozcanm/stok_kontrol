using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Microsoft.Reporting.WinForms;
using System.Runtime.InteropServices;

namespace StokKontrol
{
    public partial class Form1 : Form
    {
        readonly OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=KaleStok.accdb");

        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        public static DataTable tablePr = new DataTable();

        bool d1 = false;
        decimal cariToplam = 0;
        public Form1()
        {
            InitializeComponent();
            //Eser Tablosunu Listeletiyoruz, aynı stok no dan almamasi icun islemler yaptiracagiz
            OleDbDataAdapter adpG1 = new OleDbDataAdapter("select * from Eser", baglanti);
            DataTable dtG1 = new DataTable();
            adpG1.Fill(dtG1);
            dgvGizli.DataSource = dtG1;
            dgvGizli.Visible = false;
            numSatisFiyat.Visible = false;
            numSatisAdetGuncelle2.Visible = false;
            reportViewer1.Visible = false;

            Listele_Tur();

            //ListeleCari
            OleDbDataAdapter adpCari = new OleDbDataAdapter("select SatId, Eser.UrunAd as [Ürün], Adet, Fiyat, Toplam, Tarih, Kim from Sat INNER JOIN Eser ON Sat.EserId = Eser.EserId order by UrunAd", baglanti);
            DataTable dtCari = new DataTable();
            adpCari.Fill(dtCari);
            dgvCari.DataSource = dtCari;
            dgvCari.Columns["SatId"].Visible = dgvCari.Columns["Kim"].Visible = false;
            dgvCari.Columns[2].DefaultCellStyle.Alignment = dgvCari.Columns[3].DefaultCellStyle.Alignment = dgvCari.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            cmbCari.Items.Add("TÜMÜ");
            if (dgvCari.RowCount > 0)
            {
                cmbCari.Items.Add(dgvCari.Rows[0].Cells[6].Value);
            }
            cmbCari.SelectedIndex = 0;           
            for (int i = 1; i < dgvCari.RowCount; i++)
            {
                if (dgvCari.Rows[i].Cells[6].Value != dgvCari.Rows[i-1].Cells[6].Value)
                {
                    cmbCari.Items.Add(dgvCari.Rows[i].Cells[6].Value);
                }               
            }
            for (int i = 0; i < dgvCari.RowCount; i++)
            {
                cariToplam += (decimal)dgvCari.Rows[i].Cells[4].Value;
            }
            lblCariToplam.Text = String.Format("{0:N}\n", cariToplam);

            //Listele BarkodÜrün
            OleDbDataAdapter adpBarkod = new OleDbDataAdapter("select UrunAd as [Ürün], Barkod from Eser order by Barkod", baglanti);
            DataTable dtBarkod = new DataTable();
            adpBarkod.Fill(dtBarkod);
            dgvBarkodUrun.DataSource = dtBarkod;

            //Listele Ürün
            OleDbDataAdapter adp = new OleDbDataAdapter("select UrunId, Urun.TurId as [TurId], Tur.TurAd as [Tür], Urun.EserId, Eser.UrunAd as [Ürün], Adet, Gelis as [Geliş], Fiyat, Kart, Tarih, Urun.FirmaId as [FirmaId], Firma.FirmaAd as [Firma] from ((Urun INNER JOIN Tur ON Urun.TurId = Tur.TurId) INNER JOIN Firma ON Urun.FirmaId = Firma.FirmaId) INNER JOIN Eser ON Urun.EserId = Eser.EserId order by TurAd, UrunAd", baglanti);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvUrun.DataSource = dt;
            dgvUrun.Columns["UrunId"].Visible = dgvUrun.Columns["TurId"].Visible = dgvUrun.Columns["EserId"].Visible = dgvUrun.Columns["FirmaId"].Visible = false;

            dgvUrun.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            int dW2 = (int)(dgvUrun.Width * 0.15); //tür
            int dW4 = (int)(dgvUrun.Width * 0.45); //ürün
            int dW5 = (int)(dgvUrun.Width * 0.08); //adet
            int dW6 = (int)(dgvUrun.Width * 0.1); //geliş

            int dW7 = (int)(dgvUrun.Width * 0.1); // fiyat
            int dW8 = (int)(dgvUrun.Width * 0.1); //kart
            int dW9 = (int)(dgvUrun.Width * 0.1); //tarih
            int dW11 = (int)(dgvUrun.Width * 0.15); //firma
            dgvUrun.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            dgvUrun.Columns[2].Width = dW2;
            dgvUrun.Columns[4].Width = dW4;
            dgvUrun.Columns[5].Width = dW5;
            dgvUrun.Columns[6].Width = dW6;
            dgvUrun.Columns[7].Width = dW7;
            dgvUrun.Columns[8].Width = dW8;
            dgvUrun.Columns[9].Width = dW9;
            dgvUrun.Columns[11].Width = dW11;

            dgvUrun.Columns[5].HeaderCell.Style.Alignment = dgvUrun.Columns[5].DefaultCellStyle.Alignment = dgvUrun.Columns[7].HeaderCell.Style.Alignment = dgvUrun.Columns[7].DefaultCellStyle.Alignment = dgvUrun.Columns[6].HeaderCell.Style.Alignment = dgvUrun.Columns[6].DefaultCellStyle.Alignment = dgvUrun.Columns[8].HeaderCell.Style.Alignment = dgvUrun.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //Listele Stok
            OleDbDataAdapter adp2 = new OleDbDataAdapter("select StokId, Stok.TurId as [TurId], Tur.TurAd as [Tür], Stok.EserId as [EserId], Eser.UrunAd as [Ürün], Adet as [Stok], Fiyat, Kart from (Stok INNER JOIN Tur ON Stok.TurId = Tur.TurId) INNER JOIN Eser ON Stok.EserId = Eser.EserId order by TurAd, UrunAd", baglanti);

            DataTable dt2 = new DataTable();
            adp2.Fill(dt2);
            dgvStok.DataSource = dt2;


            if (dgvStok.Rows.Count > 0)
            {
                dgvStok.Columns["StokId"].Visible = dgvStok.Columns["TurId"].Visible = dgvStok.Columns["EserId"].Visible = false;

                dgvStok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                int dWs2 = (int)(dgvStok.Width * 0.18);
                int dWs4 = (int)(dgvStok.Width * 0.40);
                int dWs5 = (int)(dgvStok.Width * 0.07);
                int dWs6 = (int)(dgvStok.Width * 0.12);
                int dWs7 = (int)(dgvStok.Width * 0.12);
                dgvStok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                dgvStok.Columns[2].Width = dWs2;
                dgvStok.Columns[4].Width = dWs4;
                dgvStok.Columns[5].Width = dWs5;
                dgvStok.Columns[6].Width = dWs6;
                dgvStok.Columns[7].Width = dWs7;

                dgvStok.Columns[5].DefaultCellStyle.Alignment = dgvStok.Columns[5].HeaderCell.Style.Alignment = dgvStok.Columns[6].DefaultCellStyle.Alignment = dgvStok.Columns[6].HeaderCell.Style.Alignment = dgvStok.Columns[7].DefaultCellStyle.Alignment = dgvStok.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            Listele_Firma();
            cmbListele();
            cmbTurUrunListele();
            cmbListeleFirma();
            Listele_Eser();
            cmbUrunAdListele();
        }

        private void cmbListele()
        {
            //ComboBox Tür için Listele
            OleDbDataAdapter adp = new OleDbDataAdapter("select TurId, TurAd from Tur order by TurAd", baglanti);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cmbTur.DataSource = ds.Tables[0];
            cmbTur.DisplayMember = "TurAd";
            cmbTur.ValueMember = "TurId";
        }



        private void cmbListeleFirma()
        {
            //ComboBox Firma için Listele
            OleDbDataAdapter adp = new OleDbDataAdapter("select FirmaId, FirmaAd from Firma order by FirmaAd", baglanti);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cmbFirma.DataSource = ds.Tables[0];
            cmbFirma.DisplayMember = "FirmaAd";
            cmbFirma.ValueMember = "FirmaId";
        }

        private void cmbTurUrunListele()
        {
            //ComboBox Tür için Listele
            OleDbDataAdapter adp = new OleDbDataAdapter("select TurId, TurAd from Tur order by TurAd", baglanti);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cmbTurUrun.DataSource = ds.Tables[0];
            cmbTurUrun.DisplayMember = "TurAd";
            cmbTurUrun.ValueMember = "TurId";
        }
        private void Listele_Eser()
        {
            string ifade = "select EserId, UrunAd as [Ürün], Barkod from Eser where TurId = " + cmbTurUrun.SelectedValue + " order by UrunAd";
            OleDbDataAdapter adp = new OleDbDataAdapter(ifade, baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvEser.DataSource = dt;
            dgvEser.Columns["EserId"].Visible = dgvEser.Columns["Barkod"].Visible = false;
        }

        private void cmbUrunAdListele()
        {
            string ifade = "select * from Eser where TurId = " + cmbTur.SelectedValue + " order by UrunAd";
            OleDbDataAdapter adp = new OleDbDataAdapter(ifade, baglanti);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            cmbUrunAd.DataSource = ds.Tables[0];
            cmbUrunAd.DisplayMember = "UrunAd";
            cmbUrunAd.ValueMember = "EserId";
        }
        private void btnEkleTur_Click(object sender, EventArgs e)
        {
            if (txtTur.Text != null && txtTur.Text != "")
            {
                //Ekle
                OleDbCommand cmd = new OleDbCommand("insert into Tur(TurAd) values(@turAd)", baglanti);

                cmd.Parameters.AddWithValue("@turAd", txtTur.Text);

                baglanti.Open();
                cmd.ExecuteNonQuery();
                baglanti.Close();

                //Listele
                Listele_Tur();
                cmbTurUrunListele();
                cmbListele();
                txtTur.Text = "";
            }
        }

        private void Listele_Tur()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter("select TurId, TurAd as [Tür] from Tur order by TurAd", baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvTur.DataSource = dt;
            dgvTur.Columns["TurId"].Visible = false;
        }

        private void Listele_Firma()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter("select FirmaId, FirmaAd as [Firma] from Firma order by FirmaAd", baglanti);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvFirma.DataSource = dt;
            dgvFirma.Columns["FirmaId"].Visible = false;
        }

        private void Listele_Stok()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter("select StokId, Stok.TurId as [TurId], Tur.TurAd as [Tür], Stok.EserId as [EserId], Eser.UrunAd as [Ürün], Adet as [Stok], Fiyat, Kart from (Stok INNER JOIN Tur ON Stok.TurId = Tur.TurId) INNER JOIN Eser ON Stok.EserId = Eser.EserId order by TurAd, UrunAd", baglanti);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvStok.DataSource = dt;
            if (dgvStok.Rows.Count > 0)
            {
                dgvStok.Columns["StokId"].Visible = dgvStok.Columns["TurId"].Visible = dgvStok.Columns["EserId"].Visible = false;
            }

        }

        private void Listele_Urun()
        {
            OleDbDataAdapter adp = new OleDbDataAdapter("select UrunId, Urun.TurId as [TurId], Tur.TurAd as [Tür], Urun.EserId, Eser.UrunAd as [Ürün], Adet, Gelis as [Geliş], Fiyat, Kart, Tarih, Urun.FirmaId as [FirmaId], Firma.FirmaAd as [Firma] from ((Urun INNER JOIN Tur ON Urun.TurId = Tur.TurId) INNER JOIN Firma ON Urun.FirmaId = Firma.FirmaId) INNER JOIN Eser ON Urun.EserId = Eser.EserId order by TurAd, UrunAd", baglanti);

            DataTable dt = new DataTable();
            adp.Fill(dt);
            dgvUrun.DataSource = dt;

            dgvUrun.Columns["UrunId"].Visible = dgvUrun.Columns["TurId"].Visible = dgvUrun.Columns["EserId"].Visible = dgvUrun.Columns["FirmaId"].Visible = false;
        }

        private void Temizle_Urun()
        {
            //txtUrunAd.Text = "";
            numUrunAdet.Value = 1;
            txtUrunGelis.Text = "0";
            txtUrunFiyat.Text = "0";
            txtUrunKart.Text = "0";
            dtpUrunTarih.Text = DateTime.Now.ToString("d/M/yyyy");
            cmbUrunAd.Tag = null;
        }

        private void dgvTur_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dGVRow in this.dgvTur.Rows)
            {
                dGVRow.HeaderCell.Value = String.Format("{0}", dGVRow.Index + 1);
            }
            //Genişlik Ayarı
            this.dgvTur.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void btnSilTur_Click(object sender, EventArgs e)
        {
            //TÜR SİL
            if (dgvTur.Rows.Count > 0)
            {
                //int tID = (int)txtTur.Tag;

                if (txtTur.Text == null || txtTur.Text == "" || txtTur.Tag == null)
                {
                    MessageBox.Show("Tür seçili değil..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Açıklamalar 
                    int aId2 = dgvTur.SelectedRows[0].Index;
                    string aId = (aId2 + 1).ToString();

                    DialogResult sonuc = MessageBox.Show("Satır No: " + aId + "\n" + "Ürün Adı: " + txtTur.Text + "\n" + "\n" + "Bu Tür e ait olan Ürün ler de silinecek! Lütfen silmeden evvel ilgili Tür ile kayıt edilmiş Ürün varsa Ürün ün silinmemesi için Ürün Giriş ekranından Ürün ün Tür ünü değiştiriniz." + "\n" + "\n" + "Silinsin mi?", "Sil?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (sonuc == DialogResult.Yes)
                    {
                        OleDbCommand cmd = new OleDbCommand("delete from Tur where TurId=@tid", baglanti);
                        OleDbCommand cmd2 = new OleDbCommand("delete from Urun where TurId=@tid", baglanti);

                        cmd.Parameters.AddWithValue("@tid", (int)txtTur.Tag);
                        cmd2.Parameters.AddWithValue("@tid", (int)txtTur.Tag);

                        baglanti.Open();
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        baglanti.Close();

                        //Listele
                        Listele_Tur();
                        cmbTurUrunListele();
                        cmbListele();
                        Listele_Urun();
                        Listele_Stok();
                        txtTur.Tag = null;
                        txtTur.Text = "";
                    }
                }
            }
        }

        private void dgvTur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvTur.CurrentRow;
            if (row != null)
            {
                txtTur.Tag = row.Cells["TurId"].Value;
                txtTur.Text = row.Cells["Tür"].Value.ToString();
            }
        }

        private void btnGuncelleTur_Click(object sender, EventArgs e)
        {
            // TÜR GÜNCELLE
            if (dgvTur.Rows.Count > 0 && txtTur.Text != null && txtTur.Text != "" && txtTur.Tag != null)
            {
                //Açıklamalar   
                int aId2 = dgvTur.SelectedRows[0].Index;
                string aId = (aId2 + 1).ToString();
                string tAd = dgvTur.SelectedCells[1].Value.ToString();

                DialogResult sonuc = MessageBox.Show("Satır No: " + aId + "\n" + "Tür: " + tAd + "\n" + "\n" + "Aşağıdaki yeni veri ile," + "\n" + "\n" + "Tür: " + txtTur.Text + "\n" + "\n" + "Güncellensin mi?", "Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand("Update Tur set TurAd=@tad where TurId=@tid", baglanti);

                    cmd.Parameters.AddWithValue("@tad", txtTur.Text);
                    cmd.Parameters.AddWithValue("@tid", (int)txtTur.Tag); //en son yazılsın ki id yi alabilsin

                    baglanti.Open();
                    cmd.ExecuteNonQuery();
                    baglanti.Close();

                    //Listele
                    Listele_Tur();
                    cmbTurUrunListele();
                    cmbListele();
                    Listele_Urun();
                    Listele_Stok();
                    txtTur.Text = "";
                    txtTur.Tag = null;
                }
            }
        }

        private void txtUrunFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // decimal için virgül
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtUrunGelis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // decimal için virgül
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgvUrun_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dGVRow in this.dgvUrun.Rows)
            {
                dGVRow.HeaderCell.Value = String.Format("{0}", dGVRow.Index + 1);
            }
            //Genişlik Ayarı
            this.dgvUrun.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (cmbTur.SelectedIndex.ToString() == null && cmbTur.SelectedIndex.ToString() == "" && cmbTur.SelectedIndex.ToString() == "-1" && cmbFirma.SelectedIndex.ToString() == null && cmbFirma.SelectedIndex.ToString() == "" && cmbFirma.SelectedIndex.ToString() == "-1" && cmbUrunAd.SelectedIndex.ToString() == null && cmbUrunAd.SelectedIndex.ToString() == "" && cmbUrunAd.SelectedIndex.ToString() == "-1")
            {
                MessageBox.Show("Lütfen Tür veya Firma veya Ürün seçelim..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                //Ekle
                OleDbCommand cmd = new OleDbCommand("insert into Urun(TurId,EserId,Adet,Gelis,Fiyat,Kart,[Tarih],FirmaId) values(@turid,@urunad,@adet,@gelis,@fiyat,@kart,@tarih,@firmaid)", baglanti);

                cmd.Parameters.AddWithValue("@turid", cmbTur.SelectedValue);
                cmd.Parameters.AddWithValue("@urunad", cmbUrunAd.SelectedValue);
                cmd.Parameters.AddWithValue("@adet", numUrunAdet.Value);
                cmd.Parameters.AddWithValue("@gelis", txtUrunGelis.Text);
                cmd.Parameters.AddWithValue("@fiyat", txtUrunFiyat.Text);
                cmd.Parameters.AddWithValue("@kart", txtUrunKart.Text);
                cmd.Parameters.AddWithValue("@tarih", dtpUrunTarih.Text);
                cmd.Parameters.AddWithValue("@firmaid", cmbFirma.SelectedValue);


                baglanti.Open();
                cmd.ExecuteNonQuery();
                baglanti.Close();

                

                //STOKTA İLGİLİ YER VARSA GÜNCELLE YOKSA EKLE                

                bool varMi = false;
                int stokId = 0;
                int stokAdet = 0;

                for (int i = 0; i < dgvStok.RowCount; i++)
                {
                    if ((int)dgvStok.Rows[i].Cells["EserId"].Value == (int)cmbUrunAd.SelectedValue)
                    {
                        varMi = true;
                        if (varMi == true)
                        {
                            stokId = (int)dgvStok.Rows[i].Cells["StokId"].Value;
                            stokAdet = (int)dgvStok.Rows[i].Cells["Stok"].Value;
                        }
                    }
                }

                if (varMi == false)
                {
                    //EKLE - STOK
                    OleDbCommand cmd2 = new OleDbCommand("insert into Stok(TurId,EserId,Adet,Fiyat,Kart) values(@turid,@eserid,@adet,@fiyat,@kart)", baglanti);

                    cmd2.Parameters.AddWithValue("@turid", cmbTur.SelectedValue);
                    cmd2.Parameters.AddWithValue("@eserid", cmbUrunAd.SelectedValue);
                    cmd2.Parameters.AddWithValue("@adet", numUrunAdet.Value);
                    cmd2.Parameters.AddWithValue("@fiyat", txtUrunFiyat.Text);
                    cmd2.Parameters.AddWithValue("@kart", txtUrunKart.Text);

                    baglanti.Open();
                    cmd2.ExecuteNonQuery();
                    baglanti.Close();
                }
                else if (varMi == true)
                {
                    //GÜNCELLE - STOK
                    OleDbCommand cmd3 = new OleDbCommand("Update Stok set TurId=@tid, EserId=@uad, Adet=@uadet, Fiyat=@ufiyat, Kart=@ukart where StokId=@sid", baglanti);

                    cmd3.Parameters.AddWithValue("@tid", cmbTur.SelectedValue);
                    cmd3.Parameters.AddWithValue("@uad", cmbUrunAd.SelectedValue);
                    cmd3.Parameters.AddWithValue("@uadet", (stokAdet + numUrunAdet.Value));
                    cmd3.Parameters.AddWithValue("@ufiyat", txtUrunFiyat.Text);
                    cmd3.Parameters.AddWithValue("@ukart", txtUrunKart.Text);
                    cmd3.Parameters.AddWithValue("@sid", stokId); //en son yazılsın ki id yi alabilsin

                    baglanti.Open();
                    cmd3.ExecuteNonQuery();
                    baglanti.Close();
                }
                ///// STOKLA İLGİLİ YER VARSA GÜNCELLE YOKSA EKLE - SON //////

                Temizle_Urun();
                Listele_Urun();
                Listele_Stok();
            }
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            //ÜRÜN SİL
            if (dgvUrun.Rows.Count > 0)
            {
                if (cmbUrunAd.Tag == null || cmbUrunAd.SelectedItem == null || cmbUrunAd.SelectedIndex == -1)
                {
                    MessageBox.Show("Ürün seçili değil..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Açıklamalar   
                    int aId2 = dgvUrun.SelectedRows[0].Index;
                    string aId = (aId2 + 1).ToString();
                    var eid = cmbUrunAd.SelectedValue;

                    DialogResult sonuc = MessageBox.Show("Satır No: " + aId + "\n" + "Ürün Adı: " + dgvUrun.SelectedCells[4].Value + "\n" + "Adet: " + numUrunAdet.Text + "\n" + "Geliş: " + txtUrunGelis.Text + "\n" + "Fiyat: " + txtUrunFiyat.Text + "\n" + "Tarih: " + dtpUrunTarih.Text + "\n" + "\n" + "Silinsin mi?", "Sil?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (sonuc == DialogResult.Yes)
                    {
                        OleDbCommand cmd = new OleDbCommand("delete from Urun where UrunId=@uid", baglanti);

                        cmd.Parameters.AddWithValue("@uid", (int)cmbUrunAd.Tag);

                        baglanti.Open();
                        cmd.ExecuteNonQuery();
                        baglanti.Close();

                        //Listele
                        Listele_Urun();

                        /*
                        int toplam1 = 0;
                        for (int i = 0; i < dgvUrun.RowCount; i++)
                        {
                            if ((int)dgvUrun.Rows[i].Cells["EserId"].Value == (int)cmbUrunAd.SelectedValue)
                            {
                                toplam1 += (int)dgvUrun.Rows[i].Cells["Adet"].Value;
                            }
                        }
                        
                        //STOKTA İLGİLİ YER KALIRSA GÜNCELLE YOKSA STOKTAN SİL//

                        //STOKTA İLGİLİ YER VARSA GÜNCELLE YOKSA EKLE                

                        bool varMi = true;
                        int stokId = 0;
                        int stokAdet = 0;
                        int toplam2 = 0;
                        int ekleCikar = 0;

                        for (int i = 0; i < dgvStok.RowCount; i++)
                        {
                            if ((int)dgvStok.Rows[i].Cells["EserId"].Value == (int)cmbUrunAd.SelectedValue)
                            {
                                toplam2 += (int)dgvStok.Rows[i].Cells["Adet"].Value;
                            }
                        }

                        ekleCikar = toplam1 - toplam2;

                        if (toplam1 == 0)
                        {
                            varMi = false;
                        }

                        if (varMi == false)
                        {
                            //SİL - STOK
                            OleDbCommand cmd2 = new OleDbCommand("delete from Stok where EserId=@eid", baglanti);

                            cmd2.Parameters.AddWithValue("@eid", eid);

                            baglanti.Open();
                            cmd2.ExecuteNonQuery();
                            baglanti.Close();
                        }
                        else if (varMi == true)
                        {
                            //GÜNCELLE - STOK
                            for (int i = 0; i < dgvStok.RowCount; i++)
                            {
                                if ((int)dgvStok.Rows[i].Cells["EserId"].Value == (int)cmbUrunAd.SelectedValue)
                                {                                  
                                 stokId = (int)dgvStok.Rows[i].Cells["StokId"].Value;  
                                 stokAdet = (int)dgvStok.Rows[i].Cells["Adet"].Value;
                                }
                            }
                            
                            OleDbCommand cmd3 = new OleDbCommand("Update Stok set Adet=@uadet where StokId=@sid", baglanti);

                            cmd3.Parameters.AddWithValue("@uadet", (stokAdet + ekleCikar));
                            cmd3.Parameters.AddWithValue("@sid", stokId); //en son yazılsın ki id yi alabilsin

                            baglanti.Open();
                            cmd3.ExecuteNonQuery();
                            baglanti.Close();
                        }
                        ///// STOKLA İLGİLİ YER VARSA GÜNCELLE YOKSA EKLE - SON //////

                        // STOKİLA İLGİLİ GÜNCELLEME YOKSA SİL - SON //
                        Listele_Stok();
                        */
                        Temizle_Urun();
                    }
                }
            }
        }

        private void dgvUrun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvUrun.CurrentRow;
            if (row != null)
            {
                cmbTur.SelectedValue = row.Cells["TurId"].Value;
                cmbUrunAdListele();
                cmbFirma.SelectedValue = row.Cells["FirmaId"].Value;
                cmbUrunAd.Tag = row.Cells["UrunId"].Value;
                cmbUrunAd.SelectedValue = row.Cells["EserId"].Value;
                numUrunAdet.Value = (int)row.Cells["Adet"].Value;
                txtUrunGelis.Text = row.Cells["Geliş"].Value.ToString();
                txtUrunFiyat.Text = row.Cells["Fiyat"].Value.ToString();
                txtUrunKart.Text = row.Cells["Kart"].Value.ToString();
                dtpUrunTarih.Text = row.Cells["Tarih"].Value.ToString();
            }
        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            //ÜRÜN GÜNCELLE
            if (dgvUrun.Rows.Count > 0 && cmbUrunAd.SelectedIndex != -1 && cmbUrunAd.Tag != null && numUrunAdet.Value != 0 && cmbTur.SelectedIndex != -1 && cmbTur.SelectedIndex.ToString() != "" && cmbFirma.SelectedIndex != -1 && cmbFirma.SelectedIndex.ToString() != "")
            {
                //Açıklamalar
                string uId = (dgvUrun.SelectedRows[0].Index + 1).ToString();
                string uAd = dgvUrun.SelectedCells[4].Value.ToString();
                string uAdet = dgvUrun.SelectedCells[5].Value.ToString();
                string uGelis = dgvUrun.SelectedCells[6].Value.ToString();
                string uFiyat = dgvUrun.SelectedCells[7].Value.ToString();
                string uKart = dgvUrun.SelectedCells[8].Value.ToString();
                DateTime aTarih2 = (DateTime)dgvUrun.SelectedCells[9].Value;
                string uTarih = aTarih2.ToString("dd/MM/yyyy");
                string uFirma = dgvUrun.SelectedCells[11].Value.ToString();


                DialogResult sonuc = MessageBox.Show("Satır No: " + uId + "\n" + "\n" + "Ürün Adı: " + uAd + "\n" + "Adet: " + uAdet + "\n" + "Geliş: " + uGelis + "\n" + "Fiyat: " + uFiyat + "\n" + "Kart: " + uKart + "\n" + "Tarih: " + uTarih + "\n" + "Firma: " + uFirma + "\n" + "\n" + "Aşağıdaki yeni veri ile," + "\n" + "\n" + "Adet: " + numUrunAdet.Value + "\n" + "Geliş: " + txtUrunGelis.Text + "\n" + "Fiyat: " + txtUrunFiyat.Text + "\n" + "Kart: " + txtUrunKart.Text + "\n" + "Tarih: " + dtpUrunTarih.Text + "\n" + "Firma: " + cmbFirma.Text + "\n" + "\n" + "Güncellensin mi?", "Güncelle?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (sonuc == DialogResult.Yes)
                {
                    int toplam1 = 0;
                    for (int i = 0; i < dgvUrun.RowCount; i++)
                    {
                        if ((int)dgvUrun.Rows[i].Cells["EserId"].Value == (int)cmbUrunAd.SelectedValue)
                        {
                            toplam1 += (int)dgvUrun.Rows[i].Cells["Adet"].Value;
                        }
                    }

                    OleDbCommand cmd = new OleDbCommand("Update Urun set TurId=@tid, EserId=@uad, Adet=@uadet, Gelis=@ugelis, Fiyat=@ufiyat, Kart=@ukart, [Tarih]=@utarih, FirmaId=@fid where UrunId=@uid", baglanti);

                    cmd.Parameters.AddWithValue("@tid", cmbTur.SelectedValue);
                    cmd.Parameters.AddWithValue("@uad", cmbUrunAd.SelectedValue);
                    cmd.Parameters.AddWithValue("@uadet", numUrunAdet.Value);
                    cmd.Parameters.AddWithValue("@ugelis", txtUrunGelis.Text);
                    cmd.Parameters.AddWithValue("@ufiyat", txtUrunFiyat.Text);
                    cmd.Parameters.AddWithValue("@ukart", txtUrunKart.Text);
                    cmd.Parameters.AddWithValue("@utarih", dtpUrunTarih.Text);
                    cmd.Parameters.AddWithValue("@fid", cmbFirma.SelectedValue);
                    cmd.Parameters.AddWithValue("@uid", (int)cmbUrunAd.Tag); //en son yazılsın ki id yi alabilsin

                    baglanti.Open();
                    cmd.ExecuteNonQuery();
                    baglanti.Close();

                    //Listele
                    Listele_Urun();

                    /*
                    //STOKTA İLGİLİ YERi GÜNCELLE
                    int stokId = 0;
                    int stokAdet = 0;
                    int toplam2 = 0;
                    int ekleCikar = 0;
                    for (int i = 0; i < dgvUrun.RowCount; i++)
                    {
                        if ((int)dgvUrun.Rows[i].Cells["EserId"].Value == (int)cmbUrunAd.SelectedValue)
                        {
                            toplam2 += (int)dgvUrun.Rows[i].Cells["Adet"].Value;
                        }
                    }
                    ekleCikar = toplam2 - toplam1;

                    for (int i = 0; i < dgvStok.RowCount; i++)
                    {
                        if ((int)dgvStok.Rows[i].Cells["EserId"].Value == (int)cmbUrunAd.SelectedValue)
                        {
                            stokId = (int)dgvStok.Rows[i].Cells["StokId"].Value;
                            stokAdet = (int)dgvStok.Rows[i].Cells["Adet"].Value;
                        }
                    }
                   
                    OleDbCommand cmd3 = new OleDbCommand("Update Stok set TurId=@tid, EserId=@uad, Adet=@uadet, Fiyat=@ufiyat, Kart=@ukart where StokId=@sid", baglanti);

                    cmd3.Parameters.AddWithValue("@tid", cmbTur.SelectedValue);
                    cmd3.Parameters.AddWithValue("@uad", cmbUrunAd.SelectedValue);
                    cmd3.Parameters.AddWithValue("@uadet", (stokAdet + ekleCikar));
                    cmd3.Parameters.AddWithValue("@ufiyat", txtUrunFiyat.Text);
                    cmd3.Parameters.AddWithValue("@ukart", txtUrunKart.Text);
                    cmd3.Parameters.AddWithValue("@sid", stokId); //en son yazılsın ki id yi alabilsin

                    baglanti.Open();
                    cmd3.ExecuteNonQuery();
                    baglanti.Close();
                    
                    ///// STOKLA İLGİLİ YERi GÜNCELLE  //////

                    Listele_Stok();
                    */
                    Temizle_Urun();
                }
            }
            else
            {
                MessageBox.Show("Boş alanlar mevcut yahut Ürün seçili değil!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEkleFirma_Click(object sender, EventArgs e)
        {
            if (txtFirma.Text != null && txtFirma.Text != "")
            {
                //Ekle
                OleDbCommand cmd = new OleDbCommand("insert into Firma(FirmaAd) values(@firmaAd)", baglanti);

                cmd.Parameters.AddWithValue("@firmaAd", txtFirma.Text);

                baglanti.Open();
                cmd.ExecuteNonQuery();
                baglanti.Close();

                //Listele
                Listele_Firma();
                cmbListeleFirma();
                txtFirma.Text = "";
            }
        }

        private void dgvFirma_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dGVRow in this.dgvFirma.Rows)
            {
                dGVRow.HeaderCell.Value = String.Format("{0}", dGVRow.Index + 1);
            }
            //Genişlik Ayarı
            this.dgvFirma.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void dgvFirma_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvFirma.CurrentRow;
            if (row != null)
            {
                txtFirma.Tag = row.Cells["FirmaId"].Value;
                txtFirma.Text = row.Cells["Firma"].Value.ToString();
            }
        }

        private void btnGuncelleFirma_Click(object sender, EventArgs e)
        {
            // FİRMA GÜNCELLE
            if (dgvFirma.Rows.Count > 0 && txtFirma.Text != null && txtFirma.Text != "" && txtFirma.Tag != null)
            {
                //Açıklamalar   
                int aId2 = dgvFirma.SelectedRows[0].Index;
                string aId = (aId2 + 1).ToString();
                string tAd = dgvFirma.SelectedCells[1].Value.ToString();

                DialogResult sonuc = MessageBox.Show("Satır No: " + aId + "\n" + "Firma Adı: " + tAd + "\n" + "\n" + "Aşağıdaki yeni veri ile," + "\n" + "\n" + "Firma Adı: " + txtFirma.Text + "\n" + "\n" + "Güncellensin mi?", "Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand("Update Firma set FirmaAd=@tad where FirmaId=@tid", baglanti);

                    cmd.Parameters.AddWithValue("@tad", txtFirma.Text);
                    cmd.Parameters.AddWithValue("@tid", (int)txtFirma.Tag);

                    baglanti.Open();
                    cmd.ExecuteNonQuery();
                    baglanti.Close();

                    //Listele
                    Listele_Firma();
                    cmbListeleFirma();
                    Listele_Urun();
                    txtFirma.Text = "";
                    txtFirma.Tag = null;
                }
            }
        }

        private void btnSilFirma_Click(object sender, EventArgs e)
        {
            //FİRMA SİL
            if (dgvFirma.Rows.Count > 0)
            {

                if (txtFirma.Text == null || txtFirma.Text == "" || txtFirma.Tag == null)
                {
                    MessageBox.Show("Firma seçili değil..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Açıklamalar 
                    int aId2 = dgvFirma.SelectedRows[0].Index;
                    string aId = (aId2 + 1).ToString();

                    DialogResult sonuc = MessageBox.Show("Satır No: " + aId + "\n" + "Firma Adı: " + txtFirma.Text + "\n" + "\n" + "Bu Firma ya ait olan Ürün ler de silinecek! Lütfen silmeden evvel ilgili Firma ile kayıt edilmiş Ürün varsa Ürün ün silinmemesi için Ürün Giriş ekranından Ürün ün Firma sını değiştiriniz." + "\n" + "\n" + "Silinsin mi?", "Sil?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (sonuc == DialogResult.Yes)
                    {
                        OleDbCommand cmd = new OleDbCommand("delete from Firma where FirmaId=@tid", baglanti);
                        OleDbCommand cmd2 = new OleDbCommand("delete from Urun where FirmaId=@tid", baglanti);

                        cmd.Parameters.AddWithValue("@tid", (int)txtFirma.Tag);
                        cmd2.Parameters.AddWithValue("@tid", (int)txtFirma.Tag);

                        baglanti.Open();
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        baglanti.Close();

                        //Listele
                        Listele_Firma();
                        cmbListeleFirma();
                        Listele_Urun();
                        txtFirma.Tag = null;
                        txtFirma.Text = "";
                    }
                }
            }
        }

        private void dgvStok_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dGVRow in this.dgvStok.Rows)
            {
                dGVRow.HeaderCell.Value = String.Format("{0}", dGVRow.Index + 1);
            }
            //Genişlik Ayarı
            this.dgvStok.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void txtUrunAra_TextChanged(object sender, EventArgs e)
        {
            if (txtUrunAra.TextLength > 1)
            {
                txtUrunAra.ForeColor = Color.DarkGreen;

                OleDbDataAdapter adp = new OleDbDataAdapter("select UrunId, Urun.TurId as [TurId], Tur.TurAd as [Tür], Urun.EserId, Eser.UrunAd as [Ürün], Adet, Gelis as [Geliş], Fiyat, Kart, Tarih, Urun.FirmaId as [FirmaId], Firma.FirmaAd as [Firma] from ((Urun INNER JOIN Tur ON Urun.TurId = Tur.TurId) INNER JOIN Firma ON Urun.FirmaId = Firma.FirmaId) INNER JOIN Eser ON Urun.EserId = Eser.EserId WHERE UrunAd LIKE '%" + txtUrunAra.Text.ToLower() + "%' OR UrunAd LIKE '%" + txtUrunAra.Text + "%' OR UrunAd LIKE '%" + txtUrunAra.Text.ToUpper() + "%'order by TurAd, UrunAd", baglanti);

                DataTable dt = new DataTable();
                adp.Fill(dt);
                dgvUrun.DataSource = dt;

                dgvUrun.Columns["UrunId"].Visible = dgvUrun.Columns["TurId"].Visible = dgvUrun.Columns["EserId"].Visible = dgvUrun.Columns["FirmaId"].Visible = false;
            }
            else if (txtUrunAra.TextLength == 0)
            {
                Listele_Urun();
            }
            else
            {
                txtUrunAra.ForeColor = Color.DarkRed;
            }
        }

        private void txtStokAra_TextChanged(object sender, EventArgs e)
        {
            if (txtStokAra.TextLength > 1)
            {
                txtStokAra.ForeColor = Color.DarkGreen;
                /*
                OleDbDataAdapter adp = new OleDbDataAdapter("select StokId, Stok.TurId as [TurId], Tur.TurAd as [Tür], Stok.EserId as [EserId], Eser.UrunAd as [Ürün], Adet as [Stok], Fiyat, Kart from (Stok INNER JOIN Tur ON Stok.TurId = Tur.TurId) INNER JOIN Eser ON Stok.EserId = Eser.EserId order by TurAd, UrunAd", baglanti);
                */
                
                OleDbDataAdapter adp = new OleDbDataAdapter("select StokId, Stok.TurId as [TurId], Tur.TurAd as [Tür], Stok.EserId as [EserId], Eser.UrunAd as [Ürün], Adet as [Stok],Fiyat, Kart from(Stok INNER JOIN Tur ON Stok.TurId = Tur.TurId) INNER JOIN Eser ON Stok.EserId = Eser.EserId WHERE UrunAd LIKE '%" + txtStokAra.Text.ToLower() + "%' OR UrunAd LIKE '%" + txtStokAra.Text + "%' OR UrunAd LIKE '%" + txtStokAra.Text.ToUpper() + "%' order by TurAd, UrunAd", baglanti);
                
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dgvStok.DataSource = dt;
                dgvStok.Columns["EserId"].Visible = dgvStok.Columns["TurId"].Visible = false;

            }
            else if (txtStokAra.TextLength == 0)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter("select StokId, Stok.TurId as [TurId], Tur.TurAd as [Tür], Stok.EserId as [EserId], Eser.UrunAd as [Ürün], Adet as [Stok], Fiyat, Kart from (Stok INNER JOIN Tur ON Stok.TurId = Tur.TurId) INNER JOIN Eser ON Stok.EserId = Eser.EserId order by TurAd, UrunAd", baglanti);

                DataTable dt = new DataTable();
                adp.Fill(dt);
                dgvStok.DataSource = dt;
                dgvStok.Columns["EserId"].Visible = dgvStok.Columns["TurId"].Visible = false;
            }
            else
            {
                txtStokAra.ForeColor = Color.DarkRed;
            }
        }

        private void btnExcelUrun_Click(object sender, EventArgs e)
        {
            if (dgvUrun.Rows.Count > 0)
            {
                //ClosedXml - Version - 0.93.1
                //Dosya ismi
                string fileName;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                    Title = "To Excel",
                    FileName = "Ürün Listesi (" + DateTime.Now.ToString("dd-MM-yyyy") + ")"
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;
                    var workbook = new XLWorkbook();

                    //DataTable Oluştur
                    DataTable dt = new DataTable();

                    //No Sütunu Ekle
                    DataColumn columno = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        AutoIncrement = true,
                        AutoIncrementSeed = 1,
                        AutoIncrementStep = 1
                    };
                    dt.Columns.Add(columno);
                    dt.Columns["Column1"].ColumnName = "No";

                    //Diğer Tüm Sütunları Ekle
                    foreach (DataGridViewColumn column in dgvUrun.Columns)
                    {
                        dt.Columns.Add(column.HeaderText, column.ValueType);
                    }

                    //Satırları Ekle
                    foreach (DataGridViewRow row in dgvUrun.Rows)
                    {
                        dt.Rows.Add();
                        //Hücreleri Ekle
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex + 1] = cell.Value;
                            }
                        }
                    }

                    //UrunId, TurId, FirmaId Sütunları Kaldır
                    dt.Columns.RemoveAt(1);
                    dt.Columns.RemoveAt(1);
                    dt.Columns.RemoveAt(2);
                    dt.Columns.RemoveAt(8);

                    //Excel Sayfasına ekle.
                    using (workbook)
                    {
                        workbook.Worksheets.Add(dt, "Ürün Listesi");
                    }

                    //Access Veritabanında "Tutar" Sayı:Ondalık, Ölçek:2, Ondalık Basamaklar:2 - . ve , leri getiriyoruz "Fiyat" a
                    workbook.Worksheet("Ürün Listesi").Column(5).Style.NumberFormat.NumberFormatId = workbook.Worksheet("Ürün Listesi").Column(6).Style.NumberFormat.NumberFormatId = workbook.Worksheet("Ürün Listesi").Column(7).Style.NumberFormat.NumberFormatId = 4;

                    /*
                    //Fazla No yazanları siliyoruz
                    workbook.Worksheet("Ürün Listesi").Cell(dgvUrun.Rows.Count + 2, 1).Value = "";
                    workbook.Worksheet("Ürün Listesi").Cell(dgvUrun.Rows.Count + 3, 1).Value = "";
                    */

                    //Sütun Genişliklerini ve Hizaları ayarla

                    workbook.Worksheet("Ürün Listesi").Column(1).Style.Alignment.Horizontal = workbook.Worksheet("Ürün Listesi").Column(8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    workbook.Worksheet("Ürün Listesi").Column(4).Style.Alignment.Horizontal = workbook.Worksheet("Ürün Listesi").Column(5).Style.Alignment.Horizontal = workbook.Worksheet("Ürün Listesi").Column(6).Style.Alignment.Horizontal = workbook.Worksheet("Ürün Listesi").Column(7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    //Tarih, Başlıklar ekle
                    workbook.Worksheet("Ürün Listesi").PageSetup.Header.Right.AddText(string.Format("{0:dd/MM/yyyy}", DateTime.Now));
                    workbook.Worksheet("Ürün Listesi").PageSetup.Footer.Right.AddText("Kale Dekor ve Mobilya");
                    workbook.Worksheet("Ürün Listesi").PageSetup.Header.Left.AddText("Ürün Listesi");

                    workbook.Worksheet("Ürün Listesi").Columns().AdjustToContents();

                    //workbook.Worksheet("Ürün Listesi").Column(4).Width = 7;
                    workbook.Worksheet("Ürün Listesi").Column(8).Width = 10;
                    workbook.Worksheet("Ürün Listesi").PageSetup.PageOrientation = XLPageOrientation.Landscape;
                    //1 Sayfaya Sığmazsa
                    workbook.Worksheet("Ürün Listesi").PageSetup.FitToPages(1, 2);


                    /*
                    if ((workbook.Worksheet(GrpBoxFirma.Text).Column(2).Width + workbook.Worksheet(GrpBoxFirma.Text).Column(4).Width + workbook.Worksheet(GrpBoxFirma.Text).Column(5).Width + workbook.Worksheet(GrpBoxFirma.Text).Column(7).Width + workbook.Worksheet(GrpBoxFirma.Text).Column(8).Width) > 58)
                    {
                        workbook.Worksheet(GrpBoxFirma.Text).PageSetup.FitToPages(1, 2);
                    }
                    */
                    //Kaydet
                    do
                    {
                        try
                        {
                            workbook.SaveAs(fileName);
                            MessageBox.Show("Excel dosyası kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        catch (System.IO.IOException)
                        {
                            MessageBox.Show("Kayıt yapılamadı! Kaydetmeye çalıştığınız dosya açık olabilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    } while (true);
                }
            }
        }

        private void btnExcelStok_Click(object sender, EventArgs e)
        {
            if (dgvStok.Rows.Count > 0)
            {
                //ClosedXml - Version - 0.93.1              
                //Dosya ismi
                string fileName;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                    Title = "To Excel",
                    FileName = "Stok (" + DateTime.Now.ToString("dd-MM-yyyy") + ")"
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;
                    var workbook = new XLWorkbook();

                    //DataTable Oluştur
                    DataTable dt = new DataTable();

                    //No Sütunu Ekle
                    DataColumn columno = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        AutoIncrement = true,
                        AutoIncrementSeed = 1,
                        AutoIncrementStep = 1
                    };
                    dt.Columns.Add(columno);
                    dt.Columns["Column1"].ColumnName = "No";

                    //Diğer Tüm Sütunları Ekle
                    foreach (DataGridViewColumn column in dgvStok.Columns)
                    {
                        dt.Columns.Add(column.HeaderText, column.ValueType);
                    }

                    //Satırları Ekle
                    foreach (DataGridViewRow row in dgvStok.Rows)
                    {
                        dt.Rows.Add();
                        //Hücreleri Ekle
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex + 1] = cell.Value;
                            }
                        }
                    }

                    //UrunId, TurId, EserId Sütunları Kaldır
                    dt.Columns.RemoveAt(1);
                    dt.Columns.RemoveAt(1);
                    dt.Columns.RemoveAt(2);

                    //Excel Sayfasına ekle.
                    using (workbook)
                    {
                        workbook.Worksheets.Add(dt, "Stok");
                    }

                    //Access Veritabanında "Tutar" Sayı:Ondalık, Ölçek:2, Ondalık Basamaklar:2 - . ve , leri getiriyoruz "Fiyat" a
                    workbook.Worksheet("Stok").Column(5).Style.NumberFormat.NumberFormatId = workbook.Worksheet("Stok").Column(6).Style.NumberFormat.NumberFormatId = 4;

                    //Sütun Genişliklerini ve Hizaları ayarla

                    workbook.Worksheet("Stok").Column(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    workbook.Worksheet("Stok").Column(4).Style.Alignment.Horizontal = workbook.Worksheet("Stok").Column(5).Style.Alignment.Horizontal = workbook.Worksheet("Stok").Column(6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    //Tarih, Başlıklar ekle
                    workbook.Worksheet("Stok").PageSetup.Header.Right.AddText(string.Format("{0:dd/MM/yyyy}", DateTime.Now));
                    workbook.Worksheet("Stok").PageSetup.Footer.Right.AddText("Kale Dekor ve Mobilya");
                    workbook.Worksheet("Stok").PageSetup.Header.Left.AddText("Stok");

                    workbook.Worksheet("Stok").Column(1).Style.Font.FontSize = 12;
                    workbook.Worksheet("Stok").Column(2).Style.Font.FontSize = 12;
                    workbook.Worksheet("Stok").Column(3).Style.Font.FontSize = 12;
                    workbook.Worksheet("Stok").Column(4).Style.Font.FontSize = 12;
                    workbook.Worksheet("Stok").Column(5).Style.Font.FontSize = 12;
                    workbook.Worksheet("Stok").Column(6).Style.Font.FontSize = 12;

                    workbook.Worksheet("Stok").Columns().AdjustToContents();

                    workbook.Worksheet("Stok").PageSetup.FitToPages(1, 2);

                    //Kaydet
                    do
                    {
                        try
                        {
                            workbook.SaveAs(fileName);
                            MessageBox.Show("Excel dosyası kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        catch (System.IO.IOException)
                        {
                            MessageBox.Show("Kayıt yapılamadı! Kaydetmeye çalıştığınız dosya açık olabilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    } while (true);
                }
            }
        }

        private void txtUrunKart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // decimal için virgül
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void cmbTurUrun_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Listele_Eser();
        }

        private void dgvEser_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dGVRow in this.dgvEser.Rows)
            {
                dGVRow.HeaderCell.Value = String.Format("{0}", dGVRow.Index + 1);
            }
            //Genişlik Ayarı
            this.dgvEser.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void dgvEser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvEser.CurrentRow;
            if (row != null)
            {
                txtEser.Tag = row.Cells["EserId"].Value;
                txtEser.Text = row.Cells["Ürün"].Value.ToString();
                txtEserBarkod.Text = row.Cells["Barkod"].Value.ToString();
                txtEserBarkod.Tag = row.Cells["Barkod"].Value;
            }
        }

        private void btnEkleEser_Click(object sender, EventArgs e)
        {
            bool barkodVar = false;
            for (int i = 0; i < dgvGizli.RowCount; i++)
            {
                if (dgvGizli.Rows[i].Cells["Barkod"].Value != null && dgvGizli.Rows[i].Cells["Barkod"].Value.ToString() == txtEserBarkod.Text)
                {
                    barkodVar = true;
                }
            }

            if (txtEser.Text != null && txtEser.Text != "" && cmbTurUrun.SelectedIndex != -1 && txtEserBarkod.TextLength == 8 && barkodVar == false)
            {
                //Ekle
                OleDbCommand cmd = new OleDbCommand("insert into Eser(TurId,UrunAd,Barkod) values(@turid,@urunad,@urunbarkod)", baglanti);

                cmd.Parameters.AddWithValue("@turid", cmbTurUrun.SelectedValue);
                cmd.Parameters.AddWithValue("@urunad", txtEser.Text);
                cmd.Parameters.AddWithValue("@urunbarkod", txtEserBarkod.Text);

                baglanti.Open();
                cmd.ExecuteNonQuery();
                baglanti.Close();

                //Listele
                Listele_Eser();
                cmbUrunAdListele();
                OleDbDataAdapter adpG1 = new OleDbDataAdapter("select * from Eser", baglanti);
                DataTable dtG1 = new DataTable();
                adpG1.Fill(dtG1);
                dgvGizli.DataSource = dtG1;
                txtEser.Text = "";
                txtEserBarkod.Text = "12345678";

                //Lislte BarkodÜrün
                OleDbDataAdapter adpBarkod = new OleDbDataAdapter("select UrunAd as [Ürün], Barkod from Eser order by Barkod", baglanti);
                DataTable dtBarkod = new DataTable();
                adpBarkod.Fill(dtBarkod);
                dgvBarkodUrun.DataSource = dtBarkod;
            }
            else if (txtEser.Text == null || txtEser.Text == "")
            {
                MessageBox.Show("Lütfen Ürün Adını giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtEserBarkod.Text.Length != 8)
            {
                MessageBox.Show("Lütfen Barkod Numarasını giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (barkodVar == true)
            {
                MessageBox.Show("Aynı Barkod Numarasından var!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSilEser_Click(object sender, EventArgs e)
        {
            if (dgvEser.Rows.Count > 0)
            {
                //int tID = (int)txtTur.Tag;

                if (txtEser.Text == null || txtEser.Text == "" || txtEser.Tag == null)
                {
                    MessageBox.Show("Ürün seçili değil..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //Açıklamalar 
                    int aId2 = dgvEser.SelectedRows[0].Index;
                    string aId = (aId2 + 1).ToString();

                    DialogResult sonuc = MessageBox.Show("Satır No: " + aId + "\n" + "Ürün Adı: " + txtEser.Text + "\n" + "\n" + "Bu Ürün e ait olan Ürün Giriş Listesindeki ve Stok taki veriler de silinecek! Lütfen silmeden evvel ilgili Ürün ile kayıt edilmiş Ürün Giriş Listesinde ürün girişi varsa Ürün Listesindeki ve Stok taki ürünün silinmemesi için Ürün Giriş ekranından Ürün ü değiştiriniz." + "\n" + "\n" + "Silinsin mi?", "Sil?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (sonuc == DialogResult.Yes)
                    {
                        OleDbCommand cmd = new OleDbCommand("delete from Urun where EserId=@eid", baglanti);
                        OleDbCommand cmd2 = new OleDbCommand("delete from Eser where EserId=@eid", baglanti);
                        OleDbCommand cmd3 = new OleDbCommand("delete from Stok where EserId=@eid", baglanti);

                        cmd.Parameters.AddWithValue("@eid", (int)txtEser.Tag);
                        cmd2.Parameters.AddWithValue("@eid", (int)txtEser.Tag);
                        cmd3.Parameters.AddWithValue("@eid", (int)txtEser.Tag);

                        baglanti.Open();
                        cmd.ExecuteNonQuery();
                        cmd2.ExecuteNonQuery();
                        cmd3.ExecuteNonQuery();
                        baglanti.Close();

                        //Listele
                        cmbUrunAdListele();
                        Listele_Eser();
                        Listele_Urun();
                        Listele_Stok();
                        OleDbDataAdapter adpG1 = new OleDbDataAdapter("select * from Eser", baglanti);
                        DataTable dtG1 = new DataTable();
                        adpG1.Fill(dtG1);
                        dgvGizli.DataSource = dtG1;
                        txtEser.Tag = null;
                        txtEser.Text = "";
                        txtEserBarkod.Text = "12345678";

                        //Lislte BarkodÜrün
                        OleDbDataAdapter adpBarkod = new OleDbDataAdapter("select UrunAd as [Ürün], Barkod from Eser order by Barkod", baglanti);
                        DataTable dtBarkod = new DataTable();
                        adpBarkod.Fill(dtBarkod);
                        dgvBarkodUrun.DataSource = dtBarkod;
                    }
                }
            }
        }

        private void cmbTur_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            cmbUrunAdListele();
        }

        private void btnGuncelleEser_Click(object sender, EventArgs e)
        {
            bool barkodVar = false;
            for (int i = 0; i < dgvGizli.RowCount; i++)
            {
                if (dgvGizli.Rows[i].Cells["Barkod"].Value != null && dgvGizli.Rows[i].Cells["Barkod"].Value.ToString() == txtEserBarkod.Text && (string)txtEserBarkod.Tag != txtEserBarkod.Text)
                {
                    barkodVar = true;
                }
            }

            if (dgvEser.Rows.Count > 0 && txtEser.Text != null && txtEser.Text != "" && txtEser.Tag != null && txtEserBarkod.Text.Length == 8 && barkodVar == false)
            {
                //Açıklamalar   
                int aId2 = dgvEser.SelectedRows[0].Index;
                string aId = (aId2 + 1).ToString();
                string tAd = dgvEser.SelectedCells[1].Value.ToString();
                string tBarkod = dgvEser.SelectedCells[2].Value.ToString();

                DialogResult sonuc = MessageBox.Show("Satır No: " + aId + "\n" + "Ürün: " + tAd + "\n" + "Barkod :" + tBarkod + "\n" + "\n" + "Aşağıdaki yeni veri ile," + "\n" + "\n" + "Ürün: " + txtEser.Text + "\n" + "Barkod: " + txtEserBarkod.Text + "\n" + "\n" + "Güncellensin mi?", "Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand("Update Eser set UrunAd=@tad, Barkod=@tbarkod where EserId=@tid", baglanti);

                    cmd.Parameters.AddWithValue("@tad", txtEser.Text);
                    cmd.Parameters.AddWithValue("@tbarkod", txtEserBarkod.Text);
                    cmd.Parameters.AddWithValue("@tid", (int)txtEser.Tag); //en son yazılsın ki id yi alabilsin

                    baglanti.Open();
                    cmd.ExecuteNonQuery();
                    baglanti.Close();

                    //Listele
                    cmbUrunAdListele();
                    Listele_Eser();
                    Listele_Urun();
                    Listele_Stok();
                    OleDbDataAdapter adpG1 = new OleDbDataAdapter("select * from Eser order by EserId", baglanti);
                    DataTable dtG1 = new DataTable();
                    adpG1.Fill(dtG1);
                    dgvGizli.DataSource = dtG1;
                    txtEser.Tag = null;
                    txtEser.Text = "";
                    txtEserBarkod.Text = "12345678";

                    //Lislte BarkodÜrün
                    OleDbDataAdapter adpBarkod = new OleDbDataAdapter("select UrunAd as [Ürün], Barkod from Eser order by Barkod", baglanti);
                    DataTable dtBarkod = new DataTable();
                    adpBarkod.Fill(dtBarkod);
                    dgvBarkodUrun.DataSource = dtBarkod;
                }
            }
            else if (txtEser.Text == null || txtEser.Text == "")
            {
                MessageBox.Show("Lütfen Ürün Adını giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtEserBarkod.Text.Length != 8)
            {
                MessageBox.Show("Lütfen Barkod Numarasını giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (barkodVar == true)
            {
                MessageBox.Show("Aynı Barkod Numarasından var!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUrunGelis.Text = "0";
            txtUrunKart.Text = "0";
            txtUrunFiyat.Text = "0";
            numUrunAdet.Value = 1;
            //cmbUrunAd.SelectedIndex = 0;
            //cmbTur.SelectedIndex = 0;
            cmbFirma.SelectedIndex = 0;
            dtpUrunTarih.Text = DateTime.Now.ToString("d/M/yyyy");
        }

        private void btnPrintStok_Click(object sender, EventArgs e)
        {
            if (dgvStok.RowCount > 0)
            {
                /// - Data Table Oluştur - ///
                //DataTable Oluştur
                DataTable dt = new DataTable();

                //No Sütunu Ekle
                DataColumn columno = new DataColumn
                {
                    DataType = System.Type.GetType("System.Int32"),
                    AutoIncrement = true,
                    AutoIncrementSeed = 1,
                    AutoIncrementStep = 1
                };
                dt.Columns.Add(columno);
                dt.Columns["Column1"].ColumnName = "No";

                //Diğer Tüm Sütunları Ekle
                foreach (DataGridViewColumn column in dgvStok.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }

                //Satırları Ekle
                foreach (DataGridViewRow row in dgvStok.Rows)
                {
                    dt.Rows.Add();
                    //Hücreleri Ekle
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null)
                        {
                            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex + 1] = cell.Value;
                        }
                    }
                }

                //UrunId, TurId, EserId Sütunları Kaldır
                dt.Columns.RemoveAt(1);
                dt.Columns.RemoveAt(1);
                dt.Columns.RemoveAt(2);
                /// - Data Table Oluştur - ///

                //Varsayılan Yazıcı İcin
                LocalReport report = new LocalReport();
                string path = Path.GetDirectoryName(Application.ExecutablePath);
                string fullPath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\Report\rptStok.rdlc";
                report.ReportPath = fullPath;
                report.DataSources.Add(new ReportDataSource("dsStok", dt));
                PrintToPrinter(report, false);
            }
        }

        //Varsayılan Yazıcı İcin
        public static void PrintToPrinter(LocalReport report, Boolean barkod)
        {
            Export(report, barkod);
        }

        //Varsayılan Yazıcı İcin
        public static void Export(LocalReport report, Boolean barkod, bool print = true)
        {
            string deviceInfo =
             @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.27in</PageWidth>
                <PageHeight>11.69in</PageHeight>
                <MarginTop>0.5in</MarginTop>
                <MarginLeft>0.5in</MarginLeft>
                <MarginRight>0.5in</MarginRight>
                <MarginBottom>0.5in</MarginBottom>
                </DeviceInfo>";

            if (barkod == true)
            {
                //<PageHeight>5,51181in</PageHeight>
                deviceInfo =
                @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>3,14961in</PageWidth> 
                <PageHeight>3,14961in</PageHeight>
                <MarginTop>0,07874in</MarginTop>
                <MarginLeft>0,07874in</MarginLeft>
                <MarginRight>0,07874in</MarginRight>
                <MarginBottom>0,07874in</MarginBottom>
                </DeviceInfo>";
            }
            
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

            if (print)
            {
                Print(barkod);
            }
        }

        //Varsayılan Yazıcı İcin
        public static void Print(Boolean barkod)
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                if (barkod == true)
                {
                    //printerName = XX.X.X.XXX (IP address)
                    //printDoc.PrinterSettings.PrinterName = "192.168.1.100";
                    //printDoc.PrinterSettings.PrinterName = "PrimoPDF";
                    printDoc.PrinterSettings.PrinterName = "MAKBUZ-NETWORK";
                    printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                    m_currentPageIndex = 0;
                    printDoc.Print();
                }
                else
                {
                    printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                    m_currentPageIndex = 0;
                    printDoc.Print();
                }
                
            }
        }

        //Varsayılan Yazıcı İcin
        public static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        //Varsayılan Yazıcı İcin
        public static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        //Varsayılan Yazıcı İcin
        public static void DisposePrint()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        private void btnBarkod1_Click(object sender, EventArgs e)
        {
            if (txtBarkod1.Text.Length == 8)
            {
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                picBarkod1.Image = barcode.Draw(txtBarkod1.Text, 50);
            }
            else
            {
                MessageBox.Show("Lütfen 8 hane giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBarkodKaydet_Click(object sender, EventArgs e)
        {
            string fileName;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*",
                Title = "To JPG",
                FileName = txtBarkod1.Text
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmpResult = new Bitmap(picBarkod1.Width, picBarkod1.Height);
                using (Graphics g = Graphics.FromImage(bmpResult))
                    g.DrawImage(picBarkod1.Image, 0, 0, picBarkod1.Width,
                                picBarkod1.Height);

                fileName = saveFileDialog1.FileName;

                //Kaydet
                do
                {
                    try
                    {
                        //picBarkod1.Image.Save(fileName);
                        bmpResult.Save(fileName);
                        MessageBox.Show("Barkod kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("Kayıt yapılamadı! Kaydetmeye çalıştığınız dosya açık olabilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                } while (true);
            }
        }

        private void txtBarkod1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEserBarkod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        ListViewItem secili;
        decimal satisToplam = 0;
        bool barkodVar = false;
        int eserIdH = 0;
        int turIdH = 0;
        //List<int> eserlerId = new List<int>();
        //List<int> eserlerAdet = new List<int>();
        //List<decimal> eserlerFiyat = new List<decimal>();
        private void txtSatisBarkod_TextChanged(object sender, EventArgs e)
        {
            if (txtSatisBarkod.TextLength == 8)
            {
                ListViewItem lvs = new ListViewItem();
                string urunAd = "";

                decimal fiyat = 0;
                for (int i = 0; i < dgvGizli.RowCount; i++)
                {
                    if (dgvGizli.Rows[i].Cells["Barkod"].Value != null && txtSatisBarkod.Text == dgvGizli.Rows[i].Cells["Barkod"].Value.ToString())
                    {
                        barkodVar = true;
                        urunAd = dgvGizli.Rows[i].Cells["UrunAd"].Value.ToString();
                        eserIdH = (int)dgvGizli.Rows[i].Cells["EserId"].Value;
                        //eserlerId.Add((int)dgvGizli.Rows[i].Cells["EserId"].Value);
                        turIdH = (int)dgvGizli.Rows[i].Cells["TurId"].Value;
                    }
                }

                if (barkodVar == true)
                {
                    //eserlerId.Add(eserIdH);
                    //eserlerAdet.Add((int)numSatisAdet.Value);

                    for (int i = 0; i < dgvStok.RowCount; i++)
                    {
                        if (eserIdH != 0 && eserIdH == (int)dgvStok.Rows[i].Cells["EserId"].Value)
                        {
                            fiyat = (decimal)dgvStok.Rows[i].Cells["Fiyat"].Value;
                            //eserlerFiyat.Add(fiyat);
                        }
                    }

                    //ilk kolon text olarak geçer
                    lvs.Text = urunAd;
                    lvs.SubItems.Add(fiyat.ToString());
                    lvs.SubItems.Add(numSatisAdet.Value.ToString());
                    lvs.SubItems.Add(String.Format("{0:N}\n", fiyat * numSatisAdet.Value));

                    satisToplam += (fiyat * numSatisAdet.Value);
                    lblSatisToplam.Text = String.Format("{0:N}\n", satisToplam);

                    listSatis.Items.Add(lvs);

                    txtSatisBarkod.Text = null;
                }

                // /////----FİŞ EKLEME----- //////

                if (tablePr.Columns.Count == 0)
                {
                    foreach (ColumnHeader colmnPr in listSatis.Columns)
                    {
                        tablePr.Columns.Add(colmnPr.Text);
                    }
                }
                else if (tablePr.Columns.Count != 0)
                {
                    tablePr.Rows.Clear();
                }

                foreach (ListViewItem item in listSatis.Items)
                {
                    DataRow row = tablePr.NewRow();
                    for (int i = 0; i < item.SubItems.Count; i++)
                    {
                        row[i] = item.SubItems[i].Text;
                    }
                    tablePr.Rows.Add(row);
                }

                tablePr.Rows.Add();
                DataRow rowToplam = tablePr.NewRow();
                tablePr.Rows.Add(rowToplam);
                rowToplam[3] = lblSatisToplam.Text;

                if (d1 == false)
                {
                    d1 = true;
                    dsSatis.Tables.Add(tablePr);
                }

                dsSatisBindingSource.DataSource = tablePr;
                reportViewer1.RefreshReport();

                // / ---- ////
            }
        }

        

        private void btnSatisSil_Click(object sender, EventArgs e)
        {
            if (listSatis.SelectedItems.Count > 0)
            {
                listSatis.Items.Remove(listSatis.SelectedItems[0]);
                satisToplam = satisToplam - (numSatisAdetGuncelle.Value * numSatisFiyat.Value);
                lblSatisToplam.Text = String.Format("{0:N}\n", satisToplam);

                tablePr.Rows.Clear();

                foreach (ListViewItem item in listSatis.Items)
                {
                    DataRow row = tablePr.NewRow();
                    for (int i = 0; i < item.SubItems.Count; i++)
                    {
                        row[i] = item.SubItems[i].Text;
                    }
                    tablePr.Rows.Add(row);
                }

                tablePr.Rows.Add();
                DataRow rowToplam = tablePr.NewRow();
                tablePr.Rows.Add(rowToplam);
                rowToplam[3] = lblSatisToplam.Text;

                dsSatisBindingSource.DataSource = tablePr;
                reportViewer1.RefreshReport();
            }
        }

        private void btnSatisGuncelle_Click(object sender, EventArgs e)
        {
            secili.SubItems[2].Text = numSatisAdetGuncelle.Value.ToString();

            if (numSatisFiyat.Value != 0)
            {
                secili.SubItems[3].Text = (numSatisAdetGuncelle.Value * numSatisFiyat.Value).ToString();
                satisToplam = satisToplam - (numSatisAdetGuncelle2.Value * numSatisFiyat.Value);
                satisToplam = satisToplam + (numSatisAdetGuncelle.Value * numSatisFiyat.Value);
            }

            lblSatisToplam.Text = String.Format("{0:N}\n", satisToplam);

            tablePr.Rows.Clear();

            foreach (ListViewItem item in listSatis.Items)
            {
                DataRow row = tablePr.NewRow();
                for (int i = 0; i < item.SubItems.Count; i++)
                {
                    row[i] = item.SubItems[i].Text;
                }
                tablePr.Rows.Add(row);
            }

            tablePr.Rows.Add();
            DataRow rowToplam = tablePr.NewRow();
            tablePr.Rows.Add(rowToplam);
            rowToplam[3] = lblSatisToplam.Text;

            dsSatisBindingSource.DataSource = tablePr;
            reportViewer1.RefreshReport();
        }

        private void listSatis_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Hiç kayıt seçilmemiş
            if (listSatis.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                secili = listSatis.SelectedItems[0];
                lblSatisUrunAd.Text = secili.Text;
                numSatisFiyat.Text = secili.SubItems[1].Text;
                numSatisAdetGuncelle.Value = Convert.ToDecimal(secili.SubItems[2].Text);
                numSatisAdetGuncelle2.Value = Convert.ToDecimal(secili.SubItems[2].Text);
            }
        }

        private void dgvBarkodUrun_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvBarkodUrun.CurrentRow;
            if (row != null)
            {
                txtBarkod1.Text = row.Cells["Barkod"].Value.ToString();
            }
        }

        private void dgvBarkodUrun_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dGVRow in this.dgvBarkodUrun.Rows)
            {
                dGVRow.HeaderCell.Value = String.Format("{0}", dGVRow.Index + 1);
            }
            //Genişlik Ayarı
            this.dgvBarkodUrun.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnSatisTemizle_Click(object sender, EventArgs e)
        {
            tablePr.Rows.Clear();
            tableCari.Rows.Clear();
            listSatis.Items.Clear();
            lblSatisToplam.Text = "0,00";
            satisToplam = 0;
            eserIds.Clear();
            //eserlerId.Clear();
            //eserlerAdet.Clear();
            reportViewer1.RefreshReport();
        }

        private void dgvBarkodUrun_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvBarkodUrun.CurrentRow;
            if (row != null)
            {
                txtBarkod1.Text = row.Cells["Barkod"].Value.ToString();
            }
        }

        private void dgvTur_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvTur.CurrentRow;
            if (row != null)
            {
                txtTur.Tag = row.Cells["TurId"].Value;
                txtTur.Text = row.Cells["Tür"].Value.ToString();
            }
        }

        private void dgvEser_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvEser.CurrentRow;
            if (row != null)
            {
                txtEser.Tag = row.Cells["EserId"].Value;
                txtEser.Text = row.Cells["Ürün"].Value.ToString();
                txtEserBarkod.Text = row.Cells["Barkod"].Value.ToString();
                txtEserBarkod.Tag = row.Cells["Barkod"].Value;
            }
        }

        private void dgvFirma_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvFirma.CurrentRow;
            if (row != null)
            {
                txtFirma.Tag = row.Cells["FirmaId"].Value;
                txtFirma.Text = row.Cells["Firma"].Value.ToString();
            }
        }

        private void dgvUrun_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvUrun.CurrentRow;
            if (row != null)
            {
                cmbTur.SelectedValue = row.Cells["TurId"].Value;
                cmbUrunAdListele();
                cmbFirma.SelectedValue = row.Cells["FirmaId"].Value;
                cmbUrunAd.Tag = row.Cells["UrunId"].Value;
                cmbUrunAd.SelectedValue = row.Cells["EserId"].Value;
                numUrunAdet.Value = (int)row.Cells["Adet"].Value;
                txtUrunGelis.Text = row.Cells["Geliş"].Value.ToString();
                txtUrunFiyat.Text = row.Cells["Fiyat"].Value.ToString();
                txtUrunKart.Text = row.Cells["Kart"].Value.ToString();
                dtpUrunTarih.Text = row.Cells["Tarih"].Value.ToString();
            }
        }

        private void dgvStok_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvStok.CurrentRow;
            if (row != null)
            {
                lblStokUrun.Tag = row.Cells["StokId"].Value;
                lblStokUrun.Text = row.Cells["Ürün"].Value.ToString();
                numStok.Value = (int)row.Cells["Stok"].Value;
            }
        }

        private void dgvStok_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvStok.CurrentRow;
            if (row != null)
            {
                lblStokUrun.Tag = row.Cells["StokId"].Value;
                lblStokUrun.Text = row.Cells["Ürün"].Value.ToString();
                numStok.Value = (int)row.Cells["Stok"].Value;
            }
        }

        private void btnStokSil_Click(object sender, EventArgs e)
        {
            if (lblStokUrun.Tag == null)
            {
                MessageBox.Show("Ürün seçili değil..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                OleDbCommand cmd = new OleDbCommand("delete from Stok where StokId=@sid", baglanti);

                cmd.Parameters.AddWithValue("@sid", (int)lblStokUrun.Tag);

                baglanti.Open();
                cmd.ExecuteNonQuery();
                baglanti.Close();

                Listele_Stok();
            }
        }

        private void btnStokGuncelle_Click(object sender, EventArgs e)
        {
            if (lblStokUrun.Tag == null)
            {
                MessageBox.Show("Ürün seçili değil..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(numStok.Value != 0)
            {
                OleDbCommand cmd = new OleDbCommand("Update Stok set Adet=@sadet where StokId=@sid", baglanti);

                cmd.Parameters.AddWithValue("@sadet", numStok.Value);
                cmd.Parameters.AddWithValue("@sid", (int)lblStokUrun.Tag); //en son yazılsın ki id yi alabilsin

                baglanti.Open();
                cmd.ExecuteNonQuery();
                baglanti.Close();

                Listele_Stok();
            }
            
        }
        public class RawPrinterHelper
        {
            // Structure and API declarions:
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }
            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

            // SendBytesToPrinter()
            // When the function is given a printer name and an unmanaged array
            // of bytes, the function sends those bytes to the print queue.
            // Returns true on success, false on failure.
            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
            {
                Int32 dwError = 0, dwWritten = 0;
                IntPtr hPrinter = new IntPtr(0);
                DOCINFOA di = new DOCINFOA();
                bool bSuccess = false; // Assume failure unless you specifically succeed.

                di.pDocName = "RAW Document";
                // Win7
                di.pDataType = "RAW";

                // Win8+
                // di.pDataType = "XPS_PASS";

                // Open the printer.
                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    // Start a document.
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        // Start a page.
                        if (StartPagePrinter(hPrinter))
                        {
                            // Write your bytes.
                            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                // If you did not succeed, GetLastError may give more information
                // about why not.
                if (bSuccess == false)
                {
                    dwError = Marshal.GetLastWin32Error();
                }
                return bSuccess;
            }

            public static bool SendFileToPrinter(string szPrinterName, string szFileName)
            {
                // Open the file.
                FileStream fs = new FileStream(szFileName, FileMode.Open);
                // Create a BinaryReader on the file.
                BinaryReader br = new BinaryReader(fs);
                // Dim an array of bytes big enough to hold the file's contents.
                Byte[] bytes = new Byte[fs.Length];
                bool bSuccess = false;
                // Your unmanaged pointer.
                IntPtr pUnmanagedBytes = new IntPtr(0);
                int nLength;

                nLength = Convert.ToInt32(fs.Length);
                // Read the contents of the file into the array.
                bytes = br.ReadBytes(nLength);
                // Allocate some unmanaged memory for those bytes.
                pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
                // Copy the managed byte array into the unmanaged array.
                Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
                // Send the unmanaged bytes to the printer.
                bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
                // Free the unmanaged memory that you allocated earlier.
                Marshal.FreeCoTaskMem(pUnmanagedBytes);
                fs.Close();
                fs.Dispose();
                fs = null;
                return bSuccess;
            }
            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                Int32 dwCount;
                // How many characters are in the string?
                dwCount = szString.Length;
                // Assume that the printer is expecting ANSI text, and then convert
                // the string to ANSI text.
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                // Send the converted ANSI string to the printer.
                SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return true;
            }
        }
        private void btnKes_Click(object sender, EventArgs e)
        {
            
            string GS = Convert.ToString((char)29);
            string ESC = Convert.ToString((char)27);

            string COMMAND = "";
            COMMAND = ESC + "@";
            COMMAND += GS + "V" + (char)1;
            /*
            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings = new PrinterSettings();
            if (DialogResult.OK == pd.ShowDialog(this))
            {
                RawPrinterHelper.SendStringToPrinter(pd.PrinterSettings.PrinterName, COMMAND);
            }
            */
            RawPrinterHelper.SendStringToPrinter("MAKBUZ-NETWORK", COMMAND);
            /*
            try
            {
                //string ipAddress = "192.168.1.100"; ; //ie: 10.0.0.91
                //int port = 9100; //ie: 9100

                System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
                //client.Connect(ipAddress, port);
                client.Connect("192.168.1.100", 9100);
                StreamReader reader = new StreamReader(txtFilename.Text.ToString()); //ie: C:\\Apps\\test.txt
                StreamWriter writer = new StreamWriter(client.GetStream());
                string testFile = reader.ReadToEnd();
                reader.Close();
                writer.Write(testFile);
                writer.WriteLine("Hello World!");
                writer.Flush();
                writer.Close();
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            */
        }

        DataTable tableCari = new DataTable();
        List<int> eserIds = new List<int>();
        private void btnStokDus_Click(object sender, EventArgs e)
        {
            if (tablePr.Rows.Count > 0)
            {
                baglanti.Open();

                if (tableCari.Columns.Count == 0)
                {
                    foreach (ColumnHeader colmnCari in listSatis.Columns)
                    {
                        tableCari.Columns.Add(colmnCari.Text);
                    }
                }
                else if (tableCari.Columns.Count != 0)
                {
                    tableCari.Rows.Clear();
                }

                foreach (ListViewItem item in listSatis.Items)
                {
                    DataRow row = tableCari.NewRow();
                    for (int i = 0; i < item.SubItems.Count; i++)
                    {
                        row[i] = item.SubItems[i].Text;
                    }
                    tableCari.Rows.Add(row);
                }

                for (int a = 0; a < tableCari.Rows.Count; a++)
                {
                    for (int b = 0; b < dgvGizli.RowCount; b++)
                    {
                        var a4 = tableCari.Rows[a][0];
                        var b4 = dgvGizli.Rows[b].Cells["UrunAd"];
                        if ((string)tableCari.Rows[a][0] == (string)dgvGizli.Rows[b].Cells["UrunAd"].Value)
                        {
                            eserIds.Add((int)dgvGizli.Rows[b].Cells["EserId"].Value);
                        }
                    }
                }

                for (int i = 0; i < tableCari.Rows.Count; i++)
                {
                    //STOKTAN DÜŞ
                    for (int j = 0; j < dgvStok.RowCount; j++)
                    {
                        if (eserIds[i] == (int)dgvStok.Rows[j].Cells["EserId"].Value)
                        {
                            OleDbCommand cmdStok = new OleDbCommand("Update Stok set Adet=@sadet where EserId=@eid", baglanti);
                            cmdStok.Parameters.AddWithValue("@sadet", (int)dgvStok.Rows[j].Cells["Stok"].Value - Convert.ToInt32(tableCari.Rows[i][2]));
                            cmdStok.Parameters.AddWithValue("@eid", eserIds[i]);
                            cmdStok.ExecuteNonQuery();
                            Listele_Stok();
                        }
                    }

                    //CARİYE EKLE
                    OleDbCommand cmdC = new OleDbCommand("insert into Sat(EserId,Adet,Fiyat,Toplam,[Tarih],Kim) values(@eidS,@eadetS,@efiyatS,@etoplamS,@etarihS,@eKim)", baglanti);

                    cmdC.Parameters.AddWithValue("@eidS", eserIds[i]);
                    cmdC.Parameters.AddWithValue("@eadetS", Convert.ToInt32(tableCari.Rows[i][2]));
                    cmdC.Parameters.AddWithValue("@efiyatS", tableCari.Rows[i][1]);
                    cmdC.Parameters.AddWithValue("@etoplamS", Convert.ToInt32(tableCari.Rows[i][2]) * Convert.ToDecimal(tableCari.Rows[i][1]));
                    cmdC.Parameters.AddWithValue("@etarihS", DateTime.Now.ToString("d/M/yyyy"));
                    cmdC.Parameters.AddWithValue("@eKim",txtKim.Text);
                    cmdC.ExecuteNonQuery();
                }

                /*
                for (int i = 0; i < eserlerId.Count; i++)
                {
                    //STOKTAN DÜŞ
                    for (int j = 0; j < dgvStok.RowCount; j++)
                    {
                        if (eserlerId[i] == (int)dgvStok.Rows[j].Cells["EserId"].Value)
                        {
                            OleDbCommand cmdStok = new OleDbCommand("Update Stok set Adet=@sadet where EserId=@eid", baglanti);
                            cmdStok.Parameters.AddWithValue("@sadet", (int)dgvStok.Rows[j].Cells["Stok"].Value - eserlerAdet[i]);
                            cmdStok.Parameters.AddWithValue("@eid", eserlerId[i]);
                            cmdStok.ExecuteNonQuery();
                            Listele_Stok();
                        }
                    }

                    //CARİYE EKLE
                    OleDbCommand cmdC = new OleDbCommand("insert into Sat(EserId,Adet,Fiyat,Toplam,[Tarih]) values(@eidS,@eadetS,@efiyatS,@etoplamS,etarihS)", baglanti);

                    cmdC.Parameters.AddWithValue("@eidS", eserlerId[i]);
                    cmdC.Parameters.AddWithValue("@eadetS", eserlerAdet[i]);
                    cmdC.Parameters.AddWithValue("@efiyatS", eserlerFiyat[i]);
                    cmdC.Parameters.AddWithValue("@etoplamS", eserlerAdet[i] * eserlerFiyat[i]);
                    cmdC.Parameters.AddWithValue("@etarihS", DateTime.Now.ToString("d/M/yyyy"));
                    cmdC.ExecuteNonQuery();
                }
                */

                baglanti.Close();

                //cmbCariye Ekle
                for (int i = 0; i < cmbCari.Items.Count; i++)
                {
                    if (txtKim.Text != cmbCari.Items[i].ToString())
                    {
                        cmbCari.Items.Add(txtKim.Text);
                    }
                }

                cmbCari.SelectedIndex = 0;

                Listele_Stok();

                //Listele Cari
                OleDbDataAdapter adpCari = new OleDbDataAdapter("select SatId, Eser.UrunAd as [Ürün], Adet, Fiyat, Toplam, Tarih, Kim from Sat INNER JOIN Eser ON Sat.EserId = Eser.EserId order by UrunAd", baglanti);
                DataTable dtCari = new DataTable();
                adpCari.Fill(dtCari);
                dgvCari.DataSource = dtCari;
                dgvCari.Columns["SatId"].Visible = dgvCari.Columns["Kim"].Visible = false;

                for (int i = 0; i < dgvCari.RowCount; i++)
                {
                    cariToplam += (decimal)dgvCari.Rows[i].Cells[4].Value;
                }
                lblCariToplam.Text = String.Format("{0:N}\n", cariToplam);
            }
        }

        private void dgvCari_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dGVRow in this.dgvCari.Rows)
            {
                dGVRow.HeaderCell.Value = String.Format("{0}", dGVRow.Index + 1);
            }
            //Genişlik Ayarı
            this.dgvCari.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void dgvCari_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCari.CurrentRow;
            if (row != null)
            {
                lblCari.Tag = row.Cells["SatId"].Value;
                lblCari.Text = row.Cells["Ürün"].Value.ToString();
            }
        }

        private void dgvCari_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvCari.CurrentRow;
            if (row != null)
            {
                lblCari.Tag = row.Cells["SatId"].Value;
                lblCari.Text = row.Cells["Ürün"].Value.ToString();
            }
        }

        private void btnCariSil_Click(object sender, EventArgs e)
        {
            if (lblCari.Tag == null)
            {
                MessageBox.Show("Ürün seçili değil..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                cariToplam = 0;

                OleDbCommand cmd = new OleDbCommand("delete from Sat where SatId=@sid", baglanti);

                cmd.Parameters.AddWithValue("@sid", (int)lblCari.Tag);

                baglanti.Open();
                cmd.ExecuteNonQuery();
                baglanti.Close();

                //ListeleCari
                OleDbDataAdapter adpCari = new OleDbDataAdapter("select SatId, Eser.UrunAd as [Ürün], Adet, Fiyat, Toplam, Tarih, Kim from Sat INNER JOIN Eser ON Sat.EserId = Eser.EserId order by UrunAd", baglanti);
                DataTable dtCari = new DataTable();
                adpCari.Fill(dtCari);
                dgvCari.DataSource = dtCari;
                dgvCari.Columns["SatId"].Visible = dgvCari.Columns["Kim"].Visible = false;
                dgvCari.Columns[2].DefaultCellStyle.Alignment = dgvCari.Columns[3].DefaultCellStyle.Alignment = dgvCari.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                if (dgvCari.RowCount > 0)
                {
                    for (int i = 0; i < dgvCari.RowCount; i++)
                    {
                        cariToplam += (decimal)dgvCari.Rows[i].Cells[4].Value;
                    }
                    lblCariToplam.Text = String.Format("{0:N}\n", cariToplam);
                }
                else
                {
                    lblCariToplam.Text = "0,00";
                }
            }
        }

        private void btnCariExcel_Click(object sender, EventArgs e)
        {
            if (dgvCari.Rows.Count > 0)
            {
                //ClosedXml - Version - 0.93.1              
                //Dosya ismi
                string fileName;

                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "xls files (*.xlsx)|*.xlsx|All files (*.*)|*.*",
                    Title = "To Excel",
                    FileName = "Cari (" + DateTime.Now.ToString("dd-MM-yyyy") + ")"
                };

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog1.FileName;
                    var workbook = new XLWorkbook();

                    //DataTable Oluştur
                    DataTable dt = new DataTable();

                    //No Sütunu Ekle
                    DataColumn columno = new DataColumn
                    {
                        DataType = System.Type.GetType("System.Int32"),
                        AutoIncrement = true,
                        AutoIncrementSeed = 1,
                        AutoIncrementStep = 1
                    };
                    dt.Columns.Add(columno);
                    dt.Columns["Column1"].ColumnName = "No";

                    //Diğer Tüm Sütunları Ekle
                    foreach (DataGridViewColumn column in dgvCari.Columns)
                    {
                        dt.Columns.Add(column.HeaderText, column.ValueType);
                    }

                    //Satırları Ekle
                    foreach (DataGridViewRow row in dgvCari.Rows)
                    {
                        dt.Rows.Add();
                        //Hücreleri Ekle
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex + 1] = cell.Value;
                            }
                        }
                    }

                    //SatId ve Kim Sütun Kaldır
                    dt.Columns.RemoveAt(1);
                    dt.Columns.RemoveAt(6);

                    //Excel Sayfasına ekle.
                    using (workbook)
                    {
                        workbook.Worksheets.Add(dt, "Cari");
                    }

                    //Access Veritabanında "Tutar" Sayı:Ondalık, Ölçek:2, Ondalık Basamaklar:2 - . ve , leri getiriyoruz "Fiyat" a
                    workbook.Worksheet("Cari").Column(4).Style.NumberFormat.NumberFormatId = workbook.Worksheet("Cari").Column(5).Style.NumberFormat.NumberFormatId = 4;

                    //Sütun Genişliklerini ve Hizaları ayarla

                    workbook.Worksheet("Cari").Column(1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    workbook.Worksheet("Cari").Column(3).Style.Alignment.Horizontal = workbook.Worksheet("Cari").Column(5).Style.Alignment.Horizontal = workbook.Worksheet("Cari").Column(4).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

                    

                    //Tarih, Başlıklar ekle
                    workbook.Worksheet("Cari").PageSetup.Header.Right.AddText(string.Format("{0:dd/MM/yyyy}", DateTime.Now));
                    workbook.Worksheet("Cari").PageSetup.Footer.Right.AddText("Kale Dekor ve Mobilya");
                    workbook.Worksheet("Cari").PageSetup.Header.Left.AddText("Stok");

                    workbook.Worksheet("Cari").Column(1).Style.Font.FontSize = 12;
                    workbook.Worksheet("Cari").Column(2).Style.Font.FontSize = 12;
                    workbook.Worksheet("Cari").Column(3).Style.Font.FontSize = 12;
                    workbook.Worksheet("Cari").Column(4).Style.Font.FontSize = 12;
                    workbook.Worksheet("Cari").Column(5).Style.Font.FontSize = 12;
                    workbook.Worksheet("Cari").Column(6).Style.Font.FontSize = 12;

                    workbook.Worksheet("Cari").Columns().AdjustToContents();
                    workbook.Worksheet("Cari").Column(6).Width = 11;
                    workbook.Worksheet("Cari").PageSetup.FitToPages(1, 2);

                    //Kaydet
                    do
                    {
                        try
                        {
                            workbook.SaveAs(fileName);
                            MessageBox.Show("Excel dosyası kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        catch (System.IO.IOException)
                        {
                            MessageBox.Show("Kayıt yapılamadı! Kaydetmeye çalıştığınız dosya açık olabilir.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    } while (true);
                }
            }
        }

        private void btnFisYazdir_Click(object sender, EventArgs e)
        {
            //Varsayılan Yazıcı İcin
            //LocalReport report = new LocalReport();
            //string path = Path.GetDirectoryName(Application.ExecutablePath);
            //string fullPath = Path.GetDirectoryName(Application.ExecutablePath).Remove(path.Length - 10) + @"\Report\rptStok.rdlc";
            //report.ReportPath = fullPath;
            //report.DataSources.Add(new ReportDataSource("dsStok", dt));
            //PrintToPrinter(report, false);
            PrintToPrinter(this.reportViewer1.LocalReport, true);
            //this.reportViewer1.LocalReport;
        }

        private void cmbCari_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dgvCari.RowCount > 0)
            {
                cariToplam = 0;

                if (cmbCari.SelectedIndex == 0)
                {
                    //ListeleCari
                    OleDbDataAdapter adpCari = new OleDbDataAdapter("select SatId, Eser.UrunAd as [Ürün], Adet, Fiyat, Toplam, Tarih, Kim from Sat INNER JOIN Eser ON Sat.EserId = Eser.EserId order by UrunAd", baglanti);
                    DataTable dtCari = new DataTable();
                    adpCari.Fill(dtCari);
                    dgvCari.DataSource = dtCari;
                    dgvCari.Columns["SatId"].Visible = dgvCari.Columns["Kim"].Visible = false;
                    dgvCari.Columns[2].DefaultCellStyle.Alignment = dgvCari.Columns[3].DefaultCellStyle.Alignment = dgvCari.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    for (int i = 0; i < dgvCari.RowCount; i++)
                    {
                        cariToplam += (decimal)dgvCari.Rows[i].Cells[4].Value;
                    }
                    lblCariToplam.Text = String.Format("{0:N}\n", cariToplam);
                }
                else
                {
                    //ListeleCari
                    OleDbDataAdapter adpCari = new OleDbDataAdapter("select SatId, Eser.UrunAd as [Ürün], Adet, Fiyat, Toplam, Tarih, Kim from Sat INNER JOIN Eser ON Sat.EserId = Eser.EserId WHERE Kim = " + "'" + cmbCari.SelectedItem.ToString() + "'" + " order by UrunAd", baglanti);
                    DataTable dtCari = new DataTable();
                    adpCari.Fill(dtCari);
                    dgvCari.DataSource = dtCari;
                    dgvCari.Columns["SatId"].Visible = dgvCari.Columns["Kim"].Visible = false;
                    dgvCari.Columns[2].DefaultCellStyle.Alignment = dgvCari.Columns[3].DefaultCellStyle.Alignment = dgvCari.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    for (int i = 0; i < dgvCari.RowCount; i++)
                    {
                        cariToplam += (decimal)dgvCari.Rows[i].Cells[4].Value;
                    }
                    lblCariToplam.Text = String.Format("{0:N}\n", cariToplam);
                }
            }
            else
            {
                lblCariToplam.Text = "0,00";
            }
        }
    }
}
