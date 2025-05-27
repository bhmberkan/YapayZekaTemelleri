using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// using Alturos.yolo;

namespace YapayZekaTemelleri.Forms
{
    public partial class FrmObjDet : Form
    {
        public FrmObjDet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog choose = new OpenFileDialog();
            if (choose.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(choose.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var configurationDetector = new ConfigurationDetector();
            //var config = configurationDetector.Detect();
            //using (var yoloWrapper = new YoloWrapper(config))
            //{
            //    //var items = yoloWrapper.Detect(@"image.jpg");
            //    using (MemoryStream ms = new MemoryStream())
            //    {
            //        pictureBox1.Image.Save(ms, ImageFormat.Png);
            //        var items = yoloWrapper.Detect(ms.ToArray());

            //    }
            //}
        }

        private void FrmObjDet_Load(object sender, EventArgs e)
        {

        }
    }
}


/*
var configurationDetector = new ConfigurationDetector();
var config = configurationDetector.Detect();
using (var yoloWrapper = new YoloWrapper(config))
{
	var items = yoloWrapper.Detect(@"image.jpg");
	//items[0].Type -> "Person, Car, ..."
	//items[0].Confidence -> 0.0 (low) -> 1.0 (high)
	//items[0].X -> bounding box
	//items[0].Y -> bounding box
	//items[0].Width -> bounding box
	//items[0].Height -> bounding box
}
*/