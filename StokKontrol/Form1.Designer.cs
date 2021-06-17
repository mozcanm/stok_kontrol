
namespace StokKontrol
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dsSatisBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsSatis = new StokKontrol.ReportDataset.dsSatis();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSatis = new System.Windows.Forms.TabPage();
            this.btnFisYazdir = new System.Windows.Forms.Button();
            this.btnStokDus = new System.Windows.Forms.Button();
            this.btnKes = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnSatisTemizle = new System.Windows.Forms.Button();
            this.numSatisFiyat = new System.Windows.Forms.NumericUpDown();
            this.btnSatisSil = new System.Windows.Forms.Button();
            this.btnSatisGuncelle = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblSatisToplam = new System.Windows.Forms.Label();
            this.listSatis = new System.Windows.Forms.ListView();
            this.colAd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFiyat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAdet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colToplam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label16 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblSatisUrunAd = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numSatisAdetGuncelle2 = new System.Windows.Forms.NumericUpDown();
            this.numSatisAdetGuncelle = new System.Windows.Forms.NumericUpDown();
            this.numSatisAdet = new System.Windows.Forms.NumericUpDown();
            this.txtSatisBarkod = new System.Windows.Forms.TextBox();
            this.tabStok = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.numStok = new System.Windows.Forms.NumericUpDown();
            this.lblStokUrun = new System.Windows.Forms.Label();
            this.txtStokAra = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvStok = new System.Windows.Forms.DataGridView();
            this.btnStokSil = new System.Windows.Forms.Button();
            this.btnStokGuncelle = new System.Windows.Forms.Button();
            this.btnPrintStok = new System.Windows.Forms.Button();
            this.btnExcelStok = new System.Windows.Forms.Button();
            this.tabUrun = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvUrun = new System.Windows.Forms.DataGridView();
            this.dtpUrunTarih = new System.Windows.Forms.DateTimePicker();
            this.txtUrunKart = new System.Windows.Forms.TextBox();
            this.txtUrunFiyat = new System.Windows.Forms.TextBox();
            this.txtUrunGelis = new System.Windows.Forms.TextBox();
            this.numUrunAdet = new System.Windows.Forms.NumericUpDown();
            this.txtUrunAra = new System.Windows.Forms.TextBox();
            this.cmbFirma = new System.Windows.Forms.ComboBox();
            this.cmbUrunAd = new System.Windows.Forms.ComboBox();
            this.cmbTur = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUrunSil = new System.Windows.Forms.Button();
            this.btnUrunGuncelle = new System.Windows.Forms.Button();
            this.btnExcelUrun = new System.Windows.Forms.Button();
            this.btnUrunEkle = new System.Windows.Forms.Button();
            this.tabTur = new System.Windows.Forms.TabPage();
            this.dgvGizli = new System.Windows.Forms.DataGridView();
            this.txtEserBarkod = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbTurUrun = new System.Windows.Forms.ComboBox();
            this.txtEser = new System.Windows.Forms.TextBox();
            this.txtFirma = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvEser = new System.Windows.Forms.DataGridView();
            this.txtTur = new System.Windows.Forms.TextBox();
            this.dgvFirma = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTur = new System.Windows.Forms.DataGridView();
            this.btnSilEser = new System.Windows.Forms.Button();
            this.btnSilFirma = new System.Windows.Forms.Button();
            this.btnSilTur = new System.Windows.Forms.Button();
            this.btnGuncelleEser = new System.Windows.Forms.Button();
            this.btnGuncelleFirma = new System.Windows.Forms.Button();
            this.btnGuncelleTur = new System.Windows.Forms.Button();
            this.btnEkleEser = new System.Windows.Forms.Button();
            this.btnEkleFirma = new System.Windows.Forms.Button();
            this.btnEkleTur = new System.Windows.Forms.Button();
            this.tabBarkod = new System.Windows.Forms.TabPage();
            this.dgvBarkodUrun = new System.Windows.Forms.DataGridView();
            this.txtBarkod1 = new System.Windows.Forms.TextBox();
            this.btnBarkodKaydet = new System.Windows.Forms.Button();
            this.picBarkod1 = new System.Windows.Forms.PictureBox();
            this.btnBarkod1 = new System.Windows.Forms.Button();
            this.tabCari = new System.Windows.Forms.TabPage();
            this.btnCariExcel = new System.Windows.Forms.Button();
            this.lblCari = new System.Windows.Forms.Label();
            this.dgvCari = new System.Windows.Forms.DataGridView();
            this.btnCariSil = new System.Windows.Forms.Button();
            this.txtKim = new System.Windows.Forms.TextBox();
            this.cmbCari = new System.Windows.Forms.ComboBox();
            this.lblCariToplam = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dsSatisBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSatis)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabSatis.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSatisFiyat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSatisAdetGuncelle2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSatisAdetGuncelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSatisAdet)).BeginInit();
            this.tabStok.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStok)).BeginInit();
            this.tabUrun.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUrunAdet)).BeginInit();
            this.tabTur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGizli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFirma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTur)).BeginInit();
            this.tabBarkod.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarkodUrun)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBarkod1)).BeginInit();
            this.tabCari.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCari)).BeginInit();
            this.SuspendLayout();
            // 
            // dsSatisBindingSource
            // 
            this.dsSatisBindingSource.DataSource = this.dsSatis;
            this.dsSatisBindingSource.Position = 0;
            // 
            // dsSatis
            // 
            this.dsSatis.DataSetName = "dsSatis";
            this.dsSatis.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabSatis);
            this.tabControl1.Controls.Add(this.tabStok);
            this.tabControl1.Controls.Add(this.tabUrun);
            this.tabControl1.Controls.Add(this.tabTur);
            this.tabControl1.Controls.Add(this.tabBarkod);
            this.tabControl1.Controls.Add(this.tabCari);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1234, 522);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSatis
            // 
            this.tabSatis.Controls.Add(this.txtKim);
            this.tabSatis.Controls.Add(this.btnFisYazdir);
            this.tabSatis.Controls.Add(this.btnStokDus);
            this.tabSatis.Controls.Add(this.btnKes);
            this.tabSatis.Controls.Add(this.reportViewer1);
            this.tabSatis.Controls.Add(this.btnSatisTemizle);
            this.tabSatis.Controls.Add(this.numSatisFiyat);
            this.tabSatis.Controls.Add(this.btnSatisSil);
            this.tabSatis.Controls.Add(this.btnSatisGuncelle);
            this.tabSatis.Controls.Add(this.label21);
            this.tabSatis.Controls.Add(this.label18);
            this.tabSatis.Controls.Add(this.lblSatisToplam);
            this.tabSatis.Controls.Add(this.listSatis);
            this.tabSatis.Controls.Add(this.label16);
            this.tabSatis.Controls.Add(this.label19);
            this.tabSatis.Controls.Add(this.lblSatisUrunAd);
            this.tabSatis.Controls.Add(this.label17);
            this.tabSatis.Controls.Add(this.label15);
            this.tabSatis.Controls.Add(this.numSatisAdetGuncelle2);
            this.tabSatis.Controls.Add(this.numSatisAdetGuncelle);
            this.tabSatis.Controls.Add(this.numSatisAdet);
            this.tabSatis.Controls.Add(this.txtSatisBarkod);
            this.tabSatis.Location = new System.Drawing.Point(4, 29);
            this.tabSatis.Name = "tabSatis";
            this.tabSatis.Size = new System.Drawing.Size(1226, 489);
            this.tabSatis.TabIndex = 4;
            this.tabSatis.Text = "SATIŞ";
            this.tabSatis.UseVisualStyleBackColor = true;
            // 
            // btnFisYazdir
            // 
            this.btnFisYazdir.BackColor = System.Drawing.Color.PowderBlue;
            this.btnFisYazdir.Image = global::StokKontrol.Properties.Resources.fis_stok;
            this.btnFisYazdir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFisYazdir.Location = new System.Drawing.Point(561, 164);
            this.btnFisYazdir.Name = "btnFisYazdir";
            this.btnFisYazdir.Size = new System.Drawing.Size(156, 46);
            this.btnFisYazdir.TabIndex = 22;
            this.btnFisYazdir.Text = "FiŞ YAZDIR";
            this.btnFisYazdir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFisYazdir.UseVisualStyleBackColor = false;
            this.btnFisYazdir.Click += new System.EventHandler(this.btnFisYazdir_Click);
            // 
            // btnStokDus
            // 
            this.btnStokDus.BackColor = System.Drawing.Color.Teal;
            this.btnStokDus.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnStokDus.Image = global::StokKontrol.Properties.Resources.cari_stok;
            this.btnStokDus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStokDus.Location = new System.Drawing.Point(561, 425);
            this.btnStokDus.Name = "btnStokDus";
            this.btnStokDus.Size = new System.Drawing.Size(317, 50);
            this.btnStokDus.TabIndex = 21;
            this.btnStokDus.Text = "STOKTAN DÜŞ ve CARiYE EKLE";
            this.btnStokDus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStokDus.UseVisualStyleBackColor = false;
            this.btnStokDus.Click += new System.EventHandler(this.btnStokDus_Click);
            // 
            // btnKes
            // 
            this.btnKes.BackColor = System.Drawing.Color.LightGray;
            this.btnKes.Image = global::StokKontrol.Properties.Resources.cut_stok;
            this.btnKes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKes.Location = new System.Drawing.Point(561, 216);
            this.btnKes.Name = "btnKes";
            this.btnKes.Size = new System.Drawing.Size(156, 46);
            this.btnKes.TabIndex = 20;
            this.btnKes.Text = "KÂĞIT KES";
            this.btnKes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnKes.UseVisualStyleBackColor = false;
            this.btnKes.Click += new System.EventHandler(this.btnKes_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            reportDataSource4.Name = "dsSatis";
            reportDataSource4.Value = this.dsSatisBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "StokKontrol.Report.rptSatis.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(884, 179);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowContextMenu = false;
            this.reportViewer1.ShowCredentialPrompts = false;
            this.reportViewer1.ShowDocumentMapButton = false;
            this.reportViewer1.ShowExportButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowParameterPrompts = false;
            this.reportViewer1.ShowPromptAreaButton = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.Size = new System.Drawing.Size(290, 296);
            this.reportViewer1.TabIndex = 19;
            // 
            // btnSatisTemizle
            // 
            this.btnSatisTemizle.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnSatisTemizle.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnSatisTemizle.Image = global::StokKontrol.Properties.Resources.clean_stok;
            this.btnSatisTemizle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSatisTemizle.Location = new System.Drawing.Point(561, 324);
            this.btnSatisTemizle.Name = "btnSatisTemizle";
            this.btnSatisTemizle.Size = new System.Drawing.Size(156, 44);
            this.btnSatisTemizle.TabIndex = 18;
            this.btnSatisTemizle.Text = "TEMiZLE";
            this.btnSatisTemizle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSatisTemizle.UseVisualStyleBackColor = false;
            this.btnSatisTemizle.Click += new System.EventHandler(this.btnSatisTemizle_Click);
            // 
            // numSatisFiyat
            // 
            this.numSatisFiyat.DecimalPlaces = 2;
            this.numSatisFiyat.Location = new System.Drawing.Point(973, 145);
            this.numSatisFiyat.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numSatisFiyat.Name = "numSatisFiyat";
            this.numSatisFiyat.Size = new System.Drawing.Size(83, 28);
            this.numSatisFiyat.TabIndex = 17;
            // 
            // btnSatisSil
            // 
            this.btnSatisSil.BackColor = System.Drawing.Color.MistyRose;
            this.btnSatisSil.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatisSil.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSatisSil.Image = ((System.Drawing.Image)(resources.GetObject("btnSatisSil.Image")));
            this.btnSatisSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSatisSil.Location = new System.Drawing.Point(854, 71);
            this.btnSatisSil.Name = "btnSatisSil";
            this.btnSatisSil.Size = new System.Drawing.Size(88, 38);
            this.btnSatisSil.TabIndex = 15;
            this.btnSatisSil.Text = "SİL";
            this.btnSatisSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSatisSil.UseVisualStyleBackColor = false;
            this.btnSatisSil.Click += new System.EventHandler(this.btnSatisSil_Click);
            // 
            // btnSatisGuncelle
            // 
            this.btnSatisGuncelle.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnSatisGuncelle.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatisGuncelle.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnSatisGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("btnSatisGuncelle.Image")));
            this.btnSatisGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSatisGuncelle.Location = new System.Drawing.Point(723, 71);
            this.btnSatisGuncelle.Name = "btnSatisGuncelle";
            this.btnSatisGuncelle.Size = new System.Drawing.Size(125, 38);
            this.btnSatisGuncelle.TabIndex = 11;
            this.btnSatisGuncelle.Text = "GÜNCELLE";
            this.btnSatisGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSatisGuncelle.UseVisualStyleBackColor = false;
            this.btnSatisGuncelle.Click += new System.EventHandler(this.btnSatisGuncelle_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label21.Location = new System.Drawing.Point(8, 75);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(112, 20);
            this.label21.TabIndex = 4;
            this.label21.Text = "BİLGİ FİŞİ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label18.Location = new System.Drawing.Point(280, 75);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 20);
            this.label18.TabIndex = 4;
            this.label18.Text = "TOPLAM :";
            // 
            // lblSatisToplam
            // 
            this.lblSatisToplam.Location = new System.Drawing.Point(386, 75);
            this.lblSatisToplam.Name = "lblSatisToplam";
            this.lblSatisToplam.Size = new System.Drawing.Size(162, 20);
            this.lblSatisToplam.TabIndex = 4;
            this.lblSatisToplam.Text = "0,00";
            this.lblSatisToplam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // listSatis
            // 
            this.listSatis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listSatis.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAd,
            this.colFiyat,
            this.colAdet,
            this.colToplam});
            this.listSatis.FullRowSelect = true;
            this.listSatis.GridLines = true;
            this.listSatis.HideSelection = false;
            this.listSatis.Location = new System.Drawing.Point(8, 107);
            this.listSatis.Name = "listSatis";
            this.listSatis.Size = new System.Drawing.Size(547, 368);
            this.listSatis.TabIndex = 2;
            this.listSatis.UseCompatibleStateImageBehavior = false;
            this.listSatis.View = System.Windows.Forms.View.Details;
            this.listSatis.SelectedIndexChanged += new System.EventHandler(this.listSatis_SelectedIndexChanged);
            // 
            // colAd
            // 
            this.colAd.Text = "Urun";
            this.colAd.Width = 300;
            // 
            // colFiyat
            // 
            this.colFiyat.Text = "Fiyat";
            this.colFiyat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colFiyat.Width = 80;
            // 
            // colAdet
            // 
            this.colAdet.Text = "Adet";
            this.colAdet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colToplam
            // 
            this.colToplam.Text = "Toplam";
            this.colToplam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colToplam.Width = 100;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label16.Location = new System.Drawing.Point(449, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 20);
            this.label16.TabIndex = 2;
            this.label16.Text = "Adet";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label19.ForeColor = System.Drawing.Color.DarkOrange;
            this.label19.Location = new System.Drawing.Point(557, 75);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 20);
            this.label19.TabIndex = 2;
            this.label19.Text = "Adet :";
            // 
            // lblSatisUrunAd
            // 
            this.lblSatisUrunAd.AutoSize = true;
            this.lblSatisUrunAd.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSatisUrunAd.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblSatisUrunAd.Location = new System.Drawing.Point(557, 45);
            this.lblSatisUrunAd.Name = "lblSatisUrunAd";
            this.lblSatisUrunAd.Size = new System.Drawing.Size(50, 20);
            this.lblSatisUrunAd.TabIndex = 2;
            this.lblSatisUrunAd.Text = "Ürün";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Verdana", 12.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label17.ForeColor = System.Drawing.Color.DarkOrange;
            this.label17.Location = new System.Drawing.Point(557, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 20);
            this.label17.TabIndex = 2;
            this.label17.Text = "Ürün";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label15.Location = new System.Drawing.Point(8, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 20);
            this.label15.TabIndex = 2;
            this.label15.Text = "Barkod";
            // 
            // numSatisAdetGuncelle2
            // 
            this.numSatisAdetGuncelle2.Location = new System.Drawing.Point(884, 145);
            this.numSatisAdetGuncelle2.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numSatisAdetGuncelle2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSatisAdetGuncelle2.Name = "numSatisAdetGuncelle2";
            this.numSatisAdetGuncelle2.Size = new System.Drawing.Size(83, 28);
            this.numSatisAdetGuncelle2.TabIndex = 1;
            this.numSatisAdetGuncelle2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numSatisAdetGuncelle
            // 
            this.numSatisAdetGuncelle.ForeColor = System.Drawing.Color.DarkOrange;
            this.numSatisAdetGuncelle.Location = new System.Drawing.Point(630, 73);
            this.numSatisAdetGuncelle.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numSatisAdetGuncelle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSatisAdetGuncelle.Name = "numSatisAdetGuncelle";
            this.numSatisAdetGuncelle.Size = new System.Drawing.Size(83, 28);
            this.numSatisAdetGuncelle.TabIndex = 1;
            this.numSatisAdetGuncelle.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numSatisAdet
            // 
            this.numSatisAdet.Location = new System.Drawing.Point(453, 35);
            this.numSatisAdet.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numSatisAdet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSatisAdet.Name = "numSatisAdet";
            this.numSatisAdet.Size = new System.Drawing.Size(90, 28);
            this.numSatisAdet.TabIndex = 1;
            this.numSatisAdet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtSatisBarkod
            // 
            this.txtSatisBarkod.Location = new System.Drawing.Point(8, 34);
            this.txtSatisBarkod.Name = "txtSatisBarkod";
            this.txtSatisBarkod.Size = new System.Drawing.Size(138, 28);
            this.txtSatisBarkod.TabIndex = 0;
            this.txtSatisBarkod.TextChanged += new System.EventHandler(this.txtSatisBarkod_TextChanged);
            // 
            // tabStok
            // 
            this.tabStok.Controls.Add(this.label22);
            this.tabStok.Controls.Add(this.numStok);
            this.tabStok.Controls.Add(this.lblStokUrun);
            this.tabStok.Controls.Add(this.txtStokAra);
            this.tabStok.Controls.Add(this.label11);
            this.tabStok.Controls.Add(this.dgvStok);
            this.tabStok.Controls.Add(this.btnStokSil);
            this.tabStok.Controls.Add(this.btnStokGuncelle);
            this.tabStok.Controls.Add(this.btnPrintStok);
            this.tabStok.Controls.Add(this.btnExcelStok);
            this.tabStok.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabStok.Location = new System.Drawing.Point(4, 29);
            this.tabStok.Name = "tabStok";
            this.tabStok.Padding = new System.Windows.Forms.Padding(3);
            this.tabStok.Size = new System.Drawing.Size(1226, 489);
            this.tabStok.TabIndex = 1;
            this.tabStok.Text = "STOK KONTROL";
            this.tabStok.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.DarkOrange;
            this.label22.Location = new System.Drawing.Point(1064, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 20);
            this.label22.TabIndex = 18;
            this.label22.Text = "Adet";
            // 
            // numStok
            // 
            this.numStok.ForeColor = System.Drawing.Color.DarkOrange;
            this.numStok.Location = new System.Drawing.Point(1046, 31);
            this.numStok.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numStok.Name = "numStok";
            this.numStok.Size = new System.Drawing.Size(85, 28);
            this.numStok.TabIndex = 15;
            this.numStok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numStok.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblStokUrun
            // 
            this.lblStokUrun.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblStokUrun.Location = new System.Drawing.Point(587, 26);
            this.lblStokUrun.Name = "lblStokUrun";
            this.lblStokUrun.Size = new System.Drawing.Size(453, 36);
            this.lblStokUrun.TabIndex = 14;
            this.lblStokUrun.Text = "Ürün :";
            this.lblStokUrun.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStokAra
            // 
            this.txtStokAra.Location = new System.Drawing.Point(144, 27);
            this.txtStokAra.MaxLength = 45;
            this.txtStokAra.Name = "txtStokAra";
            this.txtStokAra.Size = new System.Drawing.Size(195, 28);
            this.txtStokAra.TabIndex = 11;
            this.txtStokAra.TextChanged += new System.EventHandler(this.txtStokAra_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(13, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 20);
            this.label11.TabIndex = 10;
            this.label11.Text = "ÜRÜN ARA :";
            // 
            // dgvStok
            // 
            this.dgvStok.AllowUserToAddRows = false;
            this.dgvStok.AllowUserToResizeRows = false;
            this.dgvStok.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStok.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvStok.BackgroundColor = System.Drawing.Color.White;
            this.dgvStok.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStok.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvStok.Location = new System.Drawing.Point(17, 74);
            this.dgvStok.Name = "dgvStok";
            this.dgvStok.ReadOnly = true;
            this.dgvStok.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStok.Size = new System.Drawing.Size(1192, 409);
            this.dgvStok.TabIndex = 9;
            this.dgvStok.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStok_CellClick);
            this.dgvStok.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvStok_DataBindingComplete);
            this.dgvStok.SelectionChanged += new System.EventHandler(this.dgvStok_SelectionChanged);
            // 
            // btnStokSil
            // 
            this.btnStokSil.BackColor = System.Drawing.Color.MistyRose;
            this.btnStokSil.Image = ((System.Drawing.Image)(resources.GetObject("btnStokSil.Image")));
            this.btnStokSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStokSil.Location = new System.Drawing.Point(1179, 23);
            this.btnStokSil.Name = "btnStokSil";
            this.btnStokSil.Size = new System.Drawing.Size(40, 42);
            this.btnStokSil.TabIndex = 17;
            this.btnStokSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStokSil.UseVisualStyleBackColor = false;
            this.btnStokSil.Click += new System.EventHandler(this.btnStokSil_Click);
            // 
            // btnStokGuncelle
            // 
            this.btnStokGuncelle.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnStokGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("btnStokGuncelle.Image")));
            this.btnStokGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStokGuncelle.Location = new System.Drawing.Point(1135, 23);
            this.btnStokGuncelle.Name = "btnStokGuncelle";
            this.btnStokGuncelle.Size = new System.Drawing.Size(41, 42);
            this.btnStokGuncelle.TabIndex = 16;
            this.btnStokGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStokGuncelle.UseVisualStyleBackColor = false;
            this.btnStokGuncelle.Click += new System.EventHandler(this.btnStokGuncelle_Click);
            // 
            // btnPrintStok
            // 
            this.btnPrintStok.BackColor = System.Drawing.Color.LightCyan;
            this.btnPrintStok.Image = global::StokKontrol.Properties.Resources.print_stok;
            this.btnPrintStok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintStok.Location = new System.Drawing.Point(464, 20);
            this.btnPrintStok.Name = "btnPrintStok";
            this.btnPrintStok.Size = new System.Drawing.Size(117, 43);
            this.btnPrintStok.TabIndex = 13;
            this.btnPrintStok.Text = "YAZDIR";
            this.btnPrintStok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintStok.UseVisualStyleBackColor = false;
            this.btnPrintStok.Click += new System.EventHandler(this.btnPrintStok_Click);
            // 
            // btnExcelStok
            // 
            this.btnExcelStok.BackColor = System.Drawing.Color.LightGreen;
            this.btnExcelStok.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelStok.Image")));
            this.btnExcelStok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelStok.Location = new System.Drawing.Point(348, 20);
            this.btnExcelStok.Name = "btnExcelStok";
            this.btnExcelStok.Size = new System.Drawing.Size(110, 43);
            this.btnExcelStok.TabIndex = 12;
            this.btnExcelStok.Text = "EXCEL";
            this.btnExcelStok.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcelStok.UseVisualStyleBackColor = false;
            this.btnExcelStok.Click += new System.EventHandler(this.btnExcelStok_Click);
            // 
            // tabUrun
            // 
            this.tabUrun.Controls.Add(this.button1);
            this.tabUrun.Controls.Add(this.dgvUrun);
            this.tabUrun.Controls.Add(this.dtpUrunTarih);
            this.tabUrun.Controls.Add(this.txtUrunKart);
            this.tabUrun.Controls.Add(this.txtUrunFiyat);
            this.tabUrun.Controls.Add(this.txtUrunGelis);
            this.tabUrun.Controls.Add(this.numUrunAdet);
            this.tabUrun.Controls.Add(this.txtUrunAra);
            this.tabUrun.Controls.Add(this.cmbFirma);
            this.tabUrun.Controls.Add(this.cmbUrunAd);
            this.tabUrun.Controls.Add(this.cmbTur);
            this.tabUrun.Controls.Add(this.label12);
            this.tabUrun.Controls.Add(this.label7);
            this.tabUrun.Controls.Add(this.label6);
            this.tabUrun.Controls.Add(this.label5);
            this.tabUrun.Controls.Add(this.label4);
            this.tabUrun.Controls.Add(this.label10);
            this.tabUrun.Controls.Add(this.label3);
            this.tabUrun.Controls.Add(this.label8);
            this.tabUrun.Controls.Add(this.label2);
            this.tabUrun.Controls.Add(this.btnUrunSil);
            this.tabUrun.Controls.Add(this.btnUrunGuncelle);
            this.tabUrun.Controls.Add(this.btnExcelUrun);
            this.tabUrun.Controls.Add(this.btnUrunEkle);
            this.tabUrun.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabUrun.Location = new System.Drawing.Point(4, 29);
            this.tabUrun.Name = "tabUrun";
            this.tabUrun.Size = new System.Drawing.Size(1226, 489);
            this.tabUrun.TabIndex = 2;
            this.tabUrun.Text = "Ürün Cari Giriş";
            this.tabUrun.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(1091, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 27);
            this.button1.TabIndex = 12;
            this.button1.Text = "Temizle";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvUrun
            // 
            this.dgvUrun.AllowUserToAddRows = false;
            this.dgvUrun.AllowUserToResizeRows = false;
            this.dgvUrun.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUrun.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUrun.BackgroundColor = System.Drawing.Color.White;
            this.dgvUrun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUrun.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvUrun.Location = new System.Drawing.Point(12, 146);
            this.dgvUrun.Name = "dgvUrun";
            this.dgvUrun.ReadOnly = true;
            this.dgvUrun.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUrun.Size = new System.Drawing.Size(1192, 336);
            this.dgvUrun.TabIndex = 8;
            this.dgvUrun.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUrun_CellClick);
            this.dgvUrun.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvUrun_DataBindingComplete);
            this.dgvUrun.SelectionChanged += new System.EventHandler(this.dgvUrun_SelectionChanged);
            // 
            // dtpUrunTarih
            // 
            this.dtpUrunTarih.CustomFormat = "dd/MM/yyyy";
            this.dtpUrunTarih.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpUrunTarih.Location = new System.Drawing.Point(306, 112);
            this.dtpUrunTarih.Name = "dtpUrunTarih";
            this.dtpUrunTarih.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpUrunTarih.RightToLeftLayout = true;
            this.dtpUrunTarih.Size = new System.Drawing.Size(141, 28);
            this.dtpUrunTarih.TabIndex = 7;
            // 
            // txtUrunKart
            // 
            this.txtUrunKart.Location = new System.Drawing.Point(1078, 33);
            this.txtUrunKart.MaxLength = 9;
            this.txtUrunKart.Name = "txtUrunKart";
            this.txtUrunKart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUrunKart.Size = new System.Drawing.Size(126, 28);
            this.txtUrunKart.TabIndex = 6;
            this.txtUrunKart.Text = "0";
            this.txtUrunKart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUrunKart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUrunKart_KeyPress);
            // 
            // txtUrunFiyat
            // 
            this.txtUrunFiyat.Location = new System.Drawing.Point(947, 33);
            this.txtUrunFiyat.MaxLength = 9;
            this.txtUrunFiyat.Name = "txtUrunFiyat";
            this.txtUrunFiyat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUrunFiyat.Size = new System.Drawing.Size(126, 28);
            this.txtUrunFiyat.TabIndex = 6;
            this.txtUrunFiyat.Text = "0";
            this.txtUrunFiyat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUrunFiyat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUrunFiyat_KeyPress);
            // 
            // txtUrunGelis
            // 
            this.txtUrunGelis.Location = new System.Drawing.Point(815, 33);
            this.txtUrunGelis.MaxLength = 9;
            this.txtUrunGelis.Name = "txtUrunGelis";
            this.txtUrunGelis.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUrunGelis.Size = new System.Drawing.Size(126, 28);
            this.txtUrunGelis.TabIndex = 6;
            this.txtUrunGelis.Text = "0";
            this.txtUrunGelis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUrunGelis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUrunGelis_KeyPress);
            // 
            // numUrunAdet
            // 
            this.numUrunAdet.Location = new System.Drawing.Point(724, 33);
            this.numUrunAdet.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numUrunAdet.Name = "numUrunAdet";
            this.numUrunAdet.Size = new System.Drawing.Size(85, 28);
            this.numUrunAdet.TabIndex = 5;
            this.numUrunAdet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtUrunAra
            // 
            this.txtUrunAra.Location = new System.Drawing.Point(520, 112);
            this.txtUrunAra.MaxLength = 45;
            this.txtUrunAra.Name = "txtUrunAra";
            this.txtUrunAra.Size = new System.Drawing.Size(195, 28);
            this.txtUrunAra.TabIndex = 4;
            this.txtUrunAra.TextChanged += new System.EventHandler(this.txtUrunAra_TextChanged);
            // 
            // cmbFirma
            // 
            this.cmbFirma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFirma.FormattingEnabled = true;
            this.cmbFirma.Location = new System.Drawing.Point(12, 112);
            this.cmbFirma.Name = "cmbFirma";
            this.cmbFirma.Size = new System.Drawing.Size(288, 28);
            this.cmbFirma.TabIndex = 3;
            // 
            // cmbUrunAd
            // 
            this.cmbUrunAd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUrunAd.FormattingEnabled = true;
            this.cmbUrunAd.Location = new System.Drawing.Point(221, 34);
            this.cmbUrunAd.Name = "cmbUrunAd";
            this.cmbUrunAd.Size = new System.Drawing.Size(494, 28);
            this.cmbUrunAd.TabIndex = 3;
            // 
            // cmbTur
            // 
            this.cmbTur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTur.FormattingEnabled = true;
            this.cmbTur.Location = new System.Drawing.Point(12, 34);
            this.cmbTur.Name = "cmbTur";
            this.cmbTur.Size = new System.Drawing.Size(203, 28);
            this.cmbTur.TabIndex = 3;
            this.cmbTur.SelectionChangeCommitted += new System.EventHandler(this.cmbTur_SelectionChangeCommitted_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(1140, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 20);
            this.label12.TabIndex = 2;
            this.label12.Text = "KART";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(302, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "TARİH";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(1009, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "FİYAT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(877, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "GELİŞ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(720, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "ADET";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(516, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "ÜRÜN ARA :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(217, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "ÜRÜN";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(8, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 2;
            this.label8.Text = "FİRMA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(8, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "TÜR";
            // 
            // btnUrunSil
            // 
            this.btnUrunSil.BackColor = System.Drawing.Color.MistyRose;
            this.btnUrunSil.Image = ((System.Drawing.Image)(resources.GetObject("btnUrunSil.Image")));
            this.btnUrunSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUrunSil.Location = new System.Drawing.Point(1091, 97);
            this.btnUrunSil.Name = "btnUrunSil";
            this.btnUrunSil.Size = new System.Drawing.Size(113, 43);
            this.btnUrunSil.TabIndex = 9;
            this.btnUrunSil.Text = "SİL";
            this.btnUrunSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUrunSil.UseVisualStyleBackColor = false;
            this.btnUrunSil.Click += new System.EventHandler(this.btnUrunSil_Click);
            // 
            // btnUrunGuncelle
            // 
            this.btnUrunGuncelle.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnUrunGuncelle.Image = ((System.Drawing.Image)(resources.GetObject("btnUrunGuncelle.Image")));
            this.btnUrunGuncelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUrunGuncelle.Location = new System.Drawing.Point(944, 97);
            this.btnUrunGuncelle.Name = "btnUrunGuncelle";
            this.btnUrunGuncelle.Size = new System.Drawing.Size(141, 43);
            this.btnUrunGuncelle.TabIndex = 10;
            this.btnUrunGuncelle.Text = "GÜNCELLE";
            this.btnUrunGuncelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUrunGuncelle.UseVisualStyleBackColor = false;
            this.btnUrunGuncelle.Click += new System.EventHandler(this.btnUrunGuncelle_Click);
            // 
            // btnExcelUrun
            // 
            this.btnExcelUrun.BackColor = System.Drawing.Color.LightGreen;
            this.btnExcelUrun.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelUrun.Image")));
            this.btnExcelUrun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcelUrun.Location = new System.Drawing.Point(723, 97);
            this.btnExcelUrun.Name = "btnExcelUrun";
            this.btnExcelUrun.Size = new System.Drawing.Size(108, 43);
            this.btnExcelUrun.TabIndex = 11;
            this.btnExcelUrun.Text = "EXCEL";
            this.btnExcelUrun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcelUrun.UseVisualStyleBackColor = false;
            this.btnExcelUrun.Click += new System.EventHandler(this.btnExcelUrun_Click);
            // 
            // btnUrunEkle
            // 
            this.btnUrunEkle.BackColor = System.Drawing.Color.LightCyan;
            this.btnUrunEkle.Image = ((System.Drawing.Image)(resources.GetObject("btnUrunEkle.Image")));
            this.btnUrunEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUrunEkle.Location = new System.Drawing.Point(837, 97);
            this.btnUrunEkle.Name = "btnUrunEkle";
            this.btnUrunEkle.Size = new System.Drawing.Size(101, 43);
            this.btnUrunEkle.TabIndex = 11;
            this.btnUrunEkle.Text = "EKLE";
            this.btnUrunEkle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUrunEkle.UseVisualStyleBackColor = false;
            this.btnUrunEkle.Click += new System.EventHandler(this.btnUrunEkle_Click);
            // 
            // tabTur
            // 
            this.tabTur.Controls.Add(this.dgvGizli);
            this.tabTur.Controls.Add(this.txtEserBarkod);
            this.tabTur.Controls.Add(this.label20);
            this.tabTur.Controls.Add(this.label14);
            this.tabTur.Controls.Add(this.cmbTurUrun);
            this.tabTur.Controls.Add(this.txtEser);
            this.tabTur.Controls.Add(this.txtFirma);
            this.tabTur.Controls.Add(this.label13);
            this.tabTur.Controls.Add(this.label9);
            this.tabTur.Controls.Add(this.dgvEser);
            this.tabTur.Controls.Add(this.txtTur);
            this.tabTur.Controls.Add(this.dgvFirma);
            this.tabTur.Controls.Add(this.label1);
            this.tabTur.Controls.Add(this.dgvTur);
            this.tabTur.Controls.Add(this.btnSilEser);
            this.tabTur.Controls.Add(this.btnSilFirma);
            this.tabTur.Controls.Add(this.btnSilTur);
            this.tabTur.Controls.Add(this.btnGuncelleEser);
            this.tabTur.Controls.Add(this.btnGuncelleFirma);
            this.tabTur.Controls.Add(this.btnGuncelleTur);
            this.tabTur.Controls.Add(this.btnEkleEser);
            this.tabTur.Controls.Add(this.btnEkleFirma);
            this.tabTur.Controls.Add(this.btnEkleTur);
            this.tabTur.Location = new System.Drawing.Point(4, 29);
            this.tabTur.Name = "tabTur";
            this.tabTur.Size = new System.Drawing.Size(1226, 489);
            this.tabTur.TabIndex = 3;
            this.tabTur.Text = "Tür / Ürün / Firma";
            this.tabTur.UseVisualStyleBackColor = true;
            // 
            // dgvGizli
            // 
            this.dgvGizli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGizli.Location = new System.Drawing.Point(341, 129);
            this.dgvGizli.Name = "dgvGizli";
            this.dgvGizli.Size = new System.Drawing.Size(240, 20);
            this.dgvGizli.TabIndex = 7;
            // 
            // txtEserBarkod
            // 
            this.txtEserBarkod.Location = new System.Drawing.Point(727, 126);
            this.txtEserBarkod.MaxLength = 8;
            this.txtEserBarkod.Name = "txtEserBarkod";
            this.txtEserBarkod.Size = new System.Drawing.Size(119, 28);
            this.txtEserBarkod.TabIndex = 6;
            this.txtEserBarkod.Text = "12345678";
            this.txtEserBarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEserBarkod_KeyPress);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label20.Location = new System.Drawing.Point(595, 129);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(129, 20);
            this.label20.TabIndex = 5;
            this.label20.Text = "BARKOD NO :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.Location = new System.Drawing.Point(413, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 20);
            this.label14.TabIndex = 5;
            this.label14.Text = "TÜR :";
            // 
            // cmbTurUrun
            // 
            this.cmbTurUrun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTurUrun.FormattingEnabled = true;
            this.cmbTurUrun.Location = new System.Drawing.Point(476, 55);
            this.cmbTurUrun.Name = "cmbTurUrun";
            this.cmbTurUrun.Size = new System.Drawing.Size(370, 28);
            this.cmbTurUrun.TabIndex = 4;
            this.cmbTurUrun.SelectionChangeCommitted += new System.EventHandler(this.cmbTurUrun_SelectionChangeCommitted);
            // 
            // txtEser
            // 
            this.txtEser.Location = new System.Drawing.Point(341, 89);
            this.txtEser.MaxLength = 47;
            this.txtEser.Name = "txtEser";
            this.txtEser.Size = new System.Drawing.Size(505, 28);
            this.txtEser.TabIndex = 2;
            // 
            // txtFirma
            // 
            this.txtFirma.Location = new System.Drawing.Point(852, 55);
            this.txtFirma.MaxLength = 15;
            this.txtFirma.Name = "txtFirma";
            this.txtFirma.Size = new System.Drawing.Size(370, 28);
            this.txtFirma.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label13.Location = new System.Drawing.Point(345, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 20);
            this.label13.TabIndex = 1;
            this.label13.Text = "ÜRÜN";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(848, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "FİRMA";
            // 
            // dgvEser
            // 
            this.dgvEser.AllowUserToAddRows = false;
            this.dgvEser.AllowUserToResizeRows = false;
            this.dgvEser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvEser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEser.BackgroundColor = System.Drawing.Color.White;
            this.dgvEser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEser.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvEser.Location = new System.Drawing.Point(341, 205);
            this.dgvEser.Name = "dgvEser";
            this.dgvEser.ReadOnly = true;
            this.dgvEser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEser.Size = new System.Drawing.Size(505, 277);
            this.dgvEser.TabIndex = 0;
            this.dgvEser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEser_CellClick);
            this.dgvEser.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvEser_DataBindingComplete);
            this.dgvEser.SelectionChanged += new System.EventHandler(this.dgvEser_SelectionChanged);
            // 
            // txtTur
            // 
            this.txtTur.Location = new System.Drawing.Point(9, 55);
            this.txtTur.MaxLength = 17;
            this.txtTur.Name = "txtTur";
            this.txtTur.Size = new System.Drawing.Size(326, 28);
            this.txtTur.TabIndex = 2;
            // 
            // dgvFirma
            // 
            this.dgvFirma.AllowUserToAddRows = false;
            this.dgvFirma.AllowUserToResizeRows = false;
            this.dgvFirma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvFirma.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFirma.BackgroundColor = System.Drawing.Color.White;
            this.dgvFirma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFirma.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvFirma.Location = new System.Drawing.Point(852, 136);
            this.dgvFirma.Name = "dgvFirma";
            this.dgvFirma.ReadOnly = true;
            this.dgvFirma.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFirma.Size = new System.Drawing.Size(370, 346);
            this.dgvFirma.TabIndex = 0;
            this.dgvFirma.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFirma_CellClick);
            this.dgvFirma.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvFirma_DataBindingComplete);
            this.dgvFirma.SelectionChanged += new System.EventHandler(this.dgvFirma_SelectionChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(5, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "TÜR";
            // 
            // dgvTur
            // 
            this.dgvTur.AllowUserToAddRows = false;
            this.dgvTur.AllowUserToResizeRows = false;
            this.dgvTur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTur.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTur.BackgroundColor = System.Drawing.Color.White;
            this.dgvTur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTur.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvTur.Location = new System.Drawing.Point(9, 136);
            this.dgvTur.Name = "dgvTur";
            this.dgvTur.ReadOnly = true;
            this.dgvTur.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTur.Size = new System.Drawing.Size(326, 346);
            this.dgvTur.TabIndex = 0;
            this.dgvTur.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTur_CellClick);
            this.dgvTur.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvTur_DataBindingComplete);
            this.dgvTur.SelectionChanged += new System.EventHandler(this.dgvTur_SelectionChanged);
            // 
            // btnSilEser
            // 
            this.btnSilEser.BackColor = System.Drawing.Color.MistyRose;
            this.btnSilEser.Image = ((System.Drawing.Image)(resources.GetObject("btnSilEser.Image")));
            this.btnSilEser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSilEser.Location = new System.Drawing.Point(694, 160);
            this.btnSilEser.Name = "btnSilEser";
            this.btnSilEser.Size = new System.Drawing.Size(152, 41);
            this.btnSilEser.TabIndex = 3;
            this.btnSilEser.Text = "SİL";
            this.btnSilEser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSilEser.UseVisualStyleBackColor = false;
            this.btnSilEser.Click += new System.EventHandler(this.btnSilEser_Click);
            // 
            // btnSilFirma
            // 
            this.btnSilFirma.BackColor = System.Drawing.Color.MistyRose;
            this.btnSilFirma.Image = ((System.Drawing.Image)(resources.GetObject("btnSilFirma.Image")));
            this.btnSilFirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSilFirma.Location = new System.Drawing.Point(1118, 89);
            this.btnSilFirma.Name = "btnSilFirma";
            this.btnSilFirma.Size = new System.Drawing.Size(104, 41);
            this.btnSilFirma.TabIndex = 3;
            this.btnSilFirma.Text = "SİL";
            this.btnSilFirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSilFirma.UseVisualStyleBackColor = false;
            this.btnSilFirma.Click += new System.EventHandler(this.btnSilFirma_Click);
            // 
            // btnSilTur
            // 
            this.btnSilTur.BackColor = System.Drawing.Color.MistyRose;
            this.btnSilTur.Image = ((System.Drawing.Image)(resources.GetObject("btnSilTur.Image")));
            this.btnSilTur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSilTur.Location = new System.Drawing.Point(255, 89);
            this.btnSilTur.Name = "btnSilTur";
            this.btnSilTur.Size = new System.Drawing.Size(80, 41);
            this.btnSilTur.TabIndex = 3;
            this.btnSilTur.Text = "SİL";
            this.btnSilTur.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSilTur.UseVisualStyleBackColor = false;
            this.btnSilTur.Click += new System.EventHandler(this.btnSilTur_Click);
            // 
            // btnGuncelleEser
            // 
            this.btnGuncelleEser.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnGuncelleEser.Image = ((System.Drawing.Image)(resources.GetObject("btnGuncelleEser.Image")));
            this.btnGuncelleEser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuncelleEser.Location = new System.Drawing.Point(500, 160);
            this.btnGuncelleEser.Name = "btnGuncelleEser";
            this.btnGuncelleEser.Size = new System.Drawing.Size(188, 41);
            this.btnGuncelleEser.TabIndex = 3;
            this.btnGuncelleEser.Text = "GÜNCELLE";
            this.btnGuncelleEser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuncelleEser.UseVisualStyleBackColor = false;
            this.btnGuncelleEser.Click += new System.EventHandler(this.btnGuncelleEser_Click);
            // 
            // btnGuncelleFirma
            // 
            this.btnGuncelleFirma.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnGuncelleFirma.Image = ((System.Drawing.Image)(resources.GetObject("btnGuncelleFirma.Image")));
            this.btnGuncelleFirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuncelleFirma.Location = new System.Drawing.Point(966, 89);
            this.btnGuncelleFirma.Name = "btnGuncelleFirma";
            this.btnGuncelleFirma.Size = new System.Drawing.Size(146, 41);
            this.btnGuncelleFirma.TabIndex = 3;
            this.btnGuncelleFirma.Text = "GÜNCELLE";
            this.btnGuncelleFirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuncelleFirma.UseVisualStyleBackColor = false;
            this.btnGuncelleFirma.Click += new System.EventHandler(this.btnGuncelleFirma_Click);
            // 
            // btnGuncelleTur
            // 
            this.btnGuncelleTur.BackColor = System.Drawing.Color.LemonChiffon;
            this.btnGuncelleTur.Image = ((System.Drawing.Image)(resources.GetObject("btnGuncelleTur.Image")));
            this.btnGuncelleTur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuncelleTur.Location = new System.Drawing.Point(110, 89);
            this.btnGuncelleTur.Name = "btnGuncelleTur";
            this.btnGuncelleTur.Size = new System.Drawing.Size(139, 41);
            this.btnGuncelleTur.TabIndex = 3;
            this.btnGuncelleTur.Text = "GÜNCELLE";
            this.btnGuncelleTur.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuncelleTur.UseVisualStyleBackColor = false;
            this.btnGuncelleTur.Click += new System.EventHandler(this.btnGuncelleTur_Click);
            // 
            // btnEkleEser
            // 
            this.btnEkleEser.BackColor = System.Drawing.Color.LightCyan;
            this.btnEkleEser.Image = ((System.Drawing.Image)(resources.GetObject("btnEkleEser.Image")));
            this.btnEkleEser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEkleEser.Location = new System.Drawing.Point(341, 160);
            this.btnEkleEser.Name = "btnEkleEser";
            this.btnEkleEser.Size = new System.Drawing.Size(153, 41);
            this.btnEkleEser.TabIndex = 3;
            this.btnEkleEser.Text = "EKLE";
            this.btnEkleEser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEkleEser.UseVisualStyleBackColor = false;
            this.btnEkleEser.Click += new System.EventHandler(this.btnEkleEser_Click);
            // 
            // btnEkleFirma
            // 
            this.btnEkleFirma.BackColor = System.Drawing.Color.LightCyan;
            this.btnEkleFirma.Image = ((System.Drawing.Image)(resources.GetObject("btnEkleFirma.Image")));
            this.btnEkleFirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEkleFirma.Location = new System.Drawing.Point(852, 89);
            this.btnEkleFirma.Name = "btnEkleFirma";
            this.btnEkleFirma.Size = new System.Drawing.Size(108, 41);
            this.btnEkleFirma.TabIndex = 3;
            this.btnEkleFirma.Text = "EKLE";
            this.btnEkleFirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEkleFirma.UseVisualStyleBackColor = false;
            this.btnEkleFirma.Click += new System.EventHandler(this.btnEkleFirma_Click);
            // 
            // btnEkleTur
            // 
            this.btnEkleTur.BackColor = System.Drawing.Color.LightCyan;
            this.btnEkleTur.Image = ((System.Drawing.Image)(resources.GetObject("btnEkleTur.Image")));
            this.btnEkleTur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEkleTur.Location = new System.Drawing.Point(9, 89);
            this.btnEkleTur.Name = "btnEkleTur";
            this.btnEkleTur.Size = new System.Drawing.Size(95, 41);
            this.btnEkleTur.TabIndex = 3;
            this.btnEkleTur.Text = "EKLE";
            this.btnEkleTur.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEkleTur.UseVisualStyleBackColor = false;
            this.btnEkleTur.Click += new System.EventHandler(this.btnEkleTur_Click);
            // 
            // tabBarkod
            // 
            this.tabBarkod.Controls.Add(this.dgvBarkodUrun);
            this.tabBarkod.Controls.Add(this.txtBarkod1);
            this.tabBarkod.Controls.Add(this.btnBarkodKaydet);
            this.tabBarkod.Controls.Add(this.picBarkod1);
            this.tabBarkod.Controls.Add(this.btnBarkod1);
            this.tabBarkod.Location = new System.Drawing.Point(4, 29);
            this.tabBarkod.Name = "tabBarkod";
            this.tabBarkod.Size = new System.Drawing.Size(1226, 489);
            this.tabBarkod.TabIndex = 5;
            this.tabBarkod.Text = "Barkod";
            this.tabBarkod.UseVisualStyleBackColor = true;
            // 
            // dgvBarkodUrun
            // 
            this.dgvBarkodUrun.AllowUserToAddRows = false;
            this.dgvBarkodUrun.AllowUserToResizeRows = false;
            this.dgvBarkodUrun.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvBarkodUrun.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBarkodUrun.BackgroundColor = System.Drawing.Color.White;
            this.dgvBarkodUrun.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarkodUrun.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvBarkodUrun.Location = new System.Drawing.Point(188, 14);
            this.dgvBarkodUrun.Name = "dgvBarkodUrun";
            this.dgvBarkodUrun.ReadOnly = true;
            this.dgvBarkodUrun.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBarkodUrun.Size = new System.Drawing.Size(732, 468);
            this.dgvBarkodUrun.TabIndex = 4;
            this.dgvBarkodUrun.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBarkodUrun_CellClick);
            this.dgvBarkodUrun.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvBarkodUrun_DataBindingComplete);
            this.dgvBarkodUrun.SelectionChanged += new System.EventHandler(this.dgvBarkodUrun_SelectionChanged);
            // 
            // txtBarkod1
            // 
            this.txtBarkod1.Location = new System.Drawing.Point(8, 131);
            this.txtBarkod1.MaxLength = 8;
            this.txtBarkod1.Name = "txtBarkod1";
            this.txtBarkod1.Size = new System.Drawing.Size(158, 28);
            this.txtBarkod1.TabIndex = 0;
            this.txtBarkod1.Text = "12345678";
            this.txtBarkod1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarkod1_KeyPress);
            // 
            // btnBarkodKaydet
            // 
            this.btnBarkodKaydet.BackColor = System.Drawing.Color.Bisque;
            this.btnBarkodKaydet.Image = global::StokKontrol.Properties.Resources.save_stok;
            this.btnBarkodKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBarkodKaydet.Location = new System.Drawing.Point(8, 237);
            this.btnBarkodKaydet.Name = "btnBarkodKaydet";
            this.btnBarkodKaydet.Size = new System.Drawing.Size(158, 44);
            this.btnBarkodKaydet.TabIndex = 3;
            this.btnBarkodKaydet.Text = "KAYDET";
            this.btnBarkodKaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBarkodKaydet.UseVisualStyleBackColor = false;
            this.btnBarkodKaydet.Click += new System.EventHandler(this.btnBarkodKaydet_Click);
            // 
            // picBarkod1
            // 
            this.picBarkod1.BackColor = System.Drawing.Color.White;
            this.picBarkod1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picBarkod1.Location = new System.Drawing.Point(8, 14);
            this.picBarkod1.Name = "picBarkod1";
            this.picBarkod1.Size = new System.Drawing.Size(158, 100);
            this.picBarkod1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBarkod1.TabIndex = 2;
            this.picBarkod1.TabStop = false;
            // 
            // btnBarkod1
            // 
            this.btnBarkod1.BackColor = System.Drawing.Color.Thistle;
            this.btnBarkod1.Image = global::StokKontrol.Properties.Resources.barcode_stok;
            this.btnBarkod1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBarkod1.Location = new System.Drawing.Point(8, 177);
            this.btnBarkod1.Name = "btnBarkod1";
            this.btnBarkod1.Size = new System.Drawing.Size(158, 44);
            this.btnBarkod1.TabIndex = 1;
            this.btnBarkod1.Text = "BARKOD YAP";
            this.btnBarkod1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBarkod1.UseVisualStyleBackColor = false;
            this.btnBarkod1.Click += new System.EventHandler(this.btnBarkod1_Click);
            // 
            // tabCari
            // 
            this.tabCari.Controls.Add(this.lblCariToplam);
            this.tabCari.Controls.Add(this.cmbCari);
            this.tabCari.Controls.Add(this.btnCariExcel);
            this.tabCari.Controls.Add(this.lblCari);
            this.tabCari.Controls.Add(this.dgvCari);
            this.tabCari.Controls.Add(this.btnCariSil);
            this.tabCari.Location = new System.Drawing.Point(4, 29);
            this.tabCari.Name = "tabCari";
            this.tabCari.Padding = new System.Windows.Forms.Padding(3);
            this.tabCari.Size = new System.Drawing.Size(1226, 489);
            this.tabCari.TabIndex = 6;
            this.tabCari.Text = "Cari";
            this.tabCari.UseVisualStyleBackColor = true;
            // 
            // btnCariExcel
            // 
            this.btnCariExcel.BackColor = System.Drawing.Color.LightGreen;
            this.btnCariExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnCariExcel.Image")));
            this.btnCariExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCariExcel.Location = new System.Drawing.Point(1099, 6);
            this.btnCariExcel.Name = "btnCariExcel";
            this.btnCariExcel.Size = new System.Drawing.Size(110, 39);
            this.btnCariExcel.TabIndex = 20;
            this.btnCariExcel.Text = "EXCEL";
            this.btnCariExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCariExcel.UseVisualStyleBackColor = false;
            this.btnCariExcel.Click += new System.EventHandler(this.btnCariExcel_Click);
            // 
            // lblCari
            // 
            this.lblCari.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCari.Location = new System.Drawing.Point(17, 12);
            this.lblCari.Name = "lblCari";
            this.lblCari.Size = new System.Drawing.Size(548, 36);
            this.lblCari.TabIndex = 18;
            this.lblCari.Text = "Ürün :";
            this.lblCari.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvCari
            // 
            this.dgvCari.AllowUserToAddRows = false;
            this.dgvCari.AllowUserToResizeRows = false;
            this.dgvCari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCari.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCari.BackgroundColor = System.Drawing.Color.White;
            this.dgvCari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCari.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCari.Location = new System.Drawing.Point(17, 51);
            this.dgvCari.Name = "dgvCari";
            this.dgvCari.ReadOnly = true;
            this.dgvCari.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCari.Size = new System.Drawing.Size(1192, 431);
            this.dgvCari.TabIndex = 10;
            this.dgvCari.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCari_CellContentClick);
            this.dgvCari.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCari_DataBindingComplete);
            this.dgvCari.SelectionChanged += new System.EventHandler(this.dgvCari_SelectionChanged);
            // 
            // btnCariSil
            // 
            this.btnCariSil.BackColor = System.Drawing.Color.MistyRose;
            this.btnCariSil.Image = ((System.Drawing.Image)(resources.GetObject("btnCariSil.Image")));
            this.btnCariSil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCariSil.Location = new System.Drawing.Point(571, 6);
            this.btnCariSil.Name = "btnCariSil";
            this.btnCariSil.Size = new System.Drawing.Size(40, 42);
            this.btnCariSil.TabIndex = 19;
            this.btnCariSil.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCariSil.UseVisualStyleBackColor = false;
            this.btnCariSil.Click += new System.EventHandler(this.btnCariSil_Click);
            // 
            // txtKim
            // 
            this.txtKim.Location = new System.Drawing.Point(152, 34);
            this.txtKim.MaxLength = 25;
            this.txtKim.Name = "txtKim";
            this.txtKim.Size = new System.Drawing.Size(291, 28);
            this.txtKim.TabIndex = 23;
            this.txtKim.Text = "KALE DEKOR";
            // 
            // cmbCari
            // 
            this.cmbCari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCari.FormattingEnabled = true;
            this.cmbCari.Location = new System.Drawing.Point(805, 12);
            this.cmbCari.Name = "cmbCari";
            this.cmbCari.Size = new System.Drawing.Size(288, 28);
            this.cmbCari.TabIndex = 21;
            this.cmbCari.SelectionChangeCommitted += new System.EventHandler(this.cmbCari_SelectionChangeCommitted);
            // 
            // lblCariToplam
            // 
            this.lblCariToplam.Location = new System.Drawing.Point(617, 15);
            this.lblCariToplam.Name = "lblCariToplam";
            this.lblCariToplam.Size = new System.Drawing.Size(182, 27);
            this.lblCariToplam.TabIndex = 22;
            this.lblCariToplam.Text = "0,00";
            this.lblCariToplam.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1235, 523);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Form1";
            this.Text = "STOK KONTROL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsSatisBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsSatis)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabSatis.ResumeLayout(false);
            this.tabSatis.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSatisFiyat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSatisAdetGuncelle2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSatisAdetGuncelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSatisAdet)).EndInit();
            this.tabStok.ResumeLayout(false);
            this.tabStok.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStok)).EndInit();
            this.tabUrun.ResumeLayout(false);
            this.tabUrun.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUrun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUrunAdet)).EndInit();
            this.tabTur.ResumeLayout(false);
            this.tabTur.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGizli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFirma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTur)).EndInit();
            this.tabBarkod.ResumeLayout(false);
            this.tabBarkod.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBarkodUrun)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBarkod1)).EndInit();
            this.tabCari.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabStok;
        private System.Windows.Forms.TabPage tabUrun;
        private System.Windows.Forms.TabPage tabTur;
        private System.Windows.Forms.Button btnSilTur;
        private System.Windows.Forms.Button btnGuncelleTur;
        private System.Windows.Forms.Button btnEkleTur;
        private System.Windows.Forms.TextBox txtTur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTur;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUrunAdet;
        private System.Windows.Forms.ComboBox cmbTur;
        private System.Windows.Forms.DateTimePicker dtpUrunTarih;
        private System.Windows.Forms.TextBox txtUrunFiyat;
        private System.Windows.Forms.TextBox txtUrunGelis;
        private System.Windows.Forms.Button btnUrunSil;
        private System.Windows.Forms.Button btnUrunGuncelle;
        private System.Windows.Forms.Button btnUrunEkle;
        private System.Windows.Forms.DataGridView dgvUrun;
        private System.Windows.Forms.ComboBox cmbFirma;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSilFirma;
        private System.Windows.Forms.Button btnGuncelleFirma;
        private System.Windows.Forms.Button btnEkleFirma;
        private System.Windows.Forms.TextBox txtFirma;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvFirma;
        private System.Windows.Forms.DataGridView dgvStok;
        private System.Windows.Forms.TextBox txtUrunAra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtStokAra;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnExcelUrun;
        private System.Windows.Forms.Button btnExcelStok;
        private System.Windows.Forms.TextBox txtUrunKart;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbTurUrun;
        private System.Windows.Forms.Button btnSilEser;
        private System.Windows.Forms.Button btnGuncelleEser;
        private System.Windows.Forms.Button btnEkleEser;
        private System.Windows.Forms.TextBox txtEser;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvEser;
        private System.Windows.Forms.ComboBox cmbUrunAd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabSatis;
        private System.Windows.Forms.Button btnPrintStok;
        private System.Windows.Forms.TabPage tabBarkod;
        private System.Windows.Forms.Button btnBarkod1;
        private System.Windows.Forms.PictureBox picBarkod1;
        private System.Windows.Forms.Button btnBarkodKaydet;
        private System.Windows.Forms.TextBox txtBarkod1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblSatisToplam;
        private System.Windows.Forms.ListView listSatis;
        private System.Windows.Forms.ColumnHeader colAd;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numSatisAdet;
        private System.Windows.Forms.TextBox txtSatisBarkod;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblSatisUrunAd;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numSatisAdetGuncelle;
        private System.Windows.Forms.Button btnSatisGuncelle;
        private System.Windows.Forms.Button btnSatisSil;
        private System.Windows.Forms.TextBox txtEserBarkod;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.DataGridView dgvGizli;
        private System.Windows.Forms.ColumnHeader colFiyat;
        private System.Windows.Forms.ColumnHeader colAdet;
        private System.Windows.Forms.ColumnHeader colToplam;
        private System.Windows.Forms.NumericUpDown numSatisFiyat;
        private System.Windows.Forms.NumericUpDown numSatisAdetGuncelle2;
        private System.Windows.Forms.Button btnSatisTemizle;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dsSatisBindingSource;
        private ReportDataset.dsSatis dsSatis;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView dgvBarkodUrun;
        private System.Windows.Forms.NumericUpDown numStok;
        private System.Windows.Forms.Label lblStokUrun;
        private System.Windows.Forms.Button btnStokGuncelle;
        private System.Windows.Forms.Button btnStokSil;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnKes;
        private System.Windows.Forms.Button btnStokDus;
        private System.Windows.Forms.TabPage tabCari;
        private System.Windows.Forms.DataGridView dgvCari;
        private System.Windows.Forms.Label lblCari;
        private System.Windows.Forms.Button btnCariSil;
        private System.Windows.Forms.Button btnCariExcel;
        private System.Windows.Forms.Button btnFisYazdir;
        private System.Windows.Forms.TextBox txtKim;
        private System.Windows.Forms.ComboBox cmbCari;
        private System.Windows.Forms.Label lblCariToplam;
    }
}

