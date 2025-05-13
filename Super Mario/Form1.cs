using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Mario
{
    public class CActor
    {
        public int x, y, w, h, s;
        public Bitmap im;
    }
    public class move
    {
        public int x, y, w, h, o, d, j, state;
        public List<Bitmap> im;
    }
    public class background
    {
        public Rectangle rcs, rcd;
        public Bitmap im;
    }
    public partial class Form1 : Form
    {
        public int x, y, w, h, j, r, l, mark = 2, mark2, mario = 3, countTick, coins, f1, f2, f3, f4,start,xz,yz,move=11,s=15,win;
        public Bitmap b, simage;
        Timer tt = new Timer();
        move m = new move();
        CActor machrom = new CActor();
        CActor castle = new CActor();
        List<CActor> ground = new List<CActor>();
        List<background> background = new List<background>();
        List<CActor> L = new List<CActor>();
        List<CActor> L2 = new List<CActor>();
        List<move> p = new List<move>();
        List<move> c = new List<move>();
        List<CActor> bullets = new List<CActor>();
        public Form1()
        {
            this.Size = new Size(1366, 768);
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.Load += new EventHandler(Form1_Load);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);
            this.MouseMove += new MouseEventHandler(Form1_MouseMove);
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            tt.Tick += new EventHandler(tt_Tick);
            tt.Start();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X >= this.Width / 2 -200 && e.X <= this.Width / 2 -200 + simage.Width && e.Y >= this.Height / 2 && e.Y <= this.Height / 2 + simage.Height && start == 0)
            {
                simage = new Bitmap(@"30.PNG");
            }
            else
                simage = new Bitmap(@"29.PNG");

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X >= this.Width / 2 -200 && e.X <= this.Width / 2-200 + simage.Width && e.Y >= this.Height / 2 && e.Y <= this.Height / 2 + simage.Height && start == 0)
            {
                start = 1;
            }
        }

        private void tt_Tick(object sender, EventArgs e)
        {
            if (m.j == 1)
            {
                m.y -= 55;
                for (int i = 0; i < L.Count(); i++)
                {
                    if (m.y <= L[i].y && m.y >= L[i].y && m.x + m.w > L[i].x && m.x < L[i].x + L[i].w)
                    {
                        m.j = 0;
                        m.d = 1;
                    }
                    if (m.y < j - 250)
                    {
                        m.j = 0;
                        m.d = 1;
                    }
                }
            }
            if (m.d == 1)
            {
                m.y += 55;
                if (m.y + m.h >= this.Height - 100)
                {
                    m.d = 0;
                    m.y = this.Height - 100 - m.h;
                    mark = 2;
                }
            }
            for (int i = 0; i < L.Count(); i++)
            {
                if (m.x + m.w > L[i].x && m.x < L[i].x + L[i].w && m.y < L[i].y && m.y + m.h >= L[i].y)
                {
                    m.y = L[i].y - 70;
                    m.d = 1;
                    mark = 2;
                }
            }
            for (int i = 0; i < L.Count(); i++)
            {
                if (m.x + m.w + 5 >= L[i].x && m.x + m.w <= L[i].x + L[i].w && m.y + (m.h / 2) > L[i].y && m.y + (m.h / 2) < L[i].y + L[i].h)
                {
                    r = 0;
                    m.x = L[i].x - m.w;
                }
                else if (m.x - 20 <= L[i].x + L[i].w && m.x >= L[i].x && m.y + (m.h / 2) > L[i].y && m.y + (m.h / 2) < L[i].y + L[i].h)
                {
                    l = 0;
                    m.x = L[i].x + L[i].w;
                }
            }
            if (mark2 == 0 && m.state == 0)
            {
                if (r == 1)
                {
                    m.x += s;
                    mr();
                    m.o++;
                    if (m.o > 1)
                        m.o = 0;
                }
                if (l == 1)
                {
                    if (m.o == 0 || m.o == 1)
                        m.o = 2;
                    m.x -= s;                   
                    ml();
                    m.o++;
                    if (m.o > 3)
                        m.o = 2;
                }
            }
            if (mark2 == 0 && m.state == 1)
            {
                if (r == 1)
                {
                    if (m.o <= 4)
                        m.o = 5;
                    m.x += s;
                    mr();
                    m.o++;
                    if (m.o > 6)
                        m.o = 5;
                }
                if (l == 1)
                {
                    if (m.o == 5 || m.o == 6 || m.o < 4)
                        m.o = 7;
                    m.x -= s;
                    ml();
                    m.o++;
                    if (m.o > 8)
                        m.o = 7;
                }
            }
            if (L[2].s == 0)
            {
                L[2].x += 11;
            }
            else
            {
                L[2].x -= 11;
            }
            if (m.x + 25 > L[2].x && m.x + m.w < L[2].x + L[2].w && m.y + m.h >= L[2].y && m.y < L[2].y && m.y + m.h >= L[2].y && L[2].s == 0)
            {
                mr();
            }
            else if (m.x > L[2].x && m.x < L[2].x + L[2].w && m.y + m.h >= L[2].y && m.y < L[2].y && m.y + m.h >= L[2].y && L[2].s == 1)
            {
                ml();
            }
            if (L[2].x + L[2].w >= ground[14].x - 30)
                L[2].s = 1;
            else if (L[2].x <= ground[1].x + ground[1].w)
                L[2].s = 0;

            if (p[0].d == 0)
            {
                if (p[0].o == 2 || p[0].o == 3)
                    p[0].o = 0;
                p[0].x += 10;
                p[0].o++;
                if (p[0].o > 1)
                    p[0].o = 0;
                for (int j = 0; j < L.Count(); j++)
                {
                    if (p[0].x + p[0].w + 5 >= L[j].x && p[0].x + p[0].w <= L[j].x + L[j].w && p[0].y >= L[j].y && p[0].y <= L[j].y + L[j].h)
                        p[0].d = 1;
                }
            }
            else if (p[0].d == 1)
            {
                if (p[0].o == 0 || p[0].o == 1)
                    p[0].o = 2;
                p[0].x -= 10;
                p[0].o++;
                if (p[0].o > 3)
                    p[0].o = 2;
                for (int j = 0; j < L.Count(); j++)
                {
                    if (p[0].x <= L[j].x + L[j].w && p[0].x >= L[j].x && p[0].y > L[j].y && p[0].y < L[j].y + L[j].h)
                        p[0].d = 0;
                }
            }
            else if (p[0].d == 2)
            {
                p[0].w = 30;
                p[0].h = 30;
                p[0].o = 4;
                p[0].y += 15;
            }
            if (p[1].d == 0)
            {
                if (p[1].o == 2 || p[1].o == 3)
                    p[1].o = 0;
                p[1].x += 10;
                p[1].o++;
                if (p[1].o > 1)
                    p[1].o = 0;
                if (p[1].x + p[1].w >=  ground[14].x + 600)
                    p[1].d = 1;
            }
            else if (p[1].d == 1)
            {
                if (p[1].o == 0 || p[1].o == 1)
                    p[1].o = 2;
                p[1].x -= 10;
                p[1].o++;
                if (p[1].o > 3)
                    p[1].o = 2;
                if (p[1].x <= ground[14].x)
                    p[1].d = 0;
            }
            else if (p[1].d == 2)
            {
                p[1].w = 30;
                p[1].h = 30;
                p[1].o = 4;
                p[1].y += 15;
            }
            if (p[2].d == 0)
            {
                if (p[2].o == 2 || p[2].o == 3)
                    p[2].o = 0;
                p[2].x += 10;
                p[2].o++;
                if (p[2].o > 1)
                    p[2].o = 0;
                if (p[2].x + p[2].w >= ground[14].x + 980)
                    p[2].d = 1;
            }
            else if (p[2].d == 1)
            {
                if (p[2].o == 0 || p[2].o == 1)
                    p[2].o = 2;
                p[2].x -= 10;
                p[2].o++;
                if (p[2].o > 3)
                    p[2].o = 2;
                if (p[2].x <= ground[14].x + 720)
                    p[2].d = 0;
            }
            else if (p[2].d == 2)
            {
                p[2].w = 30;
                p[2].h = 30;
                p[2].o = 4;
                p[2].y += 15;
            }
            for (int i = 0; i < p.Count(); i++)
            {
                for (int j = 0; j < bullets.Count(); j++)
                {
                    if(bullets[j].x+bullets[j].w>p[i].x && bullets[j].x<p[i].x+p[i].w && bullets[j].y+bullets[j].h>p[i].y && bullets[j].y<p[i].y+p[i].h)
                    {
                        p[i].d = 2;
                        bullets.Remove(bullets[j]);
                    }
                }
                if (m.x + m.w >= p[i].x && m.x < p[i].x + p[i].w && m.y + m.h >= p[i].y && m.y + m.h <= p[i].y + p[i].h && m.d == 1)
                {
                    p[i].d = 2;
                }
                else if (m.x + m.w >= p[i].x && m.x < p[i].x + p[i].w && m.y + (m.h / 2) >= p[i].y && m.y + m.h < p[i].y + p[i].h && m.state == 0 && p[i].d != 2)
                {
                    m.j = 2;
                }
                else if (m.x + m.w >= p[i].x && m.x < p[i].x + p[i].w && m.y + (m.h / 2) >= p[i].y && m.y + m.h < p[i].y + p[i].h && m.state == 1)
                {
                    p[i].d = 2;
                    m.state = 0;
                }

                if (p[i].y >= 2000)
                {
                    if (i == 0)
                    {
                        p[i].x = L[0].x + L[0].w;
                        p[i].y = this.Height - 98 - 80;
                        p[i].w = 60;
                        p[i].h = 80;
                        p[i].o = 0;
                        p[i].d = 0;
                    }
                    else if (i == 1)
                    {
                        p[i].x = ground[14].x ;
                        p[i].y = this.Height - 98 - 80;
                        p[i].w = 60;
                        p[i].h = 80;
                        p[i].o = 0;
                        p[i].d = 0;
                    }
                    else if(i==2)
                    {
                        p[i].x = ground[14].x + 720;
                        p[i].y = this.Height - 98 - 80;
                        p[i].w = 60;
                        p[i].h = 80;
                        p[i].o = 0;
                        p[i].d = 0;
                    }
                }
            }
            if (m.x > ground[1].x + ground[1].w && m.x + m.w < ground[14].x && m.y + m.h >= this.Height - 150)
            {
                m.j = 2;
            }
            if (m.j == 2 && m.state == 0)
            {
                m.o = 4;
                m.y += 15;
                mark2 = 1;
            }
            else if (m.j == 2 && m.state == 1)
            {
                m.o = 9;
                m.y += 15;
                mark2 = 1;
            }
            if (m.y > this.Height)
            {
                mario--;
                mark2 = 0;
                m.o = 0;
                m.j = 0;
                mark = 2;
                m.state = 0;
                if (mario == 0)
                {
                    MessageBox.Show("You Lose");
                    reload();                   
                }
                else
                {
                    int x = mario;
                    if (x < 0)
                        x = 0;
                    int y = coins;
                    int z = start;
                    reload();
                    mario = x;
                    coins = y;
                    start = z;
                }
            }
            for (int i = 0; i < c.Count(); i++)
            {
                if (c[i].x > m.x && c[i].x < m.x + 32 && c[i].y > m.y && c[i].y < m.y + m.h)
                {
                    c.Remove(c[i]);
                    coins++;
                }
            }
            if (countTick % 2 == 0)
            {
                for (int i = 0; i < c.Count(); i++)
                {
                    if (c[i].o == 3)
                        c[i].o = 0;
                    c[i].o++;
                }
            }
            if (m.y <= L[6].y + L[6].h && m.y >= L[6].y && m.x + m.w > L[6].x && m.x < L[6].x + L[6].w)
            {
                m.j = 0;
                m.d = 1;
            }
            if (m.y <= L[6].y + L[6].h && m.y >= L[6].y && m.x + m.w > L[6].x && m.x < L[6].x + L[6].w && f4 == 0)
            {
                m.j = 0;
                m.d = 1;
                f1 = 1;
                f4 = 1;
            }
            if (f1 == 1)
            {
                machrom.y -= 4;
                if (machrom.y <= L[6].y - 55)
                {
                    f1 = 0;
                    f2 = 1;
                }
            }
            if (f2 == 1)
            {
                machrom.x -= 4;
                if (machrom.x + machrom.w <= L[6].x + 5)
                {
                    f2 = 0;
                    f3 = 1;
                }
            }
            if (f3 == 1)
            {
                machrom.y += 10;
                if (machrom.y + machrom.h >= L[4].y)
                {
                    f3 = 0;
                }
            }
            if (m.x + m.w > machrom.x && m.x < machrom.x + machrom.w && machrom.y > m.y && machrom.y < m.y + m.h)
            {
                m.state = 1;
                m.o = 5;
                machrom.x = 4000;
            }
            for (int i = 0; i < bullets.Count(); i++)
            {
                if (bullets[i].s == 0)
                    bullets[i].x += 50;
                else
                    bullets[i].x -= 50;
                if (bullets[i].x > this.Width || bullets[i].x< this.Width -this.Width)
                    bullets.Remove(bullets[i]);
            }
            for (int i = 0; i < L2.Count(); i++)
            {
                if (L2[i].x >= m.x && L2[i].x <= m.x + m.w && L2[i].y < m.y + m.h)
                    m.j = 2;
            }
            if (m.x + m.w > castle.x && win==0)
            {
                win = 1;
                MessageBox.Show("You Win !!!!");
                reload();
            }

            countTick++;
            DrawDubb(this.CreateGraphics());
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(this.CreateGraphics());
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                background pnn = new background();
                pnn.im = new Bitmap(@"1.PNG");              
                background.Add(pnn);
            }           
            b = new Bitmap(this.Width, this.Height);
            simage = new Bitmap(@"29.PNG");
            x = 0;
            y = this.Height - 100;  //-180
            w = 300;
            h = 150;
            for (int i = 0; i < 15; i++)
            {
                CActor pnn = new CActor();
                pnn.x = x;                
                pnn.y = y;
                pnn.w = w;
                pnn.h = h;
                pnn.im = new Bitmap(@"2.PNG");
                ground.Add(pnn);
                x += 297;        //297       
            }          
            ground.Remove(ground[3]);
            ground.Remove(ground[2]);
            x = 250;
            y = this.Height - 150; // -230
            w = 120;
            h = 50;
            for (int i = 0; i < 2; i++)
            {
                CActor pnn = new CActor();
                pnn.im = new Bitmap(@"3.PNG");
                pnn.x = x;
                pnn.y = y;
                pnn.w = w;
                pnn.h = h;
                ground.Add(pnn);
                x = 1185;
            }
            m.im = new List<Bitmap>();
            for (int i = 0; i < 4; i++)
            {
                m.im.Add(new Bitmap((4 + i) + ".PNG"));
            }
            m.im.Add(new Bitmap("15.PNG"));
            for (int i = 0; i < 5; i++)
            {
                m.im.Add(new Bitmap((24 + i) + ".PNG"));
            }
            m.x = 15;
            m.y = this.Height - 170;
            m.w = 50;
            m.h = 70;
            m.o = 0;
            x = 100;
            w = 100;
            h = 160;
            y = this.Height - 98 - h;
            for (int i = 0; i < 2; i++)
            {
                CActor pnn = new CActor();
                pnn.im = new Bitmap(@"14.PNG");
                pnn.x = x;
                pnn.y = y;
                pnn.w = w;
                pnn.h = h;
                L.Add(pnn);
                x += 400;
            }
            x = ground[1].x + ground[1].w;
            y = this.Height - 300;  //470
            w = 150;
            h = 60;
            for (int i = 0; i < 5; i++)
            {
                CActor pnn = new CActor();
                pnn.im = new Bitmap(@"8.PNG");
                pnn.x = x;
                pnn.y = y;
                pnn.w = w;
                pnn.h = h;
                if (i == 3)
                {
                    pnn.x = 280;
                    pnn.y = this.Height - 450;
                }
                if (i == 4)
                {
                    pnn.im = new Bitmap(@"18.GIF");
                    pnn.x = this.Width - 100;
                    pnn.y = this.Height - 750;
                    pnn.w = 60;
                    pnn.h = 70;
                }
                L.Add(pnn);
                x = this.Width - 170;
                y = this.Height - 450;
            }
            x = L[0].x + L[0].w;
            w = 60;
            h = 80;
            y = this.Height - 98 - h;
            for (int i = 0; i < 2; i++)
            {
                move pi = new move();
                pi.x = x;
                pi.y = y;
                pi.w = w;
                pi.h = h;
                pi.d = 0;
                pi.im = new List<Bitmap>();
                for (int j = 0; j < 5; j++)
                {
                    pi.im.Add(new Bitmap((9 + j) + ".PNG"));
                }
                p.Add(pi);
                x = 1100;
            }
            ////////////////////////////////////////////////////
            machrom.im = new Bitmap(@"17.PNG");
            machrom.x = this.Width - 100;
            machrom.y = this.Height - 750;
            machrom.w = 50;
            machrom.h = 60;
            x = L[5].x;
            y = this.Height - 470 - 20;
            for (int i = 0; i < 8; i++)
            {
                move coin = new move();
                coin.im = new List<Bitmap>();
                for (int j = 0; j < 4; j++)
                {
                    coin.im.Add(new Bitmap((19 + j) + ".PNG"));
                }
                if (i == 4)
                {
                    x = this.Width - 170;
                    y = this.Height - 470 - 20;
                }
                coin.x = x;
                coin.y = y;
                coin.w = 37;
                coin.h = 40;
                coin.o = 0;
                c.Add(coin);
                x += 37;
            }
            x = ground[14].x + 600;
            for (int i = 0; i < 3; i++)
            {
                CActor pnn = new CActor();
                pnn.x = x;
                pnn.y = this.Height - 120;
                pnn.w = 40;
                pnn.h = 20;
                pnn.im = new Bitmap(@"32.PNG");
                L2.Add(pnn);
                x += 40;
            }
            x = ground[14].x + 720;
            w = 60;
            h = 80;
            y = this.Height - 98 - h;
            for (int i = 0; i < 1; i++)
            {
                move pi = new move();
                pi.x = x;
                pi.y = y;
                pi.w = w;
                pi.h = h;
                pi.d = 0;
                pi.im = new List<Bitmap>();
                for (int j = 0; j < 5; j++)
                {
                    pi.im.Add(new Bitmap((9 + j) + ".PNG"));
                }
                p.Add(pi);
            }
            x = ground[14].x + 980;
            for (int i = 0; i < 3; i++)
            {
                CActor pnn = new CActor();
                pnn.x = x;
                pnn.y = this.Height - 120;
                pnn.w = 40;
                pnn.h = 20;
                pnn.im = new Bitmap(@"32.PNG");
                L2.Add(pnn);
                x += 40;
            }
            castle.x = ground[14].x +1250 ;
            castle.y = this.Height - 219;
            castle.w = 80;
            castle.h =120;
            castle.im = new Bitmap(@"31.PNG");

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {           
            if (e.KeyCode == Keys.Right )
            {
                r = 1;               
            }
            if (e.KeyCode == Keys.Left && m.x-15>0 )
            {
                l = 1;
            }
            if (e.KeyCode == Keys.Space && m.j == 0 && mark == 2)
            {
                m.j = 1;
                m.d = 0;
                j = m.y;
                mark = 1;
            }
            if(e.KeyCode == Keys.Z && m.state==1)
            {
                CActor pnn = new CActor();
                pnn.x = m.x + m.w;
                pnn.y = m.y + 20;
                pnn.w = 15;
                pnn.h = 15;
                if (m.o == 5 || m.o == 6)
                    pnn.s = 0;
                else if (m.o == 7 || m.o == 8)
                   pnn.s = 1;
                Bitmap pnm = new Bitmap("33.PNG");
                pnm.MakeTransparent(pnm.GetPixel(0, 0));
                pnn.im=pnm;
                bullets.Add(pnn);
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && m.state == 0)
            {
                m.o = 0;
                r = 0;
            }
            if (e.KeyCode == Keys.Left && m.state == 0)
            {
                m.o = 2;
                l = 0;
            }
            if (e.KeyCode == Keys.Right && m.state == 1)
            {
                m.o = 5;
                r = 0;
            }
            if (e.KeyCode == Keys.Left && m.state == 1)
            {
                m.o = 7;
                l = 0;
            }
            if (e.KeyCode == Keys.Z)
            {
                s = 30;
            }
        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(b);
            DrawScene(g2);
            g.DrawImage(b, 0, 0);
        }
        void DrawScene(Graphics g)
        {
            if (start == 0)
            {
                g.Clear(Color.Black);
                g.DrawImage(simage, this.Width / 2 -200, this.Height / 2);
            }
            else
            {
                Font F = new Font("System", 35);
                g.DrawImage(background[0].im, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(xz,yz,683, 768), GraphicsUnit.Pixel);               
                g.DrawImage(machrom.im, machrom.x, machrom.y, machrom.w, machrom.h);
                for (int i = 0; i < c.Count(); i++)
                {
                    g.DrawImage(c[i].im[c[i].o], c[i].x, c[i].y, c[i].w, c[i].h);
                }
                
                for (int i = 0; i < L.Count(); i++)
                {
                    g.DrawImage(L[i].im, L[i].x, L[i].y, L[i].w, L[i].h);
                }
                for (int i = 0; i < bullets.Count(); i++)
                {
                    g.DrawImage(bullets[i].im, bullets[i].x, bullets[i].y, bullets[i].w, bullets[i].h);
                }
                for (int i = 0; i < L2.Count(); i++)
                {
                    g.DrawImage(L2[i].im, L2[i].x, L2[i].y, L2[i].w, L2[i].h);
                }               
                g.DrawImage(castle.im, castle.x, castle.y, castle.w, castle.h);
                for (int i = 0; i < ground.Count(); i++)
                {
                    g.DrawImage(ground[i].im, ground[i].x, ground[i].y, ground[i].w, ground[i].h);
                    g.DrawImage(m.im[m.o], m.x, m.y, m.w, m.h);
                }
                for (int i = 0; i < p.Count(); i++)
                {
                    g.DrawImage(p[i].im[p[i].o], p[i].x, p[i].y, p[i].w, p[i].h);
                }
                g.DrawImage(new Bitmap(@"16.PNG"), 0, 0, 150, 50);
                g.DrawImage(new Bitmap(@"23.PNG"), 250, 0, 100, 50);
                g.DrawString("X " + mario, F, Brushes.Red, 150, 0);
                g.DrawString("" + coins, F, Brushes.OrangeRed, 350, 0);
            }

        }
        void reload()
        {
            L.Clear();
            L2.Clear();
            ground.Clear();
            c.Clear();
            p.Clear();
            mario = 3;
            coins = 0;
            start = 0;
            win = 0;
            m.state = 0;
            s = 15;
            move = 11;
            xz = 0;
            yz = 0;
            f1 = 0;
            f4 = 0;
            for (int i = 0; i < 1; i++)
            {
                background pnn = new background();
                pnn.im = new Bitmap(@"1.PNG");
                background.Add(pnn);
            }
            simage = new Bitmap(@"29.PNG");
            x = 0;
            y = this.Height - 100;  //-180
            w = 300;
            h = 150;
            for (int i = 0; i < 15; i++)
            {
                CActor pnn = new CActor();
                pnn.x = x;
                pnn.y = y;
                pnn.w = w;
                pnn.h = h;
                pnn.im = new Bitmap(@"2.PNG");
                ground.Add(pnn);
                x += 297;        //297       
            }
            ground.Remove(ground[3]);
            ground.Remove(ground[2]);
            x = 250;
            y = this.Height - 150; // -230
            w = 120;
            h = 50;
            for (int i = 0; i < 2; i++)
            {
                CActor pnn = new CActor();
                pnn.im = new Bitmap(@"3.PNG");
                pnn.x = x;
                pnn.y = y;
                pnn.w = w;
                pnn.h = h;
                ground.Add(pnn);
                x = 1185;
            }
            m.im = new List<Bitmap>();
            for (int i = 0; i < 4; i++)
            {
                m.im.Add(new Bitmap((4 + i) + ".PNG"));
            }
            m.im.Add(new Bitmap("15.PNG"));
            for (int i = 0; i < 5; i++)
            {
                m.im.Add(new Bitmap((24 + i) + ".PNG"));
            }
            m.x = 15;
            m.y = this.Height - 170;
            m.w = 50;
            m.h = 70;
            m.o = 0;
            x = 100;
            w = 100;
            h = 160;
            y = this.Height - 98 - h;
            for (int i = 0; i < 2; i++)
            {
                CActor pnn = new CActor();
                pnn.im = new Bitmap(@"14.PNG");
                pnn.x = x;
                pnn.y = y;
                pnn.w = w;
                pnn.h = h;
                L.Add(pnn);
                x += 400;
            }
            x = ground[1].x + ground[1].w;
            y = this.Height - 300;  //470
            w = 150;
            h = 60;
            for (int i = 0; i < 5; i++)
            {
                CActor pnn = new CActor();
                pnn.im = new Bitmap(@"8.PNG");
                pnn.x = x;
                pnn.y = y;
                pnn.w = w;
                pnn.h = h;
                if (i == 3)
                {
                    pnn.x = 280;
                    pnn.y = this.Height - 450;
                }
                if (i == 4)
                {
                    pnn.im = new Bitmap(@"18.GIF");
                    pnn.x = this.Width - 100;
                    pnn.y = this.Height - 750;
                    pnn.w = 60;
                    pnn.h = 70;
                }
                L.Add(pnn);
                x = this.Width - 170;
                y = this.Height - 450;
            }
            x = L[0].x + L[0].w;
            w = 60;
            h = 80;
            y = this.Height - 98 - h;
            for (int i = 0; i < 2; i++)
            {
                move pi = new move();
                pi.x = x;
                pi.y = y;
                pi.w = w;
                pi.h = h;
                pi.d = 0;
                pi.im = new List<Bitmap>();
                for (int j = 0; j < 5; j++)
                {
                    pi.im.Add(new Bitmap((9 + j) + ".PNG"));
                }
                p.Add(pi);
                x = ground[14].x;
            }
            machrom.im = new Bitmap(@"17.PNG");
            machrom.x = this.Width - 100;
            machrom.y = this.Height - 750;
            machrom.w = 50;
            machrom.h = 60;
            x = L[5].x;
            y = this.Height - 470 - 20;
            for (int i = 0; i < 8; i++)
            {
                move coin = new move();
                coin.im = new List<Bitmap>();
                for (int j = 0; j < 4; j++)
                {
                    coin.im.Add(new Bitmap((19 + j) + ".PNG"));
                }
                if (i == 4)
                {
                    x = this.Width - 170;
                    y = this.Height - 470 - 20;
                }
                coin.x = x;
                coin.y = y;
                coin.w = 37;
                coin.h = 40;
                coin.o = 0;
                c.Add(coin);
                x += 37;
            }
            x = ground[14].x + 600;
            for (int i = 0; i < 3; i++)
            {
                CActor pnn = new CActor();
                pnn.x = x;
                pnn.y = this.Height - 120;
                pnn.w = 40;
                pnn.h = 20;
                pnn.im = new Bitmap(@"32.PNG");
                L2.Add(pnn);
                x += 40;
            }
            x = ground[14].x + 720;
            w = 60;
            h = 80;
            y = this.Height - 98 - h;
            for (int i = 0; i < 1; i++)
            {
                move pi = new move();
                pi.x = x;
                pi.y = y;
                pi.w = w;
                pi.h = h;
                pi.d = 0;
                pi.im = new List<Bitmap>();
                for (int j = 0; j < 5; j++)
                {
                    pi.im.Add(new Bitmap((9 + j) + ".PNG"));
                }
                p.Add(pi);
            }
            x = ground[14].x + 980;
            for (int i = 0; i < 3; i++)
            {
                CActor pnn = new CActor();
                pnn.x = x;
                pnn.y = this.Height - 120;
                pnn.w = 40;
                pnn.h = 20;
                pnn.im = new Bitmap(@"32.PNG");
                L2.Add(pnn);
                x += 40;
            }
            castle.x = ground[14].x + 1250;
            castle.y = this.Height - 219;
            castle.w = 80;
            castle.h = 120;
            castle.im = new Bitmap(@"31.PNG");

        }
        void mr()
        {
            if (xz < 1200 )
            {
                xz += move;
                for (int i = 0; i < ground.Count(); i++)
                {
                    ground[i].x -= move;
                }
                for (int i = 0; i < p.Count(); i++)
                {
                    p[i].x -= move;
                }
                for (int i = 0; i < L.Count(); i++)
                {
                    L[i].x -= move;
                }
                for (int i = 0; i < c.Count(); i++)
                {
                    c[i].x -= move;
                }
                for (int i = 0; i < L2.Count(); i++)
                {
                    L2[i].x -= move;
                }
                machrom.x -= move;
                castle.x -= move;
            }
            if (m.x > ground[14].x)
            {
                move =15;
            }
            else
                move = 11;

        }
        void ml()
        {
            if (xz > 0)
            {
                xz -= move;
                for (int i = 0; i < ground.Count(); i++)
                {
                    ground[i].x += move;
                }
                for (int i = 0; i < p.Count(); i++)
                {
                    p[i].x += move;
                }
                for (int i = 0; i < L.Count(); i++)
                {
                    L[i].x += move;
                }
                for (int i = 0; i < c.Count(); i++)
                {
                    c[i].x += move;
                }
                for (int i = 0; i < L2.Count(); i++)
                {
                    L2[i].x += move;
                }
                machrom.x += move;
                castle.x += move;
            }
        }
    }
}
