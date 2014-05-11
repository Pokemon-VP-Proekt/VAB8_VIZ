using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VAB8_VIZ.Properties;

namespace VAB8_VIZ
{
    public partial class Form1 : Form
    {
        Timer timer;
        Pacman pacman;
        Graphics graphics;
        Bitmap doubleBuffer;
        static readonly int TIMER_INTERVAL = 300;
        static readonly int WORLD_WIDTH = 15;
        static readonly int WORLD_HEIGHT = 10;
        Image foodImage;
        bool[][] foodWorld;



        public Form1()
        {
            InitializeComponent();
            foodImage = Resources.food__45x45___35x35_;
            newGame();
        }

        public void newGame()
        {
            pacman = new Pacman();
            this.Width = Pacman.RADIUS * 2 * (WORLD_WIDTH + 1);
            this.Height = Pacman.RADIUS * 2 * (WORLD_HEIGHT + 1);
            doubleBuffer = new Bitmap(Pacman.RADIUS * 2 * (WORLD_WIDTH + 1), Pacman.RADIUS * 2 * (WORLD_HEIGHT + 1));
            graphics = CreateGraphics();
            Show();
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = TIMER_INTERVAL;
            timer.Start();
            foodWorld = new bool[30][];
            for (int i = 0; i < foodWorld.Length; i++)
            {
                foodWorld[i] = new bool[WORLD_WIDTH];
                for (int j = 0; j < foodWorld[i].Length; j++)
                {
                    foodWorld[i][j] = true;
                }
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
{
    Graphics g = e.Graphics;
    g.Clear(Color.White);
    for (int i = 0; i < foodWorld.Length; i++)
    {
        for (int j = 0; j < foodWorld[i].Length; j++)
        {
            if (foodWorld[i][j])
            {
                g.DrawImageUnscaled(foodImage, j * Pacman.RADIUS * 2 + (Pacman.RADIUS * 2 - foodImage.Height) / 2, i * Pacman.RADIUS * 2 + (Pacman.RADIUS * 2 - foodImage.Width) / 2);
            }
        }
    }
    pacman.Draw(g);
}


        void timer_Tick(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(doubleBuffer);
            g.Clear(Color.White);
            for (int i = 0; i < foodWorld.Length; i++)
            {
                for (int j = 0; j < foodWorld[i].Length; j++)
                {
                    if (pacman.X == j && pacman.Y == i)
                    {
                        foodWorld[i][j] = false;
                    }
                    if (foodWorld[i][j])
                    {
                        g.DrawImageUnscaled(foodImage, j * Pacman.RADIUS * 2 + (Pacman.RADIUS * 2 - foodImage.Height) / 2, i * Pacman.RADIUS * 2 + (Pacman.RADIUS * 2 - foodImage.Width) / 2);
                    }
                }
            }
            pacman.Move(WORLD_WIDTH, WORLD_HEIGHT);
            pacman.Draw(g);
            graphics.DrawImageUnscaled(doubleBuffer, 0, 0);
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
          
        }

        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                pacman.ChangeDirection(Pacman.NASOKA.UP);
            }
            if (e.KeyCode == Keys.Down)
            {
                pacman.ChangeDirection(Pacman.NASOKA.DOWN);
            }
            if (e.KeyCode == Keys.Right)
            {
                pacman.ChangeDirection(Pacman.NASOKA.RIGHT);
            }
            if (e.KeyCode == Keys.Left)
            {
                pacman.ChangeDirection(Pacman.NASOKA.LEFT);
            }
        }



    }
}
