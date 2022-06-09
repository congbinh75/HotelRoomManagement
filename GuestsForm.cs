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
    public partial class GuestsForm : Form
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

        public GuestsForm()
        {
            InitializeComponent();

            RefreshDataGridView();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RefreshDataGridView()
        {
            data = new QLPKSEntities();
            var list = from khachHang in data.KhachHang
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

        private void dtgvRooms_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            labelGuestNum.Text = dtgvGuests.Rows[e.RowIndex].Cells[0].Value.ToString();
            labelGuestName.Text = dtgvGuests.Rows[e.RowIndex].Cells[1].Value.ToString();
            labelGuestID.Text = dtgvGuests.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            NewGuestForm newGuestForm = new NewGuestForm();
            newGuestForm.FormClosed += new FormClosedEventHandler(Form_Closed);
            newGuestForm.ShowDialog();
        }

        private void btModify_Click(object sender, EventArgs e)
        {
            ModifyGuestForm modifyGuestForm = new ModifyGuestForm(labelGuestNum.Text);
            modifyGuestForm.FormClosed += new FormClosedEventHandler(Form_Closed);
            modifyGuestForm.ShowDialog();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            data = new QLPKSEntities();
            KhachHang kh = (from khachHang in data.KhachHang
                            where khachHang.SoDienThoai == labelGuestNum.Text.Trim()
                            select khachHang).Single<KhachHang>();
            data.KhachHang.Remove(kh);
            data.SaveChanges();
            RefreshDataGridView();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            RefreshDataGridView();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals(""))
            {
                RefreshDataGridView();
                return;
            }

            data = new QLPKSEntities();
            var list = from khachHang in data.KhachHang
                       where khachHang.SoDienThoai.Trim().Contains(txtSearch.Text.Trim())
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
