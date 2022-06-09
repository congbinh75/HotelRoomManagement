using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace QLPKS
{
    public partial class CheckInOutForm : Form
    {
        //Dung de di chuyen cua so khong can border
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //--------------------------------------------

        private QLPKSEntities data;

        public CheckInOutForm()
        {
            InitializeComponent();

            RefreshDataGridView();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void RefreshDataGridView()
        {
            data = new QLPKSEntities();
            var list = from dSDatPhong in data.DSDatPhong
                       select new
                       {
                           dSDatPhong.TenPhong,
                           dSDatPhong.NgayCheckIn,
                           dSDatPhong.SDT,
                           dSDatPhong.CheckIn,
                           dSDatPhong.ThoiGianLuuTru,
                       };
            dtgvBookings.DataSource = list.ToList();
            dtgvBookings.Columns[0].HeaderText = "Số phòng";
            dtgvBookings.Columns[1].HeaderText = "Ngày check-in";
            dtgvBookings.Columns[2].HeaderText = "Số điện thoại";
            dtgvBookings.Columns[3].HeaderText = "Đã check-in";
            dtgvBookings.Columns[4].HeaderText = "Số ngày lưu trú";
        }

        private void dtgvBookings_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            labelGuestNum.Text = dtgvBookings.Rows[e.RowIndex].Cells[2].Value.ToString();
            labelRoomName.Text = dtgvBookings.Rows[e.RowIndex].Cells[0].Value.ToString();
            labelCheckInDate.Text = dtgvBookings.Rows[e.RowIndex].Cells[1].Value.ToString();
            labelDuration.Text = dtgvBookings.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void Search()
        {
            data = new QLPKSEntities();
            var list = from dSDatPhong in data.DSDatPhong
                       where (dSDatPhong.SDT.Contains(txtSearch.Text.Trim())) &&
                       (dSDatPhong.CheckIn == false) &&
                       (dSDatPhong.NgayCheckIn >= dtpickerCheckInDate.Value)
                       select dSDatPhong;
            dtgvBookings.DataSource = list.ToList();
            dtgvBookings.Columns[0].HeaderText = "Số phòng";
            dtgvBookings.Columns[1].HeaderText = "Ngày check-in";
            dtgvBookings.Columns[2].HeaderText = "Số điện thoại";
            dtgvBookings.Columns[3].HeaderText = "Đã check-in";
            dtgvBookings.Columns[4].HeaderText = "Số ngày lưu trú";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dtpickerCheckInDate_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void btCheckIn_Click(object sender, EventArgs e)
        {
            data = new QLPKSEntities();
            DSDatPhong ds = (from dsdp in data.DSDatPhong
                             where (dsdp.SDT == labelGuestNum.Text) && (dsdp.TenPhong == labelRoomName.Text)
                             select dsdp).Single<DSDatPhong>();
            ds.CheckIn = true;
            data.SaveChanges();
            RefreshDataGridView();
        }

        private void btCheckOut_Click(object sender, EventArgs e)
        {
            data = new QLPKSEntities();
            LoaiPhong gp = (from phong in data.Phong
                            join loaiPhong in data.LoaiPhong on phong.LoaiPhong equals loaiPhong.MaLoaiPhong
                            where phong.TenPhong == labelRoomName.Text
                            select loaiPhong).Single<LoaiPhong>();
            double price = (double)gp.Gia;
            double totalPrice = price * Convert.ToDouble(labelDuration.Text);

            CheckOutForm cof = new CheckOutForm(labelGuestNum.Text, labelRoomName.Text, labelCheckInDate.Text, labelDuration.Text, totalPrice.ToString());
            cof.FormClosed += new FormClosedEventHandler(Form_Closed);
            cof.ShowDialog();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            RefreshDataGridView();
        }

        private void btInvoices_Click(object sender, EventArgs e)
        {
            InvoicesForm nif = new InvoicesForm();
            nif.ShowDialog();
        }
    }
}
