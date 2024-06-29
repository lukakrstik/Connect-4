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

        public string Winner = "";

        public Scene(Color player1color, Color player2color, int startingPlayer) {
            this.player1color = player1color;
            this.player2color = player2color;
            this.startingPlayer = startingPlayer;
            this.currentPlayer = startingPlayer;
            balls = new List<Ball>();
        }

        public void addBall(Point p)
        {
            
            for (int i = 0; i < 6; i++)
            {
                if (played[i, p.X / 100] == 0)
                {
                    p.Y = i * 100; 
                }
            }
            if (p.Y < 700)
            {
                if (currentPlayer == 1 && played[p.Y / 100, p.X / 100] == 0)
                {
                    Ball ball = new Ball(p, player1color);
                    balls.Add(ball);
                    played[p.Y / 100, p.X / 100] = 1;
                    if(WinCheck(currentPlayer))
                    {
                        Winner = "Winner: Player " + currentPlayer;
                    }
                    
                    currentPlayer = 2;
                    
                }
                else if (currentPlayer == 2 && played[p.Y / 100, p.X / 100] == 0)
                {
                    Ball ball = new Ball(p, player2color);
                    balls.Add(ball);
                    played[p.Y / 100, p.X / 100] = 2;
                    if (WinCheck(currentPlayer))
                    {
                        Winner = "Winner: Player " + currentPlayer;
                    }
                    currentPlayer = 1;
                    
                }

            }
        }

        private bool WinCheck(int currplayer) {

            for (int i = 0; i < played.GetLength(0); i++)
            {
                for (int j = 0; j <= played.GetLength(1)-4; j++)
                {
                    if (played[i, j] == currplayer &&
                    played[i, j + 1] == currplayer &&
                    played[i, j + 2] == currplayer &&
                    played[i, j + 3] == currplayer)
                    {
                        return true;
                    }
                }
            }
            for (int i = 0; i <= played.GetLength(0)-4; i++)
            {
                for (int j = 0; j < played.GetLength(1); j++)
                {
                    if (played[i, j] == currplayer &&
                    played[i + 1, j ] == currplayer &&
                    played[i + 2, j ] == currplayer &&
                    played[i + 3, j ] == currplayer)
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i <= played.GetLength(0) - 4; i++)
            {
                for (int j = 0; j <= played.GetLength(1)-4; j++)
                {
                    if (played[i, j] == currplayer &&
                    played[i + 1, j + 1] == currplayer &&
                    played[i + 2, j + 2] == currplayer &&
                    played[i + 3, j + 3] == currplayer)
                    {
                        return true;
                    }
                }
            }
            for (int i = 3; i < played.GetLength(0); i++)
            {
                for (int j = 0; j <= played.GetLength(1) - 4; j++)
                {
                    if (played[i, j] == currplayer &&
                    played[i - 1, j + 1] == currplayer &&
                    played[i - 2, j + 2] == currplayer &&
                    played[i - 3, j + 3] == currplayer)
                    {
                        return true;
                    }
                }
            }

            bool tableFull = true;
            for (int i = 0; i < played.GetLength(0); i++)
            {
                for (int j = 0; j < played.GetLength(1); j++)
                {
                    if (played[i,j] == 0)
                    {
                        tableFull = false;
                    }
                }
            }
            if (tableFull)
            {
                Winner = "Draw";
            }
            return false;
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
