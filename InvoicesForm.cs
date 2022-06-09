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
    public partial class InvoicesForm : Form
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

        public InvoicesForm()
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
            var list = from hd in data.HoaDon
                       select new
                       {
                           hd.MaHoaDon,
                           hd.SDT,
                           hd.ThanhTien
                       };
            dtgvInvoices.DataSource = list.ToList();
        }

        private void dtgvInvoices_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            labelInvoiceID.Text = dtgvInvoices.Rows[e.RowIndex].Cells[0].ToString();
            labelGuestNum.Text = dtgvInvoices.Rows[e.RowIndex].Cells[1].ToString();
            labelTotalPrice.Text = dtgvInvoices.Rows[e.RowIndex].Cells[2].ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            data = new QLPKSEntities();
            var list = from hd in data.HoaDon
                       where hd.SDT.Contains(textBox4.Text)
                       select new
                       {
                           hd.MaHoaDon,
                           hd.SDT,
                           hd.ThanhTien
                       };
            dtgvInvoices.DataSource = list.ToList();
        }
    }
}
