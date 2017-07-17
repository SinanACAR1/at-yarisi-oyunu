using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace At_yarışı_oyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int nekadar;
        int para = 10;
         int birinciatınsolauzaklık,ikinciatınsolauzaklık,ucuncuatınsoluzaklık;
        Random rastgele = new Random();
        private void Form1_Load(object sender, EventArgs e)
        {
            birinciatınsolauzaklık = pictureBox1.Left;
            ikinciatınsolauzaklık = pictureBox2.Left;
            ucuncuatınsoluzaklık = pictureBox3.Left;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int birinciatıngenisligi = pictureBox1.Width;
                int ıkıncıatıngenıslıgı = pictureBox2.Width;
                int ucuncuatıngenıslıgı = pictureBox3.Width;

                pictureBox1.Left = pictureBox1.Left + rastgele.Next(10, 15);
                pictureBox2.Left = pictureBox2.Left + rastgele.Next(10, 15);
                pictureBox3.Left = pictureBox3.Left + rastgele.Next(10, 15);

                int bitişuzaklıgı = lblbıtıs.Left;

                //yarış durumu
                if (pictureBox1.Left > pictureBox2.Left + 5 && pictureBox1.Left > pictureBox3.Left + 5)
                {
                    label5.Text = "1 numaralı at birinciliği ele aldı";
                }
                if (pictureBox2.Left > pictureBox1.Left + 5 && pictureBox2.Left > pictureBox3.Left + 5)
                {
                    label5.Text = "2 numaralı at mukemmel bir şekilde birinciliği alıyor";
                }
                if (pictureBox3.Left > pictureBox1.Left + 5 && pictureBox3.Left > pictureBox2.Left + 5)
                {
                    label5.Text = "3. numaralı at birinci gidiyor";
                }

                //Hangi atın kazandığı

                if (birinciatıngenisligi + pictureBox1.Left >= bitişuzaklıgı)
                {
                    label5.Text = "1.At kazandı!!!...";
                    timer1.Stop();
                }
                if (ıkıncıatıngenıslıgı + pictureBox2.Left >= bitişuzaklıgı)
                {
                    label5.Text = "2.At kazandı!!!...";
                    timer1.Stop();
                }
                if (ucuncuatıngenıslıgı + pictureBox3.Left >= bitişuzaklıgı)
                {
                    label5.Text = "3.At kazandı!!!...";
                    timer1.Stop();
                }

                //bahis kazanma
                nekadar = int.Parse(textBox2.Text);
                if (textBox1.Text == "1" && label5.Text == "1.At kazandı!!!...")
                {
                    timer2.Stop();
                    para += nekadar;
                    label6.Text = para.ToString();
                }
                if (textBox1.Text == "2" && label5.Text == "2.At kazandı!!!...")
                {
                    timer2.Stop();
                    para += nekadar;
                    label6.Text = para.ToString();
                }
                if (textBox1.Text == "3" && label5.Text == "3.At kazandı!!!...")
                {
                    timer2.Stop();
                    para += nekadar;
                    label6.Text = para.ToString();
                }
                if (para < 0)
                {
                    timer1.Stop();
                    MessageBox.Show("Paranız yok bu şekilde oynayamazsınız.");
                }

            }
            catch
            { timer1.Stop(); MessageBox.Show("yanlış bir şey yaptın!!!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Left = 0;
            pictureBox2.Left = 0;
            pictureBox3.Left = 0;
            label5.Text = "";
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            pictureBox1.Left = 0;
            pictureBox2.Left = 0;
            pictureBox3.Left = 0;
            label5.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            para = 10;
            label6.Text = para.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //bahis kaybetme
            try
            {
                nekadar = int.Parse(textBox2.Text);
   
                if (textBox1.Text == "1" && label5.Text == "2.At kazandı!!!..." || label5.Text == "3.At kazandı!!!...")
                {
                    timer2.Stop();
                    ; para -= nekadar;
                    label6.Text = para.ToString();
                }
                if (textBox1.Text == "2" && label5.Text == "3.At kazandı!!!..." || label5.Text == "1.At kazandı!!!...")
                {
                    timer2.Stop();
                    para -= nekadar;
                    label6.Text = para.ToString();
                }
                if (textBox1.Text == "3" && label5.Text == "2.At kazandı!!!..." || label5.Text == "1.At kazandı!!!...")
                {
                    para += nekadar;
                    label6.Text = para.ToString();
                    timer2.Stop();
                }
            }
            catch { timer2.Stop(); MessageBox.Show("yanlış bir şey yaptın!!!", "HATA!!", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        
        

            }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
