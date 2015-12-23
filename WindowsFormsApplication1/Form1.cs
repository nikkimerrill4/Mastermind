using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int[] key = new int[4];
        int turn = 1;
        Color color;
        Button[,] gameboard = new Button[10, 4]; 

        public Form1()
        {
            InitializeComponent();
            InitializeGameboard();
            GenerateKey();
        }

        private void InitializeGameboard()
        {
            gameboard[0, 0] = buttonA1;
            gameboard[0, 1] = buttonA2;
            gameboard[0, 2] = buttonA3;
            gameboard[0, 3] = buttonA4;
            gameboard[1, 0] = buttonB1;
            gameboard[1, 1] = buttonB2;
            gameboard[1, 2] = buttonB3;
            gameboard[1, 3] = buttonB4;
            gameboard[2, 0] = buttonC1;
            gameboard[2, 1] = buttonC2;
            gameboard[2, 2] = buttonC3;
            gameboard[2, 3] = buttonC4;
            gameboard[3, 0] = buttonD1;
            gameboard[3, 1] = buttonD2;
            gameboard[3, 2] = buttonD3;
            gameboard[3, 3] = buttonD4;
            gameboard[4, 0] = buttonE1;
            gameboard[4, 1] = buttonE2;
            gameboard[4, 2] = buttonE3;
            gameboard[4, 3] = buttonE4;
            gameboard[5, 0] = buttonF1;
            gameboard[5, 1] = buttonF2;
            gameboard[5, 2] = buttonF3;
            gameboard[5, 3] = buttonF4;
            gameboard[6, 0] = buttonG1;
            gameboard[6, 1] = buttonG2;
            gameboard[6, 2] = buttonG3;
            gameboard[6, 3] = buttonG4;
            gameboard[7, 0] = buttonH1;
            gameboard[7, 1] = buttonH2;
            gameboard[7, 2] = buttonH3;
            gameboard[7, 3] = buttonH4;
            gameboard[8, 0] = buttonI1;
            gameboard[8, 1] = buttonI2;
            gameboard[8, 2] = buttonI3;
            gameboard[8, 3] = buttonI4;
            gameboard[9, 0] = buttonJ1;
            gameboard[9, 1] = buttonJ2;
            gameboard[9, 2] = buttonJ3;
            gameboard[9, 3] = buttonJ4;
        }

        private void GenerateKey()
        {
            Random rnd = new Random();
            for (int i = 0; i < key.Length; i++)
            {
                key[i] = rnd.Next(1,6);   
            }
            
        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            color = ((Button)sender).BackColor;
        }

        private void button_Click(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = color; 
        }

        private void guessButton_Click(object sender, EventArgs e)
        {
            //if row is not fill, do nothing
            if (full())
            {
                //Disable current line
                for (int i = 0; i < 4; i++)
                {
                    gameboard[turn - 1, i].Enabled = false;
                }

                //Compare to key
                int numReds = 0;
                int numWhts = 0;
                int[] keyCopy = (int[])key.Clone();
                int[] guess = new int[key.Length];
                for (int i = 0; i < 4; i++)
                {
                    int pieceColorNumber = getColorNumber(gameboard[turn - 1, i].BackColor);
                    if (pieceColorNumber == keyCopy[i])
                    {
                        keyCopy[i] = 0; // Mark this as matched so that we won't compare it any more
                        guess[i] = 0;
                        numReds++;
                    }
                    else 
                    {
                        guess[i] = pieceColorNumber;
                    }
                }
                for (int i = 0; i < 4; i++)
                {
                    if (guess[i] != 0 )
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (keyCopy[j] != 0 && keyCopy[j] == guess[i])
                            {

                                keyCopy[j] = 0; // Mark this as matched so that we won't compare it any more
                                guess[i] = 0;
                                numWhts++;
                                break;
                            }
                            
                        }
                    }
                    
               
                   
                }
                String label = "";
                for (int i = 1; i <= numReds; i++ )
                {
                    label = label + 'O'
                }

                    //if win display win

                    //else display results

                    //enable next line
                    for (int i = 0; i < 4; i++)
                    {
                        gameboard[turn, i].Enabled = true;
                    }

                //advance to next turn
                turn++;
            }
            
        }

        private bool full()
        {

            for (int i = 0; i < 4; i++)
            {
                if (getColorNumber(gameboard[turn - 1, i].BackColor) == -1)
                {
                    return false;
                }
            } 

            return true;
        }

       private int getColorNumber(Color c)
        {
            if (c == Color.HotPink)
            {
                return 1;
            }
            else if (c == Color.Orange)
            {
                return 2;
            }
            else if (c == Color.Yellow)
            {
                return 3;
            }
            else if (c == Color.White)
            {
                return 4;
            }
            else if (c == Color.Green)
            {
                return 5;
            }
            else if (c == Color.Purple)
            {
                return 6;
            }
            return -1;
        }


    }

}
