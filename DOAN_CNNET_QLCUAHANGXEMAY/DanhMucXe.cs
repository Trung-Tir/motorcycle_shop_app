using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DOAN_CNNET_QLCUAHANGXEMAY
{
    public partial class DanhMucXe : Form
    {
        DataColumn[] key = new DataColumn[1];
        Control_Xe x = new Control_Xe();
        string table = "Xe";
        public DanhMucXe()
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
            dataGridView1.Columns.Add("NgayNhap", "Ngày Nhập Xe");
            dataGridView1.Columns[5].DataPropertyName = "NgayNhap";
            dataGridView1.Columns.Add("PhaiKhoi", "Phân Khối");
            dataGridView1.Columns[6].DataPropertyName = "PhanKhoi";
            dataGridView1.Columns.Add("MauXe", "Màu Xe");
            dataGridView1.Columns[7].DataPropertyName = "MauXe";

        }

        void loadDTG()
        {
            if (dataGridView1.DataSource != null)
                dataGridView1.Rows.Clear();
            DataTable dtX = x.select(table);
            dataGridView1.DataSource = dtX;
            key[0] = dtX.Columns[0];
            dtX.PrimaryKey = key;
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

        private void DanhMucXe_Load(object sender, EventArgs e)
        {
            loadHangXe();
            loadAllXe();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                Model_Xe newx = new Model_Xe();
                newx.maXe = tb_maxe.Text;
                newx.tenXe = tb_tenxe.Text;
                newx.loaiXe = cbb_loaixe.SelectedItem.ToString();
                newx.maHang = cbb_tenhang.SelectedValue.ToString();
                newx.donGia = tb_dongia.Text;
                newx.ngayNhap = dtp_date.Text;
                newx.phanKhoi = tb_phankhoi.Text;
                newx.mauSac = tb_mausac.SelectedItem.ToString();
                if (x.checkTrungMa(newx.maXe, table) == 1)
                {
                    MessageBox.Show("Trùng mã xe có từ trước!");
                    return;
                }
                x.insert(newx, table);
                MessageBox.Show("Nhập xe thành công rồi nha!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex != null ? ex.Message : "Lỗi rồi !");
            }
        }
    }
}
