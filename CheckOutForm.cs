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
    public partial class CheckOutForm : Form
    {
        private QLPKSEntities data;
        public CheckOutForm(string guestNum, string roomName, string checkInDate, string duration, string totalPrice)
        {
            InitializeComponent();

            labelGuestNum.Text = guestNum;
            labelRoomName.Text = roomName;
            labelCheckInDate.Text = checkInDate;
            labelDuration.Text = duration;
            labelTotalPrice.Text = totalPrice;
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            data = new QLPKSEntities();
            HoaDon hd = new HoaDon();
            hd.MaHoaDon = labelGuestNum.Text + labelRoomName.Text + DateTime.Now.ToString("ddMMyyyy");
            hd.SDT = labelGuestNum.Text;
            hd.ThanhTien = Convert.ToDouble(labelTotalPrice.Text);
            data.HoaDon.Add(hd);
            data.SaveChanges();
            this.Close();
        }
    }
}
