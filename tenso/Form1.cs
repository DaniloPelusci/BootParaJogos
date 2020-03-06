using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace tenso
{
    public partial class Form1 : Form
    {
        int ContFlour = 0;
        int comida = 200;
        int s1 = 4;
        int d1 = 3;
        int s2 = 6;
        int d2 = 8;
        int s3 = 1;
        int d3 = 8;
        int s4 = 13;
        int a1 = 14;
        int w1 = 14;
        int a2 = 3;
        int w2 = 10;
        int a3 = 2;
        int a4 = 0;
        int a5 = 0;
        int s5 = 0;
        int s6 = 0;
        int a6 = 0;
        int w3 = 0;
        int a7 = 0;
        int w4 = 0;
        int d4 = 0;
        int w5 = 0;
        int d5 = 0;
        int w6 = 0;
        int d6 = 0;
        int w7 = 0;

        int ataque = 0;
        bool Ataquestatus = false;
        public Form1()
        {
            InitializeComponent();
        }
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;
        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInf);

        private void button1_Click(object sender, EventArgs e)
        {

            SendKeys.Send("{ENTER}");
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            SendKeys.Send("{UP}");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
                timer3.Enabled = true;
                timer4.Enabled = true;
                timer5.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                timer4.Enabled = false;
                timer5.Enabled = false;

            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            SendKeys.Send("a");
            SendKeys.Send("b");
            SendKeys.Send("c");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send(" ");
            SendKeys.Send(" ");


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("{F3}");
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            // SendKeys.Send("d");
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            //SendKeys.Send("a");



        }


        private void button2_Click(object sender, EventArgs e)
        {
            //CreateBitmapAtRuntime();
            timerColor.Enabled = true;
            if (timer1.Enabled == false)
            {
                timerMapa.Enabled = true;
            }
            else
            {
                timerMapa.Enabled = false;
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 956, 476, 0, 0);//make left button down
            mouse_event(MOUSEEVENTF_RIGHTUP, 956, 476, 0, 0);//make left button up
        }
        PictureBox pictureBox1 = new PictureBox();
        //private Point corDoMOuse;

        public void CreateBitmapAtRuntime()
        {
            pictureBox1.Size = new Size(210, 110);
            this.Controls.Add(pictureBox1);

            Bitmap flag = new Bitmap(200, 100);
            Graphics flagGraphics = Graphics.FromImage(flag);
            int red = 0;
            int white = 11;
            while (white <= 100)
            {
                flagGraphics.FillRectangle(Brushes.Red, 0, red, 200, 10);
                flagGraphics.FillRectangle(Brushes.White, 0, white, 200, 10);
                red += 20;
                white += 20;
            }
            pictureBox1.Image = flag;
        }

        private void timerColor_Tick(object sender, EventArgs e)
        {
            Point pontoChave = new Point(973, 533);
            Console.WriteLine(GetPixel(pontoChave));
            //corDoMOuse = pictureBox1.PointToClient(Cursor.Position);
            //Bitmap bmp = (Bitmap)pictureBox1.Image;
            Color target = GetPixel(pontoChave);
            //Color c = new Color();
            ////= bmp.GetPixel(corDoMOuse.X, corDoMOuse.Y);
            //if (c == target)
            //{
            //    bmp.SetPixel(corDoMOuse.X, corDoMOuse.Y, Color.Red); button2.BackColor = Color.FromArgb(100, 250, 0, 100);

            pictureBox2.BackColor = target;
            //}
            //else MessageBox.Show("Click only on white spots! You have hit " + c.ToString(),
            //                     "Wrong spot! ");
        }

        static Color GetPixel(Point position)
        {
            using (var bitmap = new Bitmap(1, 1))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(position, new Point(0, 0), new Size(1, 1));
                }
                return bitmap.GetPixel(0, 0);
            }
        }
        int aa = 10;
        private void timerMapa_Tick(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);
            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            if (ataque <= 0)
            {
                if (ContFlour == 0)
                {
                    if (aa > 0)
                    {
                        aa = VerificacaoDePixel(Target, Target2, PontoChave, aa, " ");

                    }
                    else if (s1 > 0)
                    {
                        s1 = VerificacaoDePixel(Target, Target2, PontoChave, s1, "s");
                    }
                    else if (d1 > 0)
                    {
                        d1 = VerificacaoDePixel(Target, Target2, PontoChave, d1, "d");
                    }
                    else if (s2 > 0)
                    {
                        s2 = VerificacaoDePixel(Target, Target2, PontoChave, s2, "s");
                    }
                    else if (d2 > 0)
                    {
                        d2 = VerificacaoDePixel(Target, Target2, PontoChave, d2, "d");
                    }
                    else if (s3 > 0)
                    {
                        s3 = VerificacaoDePixel(Target, Target2, PontoChave, s3, "s");
                    }
                    else if (d3 > 0)
                    {
                        d3 = VerificacaoDePixel(Target, Target2, PontoChave, d3, "d");
                    }
                    else if (s4 > 0)
                    {
                        s4 = VerificacaoDePixel(Target, Target2, PontoChave, s4, "s");
                    }
                    else if (a1 > 0)
                    {
                        a1 = VerificacaoDePixel(Target, Target2, PontoChave, a1, "a");
                    }
                    else if (w1 > 0)
                    {
                        w1 = VerificacaoDePixel(Target, Target2, PontoChave, w1, "w");
                    }
                    else if (a2 > 0)
                    {
                        a2 = VerificacaoDePixel(Target, Target2, PontoChave, a2, "a");
                    }
                    else if (w2 > 0)
                    {
                        w2 = VerificacaoDePixel(Target, Target2, PontoChave, w2, "w");
                    }
                    else if (a3 > 0)
                    {
                        a3 = VerificacaoDePixel(Target, Target2, PontoChave, a3, "a");
                        if (a3 == 0)
                        {
                            SendKeys.Send("{F6}");
                            mouse_event(MOUSEEVENTF_LEFTDOWN, 312, 300, 0, 0);//make left button down
                            mouse_event(MOUSEEVENTF_LEFTUP, 312, 300, 0, 0);//make left button up
                            ContFlour++;
                        }

                    }
                }
                else
                {

                }


                if (ContFlour == 0 & w7 == 0)
                {
                    s1 = 4;
                    d1 = 3;
                    s2 = 6;
                    d2 = 8;
                    s3 = 1;
                    d3 = 8;
                    s4 = 13;
                    a1 = 14;
                    w1 = 14;
                    a2 = 3;
                    w2 = 10;
                    a3 = 2;
                    ContFlour++;
                }
                else if (ContFlour == 1 & a3 == 0)
                {

                    s1 = 1;
                    a1 = 2;
                    s1 = 3;
                    a2 = 4;
                    s2 = 4;
                    a3 = 1;
                    s3 = 4;
                    a4 = 5;
                    w1 = 1;
                    a5 = 1;
                    w2 = 2;
                    s4 = 3;
                    d1 = 4;
                    s5 = 6;
                    d2 = 1;
                    s6 = 5;
                    a6 = 5;
                    d3 = 5;
                    w3 = 6;
                    a7 = 2;
                    w4 = 6;
                    d4 = 2;
                    w5 = 6;
                    d5 = 5;
                    w6 = 6;
                    d6 = 2;
                    w7 = 1;



                    ContFlour--;
                }

            }
            else if (ataque == 5)
            {
                if (!verificacaoAtaaque(Target))
                {
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 312, 300, 0, 0);//make left button down
                    mouse_event(MOUSEEVENTF_RIGHTUP, 312, 300, 0, 0);//make left button up
                    ataque--;
                    label7.Text = "" + ataque;
                }
            }
            else
            {
                if (!verificacaoAtaaque(Target))
                {
                    label7.Text = "" + ataque;
                    ataque--;
                }

            }
            if (comida < 0)
            {
                SendKeys.Send("{F5}");
                SendKeys.Send("{F5}");
                SendKeys.Send("{F5}");
                SendKeys.Send("{F5}");
                SendKeys.Send("{F5}");
                SendKeys.Send("{F5}");
                comida = 200;
            }
            else
            {
                comida--;
            }





            //while (s1 > 0)
            //{
            //    SendKeys.Send("s");
            //    s1--;
            //}
            //while (d1 > 0)
            //{

            //}
            //while (s2 > 0)
            //{

            //}
            //while (d2 > 0)
            //{

            //}
            //while (s3 > 0)
            //{

            //}
            //while (d3 > 0)
            //{

            //}
            //while (s4 > 0)
            //{

            //}
            //while (a1 > 0)
            //{

            //}
            //while (w1 > 0)
            //{

            //}
            //while (a2 > 0)
            //{

            //}
            //while (w2 > 0)
            //{

            //}
            //while (a3 > 0)
            //{

            //}
        }

        public int VerificacaoDePixel(Color target, Color target2, Point pontoChave, int valor, string tecla)
        {


            if (verificacaoPixel(target, target2))
            {

                if (verificacaoAtaaque(target))
                {

                    Console.WriteLine("atacando");
                    ataque = 6;

                    label7.Text = "" + ataque;
                    return valor;
                }
                else
                {
                    ataque = 6;
                    SendKeys.Send(" ");

                    label7.Text = "" + ataque;
                    return valor;
                }

            }
            else
            {
                SendKeys.Send(tecla);
                valor = valor - 1;
                Console.WriteLine(valor);
                return valor;
            }
        }
        public bool verificacaoPixel(Color target, Color target2)
        {
            if (target != Color.FromArgb(255, 70, 70, 70) | target2 != Color.FromArgb(255, 72, 73, 73))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool verificacaoAtaaque(Color target)
        {
            if (target == Color.FromArgb(255, 176, 29, 29))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void timerIniciante_Tick(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);
            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            if (ataque <= 0)
            {

                if (aa > 0)
                {
                    aa = VerificacaoDePixel(Target, Target2, PontoChave, aa, " ");

                }

            }
            else if (ataque == 5)
            {
                if (!verificacaoAtaaque(Target))
                {
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 312, 300, 0, 0);//make left button down
                    mouse_event(MOUSEEVENTF_RIGHTUP, 312, 300, 0, 0);//make left button up
                    ataque--;
                    label7.Text = "" + ataque;
                }
            }
            else
            {
                if (!verificacaoAtaaque(Target))
                {
                    label7.Text = "" + ataque;
                    ataque--;
                }

            }
        }

        private void timerMapaVespas0_Tick(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1.Text);
            int y = Convert.ToInt32(textBox2.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);
            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            if (ataque <= 0)
            {
                if (ContFlour == 0)
                {
                    if (aa > 0)
                    {
                        aa = VerificacaoDePixel(Target, Target2, PontoChave, aa, " ");

                    }
                    else if (s1 > 0)
                    {
                        s1 = VerificacaoDePixel(Target, Target2, PontoChave, s1, "s");
                    }
                    else if (d1 > 0)
                    {
                        d1 = VerificacaoDePixel(Target, Target2, PontoChave, d1, "d");
                    }
                    else if (s2 > 0)
                    {
                        s2 = VerificacaoDePixel(Target, Target2, PontoChave, s2, "s");
                    }
                    else if (d2 > 0)
                    {
                        d2 = VerificacaoDePixel(Target, Target2, PontoChave, d2, "d");
                    }
                    else if (s3 > 0)
                    {
                        s3 = VerificacaoDePixel(Target, Target2, PontoChave, s3, "s");
                    }
                    else if (d3 > 0)
                    {
                        d3 = VerificacaoDePixel(Target, Target2, PontoChave, d3, "d");
                    }
                    else if (s4 > 0)
                    {
                        s4 = VerificacaoDePixel(Target, Target2, PontoChave, s4, "s");
                    }
                    else if (a1 > 0)
                    {
                        a1 = VerificacaoDePixel(Target, Target2, PontoChave, a1, "a");
                    }
                    else if (w1 > 0)
                    {
                        w1 = VerificacaoDePixel(Target, Target2, PontoChave, w1, "w");
                    }
                    else if (a2 > 0)
                    {
                        a2 = VerificacaoDePixel(Target, Target2, PontoChave, a2, "a");
                    }
                    else if (w2 > 0)
                    {
                        w2 = VerificacaoDePixel(Target, Target2, PontoChave, w2, "w");
                    }
                    else if (a3 > 0)
                    {
                        a3 = VerificacaoDePixel(Target, Target2, PontoChave, a3, "a");
                        //if (a3 == 0)
                        //{
                        //    SendKeys.Send("{F6}");
                        //    mouse_event(MOUSEEVENTF_LEFTDOWN, 312, 300, 0, 0);//make left button down
                        //    mouse_event(MOUSEEVENTF_LEFTUP, 312, 300, 0, 0);//make left button up
                        //    ContFlour++;
                        //}

                    }
                }


                if (a3 == 0)
                {
                    s1 = 4;
                    d1 = 3;
                    s2 = 6;
                    d2 = 8;
                    s3 = 1;
                    d3 = 8;
                    s4 = 13;
                    a1 = 14;
                    w1 = 14;
                    a2 = 3;
                    w2 = 10;
                    a3 = 2;
                    ContFlour++;
                }


            }
            else if (ataque == 5)
            {
                if (!verificacaoAtaaque(Target))
                {
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 312, 300, 0, 0);//make left button down
                    mouse_event(MOUSEEVENTF_RIGHTUP, 312, 300, 0, 0);//make left button up
                    ataque--;
                    label7.Text = "" + ataque;
                }
            }
            else
            {
                if (!verificacaoAtaaque(Target))
                {
                    label7.Text = "" + ataque;
                    ataque--;
                }

            }
            if (comida < 0)
            {
                SendKeys.Send("{F5}");
                SendKeys.Send("{F5}");
                SendKeys.Send("{F5}");
                SendKeys.Send("{F5}");
                SendKeys.Send("{F5}");
                SendKeys.Send("{F5}");
                comida = 200;
            }
            else
            {
                comida--;
            }
        }
    }
}
