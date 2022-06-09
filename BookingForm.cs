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
using QLPKS.SmallForms;

namespace QLPKS
{
    public partial class BookingForm : Form
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

        public BookingForm()
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

        //Dung de di chuyen cua so khong can border
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //--------------------------------------------

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
            labelCheckedIn.Text = dtgvBookings.Rows[e.RowIndex].Cells[3].Value.ToString();
            labelDuration.Text = dtgvBookings.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void Search()
        {


            data = new QLPKSEntities();
            var list = from dSDatPhong in data.DSDatPhong
                       where dSDatPhong.SDT.Trim().Contains(txtSearch.Text.Trim()) &&
                       (checkboxCheckedIn.Checked == dSDatPhong.CheckIn) &&
                       (dSDatPhong.NgayCheckIn >= dtpickerCheckInDate.Value.Date)
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void checkboxCheckedIn_CheckedChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void dtpickerCheckInDate_ValueChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            NewBookingForm bk = new NewBookingForm();
            bk.FormClosed += new FormClosedEventHandler(Form_Closed);
            bk.ShowDialog();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            RefreshDataGridView();
        }
    }
}
