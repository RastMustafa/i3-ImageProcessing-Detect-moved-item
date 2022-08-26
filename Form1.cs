using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            //sB();


            Bitmap Resim1, Resim2, CikisResmi;
            Resim1 = new Bitmap(pictureBox1.Image);
            Resim2 = new Bitmap(pictureBox2.Image);
            int ResimGenisligi = 255;
            int ResimYuksekligi = 255;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            Pen Kalem = new Pen(System.Drawing.Color.Red, 2);
            double[,] agirlikmerkezi = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } , { 7, 8 } , { 7, 8 } , { 7, 8 } , { 7, 8 } };

            Color Renk1, Renk2;
            int objNum = 0;
            int x, y;
            int x1=0, y1=0;
            int R = 0, G = 0, B = 0;
            int xToplama = 0, ytoplami = 0;
            int xnum = 0, ynum = 0;
            bool status = false;
            bool status2 = false;
            for (x = 0; x < ResimGenisligi; x++)
            {
                for (y = 0; y < ResimYuksekligi; y++)
                {
                    Renk1 = Resim1.GetPixel(x, y);
                    Renk2 = Resim2.GetPixel(x, y);
                    R = Math.Abs(Renk1.R - Renk2.R);

                    if((x1 >30) && (y1 > 100) &&status2)
                    {
                        x1 = 0;
                        y1 = 0;
                        status = true;
                        status2=false;
                    }


                    if (R > 60)
                    {
                        if (status && xnum>100 &&ynum>100)
                        {

                            agirlikmerkezi[objNum, 0] = xToplama / (1 + xnum);
                            agirlikmerkezi[objNum, 1] = ytoplami / (1 + ynum);
                            objNum++;
                            xToplama = 0; 
                            ytoplami = 0;
                            xnum = 0; 
                            ynum = 0;
                            status = false;

                        }
                        else
                        {
                            status2 = true;
                            xnum++;
                            ynum++;
                            xToplama += x;
                            ytoplami += y;

                        }
            

                    }
                    else
                    {
                        
                        y1++;
                    }

                    CikisResmi.SetPixel(x, y, Color.FromArgb(R, R, R));
                }
                if (R < 60)
                {
                    x1++;
                }
            }
            //Graphics gfx = pic/*/*t*/*/ureBox3.CreateGraphics();

            //textBox1.Text = (agirlikmerkezi[0,0] + " " + agirlikmerkezi[0, 1]+" .. "+ xToplama / (1 + xnum)+" "+ ytoplami / (1 + ynum)).ToString();
            pictureBox3.Image = CikisResmi;
            Graphics g;
            g = Graphics.FromImage(CikisResmi);
            //CizimAlani = pictureBox3.CreateGraphics();

            g.DrawLine(Kalem, xToplama / (1 + xnum), ytoplami / (1 + ynum) - 15, xToplama / (1 + xnum), ytoplami / (1 + ynum) + 15);
            g.DrawLine(Kalem, xToplama / (1 + xnum) - 15, ytoplami / (1 + ynum), xToplama / (1 + xnum) + 15, ytoplami / (1 + ynum));
            g.DrawLine(Kalem, (float)agirlikmerkezi[1, 0], (float)agirlikmerkezi[1, 1] - 15, (float)agirlikmerkezi[1, 0], (float)agirlikmerkezi[1, 1] + 15);
            g.DrawLine(Kalem, (float)agirlikmerkezi[1, 0] - 15, (float)agirlikmerkezi[1, 1], (float)agirlikmerkezi[1, 0] + 15, (float)agirlikmerkezi[1, 1]);
            g.DrawLine(Kalem, (float)agirlikmerkezi[4, 0], (float)agirlikmerkezi[4, 1] - 15, (float)agirlikmerkezi[4, 0], (float)agirlikmerkezi[4, 1] + 15);
            g.DrawLine(Kalem, (float)agirlikmerkezi[4, 0] - 15, (float)agirlikmerkezi[4, 1], (float)agirlikmerkezi[4, 0] + 15, (float)agirlikmerkezi[4, 1]);
            g.DrawLine(Kalem, (float)agirlikmerkezi[3, 0], (float)agirlikmerkezi[3, 1] - 15, (float)agirlikmerkezi[3, 0], (float)agirlikmerkezi[3, 1] + 15);
            g.DrawLine(Kalem, (float)agirlikmerkezi[3, 0] - 15, (float)agirlikmerkezi[3, 1], (float)agirlikmerkezi[3, 0] + 15, (float)agirlikmerkezi[3, 1]);

        }
        private void sB()
        {
            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); //Cikis resmini oluşturuyor. Boyutları

            int EsiklemeDegeri = 128;


            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    if (OkunanRenk.R >= EsiklemeDegeri)
                        R = 255;
                    else
                        R = 0;
                    if (OkunanRenk.G >= EsiklemeDegeri)
                        G = 255;
                    else
                        G = 0;
                    if (OkunanRenk.B >= EsiklemeDegeri)
                        B = 255;
                    else
                        B = 0;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            pictureBox2.Image = CikisResmi;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            String Img = openFileDialog1.FileName;
            Bitmap originalImg = (Bitmap)Image.FromFile(Img);
            Bitmap resizedImg = new Bitmap(originalImg, new Size(255, 255));
            pictureBox1.Image = resizedImg;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Bitmap resizedImg = new Bitmap(pictureBox1.Image, new Size(255, 255));
            pictureBox2.Image = resizedImg;
        }
        Graphics CizimAlani;

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
