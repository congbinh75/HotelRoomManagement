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
    public partial class RoomsForm : Form
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

        public RoomsForm()
        {
            InitializeComponent();

            RefreshDataGridView();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Hide();
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
            var list = from phong in data.Phong
                       select new
                       {
                           phong.TenPhong,
                           phong.LoaiPhong
                       };
            dtgvRooms.DataSource = list.ToList();
            dtgvRooms.Columns[0].HeaderText = "Số phòng";
            dtgvRooms.Columns[1].HeaderText = "Loại phòng";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Equals(""))
            {
                RefreshDataGridView();
                return;
            }

            data = new QLPKSEntities();
            var list = from phong in data.Phong
                       where phong.TenPhong.Trim().Contains(txtSearch.Text.Trim())
                       select new
                       {
                           phong.TenPhong,
                           phong.LoaiPhong
                       };
            dtgvRooms.DataSource = list.ToList();
            dtgvRooms.Columns[0].HeaderText = "Số phòng";
            dtgvRooms.Columns[1].HeaderText = "Loại phòng";
        }

        private void dtgvRooms_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            labelRoomName.Text = dtgvRooms.Rows[e.RowIndex].Cells[0].Value.ToString();
            labelRoomType.Text = dtgvRooms.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            NewRoomForm newRoomForm = new NewRoomForm();
            newRoomForm.FormClosed += new FormClosedEventHandler(Form_Closed);
            newRoomForm.ShowDialog();
        }

        private void btModify_Click(object sender, EventArgs e)
        {
            ModifyRoomForm modifyRoomForm = new ModifyRoomForm(labelRoomName.Text, labelRoomType.Text);
            modifyRoomForm.FormClosed += new FormClosedEventHandler(Form_Closed);
            modifyRoomForm.ShowDialog();
        }

        private void Form_Closed(object sender, FormClosedEventArgs e)
        {
            RefreshDataGridView();
        }

        private void btAddRoomType_Click(object sender, EventArgs e)
        {
            NewRoomTypeForm newRoomTypeForm = new NewRoomTypeForm();
            newRoomTypeForm.ShowDialog();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            data = new QLPKSEntities();
            Phong p = (from phong in data.Phong
                       where phong.TenPhong == labelRoomName.Text.Trim()
                       select phong).Single<Phong>();
            data.Phong.Remove(p);
            data.SaveChanges();
            RefreshDataGridView();
        }
    }
}
