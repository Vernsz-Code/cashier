
namespace tes
{
    partial class FormFaktur
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFaktur));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv = new Guna.UI2.WinForms.Guna2DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.guna2CheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Tunai = new Guna.UI2.WinForms.Guna2TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.JATUHTEMPO = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_TOTALKEUNTUNGAN = new System.Windows.Forms.Label();
            this.lbl_TOTAL = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NAMAPELANGGAN = new Guna.UI2.WinForms.Guna2TextBox();
            this.TGLPENGAMBILAN = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ALAMAT = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbl_NOFAKTUR = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_TOTALBARANG = new System.Windows.Forms.Label();
            this.btnSimpan = new Guna.UI2.WinForms.Guna2Button();
            this.btnNew = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SisaStok = new Guna.UI2.WinForms.Guna2TextBox();
            this.HARGA = new Guna.UI2.WinForms.Guna2TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.QTY = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.NAMABARANG = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.qtyText = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SUBTOTAL = new Guna.UI2.WinForms.Guna2TextBox();
            this.KEUNTUNGANBUTIR = new Guna.UI2.WinForms.Guna2TextBox();
            this.KEUNTUNGANLEMPENG = new Guna.UI2.WinForms.Guna2TextBox();
            this.KEUNTUNGAN = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBarCode = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JATUHTEMPO)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QTY)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgv);
            this.groupBox3.Location = new System.Drawing.Point(16, 188);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(1295, 479);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cart";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(56)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.dgv.ColumnHeadersHeight = 30;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle15;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv.Location = new System.Drawing.Point(4, 19);
            this.dgv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 28;
            this.dgv.Size = new System.Drawing.Size(1287, 456);
            this.dgv.TabIndex = 0;
            this.dgv.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgv.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgv.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgv.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgv.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgv.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgv.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgv.ThemeStyle.HeaderStyle.Height = 30;
            this.dgv.ThemeStyle.ReadOnly = true;
            this.dgv.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgv.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv.ThemeStyle.RowsStyle.Height = 28;
            this.dgv.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgv.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // ID
            // 
            this.ID.FillWeight = 30F;
            this.ID.HeaderText = "#";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 140F;
            this.Column1.HeaderText = "No Produk";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 150F;
            this.Column2.HeaderText = "Nama Barang";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.FillWeight = 70.9137F;
            this.Column3.HeaderText = "Harga";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 70.9137F;
            this.Column4.HeaderText = "Qty";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 70.9137F;
            this.Column5.HeaderText = "Subtotal";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 40F;
            this.Column6.HeaderText = "Aksi";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "#";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.guna2CheckBox1);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.Tunai);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.lbl_TOTALKEUNTUNGAN);
            this.groupBox1.Controls.Add(this.lbl_TOTAL);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NAMAPELANGGAN);
            this.groupBox1.Controls.Add(this.TGLPENGAMBILAN);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ALAMAT);
            this.groupBox1.Location = new System.Drawing.Point(16, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1295, 126);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // guna2CheckBox1
            // 
            this.guna2CheckBox1.AutoSize = true;
            this.guna2CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.CheckedState.BorderRadius = 0;
            this.guna2CheckBox1.CheckedState.BorderThickness = 0;
            this.guna2CheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.guna2CheckBox1.Location = new System.Drawing.Point(348, 28);
            this.guna2CheckBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2CheckBox1.Name = "guna2CheckBox1";
            this.guna2CheckBox1.Size = new System.Drawing.Size(71, 22);
            this.guna2CheckBox1.TabIndex = 25;
            this.guna2CheckBox1.Text = "Kredit";
            this.guna2CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CheckBox1.UncheckedState.BorderRadius = 0;
            this.guna2CheckBox1.UncheckedState.BorderThickness = 0;
            this.guna2CheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CheckBox1.UseVisualStyleBackColor = false;
            this.guna2CheckBox1.CheckedChanged += new System.EventHandler(this.guna2CheckBox1_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(604, 28);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 18);
            this.label14.TabIndex = 24;
            this.label14.Text = "Tunai";
            // 
            // Tunai
            // 
            this.Tunai.BorderRadius = 15;
            this.Tunai.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Tunai.DefaultText = "";
            this.Tunai.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Tunai.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Tunai.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Tunai.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Tunai.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Tunai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Tunai.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Tunai.Location = new System.Drawing.Point(671, 18);
            this.Tunai.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Tunai.Name = "Tunai";
            this.Tunai.PasswordChar = '\0';
            this.Tunai.PlaceholderText = "";
            this.Tunai.SelectedText = "";
            this.Tunai.Size = new System.Drawing.Size(231, 37);
            this.Tunai.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.JATUHTEMPO);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(988, 69);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 50);
            this.panel2.TabIndex = 12;
            this.panel2.Visible = false;
            // 
            // JATUHTEMPO
            // 
            this.JATUHTEMPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.JATUHTEMPO.BackColor = System.Drawing.Color.Transparent;
            this.JATUHTEMPO.BorderRadius = 12;
            this.JATUHTEMPO.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.JATUHTEMPO.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.JATUHTEMPO.Location = new System.Drawing.Point(136, 4);
            this.JATUHTEMPO.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.JATUHTEMPO.Name = "JATUHTEMPO";
            this.JATUHTEMPO.Size = new System.Drawing.Size(92, 37);
            this.JATUHTEMPO.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(243, 15);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Hari";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 14);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Jatuh Tempo";
            // 
            // lbl_TOTALKEUNTUNGAN
            // 
            this.lbl_TOTALKEUNTUNGAN.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TOTALKEUNTUNGAN.Location = new System.Drawing.Point(699, 68);
            this.lbl_TOTALKEUNTUNGAN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TOTALKEUNTUNGAN.Name = "lbl_TOTALKEUNTUNGAN";
            this.lbl_TOTALKEUNTUNGAN.Size = new System.Drawing.Size(133, 31);
            this.lbl_TOTALKEUNTUNGAN.TabIndex = 10;
            this.lbl_TOTALKEUNTUNGAN.Text = "0";
            this.lbl_TOTALKEUNTUNGAN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_TOTALKEUNTUNGAN.Visible = false;
            // 
            // lbl_TOTAL
            // 
            this.lbl_TOTAL.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TOTAL.Location = new System.Drawing.Point(497, 69);
            this.lbl_TOTAL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TOTAL.Name = "lbl_TOTAL";
            this.lbl_TOTAL.Size = new System.Drawing.Size(133, 31);
            this.lbl_TOTAL.TabIndex = 10;
            this.lbl_TOTAL.Text = "0";
            this.lbl_TOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(341, 69);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(149, 33);
            this.label11.TabIndex = 10;
            this.label11.Text = "TOTAL : RP.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nama Pelanggan";
            // 
            // NAMAPELANGGAN
            // 
            this.NAMAPELANGGAN.BorderRadius = 15;
            this.NAMAPELANGGAN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NAMAPELANGGAN.DefaultText = "";
            this.NAMAPELANGGAN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.NAMAPELANGGAN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.NAMAPELANGGAN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NAMAPELANGGAN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NAMAPELANGGAN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NAMAPELANGGAN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NAMAPELANGGAN.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NAMAPELANGGAN.Location = new System.Drawing.Point(163, 18);
            this.NAMAPELANGGAN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NAMAPELANGGAN.Name = "NAMAPELANGGAN";
            this.NAMAPELANGGAN.PasswordChar = '\0';
            this.NAMAPELANGGAN.PlaceholderText = "F1";
            this.NAMAPELANGGAN.SelectedText = "";
            this.NAMAPELANGGAN.Size = new System.Drawing.Size(157, 37);
            this.NAMAPELANGGAN.TabIndex = 1;
            this.NAMAPELANGGAN.TextChanged += new System.EventHandler(this.NAMAPELANGGAN_TextChanged);
            // 
            // TGLPENGAMBILAN
            // 
            this.TGLPENGAMBILAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TGLPENGAMBILAN.BorderRadius = 5;
            this.TGLPENGAMBILAN.Checked = true;
            this.TGLPENGAMBILAN.CustomFormat = "yyyy-MM-dd";
            this.TGLPENGAMBILAN.FillColor = System.Drawing.SystemColors.MenuHighlight;
            this.TGLPENGAMBILAN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.TGLPENGAMBILAN.ForeColor = System.Drawing.Color.White;
            this.TGLPENGAMBILAN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.TGLPENGAMBILAN.Location = new System.Drawing.Point(1124, 23);
            this.TGLPENGAMBILAN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TGLPENGAMBILAN.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.TGLPENGAMBILAN.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.TGLPENGAMBILAN.Name = "TGLPENGAMBILAN";
            this.TGLPENGAMBILAN.Size = new System.Drawing.Size(156, 37);
            this.TGLPENGAMBILAN.TabIndex = 3;
            this.TGLPENGAMBILAN.Value = new System.DateTime(2023, 9, 4, 11, 24, 25, 539);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alamat";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(995, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Tgl Pengambilan";
            // 
            // ALAMAT
            // 
            this.ALAMAT.BorderRadius = 15;
            this.ALAMAT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ALAMAT.DefaultText = "";
            this.ALAMAT.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ALAMAT.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ALAMAT.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ALAMAT.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ALAMAT.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ALAMAT.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ALAMAT.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ALAMAT.Location = new System.Drawing.Point(89, 69);
            this.ALAMAT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ALAMAT.Name = "ALAMAT";
            this.ALAMAT.PasswordChar = '\0';
            this.ALAMAT.PlaceholderText = "";
            this.ALAMAT.SelectedText = "";
            this.ALAMAT.Size = new System.Drawing.Size(231, 37);
            this.ALAMAT.TabIndex = 1;
            // 
            // lbl_NOFAKTUR
            // 
            this.lbl_NOFAKTUR.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NOFAKTUR.Location = new System.Drawing.Point(189, 14);
            this.lbl_NOFAKTUR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_NOFAKTUR.Name = "lbl_NOFAKTUR";
            this.lbl_NOFAKTUR.Size = new System.Drawing.Size(133, 31);
            this.lbl_NOFAKTUR.TabIndex = 16;
            this.lbl_NOFAKTUR.Text = "100";
            this.lbl_NOFAKTUR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(13, 14);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(169, 33);
            this.label9.TabIndex = 17;
            this.label9.Text = "NO FAKTUR :";
            // 
            // guna2Button1
            // 
            this.guna2Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Button1.BorderRadius = 8;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(56)))));
            this.guna2Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(1145, 14);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(165, 41);
            this.guna2Button1.TabIndex = 20;
            this.guna2Button1.Text = "  Input Manual";
            this.guna2Button1.Visible = false;
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lbl_TOTALBARANG);
            this.panel1.Controls.Add(this.btnSimpan);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(16, 674);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1295, 170);
            this.panel1.TabIndex = 1;
            // 
            // lbl_TOTALBARANG
            // 
            this.lbl_TOTALBARANG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_TOTALBARANG.Font = new System.Drawing.Font("Bahnschrift", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TOTALBARANG.Location = new System.Drawing.Point(0, 119);
            this.lbl_TOTALBARANG.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TOTALBARANG.Name = "lbl_TOTALBARANG";
            this.lbl_TOTALBARANG.Size = new System.Drawing.Size(133, 31);
            this.lbl_TOTALBARANG.TabIndex = 19;
            this.lbl_TOTALBARANG.Text = "-";
            this.lbl_TOTALBARANG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSimpan
            // 
            this.btnSimpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSimpan.BorderRadius = 12;
            this.btnSimpan.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSimpan.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSimpan.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSimpan.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSimpan.FillColor = System.Drawing.Color.SteelBlue;
            this.btnSimpan.Font = new System.Drawing.Font("Bahnschrift", 9F);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Image = ((System.Drawing.Image)(resources.GetObject("btnSimpan.Image")));
            this.btnSimpan.Location = new System.Drawing.Point(0, 73);
            this.btnSimpan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(127, 37);
            this.btnSimpan.TabIndex = 17;
            this.btnSimpan.Text = "Checkout";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.BorderRadius = 12;
            this.btnNew.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNew.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNew.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNew.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNew.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(56)))));
            this.btnNew.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(0, 27);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(177, 37);
            this.btnNew.TabIndex = 18;
            this.btnNew.Text = "Tambah Barang";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.SisaStok);
            this.groupBox2.Controls.Add(this.HARGA);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.QTY);
            this.groupBox2.Controls.Add(this.NAMABARANG);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.qtyText);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.SUBTOTAL);
            this.groupBox2.Controls.Add(this.KEUNTUNGANBUTIR);
            this.groupBox2.Controls.Add(this.KEUNTUNGANLEMPENG);
            this.groupBox2.Controls.Add(this.KEUNTUNGAN);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(271, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(1024, 170);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(320, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "Sisa Stok";
            // 
            // SisaStok
            // 
            this.SisaStok.BorderRadius = 15;
            this.SisaStok.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SisaStok.DefaultText = "";
            this.SisaStok.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SisaStok.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SisaStok.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SisaStok.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SisaStok.Enabled = false;
            this.SisaStok.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SisaStok.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SisaStok.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SisaStok.Location = new System.Drawing.Point(400, 73);
            this.SisaStok.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SisaStok.Name = "SisaStok";
            this.SisaStok.PasswordChar = '\0';
            this.SisaStok.PlaceholderText = "";
            this.SisaStok.SelectedText = "";
            this.SisaStok.Size = new System.Drawing.Size(135, 37);
            this.SisaStok.TabIndex = 20;
            // 
            // HARGA
            // 
            this.HARGA.BorderRadius = 15;
            this.HARGA.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.HARGA.DefaultText = "";
            this.HARGA.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.HARGA.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.HARGA.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.HARGA.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.HARGA.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.HARGA.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.HARGA.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.HARGA.Location = new System.Drawing.Point(109, 73);
            this.HARGA.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HARGA.Name = "HARGA";
            this.HARGA.PasswordChar = '\0';
            this.HARGA.PlaceholderText = "";
            this.HARGA.SelectedText = "";
            this.HARGA.Size = new System.Drawing.Size(181, 37);
            this.HARGA.TabIndex = 18;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 82);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 18);
            this.label17.TabIndex = 19;
            this.label17.Text = "Harga Pcs";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(624, 78);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(203, 24);
            this.label8.TabIndex = 15;
            this.label8.Text = "Manual Input or Scan...";
            // 
            // QTY
            // 
            this.QTY.BackColor = System.Drawing.Color.Transparent;
            this.QTY.BorderRadius = 13;
            this.QTY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.QTY.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.QTY.Location = new System.Drawing.Point(400, 22);
            this.QTY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.QTY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QTY.Name = "QTY";
            this.QTY.Size = new System.Drawing.Size(135, 37);
            this.QTY.TabIndex = 4;
            this.QTY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QTY.ValueChanged += new System.EventHandler(this.QTY_ValueChanged);
            // 
            // NAMABARANG
            // 
            this.NAMABARANG.BorderRadius = 15;
            this.NAMABARANG.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NAMABARANG.DefaultText = "";
            this.NAMABARANG.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.NAMABARANG.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.NAMABARANG.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NAMABARANG.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NAMABARANG.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NAMABARANG.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NAMABARANG.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NAMABARANG.Location = new System.Drawing.Point(123, 23);
            this.NAMABARANG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NAMABARANG.Name = "NAMABARANG";
            this.NAMABARANG.PasswordChar = '\0';
            this.NAMABARANG.PlaceholderText = "";
            this.NAMABARANG.SelectedText = "";
            this.NAMABARANG.Size = new System.Drawing.Size(168, 37);
            this.NAMABARANG.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 12;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.Enabled = false;
            this.btnCancel.FillColor = System.Drawing.Color.Maroon;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnCancel.Location = new System.Drawing.Point(929, 122);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(53, 37);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 12;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.Enabled = false;
            this.btnSave.FillColor = System.Drawing.Color.DarkGreen;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnSave.Location = new System.Drawing.Point(871, 122);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(53, 37);
            this.btnSave.TabIndex = 11;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // qtyText
            // 
            this.qtyText.AutoSize = true;
            this.qtyText.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtyText.Location = new System.Drawing.Point(320, 33);
            this.qtyText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.qtyText.Name = "qtyText";
            this.qtyText.Size = new System.Drawing.Size(57, 18);
            this.qtyText.TabIndex = 2;
            this.qtyText.Text = "Per Pcs";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 130);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 18);
            this.label12.TabIndex = 2;
            this.label12.Text = "Subtotal";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(844, 27);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(153, 34);
            this.label10.TabIndex = 2;
            this.label10.Text = "* Pilih salah satu Beli\r\nPer Box, Strip atau Tab";
            this.label10.Visible = false;
            // 
            // SUBTOTAL
            // 
            this.SUBTOTAL.BorderRadius = 15;
            this.SUBTOTAL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.SUBTOTAL.DefaultText = "";
            this.SUBTOTAL.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.SUBTOTAL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.SUBTOTAL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SUBTOTAL.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.SUBTOTAL.Enabled = false;
            this.SUBTOTAL.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SUBTOTAL.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SUBTOTAL.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.SUBTOTAL.Location = new System.Drawing.Point(109, 119);
            this.SUBTOTAL.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SUBTOTAL.Name = "SUBTOTAL";
            this.SUBTOTAL.PasswordChar = '\0';
            this.SUBTOTAL.PlaceholderText = "";
            this.SUBTOTAL.SelectedText = "";
            this.SUBTOTAL.Size = new System.Drawing.Size(181, 37);
            this.SUBTOTAL.TabIndex = 1;
            // 
            // KEUNTUNGANBUTIR
            // 
            this.KEUNTUNGANBUTIR.BorderRadius = 15;
            this.KEUNTUNGANBUTIR.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.KEUNTUNGANBUTIR.DefaultText = "";
            this.KEUNTUNGANBUTIR.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.KEUNTUNGANBUTIR.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.KEUNTUNGANBUTIR.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.KEUNTUNGANBUTIR.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.KEUNTUNGANBUTIR.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.KEUNTUNGANBUTIR.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.KEUNTUNGANBUTIR.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.KEUNTUNGANBUTIR.Location = new System.Drawing.Point(951, 70);
            this.KEUNTUNGANBUTIR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.KEUNTUNGANBUTIR.Name = "KEUNTUNGANBUTIR";
            this.KEUNTUNGANBUTIR.PasswordChar = '\0';
            this.KEUNTUNGANBUTIR.PlaceholderText = "";
            this.KEUNTUNGANBUTIR.SelectedText = "";
            this.KEUNTUNGANBUTIR.Size = new System.Drawing.Size(48, 37);
            this.KEUNTUNGANBUTIR.TabIndex = 1;
            this.KEUNTUNGANBUTIR.Visible = false;
            // 
            // KEUNTUNGANLEMPENG
            // 
            this.KEUNTUNGANLEMPENG.BorderRadius = 15;
            this.KEUNTUNGANLEMPENG.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.KEUNTUNGANLEMPENG.DefaultText = "";
            this.KEUNTUNGANLEMPENG.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.KEUNTUNGANLEMPENG.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.KEUNTUNGANLEMPENG.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.KEUNTUNGANLEMPENG.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.KEUNTUNGANLEMPENG.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.KEUNTUNGANLEMPENG.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.KEUNTUNGANLEMPENG.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.KEUNTUNGANLEMPENG.Location = new System.Drawing.Point(895, 70);
            this.KEUNTUNGANLEMPENG.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.KEUNTUNGANLEMPENG.Name = "KEUNTUNGANLEMPENG";
            this.KEUNTUNGANLEMPENG.PasswordChar = '\0';
            this.KEUNTUNGANLEMPENG.PlaceholderText = "";
            this.KEUNTUNGANLEMPENG.SelectedText = "";
            this.KEUNTUNGANLEMPENG.Size = new System.Drawing.Size(51, 37);
            this.KEUNTUNGANLEMPENG.TabIndex = 1;
            this.KEUNTUNGANLEMPENG.Visible = false;
            // 
            // KEUNTUNGAN
            // 
            this.KEUNTUNGAN.BorderRadius = 15;
            this.KEUNTUNGAN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.KEUNTUNGAN.DefaultText = "";
            this.KEUNTUNGAN.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.KEUNTUNGAN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.KEUNTUNGAN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.KEUNTUNGAN.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.KEUNTUNGAN.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.KEUNTUNGAN.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.KEUNTUNGAN.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.KEUNTUNGAN.Location = new System.Drawing.Point(840, 70);
            this.KEUNTUNGAN.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.KEUNTUNGAN.Name = "KEUNTUNGAN";
            this.KEUNTUNGAN.PasswordChar = '\0';
            this.KEUNTUNGAN.PlaceholderText = "";
            this.KEUNTUNGAN.SelectedText = "";
            this.KEUNTUNGAN.Size = new System.Drawing.Size(47, 37);
            this.KEUNTUNGAN.TabIndex = 1;
            this.KEUNTUNGAN.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 2;
            this.label5.Text = "Nama Barang";
            // 
            // btnBarCode
            // 
            this.btnBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBarCode.BorderRadius = 8;
            this.btnBarCode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBarCode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBarCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBarCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBarCode.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(56)))));
            this.btnBarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBarCode.ForeColor = System.Drawing.Color.White;
            this.btnBarCode.Image = ((System.Drawing.Image)(resources.GetObject("btnBarCode.Image")));
            this.btnBarCode.Location = new System.Drawing.Point(1145, 14);
            this.btnBarCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBarCode.Name = "btnBarCode";
            this.btnBarCode.Size = new System.Drawing.Size(165, 41);
            this.btnBarCode.TabIndex = 19;
            this.btnBarCode.Text = "  Scan BarCode";
            this.btnBarCode.Click += new System.EventHandler(this.btnBarCode_Click);
            // 
            // FormFaktur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 859);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnBarCode);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_NOFAKTUR);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormFaktur";
            this.Text = "FormFaktur";
            this.Load += new System.EventHandler(this.FormFaktur_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JATUHTEMPO)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QTY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private Guna.UI2.WinForms.Guna2DataGridView dgv;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_TOTALKEUNTUNGAN;
        private System.Windows.Forms.Label lbl_TOTAL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox NAMAPELANGGAN;
        private Guna.UI2.WinForms.Guna2DateTimePicker TGLPENGAMBILAN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2TextBox ALAMAT;
        private System.Windows.Forms.Label lbl_NOFAKTUR;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2Button btnBarCode;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_TOTALBARANG;
        private Guna.UI2.WinForms.Guna2Button btnSimpan;
        private Guna.UI2.WinForms.Guna2Button btnNew;
        private System.Windows.Forms.GroupBox groupBox2;
        private Guna.UI2.WinForms.Guna2NumericUpDown QTY;
        private Guna.UI2.WinForms.Guna2TextBox NAMABARANG;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private System.Windows.Forms.Label qtyText;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2TextBox SUBTOTAL;
        private Guna.UI2.WinForms.Guna2TextBox KEUNTUNGANBUTIR;
        private Guna.UI2.WinForms.Guna2TextBox KEUNTUNGANLEMPENG;
        private Guna.UI2.WinForms.Guna2TextBox KEUNTUNGAN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2NumericUpDown JATUHTEMPO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox HARGA;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2TextBox SisaStok;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewImageColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.Label label14;
        private Guna.UI2.WinForms.Guna2TextBox Tunai;
        private Guna.UI2.WinForms.Guna2CheckBox guna2CheckBox1;
    }
}