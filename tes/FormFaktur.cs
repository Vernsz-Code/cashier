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
using System.Globalization;


namespace tes
{
    public partial class FormFaktur : Form
    {
        string server = "localhost";
        string database = "cashier";
        string uid = "root";
        string password = "";
        int subTotals = 0;
        decimal stoks;
        int juBox;
        string valuePayment = "";

        /*string harga_jual1;
        string harga_jual2;
        string harga_jual3;
        string harga_jual4;*/

        string kode_barang;
        string stokBarang;

        /*string stokLempengBox;
        string IdPBF;*/

        private decimal hargaSatuan;

        public FormFaktur()
        {
            InitializeComponent();
        }
        private void btnBarCode_Click(object sender, EventArgs e)
        {
            btnBarCode.Visible = false;
            guna2Button1.Visible = true;
            panel1.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2Button1.Visible = false;
            btnBarCode.Visible = true;
            panel1.Visible = true;
        }

        private void QTY_ValueChanged(object sender, EventArgs e)
        {
            decimal odd = QTY.Value;

            decimal HargaJual = hargaSatuan;

            decimal hasil = HargaJual * odd;

            decimal hasilTest = (stoks - odd) / juBox;

            int hasilTestCovert = (int)Math.Ceiling(hasilTest);


            SisaStok.Text = hasilTestCovert.ToString();

            SUBTOTAL.Text = hasil.ToString("N0", new CultureInfo("id-ID"));
        }

        private void HapusDataBarangKeluar(int kodeBarangToDelete)
        {
            try
            {
                string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string deleteQuery = "DELETE FROM tb_cart WHERE id = @kodeBarangToDelete";
                MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection);
                deleteCmd.Parameters.AddWithValue("@kodeBarangToDelete", kodeBarangToDelete);

                int rowsAffected = deleteCmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    dgv.Rows.RemoveAt(dgv.SelectedRows[0].Index);
                    MessageBox.Show("Data berhasil dihapus");
                    RefreshCart();
                }
                else
                {
                    MessageBox.Show("Data tidak ditemukan atau gagal dihapus");
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan 1: " + ex.Message);
            }
        }

        public int getStock(int kodeBarang)
        {
            int jumlah = 0;

            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT sisaPcs FROM tb_stok WHERE kode_brg = @kodeBarang";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@kodeBarang", kodeBarang);

