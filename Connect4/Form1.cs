using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4
{
    
    public partial class Form1 : Form
    {
        Scene Scene {  get; set; }
        private Color player1color = Color.Blue;
        private Color player2color = Color.Red;
        private int startingPlayer = 1;
        private bool gameStarted = false;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Width = 710;
            Height = 800;
            Scene = new Scene(player1color, player2color, startingPlayer);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveToFile(saveFileDialog.FileName);
            }
        }

        private void SaveToFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, Scene);
            fs.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadToFile(openFileDialog.FileName);
            }
        }

        private void LoadToFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            IFormatter formatter = new BinaryFormatter();
            Scene = formatter.Deserialize(fs) as Scene;
            fs.Close(); ;
        }

        private void startGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            label1 .Visible = false;
            Scene = new Scene(player1color, player2color, startingPlayer);
            gameStarted = !gameStarted;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void starterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void playerColor1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                player1color = colorDialog.Color;
            }
        }

        private void playerColor2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                player2color = colorDialog.Color;
            }
        }

        private void player1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player1ToolStripMenuItem.Checked = true;
            player2ToolStripMenuItem.Checked = false;
            startingPlayer = 1;
        }

        private void player2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player1ToolStripMenuItem.Checked = false;
            player2ToolStripMenuItem.Checked = true;
            startingPlayer = 2;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int X = (e.X / 100) * 100;
            int Y = (e.Y / 100) * 100;
            if (gameStarted && X < 700 && Y < 750 && Y > 5 && Scene.Winner.Length == 0)
            {
                Scene.addBall(e.Location);
                Invalidate();
                if (Scene.Winner.Length != 0)
                {
                    ShowWinner();
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Scene.Draw(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.ImageLocation = "https://res.cloudinary.com/practicaldev/image/fetch/s--aoSCEM7T--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_800/https://dev-to-uploads.s3.amazonaws.com/uploads/articles/22h00ieh9xkoucd1olpe.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void ShowWinner()
        {
            DialogResult result = MessageBox.Show(Scene.Winner,"Congratulations!!!");
            if (result == DialogResult.OK)
            {
                button1.Visible = true;
                label1.Visible = true;
                Scene = Scene = new Scene(player1color, player2color, startingPlayer);
                gameStarted = false;
                Invalidate();
            }
        }
    }
}
