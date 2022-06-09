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
    public partial class ModifyGuestForm : Form
    {
        private QLPKSEntities data;
        public ModifyGuestForm(string guestNum)
        {
            InitializeComponent();

            labelGuestNum.Text = guestNum;
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
            KhachHang kh = (from khachHang in data.KhachHang
                            where khachHang.SoDienThoai == labelGuestNum.Text
                            select khachHang).Single<KhachHang>();
            kh.TenKhachHang = txtGuestName.Text;
            kh.CMND = txtGuestID.Text;
            data.SaveChanges();
            this.Close();
        }
    }
}
