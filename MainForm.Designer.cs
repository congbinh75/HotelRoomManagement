
namespace QLPKS
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btMinimize = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.btRooms = new System.Windows.Forms.Button();
            this.btCheckInOut = new System.Windows.Forms.Button();
            this.btBooking = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btGuests = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.btMinimize);
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 52);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btMinimize
            // 
            this.btMinimize.FlatAppearance.BorderSize = 0;
            this.btMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btMinimize.Image")));
            this.btMinimize.Location = new System.Drawing.Point(802, 12);
            this.btMinimize.Name = "btMinimize";
            this.btMinimize.Size = new System.Drawing.Size(40, 24);
            this.btMinimize.TabIndex = 2;
            this.btMinimize.UseVisualStyleBackColor = true;
            this.btMinimize.Click += new System.EventHandler(this.btMinimize_Click);
            // 
            // btExit
            // 
            this.btExit.FlatAppearance.BorderSize = 0;
            this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btExit.Image = ((System.Drawing.Image)(resources.GetObject("btExit.Image")));
            this.btExit.Location = new System.Drawing.Point(848, 12);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(40, 24);
            this.btExit.TabIndex = 1;
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btRooms
            // 
            this.btRooms.BackColor = System.Drawing.Color.CadetBlue;
            this.btRooms.FlatAppearance.BorderSize = 5;
            this.btRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.btRooms.ForeColor = System.Drawing.SystemColors.Control;
            this.btRooms.Image = ((System.Drawing.Image)(resources.GetObject("btRooms.Image")));
            this.btRooms.Location = new System.Drawing.Point(21, 106);
            this.btRooms.Name = "btRooms";
            this.btRooms.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.btRooms.Size = new System.Drawing.Size(200, 329);
            this.btRooms.TabIndex = 0;
            this.btRooms.Text = "Danh sách phòng";
            this.btRooms.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btRooms.UseVisualStyleBackColor = false;
            this.btRooms.Click += new System.EventHandler(this.btRooms_Click);
            // 
            // btCheckInOut
            // 
            this.btCheckInOut.BackColor = System.Drawing.Color.CadetBlue;
            this.btCheckInOut.FlatAppearance.BorderSize = 5;
            this.btCheckInOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCheckInOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCheckInOut.ForeColor = System.Drawing.SystemColors.Control;
            this.btCheckInOut.Image = ((System.Drawing.Image)(resources.GetObject("btCheckInOut.Image")));
            this.btCheckInOut.Location = new System.Drawing.Point(670, 106);
            this.btCheckInOut.Name = "btCheckInOut";
            this.btCheckInOut.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.btCheckInOut.Size = new System.Drawing.Size(200, 329);
            this.btCheckInOut.TabIndex = 1;
            this.btCheckInOut.Text = "Check in/ out";
            this.btCheckInOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btCheckInOut.UseVisualStyleBackColor = false;
            this.btCheckInOut.Click += new System.EventHandler(this.btCheckInOut_Click);
            // 
            // btBooking
            // 
            this.btBooking.BackColor = System.Drawing.Color.CadetBlue;
            this.btBooking.FlatAppearance.BorderSize = 5;
            this.btBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBooking.ForeColor = System.Drawing.SystemColors.Control;
            this.btBooking.Image = ((System.Drawing.Image)(resources.GetObject("btBooking.Image")));
            this.btBooking.Location = new System.Drawing.Point(455, 106);
            this.btBooking.Name = "btBooking";
            this.btBooking.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.btBooking.Size = new System.Drawing.Size(200, 329);
            this.btBooking.TabIndex = 2;
            this.btBooking.Text = "Đặt phòng";
            this.btBooking.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btBooking.UseVisualStyleBackColor = false;
            this.btBooking.Click += new System.EventHandler(this.btBooking_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.btGuests);
            this.panel2.Controls.Add(this.btBooking);
            this.panel2.Controls.Add(this.btCheckInOut);
            this.panel2.Controls.Add(this.btRooms);
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 543);
            this.panel2.TabIndex = 1;
            // 
            // btGuests
            // 
            this.btGuests.BackColor = System.Drawing.Color.CadetBlue;
            this.btGuests.FlatAppearance.BorderSize = 5;
            this.btGuests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGuests.ForeColor = System.Drawing.SystemColors.Control;
            this.btGuests.Image = ((System.Drawing.Image)(resources.GetObject("btGuests.Image")));
            this.btGuests.Location = new System.Drawing.Point(236, 106);
            this.btGuests.Name = "btGuests";
            this.btGuests.Padding = new System.Windows.Forms.Padding(0, 0, 0, 50);
            this.btGuests.Size = new System.Drawing.Size(200, 329);
            this.btGuests.TabIndex = 3;
            this.btGuests.Text = "Khách hàng";
            this.btGuests.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btGuests.UseVisualStyleBackColor = false;
            this.btGuests.Click += new System.EventHandler(this.btGuests_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Phòng Khách Sạn";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btMinimize;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btRooms;
        private System.Windows.Forms.Button btCheckInOut;
        private System.Windows.Forms.Button btBooking;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btGuests;
    }
}

