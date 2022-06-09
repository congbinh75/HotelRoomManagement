using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPKS
{
    public partial class NewBookingForm : Form
    {
        QLPKSEntities data;
        public NewBookingForm()
        {
            InitializeComponent();

            RefreshDataGridViews();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshDataGridViews()
        {
            data = new QLPKSEntities();

            var list1 = from khachHang in data.KhachHang
                       select new
                       {
                           khachHang.SoDienThoai,
                           khachHang.TenKhachHang,
                           khachHang.CMND
                       };
            dtgvGuests.DataSource = list1.ToList();
            dtgvGuests.Columns[0].HeaderText = "Số điện thoại";
            dtgvGuests.Columns[1].HeaderText = "Tên khách hàng";
            dtgvGuests.Columns[2].HeaderText = "CMND/CC";

            var list2 = from loaiPhong in data.LoaiPhong
                        select new
                        {
                            loaiPhong.MaLoaiPhong
                        };
            cmbRoomType.DataSource = list2.ToList();
            cmbRoomType.ValueMember = "MaLoaiPhong";

            var list3 = from phong in data.Phong
                        where phong.LoaiPhong == cmbRoomType.SelectedValue.ToString()
                        select new
                        {
                            phong.TenPhong
                        };
            dtgvRooms.DataSource = list3.ToList();
        }

        private void dtgvGuests_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            labelGuestName.Text = dtgvGuests.Rows[e.RowIndex].Cells[1].Value.ToString();
            labelGuestNum.Text = dtgvGuests.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void dtgvRooms_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            labelCheckInDate.Text = dtpickerCheckInDate.Value.ToString();
            labelRoomName.Text = dtgvRooms.Rows[e.RowIndex].Cells[0].Value.ToString();
            labelDuration.Text = txtDuration.Text;
        }

        private void btBook_Click(object sender, EventArgs e)
        {
            data = new QLPKSEntities();
            DSDatPhong dp = new DSDatPhong();
            dp.SDT = labelGuestNum.Text;
            dp.NgayCheckIn = Convert.ToDateTime(labelCheckInDate.Text);
            dp.TenPhong = labelRoomName.Text;
            dp.ThoiGianLuuTru = Convert.ToInt32(labelDuration.Text);
            dp.CheckIn = false;
            data.DSDatPhong.Add(dp);
            data.SaveChanges();
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals(""))
            {
                RefreshDataGridViews();
                return;
            }

            data = new QLPKSEntities();
            var list = from khachHang in data.KhachHang
                       where khachHang.SoDienThoai.Trim().Contains(textBox4.Text.Trim())
                       select new
                       {
                           khachHang.SoDienThoai,
                           khachHang.TenKhachHang,
                           khachHang.CMND
                       };
            dtgvGuests.DataSource = list.ToList();
            dtgvGuests.Columns[0].HeaderText = "Số điện thoại";
            dtgvGuests.Columns[1].HeaderText = "Tên khách hàng";
            dtgvGuests.Columns[2].HeaderText = "CMND/CC";
        }
    }
}
