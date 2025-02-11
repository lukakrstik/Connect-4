﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4
{
    internal class Ball
    {
        private Point center {  get; set; }
        private Color color {  get; set; }
        private int radius = 45;

        public Ball(Point center, Color color)
        {
            this.center = center;
            this.color = color;
        }

        public void Draw(Graphics g)
        {
            
            int X = (center.X / 100) * 100;
            int Y = (center.Y / 100) * 100;
            
               Brush b = new SolidBrush(color);
               g.FillEllipse(b, X, Y+50, 2 * radius, 2 * radius);
               b.Dispose();
               Color shadeColor = ControlPaint.Dark(color);
               Pen p = new Pen(new SolidBrush(shadeColor), 8);
               g.DrawEllipse(p, X+4, Y+54,(float) 1.82 * radius, (float) 1.82 * radius); 
               p.Dispose();


        }
    }
}
