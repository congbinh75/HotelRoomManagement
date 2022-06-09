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
    public partial class MainForm : Form
    {
        //Dung de di chuyen cua so khong can border
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //--------------------------------------------

        private RoomsForm roomsForm = null;
        private GuestsForm guestsForm = null;
        private BookingForm bookingForm = null;
        private CheckInOutForm checkInOutForm = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void btRooms_Click(object sender, EventArgs e)
        {
            roomsForm = new RoomsForm();
            roomsForm.ShowDialog();
        }

        private void btGuests_Click(object sender, EventArgs e)
        {
            guestsForm = new GuestsForm();
            guestsForm.ShowDialog();
        }

        private void btBooking_Click(object sender, EventArgs e)
        {
            bookingForm = new BookingForm();
            bookingForm.ShowDialog();
        }

        private void btCheckInOut_Click(object sender, EventArgs e)
        {
            checkInOutForm = new CheckInOutForm();
            checkInOutForm.ShowDialog();
        }
    }
}
