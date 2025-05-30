using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace YapayZekaTemelleri.Forms
{
    public partial class FrmAforge1 : Form
    {
        public FrmAforge1()
        {
            InitializeComponent();
        }

        FilterInfoCollection fico;
        VideoCaptureDevice vc;
        private void FrmAforge1_Load(object sender, EventArgs e)
        {
         
           this.BackColor = Color.FromArgb(30, 30, 30);
        
        StyleHelper.ApplyButtonStyles(this);
            StyleHelper.ApplyLabelStyles(this);

            fico = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo f in fico)
            {
                comboBox1.Items.Add(f.Name);
            }
        }

        private void Vc_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap original = (Bitmap)eventArgs.Frame.Clone();
            original.RotateFlip(RotateFlipType.RotateNoneFlipX); // Yatayda ters çevir
            pictureBox1.Image = original;

            //Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            //pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                vc = new VideoCaptureDevice(fico[comboBox1.SelectedIndex].MonikerString);
                vc.NewFrame += Vc_NewFrame;
                vc.Start();
            }
        }

        private void FrmAforge1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //uygulamadan çıkış yaparken kamera açık kalmamalı
            if (vc != null && vc.IsRunning)
            {
                vc.SignalToStop();
                vc.WaitForStop();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
            this.Close();
        }
    }
}
