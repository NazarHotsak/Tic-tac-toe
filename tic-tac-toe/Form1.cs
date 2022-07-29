using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        Computer computer = new Computer();
        
        bool turn = true; // true = X false = Y
        
        bool isMoveComputer = true;
        
        char[] Field = new char[9];

        int countMove = 0;

        private void buttom_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btn.Text = turn ? "X" : "O";
            
            Field[btn.TabIndex - 1] = btn.Text[0];

            countMove++;

            btn.Enabled = false;

            turn = !turn;

            if (false == CheckForWinner() && isMoveComputer) 
            {
                MoveComputer();
            }
        }

        private void MoveComputer()
        {
            char[] newField = new char[9];
            
            Array.Copy(Field, newField, Field.Length);

            isMoveComputer = false;

            switch (computer.ComputerTapIndexOfMove(newField, turn))
            {
                case 0:
                    y1x1.PerformClick();
                    break;
                case 1:
                    y1x2.PerformClick();
                    break;
                case 2:
                    y1x3.PerformClick();
                    break;
                case 3:
                    y2x1.PerformClick();
                    break;
                case 4:
                    y2x2.PerformClick();
                    break;
                case 5:
                    y2x3.PerformClick();
                    break;
                case 6:
                    y3x1.PerformClick();
                    break;
                case 7:
                    y3x2.PerformClick();
                    break;
                case 8:
                    y3x3.PerformClick();
                    break;
            }

            isMoveComputer = true;
        }

        private bool CheckForWinner() 
        {
            bool thereIsWinner = false;

            if (((y1x1.Text == y1x2.Text) && (y1x2.Text == y1x3.Text) && y1x1.Text != "" && y1x2.Text != "" && y1x3.Text != "")
                || ((y2x1.Text == y2x2.Text) && (y2x2.Text == y2x3.Text) && y2x1.Text != "" && y2x2.Text != "" && y2x3.Text != "")
                || ((y3x1.Text == y3x2.Text) && (y3x2.Text == y3x3.Text) && y3x1.Text != "" && y3x2.Text != "" && y3x3.Text != "")
                || ((y3x1.Text == y2x2.Text) && (y2x2.Text == y1x3.Text) && y3x1.Text != "" && y2x2.Text != "" && y1x3.Text != "")
                || ((y1x1.Text == y2x2.Text) && (y2x2.Text == y3x3.Text) && y1x1.Text != "" && y2x2.Text != "" && y3x3.Text != "")
                || ((y1x1.Text == y2x1.Text) && (y2x1.Text == y3x1.Text) && y1x1.Text != "" && y2x1.Text != "" && y3x1.Text != "")
                || ((y1x2.Text == y2x2.Text) && (y2x2.Text == y3x2.Text) && y1x2.Text != "" && y2x2.Text != "" && y3x2.Text != "")
                || ((y1x3.Text == y2x3.Text) && (y2x3.Text == y3x3.Text) && y1x3.Text != "" && y2x3.Text != "" && y3x3.Text != "")
                )
            {
                thereIsWinner = true;
            }

            if (thereIsWinner || countMove == 9)
            {
                string winner = countMove == 9 ? "Draw" : turn ? "O" : "X";

                MessageBox.Show("Winner" + " " + winner + '!');
                DisableBottons();
            }
            return thereIsWinner;
        }

        private void DisableBottons()
        {
            y1x1.Enabled = false;
            y1x2.Enabled = false;
            y1x3.Enabled = false;
            y2x1.Enabled = false;
            y2x2.Enabled = false;
            y2x3.Enabled = false;
            y3x1.Enabled = false;
            y3x2.Enabled = false;
            y3x3.Enabled = false;
        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            Field = new char[9];
            countMove = 0;
            turn = true;

            y1x1.Text = "";
            y1x2.Text = "";
            y1x3.Text = "";
            y2x1.Text = "";
            y2x2.Text = "";
            y2x3.Text = "";
            y3x1.Text = "";
            y3x2.Text = "";
            y3x3.Text = "";

            y1x1.Enabled = true;
            y1x2.Enabled = true;
            y1x3.Enabled = true;
            y2x1.Enabled = true;
            y2x2.Enabled = true;
            y2x3.Enabled = true;
            y3x1.Enabled = true;
            y3x2.Enabled = true;
            y3x3.Enabled = true;

        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Text = turn ? "X" : "O";
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Enabled)
            {
                btn.Text = "";
            }
        }

        private void FirstMove_Click(object sender, EventArgs e)
        {
            NewGame_Click(sender, e);
            MoveComputer();
        }
    }
}





