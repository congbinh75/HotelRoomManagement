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
    public partial class ModifyRoomForm : Form
    {
        private QLPKSEntities data;
        public ModifyRoomForm(string roomName, string roomType)
        {
            InitializeComponent();

            labelRoomName.Text = roomName;
            FillComboBox();
            cmbRoomType.SelectedValue = roomType;
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

        private void btModify_Click(object sender, EventArgs e)
        {
            data = new QLPKSEntities();
            Phong p = (from phong in data.Phong
                       where phong.TenPhong == labelRoomName.Text.Trim()
                       select phong).Single<Phong>();
            p.LoaiPhong = cmbRoomType.SelectedValue.ToString();
            data.SaveChanges();
            this.Close();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