                    try
                    {
                        connection.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            jumlah = Convert.ToInt32(result);
                        }
                        else
                        {
                            MessageBox.Show("Stok Habis: " + kodeBarang);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan 2: " + ex.Message);
                    }
                }
            }

            return jumlah;
        }

        private void HapusDataCart(int nofaktur)
        {
            try
            {
                string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                string deleteQuery = "DELETE FROM tb_cart WHERE no_faktur = @nofaktur";
                MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, connection);
                deleteCmd.Parameters.AddWithValue("@nofaktur", nofaktur);

                deleteCmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan 3: " + ex.Message);
            }
        }

        public void kurangStokBox(int kodeBarang, int qty)
        {
            try
            {
                string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
                string query = "SELECT sisaBox, sisaPcs, isiBox FROM tb_stok WHERE kode_brg = @kode_barang"; // Perbaiki query SQL
                int hasilAkhir = 0;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@kode_barang", kodeBarang);

                        try
                        {
                            connection.Open();

                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        int isiBox = reader.GetInt32(2);
                                        int sisaPcs = reader.GetInt32(1);
                                        //(stoks - odd) / juBox
                                        decimal hasil = (sisaPcs - qty) / isiBox;

                                        hasilAkhir = (int)Math.Ceiling(hasil);

                                        
                                    }
                                }
                            }
                            connection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Terjadi kesalahan 4.1: " + ex.Message);
                        }
                    }

                    string update = "UPDATE tb_stok SET sisaBox = @sisaStokBox WHERE kode_brg = @kodeBarang";

                    using (MySqlCommand cmd = new MySqlCommand(update, connection))
                    {
                        cmd.Parameters.AddWithValue("@sisaStokBox", hasilAkhir);
                        cmd.Parameters.AddWithValue("@kodeBarang", kodeBarang);

                        try
                        {
                            connection.Open();
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Terjadi kesalahan 4.2: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan 4: " + ex.Message);
            }

        }



        private void addBayar()
        {
            if (string.IsNullOrEmpty(Tunai.Text))
            {
                MessageBox.Show("Harap isi Columnya!");
            }
            else
            {
                try
                {
                    string bayar = Tunai.Text;
                    DateTime tanggal = DateTime.Now;
                    string tanggals = tanggal.ToString("yyyy-MM-dd");

                    string kueri = "INSERT INTO tb_riwayat (tgl, no_faktur, harga) VALUES (@tgl, @nofaktur, @harga)";
                    string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};AllowUserVariables=true;";

                    MySqlConnection connection = new MySqlConnection(connectionString);

                    using (MySqlCommand cmd = new MySqlCommand(kueri, connection))
                    {
                        cmd.Parameters.AddWithValue("@tgl", tanggals);
                        cmd.Parameters.AddWithValue("@nofaktur", lbl_NOFAKTUR.Text);
                        cmd.Parameters.AddWithValue("@harga", bayar);

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    //MessageBox.Show("berhasil ditambahkan");
                    Tunai.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat menambahkan data: " + ex.Message);
                }
            }
        }

        public void insertData()
        {
            if (string.IsNullOrEmpty(NAMAPELANGGAN.Text) || string.IsNullOrEmpty(ALAMAT.Text) /*|| string.IsNullOrEmpty(groupBox2.Text)*/)
            {
                MessageBox.Show("Harap isi Data Pelanggan terlebih dahulu!");
            }
            else
            {
                try
                {
                    if (dgv.Rows.Count > 0)
                    {

                        foreach (DataGridViewRow row in dgv.Rows)
                        {
                            string noFaktur = lbl_NOFAKTUR.Text;
                            string kodeBarang = row.Cells["column1"].Value.ToString();
                            string namaBarang = row.Cells["column2"].Value.ToString();
                            string harga = row.Cells["column3"].Value.ToString();
                            string qty = row.Cells["column4"].Value.ToString();
                            string subtotal = row.Cells["column5"].Value.ToString();

                            string namaPelanggan = NAMAPELANGGAN.Text;
                            string alamat = ALAMAT.Text;
                            string tglPengembalian = TGLPENGAMBILAN.Value.ToString("yyyy-MM-dd");
                            decimal getjatuhTempo = JATUHTEMPO.Value;

                            harga = harga.Replace(".", "");
                            subtotal = subtotal.Replace(".", "");

                            int.TryParse(kodeBarang, out int kode);

                            int.TryParse(qty, out int beliBox);

                            //int sisaBox = getStock(kode);

                            KurangiStok(kode, beliBox);
                            updatePcsKeluar(kode, beliBox);

                            kurangStokBox(kode, beliBox);

                            /*if (beliBox > 0)
                            {
                                // Mengurangkan stok untuk per satuan
                                if (sisaBox >= beliBox)
                                {
                                    KurangiStok(kodeBarang, beliBox);
                                }
                                else
                                {
                                    MessageBox.Show("Stok tidak cukup untuk barang dengan kode " + kodeBarang);
                                    return;
                                }
                            }*/

                            DateTime tglPengembalianDateTime = DateTime.Parse(tglPengembalian);
                            DateTime jatuhTempoDateTime = tglPengembalianDateTime.AddDays(Convert.ToDouble(getjatuhTempo));

                            string jatuhTempo = jatuhTempoDateTime.ToString("yyyy-MM-dd");

                            string totalHarga = lbl_TOTAL.Text;
                            string tunai = Tunai.Text;
                            totalHarga = totalHarga.Replace(".", "");
                            string totalBarang = lbl_TOTALBARANG.Text;
                            //int totalBarang = int.Parse(totalBarangText);
                            string status;
                            subtotal = subtotal.Replace(".", "");

                            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
                            string query = "INSERT INTO `tb_transaksi` (`no_faktur`, `kode_barang`, `nama_barang`, `harga`, `qty`, `nama_pelanggan`, `alamat`, `tgl`, `jatuh_tempo`, `subtotal`, `total_barang`, `total_harga`, `payment`, `status`, `sisaHutang`, `retur`, `subretur`, `Tunai`, `qtyawal`) " +
                                            "VALUES (@noFaktur, @kodeBarang, @namaBarang, @harga, @qty, @namaPelanggan, @alamat, @tglPengembalian, @jatuhTempo, @subtotal, @totalBarang, @totalHarga, @payment, @status, @totalHarga, @retur, @subretur, @Tunai, @qty)";
                            //string kueriTunai = "INSERT INTO tb_riwayat value ('', @noFaktur, @tglPengembalian, @tunai);";
                            MySqlConnection connection = new MySqlConnection(connectionString);
                            connection.Open();

                            if (valuePayment == "Tunai" || valuePayment == "")
                            {
                                status = "Lunas";
                            }
                            else
                            {
                                status = "Tidak Lunas";
                            }
                            using (MySqlCommand cmd = new MySqlCommand(query, connection))
                            {
                                cmd.Parameters.AddWithValue("@noFaktur", noFaktur);
                                cmd.Parameters.AddWithValue("@kodeBarang", kodeBarang);
                                cmd.Parameters.AddWithValue("@namaBarang", namaBarang);
                                cmd.Parameters.AddWithValue("@harga", harga);
                                cmd.Parameters.AddWithValue("@qty", qty);
                                cmd.Parameters.AddWithValue("@namaPelanggan", namaPelanggan);
                                cmd.Parameters.AddWithValue("@alamat", alamat);
                                cmd.Parameters.AddWithValue("@tglPengembalian", tglPengembalian);
                                cmd.Parameters.AddWithValue("@jatuhTempo", jatuhTempo);
                                cmd.Parameters.AddWithValue("@subtotal", subtotal);
                                cmd.Parameters.AddWithValue("@totalBarang", totalBarang);
                                cmd.Parameters.AddWithValue("@totalHarga", totalHarga);
                                cmd.Parameters.AddWithValue("@tunai", tunai);
                                cmd.Parameters.AddWithValue("@payment", valuePayment);
                                cmd.Parameters.AddWithValue("@status", status);
                                cmd.Parameters.AddWithValue("@retur", 0);
                                cmd.Parameters.AddWithValue("@subretur", 0);
                                //cmd.Parameters.AddWithValue("@Tunai", Tunai.Text);

                                cmd.ExecuteNonQuery();
                            }
                            /*using (MySqlCommand cmd = new MySqlCommand(kueriTunai, connection))
                            {
                                cmd.Parameters.AddWithValue("@noFaktur", noFaktur);
                                cmd.Parameters.AddWithValue("@tglPengembalian", tglPengembalian);

                                cmd.Parameters.AddWithValue("@tunai", tunai);
                                cmd.ExecuteNonQuery();
                            }*/
                            connection.Close();
                        }

                        MessageBox.Show("Data Berhasil Disimpan");
                        int noFakturToDelete = Convert.ToInt32(lbl_NOFAKTUR.Text);
                        HapusDataCart(noFakturToDelete);
                        NAMAPELANGGAN.Text = "";
                        ALAMAT.Text = "";
                        guna2CheckBox1.Checked = false;
                        //FrmCetakFaktur frmCetak = new FrmCetakFaktur();
                        //frmCetak.NoFaktur = lbl_NOFAKTUR.Text;
                        //frmCetak.Subtotal = SUBTOTAL.Text;
                        //frmCetak.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No data to insert.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan 5: " + ex.Message);
                }
            }
        }

        public void addCart()
        {
            try
            {
                string hargaText = HARGA.Text;
                hargaText = hargaText.Replace(".", "");

                string subTotal = SUBTOTAL.Text;
                subTotal = subTotal.Replace(".", "");

                string kueri = "INSERT INTO `tb_cart`(`no_faktur`, `kode_barang`, `nama_barang`,  `harga`, `qty`, `subtotal`, `isiBox`) VALUES ('" + lbl_NOFAKTUR.Text + "', '" + kode_barang + "', '" + NAMABARANG.Text + "', '" + hargaText + "', '" + this.QTY.Text + "', '" + subTotal + "', '" + juBox + "')";
                string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(kueri, connection);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                MessageBox.Show("Succesfully Added");
                connection.Close();

                this.NAMABARANG.Text = "";
                this.HARGA.Text = "";
                this.QTY.Value = 1;
                this.SUBTOTAL.Text = "";
                this.SisaStok.Text = "";

                RefreshCart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan 6: " + ex.Message);
            }
        }

        private void RefreshCart()
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT id, kode_barang, nama_barang, harga, subtotal, qty, harga FROM tb_cart WHERE no_faktur = @noFaktur";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        cmd.Parameters.AddWithValue("@noFaktur", lbl_NOFAKTUR.Text);

                        decimal totalHarga = 0;
                        int totalBarang = 0;

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dgv.Rows.Clear();

                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(0);
                                    string kodeBarang = reader.GetString(1);
                                    string namaBarang = reader.GetString(2);
                                    decimal harga = reader.GetDecimal(3);
                                    decimal subtotal = reader.GetDecimal(4);
                                    int qty = reader.GetInt32(5);

                                    string hargaBrg = harga.ToString("N0", new CultureInfo("id-ID"));
                                    string subTotal = subtotal.ToString("N0", new CultureInfo("id-ID"));

                                    Image editIcon = Properties.Resources.icons8_delete_24px_1; // Ganti dengan gambar ikon Anda

                                    dgv.Rows.Add(id, kodeBarang, namaBarang, hargaBrg, qty, subTotal, editIcon);

                                    totalHarga += subtotal;
                                    totalBarang += qty;
                                }
                                subTotals = Convert.ToInt32(totalHarga);
                                lbl_TOTAL.Text = totalHarga.ToString("N0", new CultureInfo("id-ID"));
                                lbl_TOTALBARANG.Text = totalBarang.ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan 7: " + ex.Message);
                    }
                }
            }
        }
        void LoadNoFaktur()
        {
            TGLPENGAMBILAN.Value = DateTime.Now;

            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "SELECT MAX(no_faktur) FROM tb_transaksi";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        int highestFaktur = Convert.ToInt32(result);
                        int nextFaktur = highestFaktur + 1;
                        lbl_NOFAKTUR.Text = nextFaktur.ToString();
                        lbl_TOTAL.Text = "0";
                        dgv.Rows.Clear();
                        RefreshCart();
                    }
                    else
                    {
                        lbl_NOFAKTUR.Text = "1000";
                        RefreshCart();
                    }
                }
            }
        }

        public void updatePcsKeluar(int kodeBarang, int jumlahDikurangkan)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "UPDATE tb_stok SET pcsKeluar = pcsKeluar + @jumlahDikurangkan WHERE kode_brg = @kodeBarang";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@kodeBarang", kodeBarang);
                    cmd.Parameters.AddWithValue("@jumlahDikurangkan", jumlahDikurangkan);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan 8: " + ex.Message);
                    }
                }
            }
        }

        public void KurangiStok(int kodeBarang, int jumlahDikurangkan)
        {
            string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
            string query = "UPDATE tb_stok SET sisaPcs = sisaPcs - @jumlahDikurangkan WHERE kode_brg = @kodeBarang";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@kodeBarang", kodeBarang);
                    cmd.Parameters.AddWithValue("@jumlahDikurangkan", jumlahDikurangkan);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Terjadi kesalahan 8: " + ex.Message);
                    }
                }
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmPilihBarang frmPilihBarang = new frmPilihBarang();
            frmPilihBarang.OnBarangInfoSelected += (barangInfo) =>
            {
                kode_barang = barangInfo.KodeBarang;

                groupBox2.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;

                string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
                MySqlConnection connection = new MySqlConnection(connectionString);

                try
                {
                    connection.Open();

                    string query = "SELECT kode_brg, nama_brg, sisaBox, sisaPcs, hargaPcs, hargaBeli, isiBox FROM tb_stok where kode_brg = @kode_barang"; // Ganti dengan nama tabel dan query Anda
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@kode_barang", barangInfo.KodeBarang);
                    
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        NAMABARANG.Text = reader["nama_brg"].ToString();

                        decimal hargaPcs = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);

                        string hargaPcsRupiah = hargaPcs.ToString("N0", new CultureInfo("id-ID"));

                        HARGA.Text = hargaPcsRupiah;

                        hargaSatuan = hargaPcs;

                        juBox = reader.GetInt32(6);
                        stoks = reader.GetInt32(3);

                        decimal StokBarang = reader.GetDecimal(3);

                        stokBarang = reader["sisaPcs"].ToString();

                        if (decimal.TryParse(stokBarang, out StokBarang))
                        {
                            if (StokBarang == 0)
                            {
                                MessageBox.Show("Stok Barang Habis / Akan Habis", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                QTY.Maximum = StokBarang;
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Kode Barang tidak ditemukan");
                    }

                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan 9: " + ex.Message);
                }
            };

            frmPilihBarang.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NAMABARANG.Text) ||
                string.IsNullOrEmpty(HARGA.Text)
                )
            {
                MessageBox.Show("Harap isi semua kolom!");
            }
            else
            {
                addCart();
            }
        }

        private void FormFaktur_Load(object sender, EventArgs e)
        {
            NAMAPELANGGAN.Focus();
            LoadNoFaktur();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv.Columns["column6"].Index && e.RowIndex >= 0)
            {
                int kodeBarangToDelete = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["ID"].Value);
                HapusDataBarangKeluar(kodeBarangToDelete);
            }
        }

        private void kembalian()
        {
            decimal a = 0, c = 0;
            string b = Tunai.Text, d = lbl_TOTAL.Text;
            d = d.Replace(".", "");
            if (b == "")
            {
                a = 0;
            }
            else
            {

                a = decimal.Parse(b);
            }
            c = decimal.Parse(d.ToString());

            decimal hasil = a - c;

            string hasilKembalian = hasil.ToString("N0", new CultureInfo("id-ID"));

            string value = valuePayment;
            if (value == "Tunai")
            {
                if (string.IsNullOrEmpty(Tunai.Text))
                {
                    MessageBox.Show("Harap isi Uang Tunai terlebih dahulu!");
                }
                else
                {
                    int t = int.Parse(Tunai.Text);

                    int hasils = t - subTotals;

                    if (hasils < 0)
                    {
                        if (MessageBox.Show("Anda Yakin Ingin Insert?", "Uang Anda kurang : " + hasils, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            insertData();
                        }
                    }
                    else if(hasils == 0)
                    {
                        insertData();
                    }
                    else
                    {
                        MessageBox.Show("kembalian : Rp." + hasil);
                        insertData();
                    }
                }
            }
            else
            {
                insertData();
            }
        }

        private void InsertKas()
        {
            try
            {
                string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};AllowUserVariables=true;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                string kueri = "INSERT INTO `tb_kas` (`no`, `faktur`, `tgl`, `jenis`, `kategori`, `pemasukan`, `pengeluaran`, `keterangan`, `operator`) VALUES (NULL, @faktur, @tgl, @jenis, @kategori, @pengeluaran, 0, @ket, @op);";
                DateTime tgl = DateTime.Now;
                string tglString = tgl.ToString("yyyy/MM/dd");
                string kodeBarang = "PJL-" + tglString + "-" + lbl_NOFAKTUR.Text;
                kodeBarang = kodeBarang.Replace(".", "");
                string namaBarang = NAMABARANG.Text;
                namaBarang = namaBarang.Replace(".", "");
                string totalHarga = lbl_TOTAL.Text;
                totalHarga = totalHarga.Replace(".", "");
                string jenis = "Pemasukan";
                string Kategori = "Penjualan";
                string ket = "Penjualan barang  dengan kode Faktur: " + lbl_NOFAKTUR.Text;
                string op = "Kasir";

                using (MySqlCommand cmd = new MySqlCommand(kueri, connection))
                {
                    cmd.Parameters.AddWithValue("@faktur", kodeBarang);
                    cmd.Parameters.AddWithValue("@tgl", tglString);
                    cmd.Parameters.AddWithValue("@jenis", jenis);
                    cmd.Parameters.AddWithValue("@kategori", Kategori);
                    cmd.Parameters.AddWithValue("@pengeluaran", totalHarga);
                    cmd.Parameters.AddWithValue("@ket", ket);
                    cmd.Parameters.AddWithValue("@op", op);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                kembalian();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kesalahan dalam Insert uang Kas", ex.Message);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            InsertKas();
            addBayar();
            //insertData();
            LoadNoFaktur();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.NAMABARANG.Text = "";
            this.HARGA.Text = "";
            this.QTY.Value = 1;
            this.SUBTOTAL.Text = "";
            this.SisaStok.Text = "";
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2CheckBox1.Checked == true)
            {
                label14.Text = "Dp";
                panel2.Visible = true;
                valuePayment = "Kredit";
            }
            else
            {
                label14.Text = "Tunai";
                panel2.Visible = false;
                valuePayment = "Tunai";
            }
        }

        private void NAMAPELANGGAN_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine(NAMAPELANGGAN.Text);

            string inputText = NAMAPELANGGAN.Text;

            if (!string.IsNullOrEmpty(inputText))
            {
                string[] values = inputText.Split(' ');
                if (values.Length > 0)
                {
                    string lastValue = values[values.Length - 1];
                    Console.WriteLine("Nilai terakhir: " + lastValue);
                }
            }
        }
    }
}
