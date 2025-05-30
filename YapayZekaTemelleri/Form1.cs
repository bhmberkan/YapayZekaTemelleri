using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeechLib;
using System.Speech.Recognition;
namespace YapayZekaTemelleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void ProductList()
        {
            var products = db.tblproduct.Select(x=> new {
            
                x.NAME,
                x.BRAND,
                x.STOCK,
                x.BUYPRİCE,
                x.SELLPRİCE,
                x.CATEGORY,
                x.DATEADD,
                x.PRODUCTCASE
            }).ToList();
            dataGridView1.DataSource = products;
        }

        public void AddProduct()
        {
            tblproduct t = new tblproduct();
            t.NAME = textBox1.Text;
            t.BRAND = textBox2.Text;
            t.BUYPRİCE = decimal.Parse(textBox4.Text);
            t.SELLPRİCE = decimal.Parse(textBox5.Text);
            t.STOCK = short.Parse(textBox3.Text);
            t.PRODUCTCASE = true;
            t.DATEADD = DateTime.Parse(maskedTextBox1.Text);
            t.CATEGORY = textBox6.Text;
            db.tblproduct.Add(t);
            db.SaveChanges();
        }

        // bu şekilde çalıştırınca çalışıyor ama enabled foksiyonunu çalıştırınca çalışmıyor garip.
        void enabled()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            comboBox1.Enabled = false;
            maskedTextBox1.Enabled = false;
        }

        void colormetod()
        {
            textBox1.BackColor = Color.White;
            textBox2.BackColor = Color.White;
            textBox3.BackColor = Color.White;
            textBox4.BackColor = Color.White;
            textBox5.BackColor = Color.White;
            textBox6.BackColor = Color.White;
            comboBox1.BackColor = Color.White;
            maskedTextBox1.BackColor = Color.White;
        }

        DbYapayZekaEntities db = new DbYapayZekaEntities();

        private void BtnSpeak_Click(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(richTextBox1.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            Grammar g = new DictationGrammar();
            sr.LoadGrammar(g);
            try
            {
                richTextBox1.Text = "Lütfen konuşun...";
                sr.SetInputToDefaultAudioDevice();
                RecognitionResult res = sr.Recognize();

                if (res != null)
                {
                    richTextBox1.Text = res.Text;
                }
                else
                {
                    richTextBox1.Text = "Anlaşılamadı, lütfen tekrar deneyin.";
                }
            }
            catch (Exception ex)
            {
                richTextBox1.Text = "Bir hata oluştu: " + ex.Message;
            }
        }

        private void btnproductadd_Click(object sender, EventArgs e)
        {
          
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

            if (richTextBox1.BackColor == Color.Yellow && textBox1.Enabled==true)
            {
                textBox1.Text = richTextBox1.Text;
                //enabled();
                colormetod();
            }
            
            if (textBox2.BackColor == Color.Yellow && textBox2.Enabled == true)
            {
                textBox2.Text = richTextBox1.Text;
               // enabled();
                colormetod();
            }

            if (textBox3.BackColor == Color.Yellow && textBox3.Enabled == true)
            {
                textBox3.Text = richTextBox1.Text;
                // enabled();
                colormetod();
            }

            if(textBox4.BackColor==Color.Yellow && textBox4.Enabled==true)
            {
                textBox4.Text = richTextBox1.Text;
                //enabled();
                colormetod();
            }
            if (textBox5.BackColor == Color.Yellow && textBox5.Enabled == true)
            {
                textBox5.Text = richTextBox1.Text;
                // enabled();
                colormetod();
            }
            if (textBox6.BackColor == Color.Yellow && textBox6.Enabled == true)
            {
                textBox6.Text = richTextBox1.Text;
                //enabled();
                colormetod();
            }

            if(maskedTextBox1.BackColor==Color.Yellow && maskedTextBox1.Enabled==true)
            {
               
                // maskedTextBox1.Text = DateTime.Now.ToShortDateString();  // date düzgün gelmiyordu
                //enabled();
                colormetod();
            }

            if(comboBox1.BackColor==Color.Yellow && comboBox1.Enabled==true)
            {
                comboBox1.Text = "Active";
                //enabled();
                colormetod();
            }

            // buırada textboxta yazan yazıya göre veri tabanındaki veriyi ekranda gösteriyoruz.
            // örn. list of product  dediğimizde ürünler listesini getirecektir.
            if (richTextBox1.Text == "List of products" || richTextBox1.Text == "Products lists" || richTextBox1.Text == "10")
            {
                ProductList();
            }
           
            if (richTextBox1.Text == "Add" || richTextBox1.Text == "Add to" || richTextBox1.Text == "Add the")
            {

                AddProduct();

                label10.Text = "Products saved in database";
                ProductList();

                enabled();
            }


            if (richTextBox1.Text == "Product name" || richTextBox1.Text=="Name" || richTextBox1.Text=="The name")
            {
                textBox1.Focus();
                textBox1.BackColor = Color.Yellow;
                textBox1.Enabled = true;
            }

            if (richTextBox1.Text == "Brand" || richTextBox1.Text == "Mark")
            {
                textBox2.Focus();
                textBox2.BackColor = Color.Yellow;
                textBox2.Enabled = true;
            }

            if (richTextBox1.Text == "Stock" || richTextBox1.Text == "Stocks" ||richTextBox1.Text=="Store")
            {
                textBox3.Focus();
                textBox3.BackColor = Color.Yellow;
                textBox3.Enabled = true;
            }

            if (richTextBox1.Text == "Buy price" || richTextBox1.Text == "Buying price" || richTextBox1.Text == "Buy" || richTextBox1.Text == "By")
            {
                textBox4.Focus();
                textBox4.BackColor = Color.Yellow;
                textBox4.Enabled = true;
            }


            if (richTextBox1.Text == "Sell price" || richTextBox1.Text == "Sell")
            {
                textBox5.Focus();
                textBox5.BackColor = Color.Yellow;
                textBox5.Enabled = true;
            }

            if (richTextBox1.Text == "Category")
            {
                textBox6.Focus();
                textBox6.BackColor = Color.Yellow;
                textBox6.Enabled = true; 
            }
            if (richTextBox1.Text == "State")
            {

                comboBox1.Focus();
                comboBox1.BackColor = Color.Yellow;
                comboBox1.Enabled = true;
            }

            if(richTextBox1.Text=="Date")
            {
                maskedTextBox1.Focus();
                maskedTextBox1.BackColor = Color.Yellow;
                maskedTextBox1.Enabled = true;
            }

            
            if(richTextBox1.Text=="Exit application" || richTextBox1.Text=="Exist application" || richTextBox1.Text=="Exit app" || richTextBox1.Text=="Exit")
            {
                timer1.Stop();
                Application.Exit();
            }
            if(richTextBox1.Text=="Paint")
            {
                System.Diagnostics.Process.Start("MsPaint");
            }
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         //   enabled();
            colormetod();
        }

        private void maskedTextBox1_BackColorChanged(object sender, EventArgs e)
        {
            if(maskedTextBox1.BackColor==Color.Yellow)
            {
                maskedTextBox1.Text = DateTime.Now.ToString("dd.MM.yyyy");
            }
        }

        private void comboBox1_BackColorChanged(object sender, EventArgs e)
        {
            if(comboBox1.BackColor==Color.Yellow)
            {
                comboBox1.Text = "Active";
                // video 14 te kaldık
            }
        }

        private void label10_TextChanged(object sender, EventArgs e)
        {
            SpVoice ses = new SpVoice();
            ses.Speak(label10.Text);
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            enabled();
            colormetod();
            //timer1.Start();

            this.BackColor = Color.FromArgb(30, 30, 30);

            // Örnek: Bir buton stili
            StyleHelper.ApplyButtonStyles(this);

            // Örnek: Label stili
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            StyleHelper.ApplyLabelStyles(this);

            // Örnek: DataGridView stili
            dataGridView1.BackgroundColor = Color.FromArgb(45, 45, 48);
            dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dataGridView1.DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            //Grammar g = new DictationGrammar();
            //sr.LoadGrammar(g);
            //try
            //{
            //    richTextBox1.Text = " lütfen konuşun ";
            //    sr.SetInputToDefaultAudioDevice();
            //    RecognitionResult res = sr.Recognize();

            //    richTextBox1.Text = res.Text;
            //}
            //catch (Exception)
            //{
            //    richTextBox1.Text = "Tekrar deneyin";
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Forms.FrmObjDet fr = new Forms.FrmObjDet();
            fr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forms.FrmAforge1 fr = new Forms.FrmAforge1();
            fr.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
