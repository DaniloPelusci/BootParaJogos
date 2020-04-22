using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace tenso
{
    public partial class Form1 : Form
    {
        List<Teclas> list = new List<Teclas>();
        int subir = 15;
        int ContFlour = 0;
        int comida = 200;
        bool auxiliar = false;


        int Autopotion = 0;
        int treino = 30;

        //--------- auxiliares
        Teclas comercomer = new Teclas(0, "{F5}");

        //------------D

        Teclas d1 = new Teclas(0, "d");
        Teclas d2 = new Teclas(0, "d");
        Teclas d3 = new Teclas(0, "d");
        Teclas d4 = new Teclas(0, "d");
        Teclas d5 = new Teclas(0, "d");
        Teclas d6 = new Teclas(0, "d");
        Teclas d7 = new Teclas(0, "d");
        Teclas d8 = new Teclas(0, "d");
        Teclas d9 = new Teclas(0, "d");
        //------------S

        Teclas s1 = new Teclas(0, "s");
        Teclas s2 = new Teclas(0, "s");
        Teclas s3 = new Teclas(0, "s");
        Teclas s5 = new Teclas(0, "s");
        Teclas s6 = new Teclas(0, "s");

        Teclas s4 = new Teclas(0, "s");
        Teclas s7 = new Teclas(0, "s");

        Teclas s8 = new Teclas(0, "s");
        Teclas s9 = new Teclas(0, "s");
        Teclas s10 = new Teclas(0, "s");


        //------------A
        Teclas a1 = new Teclas(0, "a");
        Teclas a2 = new Teclas(0, "a");
        Teclas a3 = new Teclas(0, "a");
        Teclas a4 = new Teclas(0, "a");
        Teclas a5 = new Teclas(0, "a");
        Teclas a6 = new Teclas(0, "a");
        Teclas a7 = new Teclas(0, "a");
        Teclas a9 = new Teclas(0, "a");
        Teclas a8 = new Teclas(0, "a");

        //-----------W
        Teclas w1 = new Teclas(0, "w");
        Teclas w2 = new Teclas(0, "w");
        Teclas w3 = new Teclas(0, "w");
        Teclas w4 = new Teclas(0, "w");
        Teclas w5 = new Teclas(0, "w");
        Teclas w6 = new Teclas(0, "w");
        Teclas w7 = new Teclas(0, "w");
        Teclas w8 = new Teclas(0, "w");
        Teclas w9 = new Teclas(0, "w");
        Teclas w10 = new Teclas(0, "w");
        Teclas aa = new Teclas(0, " ");
        //--------------------q
        Teclas q1 = new Teclas(0, "q");



        int asair = 1;
        // teste


        int ataque = 2;
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
            //if (timer1.Enabled == false)
            //{
            timer1.Enabled = true;
            //    timer2.Enabled = true;
            //    timer3.Enabled = true;
            //    timer4.Enabled = true;
            //    timer5.Enabled = true;
            //}
            //else
            //{
            //    timer1.Enabled = false;
            //    timer2.Enabled = false;
            //    timer3.Enabled = false;
            //    timer4.Enabled = false;
            //    timer5.Enabled = false;

            //}
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




        private void button2_Click(object sender, EventArgs e)
        {
            //CreateBitmapAtRuntime();
            timerColor.Enabled = true;
            //if (timerMapa.Enabled == false)
            //{
            timerMapa.Enabled = true;
            //}
            //else
            //{
            //    timerMapa.Enabled = false;
            //}
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



        public int VerificacaoDePixel(Color target, Color target2, Point pontoChave, Teclas teclas)
        {


            if (verificacaoPixel(target, target2))
            {

                if (verificacaoAtaaque(target))
                {

                    Console.WriteLine("atacando");
                    AtribuicaoAtaque();

                    label7.Text = "" + ataque;
                    label8.Text = "" + teclas.Quantidade + "" + teclas.NomeTecla + pontoChave;
                    return teclas.Quantidade;
                }
                else if (!verificacaoAtaaque(target) || verificacaoPixel(target, target2))
                {
                    AtribuicaoAtaque();
                    SendKeys.Send(" ");

                    label7.Text = "" + ataque;
                    label8.Text = "" + teclas.Quantidade + "" + teclas.NomeTecla;
                    return teclas.Quantidade;
                }
                label8.Text = "" + teclas.Quantidade + "" + teclas.NomeTecla;
                return teclas.Quantidade;


            }
            else
            {
                SendKeys.Send(teclas.NomeTecla);
                teclas.Quantidade--;
                Console.WriteLine(teclas.Quantidade);
                label8.Text = "" + teclas.Quantidade + "" + teclas.NomeTecla;
                return teclas.Quantidade;
            }
        }




        public bool verificacaoPixelSeForDiferente(Color target, Color target2)
        {
            if (target != Color.FromArgb(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text)) | target2 != Color.FromArgb(Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox10.Text)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool verificacaoPixel(Color target, Color target2)
        {
            if (target != Color.FromArgb(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text)) || target2 != Color.FromArgb(Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox10.Text)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool verificacaoPixelSeForIguale(Color target, Color target2)
        {
            if (target == Color.FromArgb(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text)) | target2 == Color.FromArgb(Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox10.Text)))
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
            if (target == Color.FromArgb(Convert.ToInt32(textBox14.Text), Convert.ToInt32(textBox13.Text), Convert.ToInt32(textBox12.Text), Convert.ToInt32(textBox11.Text)))
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
            aa.Quantidade = 2000;
            timerIniciante.Enabled = true;

        }


        private void AtribuicaoAtaque()
        {
            ataque = 5;
            // para lutiar ataque = 8;
            auxiliar = false;
        }



        private void button4_Click(object sender, EventArgs e)
        {

            // timerColor.Enabled = true;
            label8.Text = "" + aa;


            timerMapaVespas0.Enabled = true;



        }

        private void button5_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1X.Text);
            int y = Convert.ToInt32(textBox2Y.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);
            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            textBox3.Text = "" + Target.A;
            textBox4.Text = "" + Target.R;
            textBox5.Text = "" + Target.G;
            textBox6.Text = "" + Target.B;
            // ponto 2
            textBox7.Text = "" + Target2.A;
            textBox8.Text = "" + Target2.R;
            textBox9.Text = "" + Target2.G;
            textBox10.Text = "" + Target2.B;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1X.Text);
            int y = Convert.ToInt32(textBox2Y.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);
            textBox14.Text = "" + Target.A;
            textBox13.Text = "" + Target.R;
            textBox12.Text = "" + Target.G;
            textBox11.Text = "" + Target.B;

        }

        private void button7_Click(object sender, EventArgs e)
        {

            timerhorm.Enabled = true;
            timerAutopotion.Enabled = true;


        }

        private void button8_Click(object sender, EventArgs e)
        {

            //timer3.Enabled = true;
            //timer4.Enabled = true;
            timerAutopotion.Enabled = true;
            timerColor.Enabled = true;
        }



        private void button9_Click(object sender, EventArgs e)
        {
            timerAutopotion.Enabled = true;
            rorc.Enabled = true;
        }



        private void button10_Click(object sender, EventArgs e)
        {
            timerAutopotion.Enabled = true;
            timerMinelv2.Enabled = true;
            timerColor.Enabled = true;
        }


        //--------------------------- timers


        private void timerMapaVespas0_Tick(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1X.Text);
            int y = Convert.ToInt32(textBox2Y.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);
            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            if (ataque <= 0)
            {
                try
                {
                    if (list[0].Quantidade > 0)
                    {

                        list[0].Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, list[0]);

                    }
                    else
                    {
                        list.RemoveAt(0);
                    }
                }
                catch
                {
                    s1.Quantidade = 4;
                    d1.Quantidade = 3;
                    s2.Quantidade = 6;
                    d2.Quantidade = 8;
                    s3.Quantidade = 1;
                    d3.Quantidade = 8;
                    s4.Quantidade = 13;
                    a1.Quantidade = 14;
                    w1.Quantidade = 14;
                    a2.Quantidade = 3;
                    w2.Quantidade = 10;
                    a3.Quantidade = 2;
                    list.Add(s1);
                    list.Add(d1);
                    list.Add(s2);
                    list.Add(d2);
                    list.Add(s3);
                    list.Add(d3);
                    list.Add(s4);
                    list.Add(a1);
                    list.Add(w1);
                    list.Add(a2);
                    list.Add(w2);
                    list.Add(a3);
                }
            }
            else if (ataque == 5 && !verificacaoAtaaque(Target) && verificacaoPixelSeForIguale(Target, Target2))
            {
                Point pontoChave = new Point(964, 521);
                Console.WriteLine(GetPixel(pontoChave));
                Color target = GetPixel(pontoChave);
                pictureBox2.BackColor = target;

                label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);

                mouse_event(MOUSEEVENTF_RIGHTDOWN, 312, 300, 0, 0);//make left button down
                mouse_event(MOUSEEVENTF_RIGHTUP, 312, 300, 0, 0);//make left button up

                label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);
                ataque += 2;



            }
            else if (verificacaoAtaaque(Target) || !verificacaoPixelSeForIguale(Target, Target2))
            {
                label7.Text = "atacando" + ataque;
                if (ataque <= 4)
                {
                    ataque += 2;
                }


            }
            else
            {
                {
                    label7.Text = "atacando" + ataque;
                    ataque--;
                }
            }
            label7.Text = "atacando" + ataque;

            //else if (ataque == 5)
            //{
            //    if (!verificacaoAtaaque(Target))
            //    {
            //        mouse_event(MOUSEEVENTF_RIGHTDOWN, 312, 300, 0, 0);//make left button down
            //        mouse_event(MOUSEEVENTF_RIGHTUP, 312, 300, 0, 0);//make left button up
            //        ataque--;
            //        label7.Text = "" + ataque;
            //    }
            //}
            //else
            //{
            //    if (!verificacaoAtaaque(Target))
            //    {
            //        label7.Text = "" + ataque;
            //        ataque--;
            //    }

            //}
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

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            Point pontoChave = new Point(455, 34);
            Console.WriteLine(GetPixel(pontoChave));
            Color target = GetPixel(pontoChave);

            if (target == Color.FromArgb(255, 45, 45, 45))
            {
                SendKeys.Send(" ");
                Autopotion = 1;
            }
            if (Autopotion > 0)
            {
                SendKeys.Send("{F1}");
                Autopotion--;

            }



        }

        private void timer2_Tick_2(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1X.Text);
            int y = Convert.ToInt32(textBox2Y.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);
            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            if (ataque == 0 && !auxiliar)
            {
                ataque += 5;
                auxiliar = false;
                label7.Text = "" + ataque;
            }
            if (ataque <= 0)
            {
                if (ContFlour == 0)
                {
                    try
                    {
                        if (list[0].Quantidade > 0)
                        {

                            list[0].Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, list[0]);

                        }
                        else
                        {
                            list.RemoveAt(0);
                        }
                    }
                    catch
                    {
                        s1.Quantidade = 10;
                        d1.Quantidade = 16;
                        w1.Quantidade = 19;
                        a1.Quantidade = 16;
                        s2.Quantidade = 7;
                        d2.Quantidade = 3;
                        s3.Quantidade = 11;
                        a2.Quantidade = 1;
                        s4.Quantidade = 24;
                        d3.Quantidade = 5;
                        s5.Quantidade = 3;
                        d4.Quantidade = 4;
                        s6.Quantidade = 11;
                        w2.Quantidade = 2;
                        d5.Quantidade = 30;
                        w3.Quantidade = 7;
                        a3.Quantidade = 13;
                        w4.Quantidade = 4;
                        d6.Quantidade = 6;
                        w5.Quantidade = 6;
                        d7.Quantidade = 6;
                        w7.Quantidade = 17;
                        d8.Quantidade = 5;
                        w8.Quantidade = 8;
                        a4.Quantidade = 15;
                        w9.Quantidade = 5;
                        a5.Quantidade = 15;
                        s7.Quantidade = 13;
                        a5.Quantidade = 17;
                        w10.Quantidade = 8;
                        //---------------
                        list.Add(s1);
                        list.Add(d1);
                        list.Add(w1);
                        list.Add(a1);
                        list.Add(s2);
                        list.Add(d2);
                        list.Add(s3);
                        list.Add(a2);
                        list.Add(s4);
                        list.Add(d3);
                        list.Add(s5);
                        list.Add(d4);
                        list.Add(s6);
                        list.Add(w2);
                        list.Add(d5);
                        list.Add(w3);
                        list.Add(a3);
                        list.Add(w4);
                        list.Add(d6);
                        list.Add(w5);
                        list.Add(d7);
                        list.Add(w7);
                        list.Add(d8);
                        list.Add(w8);
                        list.Add(a4);
                        list.Add(w9);
                        list.Add(a5);
                        list.Add(s7);
                        list.Add(a5);
                        list.Add(w10);

                    }







                }
                else if (ataque <= 5 && !verificacaoAtaaque(Target) && !verificacaoPixel(Target, Target2) && !auxiliar)
                {
                    Point pontoChave = new Point(964, 521);
                    Console.WriteLine(GetPixel(pontoChave));
                    Color target = GetPixel(pontoChave);
                    pictureBox2.BackColor = target;

                    label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);

                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 312, 300, 0, 0);//make left button down
                    mouse_event(MOUSEEVENTF_RIGHTUP, 312, 300, 0, 0);//make left button up

                    label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);
                    ataque += 3;
                    auxiliar = true;





                }
                else if (!verificacaoAtaaque(Target) && !verificacaoPixelSeForIguale(Target, Target2))
                {

                    if (ataque < 5)
                    {

                        SendKeys.Send(" ");
                        ataque += 5;
                        label7.Text = "atacando" + ataque;
                        auxiliar = false;
                    }
                    else if (ataque == 1 && !auxiliar)
                    {
                        label7.Text = "atacando" + ataque;
                        ataque += 5;
                        auxiliar = false;
                    }
                    if (!verificacaoAtaaque(Target) && verificacaoPixelSeForIguale(Target, Target2) && !auxiliar)
                    {

                        ataque += 5;
                        auxiliar = false;
                    }



                }
                else
                {
                    {
                        label7.Text = "atacando" + ataque;
                        ataque--;
                    }
                }

                label7.Text = "atacando" + ataque;
                if (comida < 10)
                {

                    SendKeys.Send("{F5}");
                    label7.Text = "atacando" + ataque + "{F5}";
                    if (comida % 2 == 0)
                    {
                        SendKeys.Send("{F3}");
                    }
                    if (comida == 1)
                    {

                        comida = 200;
                    }
                    comida--;
                }
                else
                {
                    comida--;
                }
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1X.Text);
            int y = Convert.ToInt32(textBox2Y.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);
            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            if (ataque == 0 && !auxiliar)
            {
                ataque += 5;
                auxiliar = false;
                label7.Text = "" + ataque;
            }
            if (ataque <= 0)
            {
                if (ContFlour == 0)
                {
                    if (aa.Quantidade > 0)
                    {

                        aa.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, aa);
                        label8.Text = "" + aa;
                    }
                    else if (s1.Quantidade > 0)
                    {
                        s1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s1);
                    }
                    else if (a1.Quantidade > 0)
                    {
                        a1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a1);
                    }
                    else if (s2.Quantidade > 0)
                    {
                        s2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s2);
                    }
                    else if (a2.Quantidade > 0)
                    {
                        a2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a2);
                    }
                    else if (s3.Quantidade > 0)
                    {
                        s3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s3);
                    }
                    else if (d1.Quantidade > 0)
                    {
                        d1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d1);
                    }
                    else if (s4.Quantidade > 0)
                    {
                        s4.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s4);
                    }
                    else if (d2.Quantidade > 0)
                    {
                        d2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d2);
                    }
                    else if (s5.Quantidade > 0)
                    {
                        s5.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s5);
                    }
                    else if (a3.Quantidade > 0)
                    {
                        a3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a3);
                    }
                    else if (s6.Quantidade > 0)
                    {
                        s6.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s6);
                    }
                    else if (a4.Quantidade > 0)
                    {
                        a4.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a4);
                    }
                    else if (s7.Quantidade > 0)
                    {
                        s7.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s7);
                    }
                    else if (d3.Quantidade > 0)
                    {
                        d3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d3);
                    }
                    else if (w1.Quantidade > 0)
                    {
                        w1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w1);
                    }
                    else if (d4.Quantidade > 0)
                    {
                        d4.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d4);
                    }
                    else if (w2.Quantidade > 0)
                    {
                        w2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w2);
                    }
                    else if (d5.Quantidade > 0)
                    {
                        d5.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d5);
                    }
                    else if (w3.Quantidade > 0)
                    {
                        w3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w3);
                    }
                    else if (s8.Quantidade > 0)
                    {
                        s8.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s8);
                    }
                    else if (a5.Quantidade > 0)
                    {
                        a5.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a5);
                    }
                    else if (s9.Quantidade > 0)
                    {
                        s9.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s9);
                    }
                    else if (a6.Quantidade > 0)
                    {
                        a6.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a6);
                    }
                    else if (s10.Quantidade > 0)
                    {
                        s10.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s10);
                    }
                    else if (a7.Quantidade > 0)
                    {
                        a7.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a7);
                    }
                    else if (w4.Quantidade > 0)
                    {
                        w4.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w4);
                    }
                    else if (d6.Quantidade > 0)
                    {
                        d6.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d6);
                    }
                    else if (w5.Quantidade > 0)
                    {
                        w5.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w5);
                    }
                    else if (a8.Quantidade > 0)
                    {
                        a8.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a8);
                    }
                    else if (w6.Quantidade > 0)
                    {
                        w6.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w6);
                    }
                    else if (a9.Quantidade > 0)
                    {
                        a9.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a9);
                    }
                    else if (w7.Quantidade > 0)
                    {
                        w7.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w7);
                    }
                    else if (d7.Quantidade > 0)
                    {
                        d7.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d7);
                    }
                    else if (w8.Quantidade > 0)
                    {
                        w8.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w8);
                    }
                    else if (d8.Quantidade > 0)
                    {
                        d8.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d8);
                    }
                    else if (w9.Quantidade > 0)
                    {
                        w9.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w9);
                    }

                    else if (comercomer.Quantidade > 0)
                    {
                        comercomer.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, comercomer);
                    }
                }
                if (w9.Quantidade == 0)
                {
                    comida = 10;
                    s1.Quantidade = 9;
                    a1.Quantidade = 4;
                    s2.Quantidade = 20;
                    a2.Quantidade = 1;
                    s3.Quantidade = 7;
                    d1.Quantidade = 3;
                    s4.Quantidade = 14;
                    d2.Quantidade = 3;
                    s5.Quantidade = 9;
                    a3.Quantidade = 4;
                    s6.Quantidade = 8;
                    a4.Quantidade = 1;
                    s7.Quantidade = 14;
                    d3.Quantidade = 19;
                    w1.Quantidade = 8;
                    d4.Quantidade = 6;
                    w2.Quantidade = 5;
                    d5.Quantidade = 5;

                    ////

                    a5.Quantidade = 5;
                    s9.Quantidade = 5;
                    a6.Quantidade = 6;
                    s10.Quantidade = 8;
                    a7.Quantidade = 19;
                    w4.Quantidade = 22;
                    d6.Quantidade = 5;
                    w5.Quantidade = 9;
                    a8.Quantidade = 5;
                    w6.Quantidade = 15;
                    a9.Quantidade = 1;
                    w7.Quantidade = 8;
                    d7.Quantidade = 1;
                    w8.Quantidade = 17;
                    d8.Quantidade = 3;
                    w9.Quantidade = 10;




                }






            }
            else if (ataque <= 5 && !verificacaoAtaaque(Target) && !verificacaoPixel(Target, Target2) && !auxiliar)
            {
                Point pontoChave = new Point(964, 521);
                Console.WriteLine(GetPixel(pontoChave));
                Color target = GetPixel(pontoChave);
                pictureBox2.BackColor = target;

                label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);

                mouse_event(MOUSEEVENTF_RIGHTDOWN, 312, 300, 0, 0);//make left button down
                mouse_event(MOUSEEVENTF_RIGHTUP, 312, 300, 0, 0);//make left button up

                label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);
                ataque += 3;
                auxiliar = true;





            }
            else if (!verificacaoAtaaque(Target) && !verificacaoPixelSeForIguale(Target, Target2))
            {

                if (ataque < 5)
                {

                    SendKeys.Send(" ");
                    ataque += 5;
                    label7.Text = "atacando" + ataque;
                    auxiliar = false;
                }
                else if (ataque == 1 && !auxiliar)
                {
                    label7.Text = "atacando" + ataque;
                    ataque += 5;
                    auxiliar = false;
                }
                if (!verificacaoAtaaque(Target) && verificacaoPixelSeForIguale(Target, Target2) && !auxiliar)
                {

                    ataque += 5;
                    auxiliar = false;
                }



            }
            else
            {
                {
                    label7.Text = "atacando" + ataque;
                    ataque--;
                }
            }

            label7.Text = "atacando" + ataque;
            if (comida < 10)
            {

                SendKeys.Send("{F5}");
                label7.Text = "atacando" + ataque + "{F5}";
                if (comida % 2 == 0)
                {
                    SendKeys.Send("{F3}");
                }
                if (comida == 1)
                {

                    comida = 200;
                }
                comida--;
            }
            else
            {
                comida--;
            }
        }

        private void timerIniciante_Tick(object sender, EventArgs e)
        {

            int x = Convert.ToInt32(textBox1X.Text);
            int y = Convert.ToInt32(textBox2Y.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);
            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            if (ataque == 0 && !auxiliar)
            {
                ataque += 5;
                auxiliar = false;
                label7.Text = "" + ataque;
            }
            if (ataque <= 0)
            {
                if (ContFlour == 0)
                {
                    if (aa.Quantidade > 0)
                    {

                        aa.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, aa);
                        label8.Text = "" + aa;
                    }

                }






            }
            else if (ataque <= 5 && !verificacaoAtaaque(Target) && !verificacaoPixel(Target, Target2) && !auxiliar)
            {
                Point pontoChave = new Point(964, 521);
                Console.WriteLine(GetPixel(pontoChave));
                Color target = GetPixel(pontoChave);
                pictureBox2.BackColor = target;

                label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);

                mouse_event(MOUSEEVENTF_RIGHTDOWN, 312, 300, 0, 0);//make left button down
                mouse_event(MOUSEEVENTF_RIGHTUP, 312, 300, 0, 0);//make left button up

                label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);
                ataque += 3;
                auxiliar = true;





            }
            else if (!verificacaoAtaaque(Target) && !verificacaoPixelSeForIguale(Target, Target2))
            {

                if (ataque < 5)
                {

                    SendKeys.Send(" ");
                    ataque += 5;
                    label7.Text = "atacando" + ataque;
                    auxiliar = false;
                }
                else if (ataque == 1 && !auxiliar)
                {
                    label7.Text = "atacando" + ataque;
                    ataque += 5;
                    auxiliar = false;
                }
                if (!verificacaoAtaaque(Target) && verificacaoPixelSeForIguale(Target, Target2) && !auxiliar)
                {

                    ataque += 5;
                    auxiliar = false;
                }



            }
            else
            {
                {
                    label7.Text = "atacando" + ataque;
                    ataque--;
                }
            }

            label7.Text = "atacando" + ataque;
            if (comida < 0)
            {

                SendKeys.Send("{F5}");
                SendKeys.Send("{F3}");

                comida = 400;

            }
            else
            {
                comida--;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendKeys.Send("{F4}");


            Cursor.Position = new Point(280, 333);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 312, 300, 0, 0);//make left button down
            mouse_event(MOUSEEVENTF_LEFTUP, 312, 300, 0, 0);//make left button up
            Cursor.Position = new Point(597, 287);
            timer1.Enabled = false;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1X.Text);
            int y = Convert.ToInt32(textBox2Y.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);

            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            if (ataque <= 0)
            {
                try
                {
                    if (list[0].Quantidade > 0)
                    {

                        list[0].Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, list[0]);

                    }
                    else
                    {
                        list.RemoveAt(0);
                    }
                }
                catch
                {
                    comercomer.Quantidade = 5;
                    s1.Quantidade = 11;
                    w1.Quantidade = 7;
                    a1.Quantidade = 8;
                    w2.Quantidade = 4;
                    a2.Quantidade = 13;
                    w3.Quantidade = 3;
                    a3.Quantidade = 21;
                    s2.Quantidade = 5;
                    w4.Quantidade = 2;
                    a4.Quantidade = 7;
                    s3.Quantidade = 3;
                    a5.Quantidade = 21;
                    s4.Quantidade = 5;
                    w5.Quantidade = 5;
                    d1.Quantidade = 22;
                    w6.Quantidade = 2;
                    d2.Quantidade = 8;
                    w7.Quantidade = 3;
                    d3.Quantidade = 22;
                    s5.Quantidade = 5;
                    w8.Quantidade = 1;
                    d4.Quantidade = 5;
                    w9.Quantidade = 1;
                    d5.Quantidade = 6;
                    s6.Quantidade = 4;
                    d6.Quantidade = 21;
                    a6.Quantidade = 13;
                    w10.Quantidade = 2;
                    //------------

                    list.Add(s1);
                    list.Add(w1);
                    list.Add(a1);
                    list.Add(w2);
                    list.Add(a2);
                    list.Add(w3);
                    list.Add(a3);
                    list.Add(s2);
                    list.Add(w4);
                    list.Add(a4);
                    list.Add(s3);
                    list.Add(a5);
                    list.Add(s4);
                    list.Add(w5);
                    list.Add(d1);
                    list.Add(w6);
                    list.Add(d2);
                    list.Add(w7);
                    list.Add(d3);
                    list.Add(s5);
                    list.Add(w8);
                    list.Add(d4);
                    list.Add(w9);
                    list.Add(d5);
                    list.Add(s6);
                    list.Add(d6);
                    list.Add(a6);
                    list.Add(w10);

                }









            }
            else if (!verificacaoAtaaque(Target) && !verificacaoPixelSeForIguale(Target, Target2))
            {

                if (ataque < 2)
                {

                    SendKeys.Send(" ");
                    ataque += 2;
                    label7.Text = "atacando" + ataque;
                    auxiliar = false;
                }
                else if (ataque == 1 && !auxiliar)
                {
                    label7.Text = "atacando" + ataque;
                    ataque += 2;
                    auxiliar = false;
                }
                if (!verificacaoAtaaque(Target) && verificacaoPixelSeForIguale(Target, Target2) && !auxiliar)
                {

                    ataque += 2;
                    auxiliar = false;
                }



            }
            else
            {
                {
                    label7.Text = "atacando" + ataque;
                    ataque--;
                }
            }

            label7.Text = "atacando" + ataque;
            if (comida < 10)
            {

                SendKeys.Send("{F5}");
                label7.Text = "atacando" + ataque + "{F5}";
                if (comida % 2 == 0)
                {
                    SendKeys.Send("{F3}");
                }
                if (comida == 1)
                {

                    comida = 200;
                }
                comida--;
            }
            else
            {
                comida--;
            }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {

            int x = Convert.ToInt32(textBox1X.Text);
            int y = Convert.ToInt32(textBox2Y.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);
            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            if (ataque == 0 && !auxiliar)
            {
                ataque += 5;
                auxiliar = false;
                label7.Text = "" + ataque;
            }
            if (ataque <= 0)
            {

                try
                {
                    if (list[0].Quantidade > 0)
                    {

                        list[0].Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, list[0]);

                    }
                    else
                    {
                        list.RemoveAt(0);
                    }
                }
                catch
                {
                    s1.Quantidade = 11;
                    w1.Quantidade = 7;
                    a1.Quantidade = 8;
                    w2.Quantidade = 4;
                    a2.Quantidade = 13;
                    w3.Quantidade = 3;
                    a3.Quantidade = 21;
                    s2.Quantidade = 5;
                    w4.Quantidade = 2;
                    a4.Quantidade = 7;
                    s3.Quantidade = 3;
                    a5.Quantidade = 21;
                    s4.Quantidade = 5;
                    w5.Quantidade = 5;
                    d1.Quantidade = 22;
                    w6.Quantidade = 2;
                    d2.Quantidade = 8;
                    w7.Quantidade = 3;
                    d3.Quantidade = 22;
                    s5.Quantidade = 5;
                    w8.Quantidade = 1;
                    d4.Quantidade = 5;
                    w9.Quantidade = 1;
                    d5.Quantidade = 6;
                    s6.Quantidade = 4;
                    d6.Quantidade = 21;
                    a6.Quantidade = 13;
                    w10.Quantidade = 2;
                    //----------------

                    list.Add(s1);
                    list.Add(w1);
                    list.Add(a1);
                    list.Add(w2);
                    list.Add(a2);
                    list.Add(w3);
                    list.Add(a3);
                    list.Add(s2);
                    list.Add(w4);
                    list.Add(a4);
                    list.Add(s3);
                    list.Add(a5);
                    list.Add(s4);
                    list.Add(w5);
                    list.Add(d1);
                    list.Add(w6);
                    list.Add(d2);
                    list.Add(w7);
                    list.Add(d3);
                    list.Add(s5);
                    list.Add(w8);
                    list.Add(d4);
                    list.Add(w9);
                    list.Add(d5);
                    list.Add(s6);
                    list.Add(d6);
                    list.Add(a6);
                    list.Add(w10);

                }




            }
            else if (ataque <= 5 && !verificacaoAtaaque(Target) && !verificacaoPixel(Target, Target2) && !auxiliar)
            {
                Point pontoChave = new Point(964, 521);
                Console.WriteLine(GetPixel(pontoChave));
                Color target = GetPixel(pontoChave);
                pictureBox2.BackColor = target;

                label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);

                mouse_event(MOUSEEVENTF_RIGHTDOWN, 312, 300, 0, 0);//make left button down
                mouse_event(MOUSEEVENTF_RIGHTUP, 312, 300, 0, 0);//make left button up

                label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);
                ataque += 3;
                auxiliar = true;





            }
            else if (!verificacaoAtaaque(Target) && !verificacaoPixelSeForIguale(Target, Target2))
            {

                if (ataque < 5)
                {

                    SendKeys.Send(" ");
                    ataque += 5;
                    label7.Text = "atacando" + ataque;
                    auxiliar = false;
                }
                else if (ataque == 1 && !auxiliar)
                {
                    label7.Text = "atacando" + ataque;
                    ataque += 5;
                    auxiliar = false;
                }
                if (!verificacaoAtaaque(Target) && verificacaoPixelSeForIguale(Target, Target2) && !auxiliar)
                {

                    ataque += 5;
                    auxiliar = false;
                }



            }
            else
            {
                {
                    label7.Text = "atacando" + ataque;
                    ataque--;
                }
            }

            label7.Text = "atacando" + ataque;
            if (comida < 0)
            {

                SendKeys.Send("{F5}");
                SendKeys.Send("{F3}");

                comida = 400;

            }
            else
            {
                comida--;
            }

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (treino == 3)
            {
                Cursor.Position = new Point(475, 583);
                mouse_event(MOUSEEVENTF_RIGHTDOWN, 312, 300, 0, 0);//make left button down
                mouse_event(MOUSEEVENTF_RIGHTUP, 312, 300, 0, 0);//make left button up
            }
            else if (treino == 31)
            {


                Cursor.Position = new Point(222, 300);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 312, 300, 0, 0);//make left button down
                mouse_event(MOUSEEVENTF_LEFTUP, 312, 300, 0, 0);//make left button up
                treino = 0;
            }

        }

        private void timerColor_Tick(object sender, EventArgs e)
        {
            Point pontoChave = new Point(455, 34);
            Console.WriteLine(GetPixel(pontoChave));
            Color target = GetPixel(pontoChave);
            pictureBox2.BackColor = target;
            //corDoMOuse = pictureBox1.PointToClient(Cursor.Position);
            //Bitmap bmp = (Bitmap)pictureBox1.Image;

            //Color c = new Color();
            ////= bmp.GetPixel(corDoMOuse.X, corDoMOuse.Y);
            //if (c == target)
            //{
            //    bmp.SetPixel(corDoMOuse.X, corDoMOuse.Y, Color.Red); button2.BackColor = Color.FromArgb(100, 250, 0, 100);


            //}
            //else MessageBox.Show("Click only on white spots! You have hit " + c.ToString(),
            //                     "Wrong spot! ");
        }

        private void timerMapa_Tick(object sender, EventArgs e)
        {

            int x = Convert.ToInt32(textBox1X.Text);
            int y = Convert.ToInt32(textBox2Y.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);
            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            if (ataque == 0 && !auxiliar)
            {
                ataque += 5;
                auxiliar = false;
                label7.Text = "" + ataque;
            }
            if (ataque <= 0)
            {
                if (ContFlour == 0)
                {
                    try
                    {
                        if (list[0].Quantidade > 0)
                        {

                            list[0].Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, list[0]);

                        }
                        else
                        {
                            list.RemoveAt(0);
                        }
                    }
                    catch
                    {
                        aa.Quantidade = 3;
                        s1.Quantidade = 4;
                        d1.Quantidade = 3;
                        s2.Quantidade = 6;
                        d2.Quantidade = 8;
                        s3.Quantidade = 1;
                        d3.Quantidade = 8;
                        s4.Quantidade = 13;
                        a1.Quantidade = 14;
                        w1.Quantidade = 14;
                        a2.Quantidade = 3;
                        w2.Quantidade = 10;
                        a3.Quantidade = 2;
                        w5.Quantidade = 1;
                        comercomer.Quantidade = 5;
                        //----------------

                        list.Add(aa);
                        list.Add(s1);
                        list.Add(d1);
                        list.Add(s2);
                        list.Add(d2);
                        list.Add(s3);
                        list.Add(d3);
                        list.Add(s4);
                        list.Add(a1);
                        list.Add(w1);
                        list.Add(a2);
                        list.Add(w2);
                        list.Add(a3);
                        list.Add(w5);
                        list.Add(comercomer);

                        if (subir == 15)
                        {
                            timer1.Enabled = true;
                            ContFlour++;
                            w5.Quantidade--;
                            asair = 0;
                        }
                        else if (subir > 0)
                        {
                            label8.Text = "" + subir;
                            subir--;
                        }
                        else
                        {
                            a3.Quantidade--;
                            asair = 0;
                        }

                    }
                }

                else if (ContFlour == 1)
                {
                    try
                    {
                        if (list[0].Quantidade > 0)
                        {

                            list[0].Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, list[0]);

                        }
                        else
                        {
                            list.RemoveAt(0);
                        }
                    }
                    catch
                    {

                        aa.Quantidade = 3;
                        s1.Quantidade = 1;
                        a1.Quantidade = 2;
                        s2.Quantidade = 3;
                        a2.Quantidade = 2;
                        s3.Quantidade = 3;
                        a3.Quantidade = 2;
                        s4.Quantidade = 6;
                        a4.Quantidade = 3;
                        s5.Quantidade = 4;
                        a5.Quantidade = 5;
                        w1.Quantidade = 4;
                        s6.Quantidade = 4;
                        d1.Quantidade = 5;
                        w2.Quantidade = 8;
                        d2.Quantidade = 4;
                        w3.Quantidade = 3;
                        d6.Quantidade = 5;
                        a6.Quantidade = 1;
                        w6.Quantidade = 6;
                        d4.Quantidade = 2;
                        w5.Quantidade = 1;
                        asair = 1;
                        comercomer.Quantidade = 5;

                        //------------------------------

                        list.Add(aa);
                        list.Add(s1);
                        list.Add(a1);
                        list.Add(s2);
                        list.Add(a2);
                        list.Add(s3);
                        list.Add(a3);
                        list.Add(s4);
                        list.Add(a4);
                        list.Add(s5);
                        list.Add(a5);
                        list.Add(w1);
                        list.Add(s6);
                        list.Add(d1);
                        list.Add(w2);
                        list.Add(d2);
                        list.Add(w3);
                        list.Add(d6);
                        list.Add(a6);
                        list.Add(w6);
                        list.Add(d4);
                        list.Add(w5);
                        asair = 1;
                        list.Add(comercomer);

                        ContFlour--;
                        asair = 1;

                    }
                }


            }






            else if (ataque <= 5 && !verificacaoAtaaque(Target) && !verificacaoPixel(Target, Target2) && !auxiliar)
            {
                Point pontoChave = new Point(964, 521);
                Console.WriteLine(GetPixel(pontoChave));
                Color target = GetPixel(pontoChave);
                pictureBox2.BackColor = target;

                label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);

                mouse_event(MOUSEEVENTF_RIGHTDOWN, 312, 300, 0, 0);//make left button down
                mouse_event(MOUSEEVENTF_RIGHTUP, 312, 300, 0, 0);//make left button up

                label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);
                ataque += 3;
                auxiliar = true;





            }
            else if (!verificacaoAtaaque(Target) && !verificacaoPixelSeForIguale(Target, Target2))
            {

                if (ataque < 5)
                {

                    SendKeys.Send(" ");
                    ataque += 5;
                    label7.Text = "atacando" + ataque;
                    auxiliar = false;
                }
                else if (ataque == 1 && !auxiliar)
                {
                    label7.Text = "atacando" + ataque;
                    ataque += 5;
                    auxiliar = false;
                }
                if (!verificacaoAtaaque(Target) && verificacaoPixelSeForIguale(Target, Target2) && !auxiliar)
                {

                    ataque += 5;
                    auxiliar = false;
                }



            }
            else
            {
                {
                    label7.Text = "atacando" + ataque;
                    ataque--;
                }
            }

            label7.Text = "atacando" + ataque;
            if (comida < 0)
            {

                SendKeys.Send("{F5}");
                SendKeys.Send("{F3}");

                comida = 400;

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


        private void timer5_Tick(object sender, EventArgs e)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, 956, 476, 0, 0);//make left button down
            mouse_event(MOUSEEVENTF_RIGHTUP, 956, 476, 0, 0);//make left button up
        }

        private void timer2_Tick_3(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1X.Text);
            int y = Convert.ToInt32(textBox2Y.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);
            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            if (ataque == 8 && !verificacaoAtaaque(Target))
            {
                SendKeys.Send(" ");
            }
            if (ataque == 0 && !auxiliar)
            {
                SendKeys.Send(" ");
                ataque += 5;
                auxiliar = false;
                label7.Text = "" + ataque;
            }
            if (ataque <= 0)
            {
                if (ContFlour == 0)
                {
                    if (aa.Quantidade > 0)
                    {

                        aa.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, aa);
                        label8.Text = "" + aa;
                    }
                    else if (s1.Quantidade > 0)
                    {
                        s1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s1);
                    }
                    else if (d1.Quantidade > 0)
                    {
                        d1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d1);
                    }
                    else if (s2.Quantidade > 0)
                    {
                        s2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s2);
                    }
                    else if (d2.Quantidade > 0)
                    {
                        d2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d2);
                    }
                    else if (s3.Quantidade > 0)
                    {
                        s3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s3);
                    }
                    else if (a1.Quantidade > 0)
                    {
                        a1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a1);
                    }
                    else if (s4.Quantidade > 0)
                    {
                        s4.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s4);
                    }
                    else if (d3.Quantidade > 0)
                    {
                        d3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d3);
                    }
                    else if (s5.Quantidade > 0)
                    {
                        s5.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s5);
                    }
                    else if (w1.Quantidade > 0)
                    {
                        w1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w1);
                    }
                    else if (a2.Quantidade > 0)
                    {
                        a2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a2);
                    }
                    else if (w2.Quantidade > 0)
                    {
                        w2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w2);
                    }
                    else if (d4.Quantidade > 0)
                    {
                        d4.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d4);
                    }
                    else if (s6.Quantidade > 0)
                    {
                        s6.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s6);
                    }
                    else if (d5.Quantidade > 0)
                    {
                        d5.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d5);
                    }
                    else if (s7.Quantidade > 0)
                    {
                        s7.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s7);
                    }
                    else if (d6.Quantidade > 0)
                    {
                        d6.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d6);
                    }
                    else if (s8.Quantidade > 0)
                    {
                        s8.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s8);
                    }
                    else if (d7.Quantidade > 0)
                    {
                        d7.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d7);
                    }
                    else if (s9.Quantidade > 0)
                    {
                        s9.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s9);
                    }
                    else if (d8.Quantidade > 0)
                    {
                        d8.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d8);
                    }
                    else if (s10.Quantidade > 0)
                    {
                        s10.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s10);
                    }
                    else if (w3.Quantidade > 0)
                    {
                        w3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w3);
                    }
                    else if (d9.Quantidade > 0)
                    {
                        d9.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d9);
                    }
                    else if (a3.Quantidade > 0)
                    {
                        a3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a3);
                    }
                    else if (q1.Quantidade > 0)
                    {
                        q1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, q1);
                        timer2.Interval = 1500;
                    }
                    else if (w4.Quantidade > 0)
                    {
                        timer2.Interval = 550;
                        w4.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w4);
                    }
                    else if (a4.Quantidade > 0)
                    {
                        a4.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a4);
                    }
                    else if (w5.Quantidade > 0)
                    {
                        w5.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w5);
                    }
                    else if (a5.Quantidade > 0)
                    {
                        a5.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a5);
                    }


                    else if (comercomer.Quantidade > 0)
                    {
                        comercomer.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, comercomer);
                    }
                }
                if (a5.Quantidade == 0)
                {
                    comida = 10;
                    s1.Quantidade = 4;
                    d1.Quantidade = 5;
                    s2.Quantidade = 2;
                    d2.Quantidade = 3;
                    s3.Quantidade = 5;
                    a1.Quantidade = 4;
                    s4.Quantidade = 15;
                    d3.Quantidade = 1;
                    s5.Quantidade = 12;
                    w1.Quantidade = 14;
                    a2.Quantidade = 1;
                    w2.Quantidade = 12;
                    d4.Quantidade = 8;
                    s6.Quantidade = 4;
                    d5.Quantidade = 4;
                    s7.Quantidade = 3;
                    d6.Quantidade = 2;
                    s8.Quantidade = 2;
                    d7.Quantidade = 4;
                    s9.Quantidade = 3;
                    d8.Quantidade = 13;
                    s10.Quantidade = 6;
                    w3.Quantidade = 7;
                    d9.Quantidade = 15;
                    //----- volta
                    a3.Quantidade = 29;
                    q1.Quantidade = 13;
                    w4.Quantidade = 3;
                    a4.Quantidade = 4;
                    w5.Quantidade = 5;
                    a5.Quantidade = 1;






                }






            }
            else if (ataque <= 5 && !verificacaoAtaaque(Target) && !verificacaoPixel(Target, Target2) && !auxiliar)
            {
                Point pontoChave = new Point(964, 521);
                Console.WriteLine(GetPixel(pontoChave));
                Color target = GetPixel(pontoChave);
                pictureBox2.BackColor = target;

                label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);

                mouse_event(MOUSEEVENTF_RIGHTDOWN, 312, 300, 0, 0);//make left button down
                mouse_event(MOUSEEVENTF_RIGHTUP, 312, 300, 0, 0);//make left button up

                label7.Text = "" + ataque + !verificacaoPixel(Target, Target2);
                ataque += 1;
                auxiliar = true;





            }
            else if (!verificacaoAtaaque(Target) && !verificacaoPixelSeForIguale(Target, Target2))
            {

                if (ataque < 5)
                {

                    SendKeys.Send(" ");
                    ataque += 4;
                    label7.Text = "atacando" + ataque;
                    auxiliar = false;
                }
                //else if (ataque == 1 && !auxiliar)
                //{
                //    SendKeys.Send(" ");
                //    label7.Text = "atacando" + ataque;
                //    ataque += 4;
                //    auxiliar = false;
                //}
                //if (!verificacaoAtaaque(Target) && verificacaoPixelSeForIguale(Target, Target2) && !auxiliar)
                //{

                //    ataque += 4;
                //    auxiliar = false;
                //}



            }
            else
            {
                {
                    label7.Text = "atacando" + ataque;
                    ataque--;
                }
            }


            if (comida < 10)
            {

                SendKeys.Send("{F5}");

                if (comida % 2 == 0)
                {
                    SendKeys.Send("{F3}");
                }
                if (comida == 1)
                {

                    comida = 200;
                }
                comida--;
            }
            else
            {
                comida--;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            timerAutopotion.Enabled = true;
            timer2.Enabled = true;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            timerColor.Enabled = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            timerMinotauro.Enabled = true;
            timerAutopotion.Enabled = true;
        }

        private void timer6_Tick_1(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1X.Text);
            int y = Convert.ToInt32(textBox2Y.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);

            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            if (ataque <= 0)
            {

                if (aa.Quantidade > 0)
                {

                    aa.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, aa);

                }
                else if (comercomer.Quantidade > 0)
                {
                    comercomer.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, comercomer);
                }
                else if (s1.Quantidade > 0)
                {
                    s1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s1);

                }
                else if (d1.Quantidade > 0)
                {
                    d1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d1);

                }
                else if (w1.Quantidade > 0)
                {
                    w1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w1);

                }
                else if (d2.Quantidade > 0)
                {
                    d2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d2);

                }
                else if (w2.Quantidade > 0)
                {
                    w2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w2);

                }
                else if (s2.Quantidade > 0)
                {
                    s2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s2);

                }
                else if (a1.Quantidade > 0)
                {
                    a1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a1);

                }
                else if (d3.Quantidade > 0)
                {
                    d3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d3);

                }
                else if (w3.Quantidade > 0)
                {
                    w3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w3);

                }
                else if (a2.Quantidade > 0)
                {
                    a2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a2);

                }
                else if (s3.Quantidade > 0)
                {
                    s3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s3);

                }
                else if (a3.Quantidade > 0)
                {
                    a3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a3);

                }
                else if (s4.Quantidade > 0)
                {
                    s4.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s4);

                }


                if (s4.Quantidade == 0)
                {
                    // caverna 1 dos anões
                    comercomer.Quantidade = 5;
                    s1.Quantidade = 1;
                    d1.Quantidade = 2;
                    w1.Quantidade = 1;
                    d2.Quantidade = 4;
                    w2.Quantidade = 4;
                    s2.Quantidade = 2;
                    a1.Quantidade = 9;
                    d3.Quantidade = 9;
                    w3.Quantidade = 3;
                    a2.Quantidade = 1;
                    s3.Quantidade = 4;
                    a3.Quantidade = 5;
                    s4.Quantidade = 1;




                }





            }
            else if (!verificacaoAtaaque(Target) && !verificacaoPixelSeForIguale(Target, Target2))
            {

                if (ataque < 2)
                {

                    SendKeys.Send(" ");
                    ataque += 2;
                    label7.Text = "atacando" + ataque;
                    auxiliar = false;
                }
                else if (ataque == 1 && !auxiliar)
                {
                    label7.Text = "atacando" + ataque;
                    ataque += 2;
                    auxiliar = false;
                }
                if (!verificacaoAtaaque(Target) && verificacaoPixelSeForIguale(Target, Target2) && !auxiliar)
                {

                    ataque += 2;
                    auxiliar = false;
                }



            }
            else
            {
                {
                    label7.Text = "atacando" + ataque;
                    ataque--;
                }
            }

            label7.Text = "atacando" + ataque;
            if (comida < 10)
            {

                SendKeys.Send("{F5}");
                label7.Text = "atacando" + ataque + "{F5}";
                if (comida % 2 == 0)
                {

                }
                if (comida == 1)
                {

                    comida = 200;
                }
                comida--;
            }
            else
            {
                comida--;
            }

        }

        private void timer7_Tick(object sender, EventArgs e)
        {

        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(textBox1X.Text);
            int y = Convert.ToInt32(textBox2Y.Text);
            Point PontoChave = new Point(x, y);
            Color Target = GetPixel(PontoChave);

            //ponto 2
            int x2 = Convert.ToInt32(textBoxPonto2X.Text);
            int y2 = Convert.ToInt32(textBoxPonto2Y.Text);
            Point PontoChave2 = new Point(x2, y2);
            Color Target2 = GetPixel(PontoChave2);
            if (ataque <= 0)
            {

                if (aa.Quantidade > 0)
                {

                    aa.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, aa);

                }
                else if (comercomer.Quantidade > 0)
                {
                    comercomer.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, comercomer);
                }
                else if (w1.Quantidade > 0)
                {
                    w1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w1);


                }
                else if (a1.Quantidade > 0)
                {
                    a1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a1);

                }
                else if (w2.Quantidade > 0)
                {
                    w2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w2);

                }
                else if (a2.Quantidade > 0)
                {
                    a2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a2);

                }
                else if (w3.Quantidade > 0)
                {
                    w3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w3);

                }
                else if (a3.Quantidade > 0)
                {
                    a3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, a3);

                }
                else if (s1.Quantidade > 0)
                {
                    s1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s1);

                }
                else if (w4.Quantidade > 0)
                {
                    w4.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, w4);

                }
                else if (d1.Quantidade > 0)
                {
                    d1.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d1);

                }
                else if (s2.Quantidade > 0)
                {
                    s2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s2);

                }
                else if (d2.Quantidade > 0)
                {
                    d2.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d2);

                }
                else if (s3.Quantidade > 0)
                {
                    s3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s3);

                }
                else if (d3.Quantidade > 0)
                {
                    d3.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, d3);

                }
                else if (s4.Quantidade > 0)
                {
                    s4.Quantidade = VerificacaoDePixel(Target, Target2, PontoChave, s4);

                }


                if (s4.Quantidade == 0)
                {
                    // caverna 1 dos anões
                    comercomer.Quantidade = 5;
                    aa.Quantidade = 4;

                    w1.Quantidade = 6;
                    a1.Quantidade = 18;
                    w2.Quantidade = 4;
                    a2.Quantidade = 6;
                    w3.Quantidade = 1;
                    a3.Quantidade = 5;
                    s1.Quantidade = 5;
                    //------ volta
                    w4.Quantidade = 5;
                    d1.Quantidade = 5;
                    s2.Quantidade = 1;
                    d2.Quantidade = 6;
                    s3.Quantidade = 4;
                    d3.Quantidade = 18;
                    s4.Quantidade = 6;





                }





            }
            else if (!verificacaoAtaaque(Target) && !verificacaoPixelSeForIguale(Target, Target2))
            {

                if (ataque < 2)
                {

                    SendKeys.Send(" ");
                    ataque += 2;
                    label7.Text = "atacando" + ataque;
                    auxiliar = false;
                }
                else if (ataque == 1 && !auxiliar)
                {
                    label7.Text = "atacando" + ataque;
                    ataque += 2;
                    auxiliar = false;
                }
                if (!verificacaoAtaaque(Target) && verificacaoPixelSeForIguale(Target, Target2) && !auxiliar)
                {

                    ataque += 2;
                    auxiliar = false;
                }



            }
            else
            {
                {
                    label7.Text = "atacando" + ataque;
                    ataque--;
                }
            }

            label7.Text = "atacando" + ataque;
            if (comida < 10)
            {

                SendKeys.Send("{F5}");
                label7.Text = "atacando" + ataque + "{F5}";
                if (comida % 2 == 0)
                {

                }
                if (comida == 1)
                {

                    comida = 200;
                }
                comida--;
            }
            else
            {
                comida--;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            timerAutopotion.Enabled = true;
            timerTarantola.Enabled = true;
        }
    }
}
