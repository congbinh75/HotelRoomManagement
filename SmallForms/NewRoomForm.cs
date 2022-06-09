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
    public partial class NewRoomForm : Form
    {
        private QLPKSEntities data;
        public NewRoomForm()
        {
            InitializeComponent();

            FillComboBox();
        }

        private void FillComboBox()
        {
            data = new QLPKSEntities();
            var list = from loaiPhong in data.LoaiPhong
                       select new
                       {
                           loaiPhong.MaLoaiPhong,
                           loaiPhong.TenLoaiPhong
                       };
            cmbRoomType.DataSource = list.ToList();
            cmbRoomType.DisplayMember = "TenLoaiPhong";
            cmbRoomType.ValueMember = "MaLoaiPhong";
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            data = new QLPKSEntities();
            Phong phong = new Phong();
            phong.TenPhong = txtRoomName.Text;
            phong.LoaiPhong = cmbRoomType.SelectedValue.ToString();
            data.Phong.Add(phong);
            data.SaveChanges();
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
