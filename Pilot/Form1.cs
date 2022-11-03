using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Pilot
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap sky, plane, cloud, cloud2, cloud3;
        Rectangle r1; //рентангл в который вписывается самолетик
        Rectangle r2;
        Rectangle r3;
        Rectangle r4;
        Random rn;
        int dx; //приращение по х, для изменения скорости
        int cx;

        Boolean demo = true;
        private void timer1_Tick(object sender, EventArgs e)
        {
            g.DrawImage(sky, new Point(0, 0));
            if (r1.X < ClientRectangle.Width || r2.X > ClientRectangle.Width || r3.X > ClientRectangle.Width || r4.X > ClientRectangle.Width)
            {
                r1.X += dx;
                r2.X += cx;
                r3.X += cx;
                r4.X += cx;
            }
            else
            {
                r1.X = -40;
                r1.Y = 20 + rn.Next(ClientSize.Height - 40 - plane.Height);
                dx = 2 + rn.Next(5);

                r2.X = 1000;
                r2.Y = 20 + rn.Next(ClientSize.Height - 40 - cloud.Height);
                cx = -2 - rn.Next(5);

                r3.X = 1100;
                r3.Y = 40 + rn.Next(ClientSize.Height - 20 - cloud.Height);
                cx = -2 - rn.Next(6);

                r4.X = 1100;
                r4.Y = 40 + rn.Next(ClientSize.Height - 20 - cloud.Height);
                cx = -2 - rn.Next(6);

            }

            g.DrawImage(cloud2, r3.X, r3.Y);
            if (!demo)
                Invalidate(r3);
            else
            {
                Rectangle reg = new Rectangle(20, 20, sky.Width - 40, sky.Height - 40);
                g.DrawRectangle(Pens.Black, reg.X, reg.Y, reg.Width - 1, reg.Height - 1);
                Invalidate(reg);
            }

            g.DrawImage(plane, r1.X, r1.Y);
            if(!demo)
            Invalidate(r1);
            else
            {
                Rectangle reg = new Rectangle(20, 20, sky.Width - 40, sky.Height - 40);
                g.DrawRectangle(Pens.Black, reg.X, reg.Y, reg.Width - 1, reg.Height - 1);
                Invalidate(reg);
            }
            
            g.DrawImage(cloud, r2.X, r2.Y);
            if (!demo)
                Invalidate(r2);
            else
            {
                Rectangle reg = new Rectangle(20, 20, sky.Width - 40, sky.Height - 40);
                g.DrawRectangle(Pens.Black, reg.X, reg.Y, reg.Width - 1, reg.Height - 1);
                Invalidate(reg);
            }

            g.DrawImage(cloud3, r4.X, r4.Y);
            if (!demo)
                Invalidate(r4);
            else
            {
                Rectangle reg = new Rectangle(20, 20, sky.Width - 40, sky.Height - 40);
                g.DrawRectangle(Pens.Black, reg.X, reg.Y, reg.Width - 1, reg.Height - 1);
                Invalidate(reg);
            }

        }

        public Form1()
        {
            InitializeComponent();
            try
            {
                sky = new Bitmap("sky.bmp");
                plane = new Bitmap("plane2.bmp");
                cloud = new Bitmap("cloud.png");
                cloud2 = new Bitmap("cloud2.png");
                cloud3 = new Bitmap("cloud2.png");
                BackgroundImage = new Bitmap("sky.bmp");
            }
            catch(Exception e)
            {
                MessageBox.Show("Картини не зашрузились", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            plane.MakeTransparent();
            cloud.MakeTransparent();
            cloud2.MakeTransparent();
            cloud3.MakeTransparent();
            ClientSize = new Size(new Point(BackgroundImage.Width, BackgroundImage.Height));
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            g = Graphics.FromImage(BackgroundImage);
            rn = new Random();
            r1.X = -40;
            r1.Y = 20 + rn.Next(20);
            r1.Width = plane.Width;
            r1.Height = plane.Height;
            dx = 5;
            r2.X = 400;
            r2.Y = 20 + rn.Next(20);
            r2.Width = cloud.Width;
            r2.Height = cloud.Height;
            r3.X = 1100;
            r3.Y = 20 + rn.Next(20);
            r3.Width = cloud.Width;
            r3.Height = cloud.Height;
            r4.X = 1300;
            r4.Y = 20 + rn.Next(20);
            r4.Width = cloud.Width;
            r4.Height = cloud.Height;
            cx = -3;
            timer1.Interval = 20;
            timer1.Enabled = true;
 
        }
    }
}
