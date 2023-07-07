using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOAN_CNNET_QLCUAHANGXEMAY
{
    public partial class KhachHang : Form
    {
        DataColumn[] key = new DataColumn[1];
        Control_Xe x = new Control_Xe();
        string table = "Xe";
        public KhachHang()
        {
            InitializeComponent();
        }
        void AddHeader()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("MaXe", "Mã Xe");
            dataGridView1.Columns[0].DataPropertyName = "MaXe";
            dataGridView1.Columns.Add("TenXe", "Tên Xe");
            dataGridView1.Columns[1].DataPropertyName = "TenXe";
            dataGridView1.Columns.Add("LoaiXe", "Loại Xe");
            dataGridView1.Columns[2].DataPropertyName = "LoaiXe";
            dataGridView1.Columns.Add("MaHang", "Hãng Xe");
            dataGridView1.Columns[3].DataPropertyName = "MaHang";
            dataGridView1.Columns.Add("DonGia", "Đơn Giá");
            dataGridView1.Columns[4].DataPropertyName = "DonGia";
            dataGridView1.Columns.Add("PhaiKhoi", "Phân Khối");
            dataGridView1.Columns[5].DataPropertyName = "PhanKhoi";
            dataGridView1.Columns.Add("MauXe", "Màu Xe");
            dataGridView1.Columns[6].DataPropertyName = "MauXe";
        }
        void loadDTG()
        {
            DataTable dtX = x.select(table);
            dataGridView1.DataSource = dtX;
            key[0] = dtX.Columns[0];
            dtX.PrimaryKey = key;
        }
        void loadTheoHang()
        {
            string ma = "MaHang";
            string change = cbb_tenhang.SelectedValue.ToString();
            DataTable dtSV = x.selectedChance(table, ma, change);
            dataGridView1.DataSource = dtSV;
            key[0] = dtSV.Columns[0];
            dtSV.PrimaryKey = key;
        }
        void loadHangXe()
        {
            string table = "HangXe";
            if (dataGridView1.DataSource != null)
                dataGridView1.Rows.Clear();
            DataTable dt = x.select(table);
            cbb_tenhang.DataSource = dt;
            cbb_tenhang.DisplayMember = "TenHang";
            cbb_tenhang.ValueMember = "MaHang";
        }
        void loadAllXe()
        {
            AddHeader();
            loadDTG();
        }

        private void KhachHang_Load(object sender, EventArgs e)
        {
            loadHangXe();
            loadAllXe();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tb_maxe.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tb_tenxe.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tb_loaixe.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString(); 
            cbb_tenhang.SelectedValue = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tb_dongia.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            tb_phankhoi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            tb_mausac.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            btn_mua.Enabled = true;
        }

        private void cbb_tenhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTheoHang();
        }

        private void btn_mua_Click(object sender, EventArgs e)
        {

        }
    }
}
