using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4
{
    internal class Scene
    {
        public Color player1color { get; set; }
        public Color player2color { get; set; }
        public int startingPlayer { get; set; }
        
        public int currentPlayer { get; set; }

        public int[,] played = new int[6, 7];

        public List<Ball> balls = new List<Ball>();

        public Scene(Color player1color, Color player2color, int startingPlayer) {
            this.player1color = player1color;
            this.player2color = player2color;
            this.startingPlayer = startingPlayer;
            this.currentPlayer = startingPlayer;
            balls = new List<Ball>();
        }

        public void addBall(Point p)
        {
            if (currentPlayer == 1)
            {
                Ball ball = new Ball(p, player1color);
                balls.Add(ball);
                currentPlayer = 2;
                played[p.Y / 100, p.X / 100] = 1;
            }
            else if(currentPlayer == 2)
            {
                Ball ball = new Ball(p, player2color);
                balls.Add(ball);
                currentPlayer = 1;
                played[p.Y / 100, p.X / 100] = 2;
            }
           

            for (int i = 0; i < played.GetLength(0); i++)
            {
                for (int j = 0; j < played.GetLength(1); j++)
                {
                    Console.Write(played[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void Draw(Graphics g)
        {
            foreach (Ball ball in balls)
            {
                ball.Draw(g);
            }
        }
    }
}
