using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace VAB8_VIZ

{
    
    public class Pacman
    {
        public enum NASOKA
        {
            RIGHT,
            LEFT,
            UP,
            DOWN
        }
        public int X { get; set; }
        public int Y { get; set; }
        Brush brush;
       public NASOKA Nasoka;
        public bool flag = false;
        public static readonly int RADIUS = 20;
        private int velocity;
        private bool isOpen;
        public Pacman()
        {
            velocity = RADIUS;
            X = 7;
            Y = 5;
            Nasoka = NASOKA.RIGHT;
            brush = new SolidBrush(Color.Yellow);
        }
        public void ChangeDirection(NASOKA direction)
        {
            Nasoka = direction;
        }
        public void Move(int width, int height)
        {
            if (Nasoka == NASOKA.RIGHT)
            {
                X += 1;
                if (X >= width)
                {
                    X = 0;
                }
            }
            if (Nasoka == NASOKA.LEFT)
            {
                X -= 1;
                if (X < 0)
                {
                    X = width - 1;
                }
            }
            if (Nasoka == NASOKA.UP)
            {
                Y -= 1;
                if (Y < 0)
                {
                    Y = height - 1;
                }
            }
            if (Nasoka == NASOKA.DOWN)
            {
                Y += 1;
                if (Y >= height)
                {
                    Y = 0;
                }

            }

            isOpen = !isOpen;
        }
        public void Draw(Graphics g)
        {
            if (isOpen)
            {
                g.FillEllipse(brush, X * 2 * RADIUS, Y * 2 * RADIUS, RADIUS * 2, RADIUS * 2);
            }
            else
            {
                if (Nasoka == NASOKA.RIGHT)
                {
                    g.FillPie(brush, X * 2 * RADIUS, Y * 2 * RADIUS, RADIUS * 2, RADIUS * 2, 45, 270);
                }
                else if (Nasoka == NASOKA.LEFT)
                {
                    g.FillPie(brush, X * 2 * RADIUS, Y * 2 * RADIUS, RADIUS * 2, RADIUS * 2, 225, 270);
                }
                else if (Nasoka == NASOKA.UP)
                {
                    g.FillPie(brush, X * 2 * RADIUS, Y * 2 * RADIUS, RADIUS * 2, RADIUS * 2, 315, 270);
                }
                else
                {
                    g.FillPie(brush, X * 2 * RADIUS, Y * 2 * RADIUS, RADIUS * 2, RADIUS * 2, 135, 270);
                }
            }
        }



    }

}
