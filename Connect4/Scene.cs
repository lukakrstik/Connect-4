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
            }
            else
            {
                Ball ball = new Ball(p, player2color);
                balls.Add(ball);
                currentPlayer = 1;
            }
            
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
