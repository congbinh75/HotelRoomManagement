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
    public partial class NewRoomTypeForm : Form
    {
        QLPKSEntities data;
        public NewRoomTypeForm()
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
            LoaiPhong loaiPhong = new LoaiPhong();
            loaiPhong.MaLoaiPhong = txtRoomTypeID.Text;
            loaiPhong.TenLoaiPhong = txtRoomTypeName.Text;
            loaiPhong.MoTa = txtDescription.Text;
            loaiPhong.Gia = Convert.ToDouble(txtPrice.Text);
            data.LoaiPhong.Add(loaiPhong);
            data.SaveChanges();
            this.Close();
        }
    }
}
