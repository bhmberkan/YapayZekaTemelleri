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
            fico = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo f in fico)
            {
                comboBox1.Items.Add(f.Name);
            }
        }
    }
}
