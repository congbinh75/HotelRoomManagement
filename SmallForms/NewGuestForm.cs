using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPKS.SmallForms
{
    public partial class NewGuestForm : Form
    {
        private QLPKSEntities data;
        public NewGuestForm()
        {
            InitializeComponent();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            data = new QLPKSEntities();
            KhachHang kh = new KhachHang();
            kh.TenKhachHang = txtGuestName.Text;
            kh.SoDienThoai = txtGuestNum.Text;
            kh.CMND = txtGuestID.Text;
            data.KhachHang.Add(kh);
            data.SaveChanges();
            this.Close();
        }
    }
}
