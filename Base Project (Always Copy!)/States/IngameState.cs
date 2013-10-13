using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class IngameState : BasicState
{
    
    Rectangle dimensions = new Rectangle(0, 0, 800, 800);
    int tileWidth = 20;

    bool[,] currentState;
    bool[,] nextState;

    //When mouse is held down over a tile, it's corresponding value
    //in clicked is set to true. This stops it flicking back and forth erraticaly.
    bool[,] clicked;
    bool paused = true;
    bool mousedown = false;

    public IngameState()
    {
        //Setting Size of Arrays.
        currentState = new bool[(int)Math.Floor((Double)(dimensions.Width - dimensions.X) / tileWidth),
            (int)Math.Floor((Double)(dimensions.Width - dimensions.X) / tileWidth)];
        nextState = new bool[currentState.GetLength(0), currentState.GetLength(1)];
        clicked = new bool[currentState.GetLength(0), currentState.GetLength(1)];
    }

    public override void Update()
    {
        if (paused == false)
        {
            for (int i = 0; i < currentState.GetLength(0); i++)
            {
                for (int j = 0; j < currentState.GetLength(1); j++)
                {
                    int aliveNum = 0;

                    #region Checking Neighbours for alive Cells.
                    if (i > 0)
                    {
                        if (currentState[i - 1, j] == true)
                            aliveNum++;
                    }

                    if (i < currentState.GetLength(0) - 1)
                    {
                        if (currentState[i + 1, j] == true)
                            aliveNum++;
                    }

                    if (j > 0)
                    {
                        if (currentState[i, j - 1] == true)
                            aliveNum++;
                    }

                    if (j < currentState.GetLength(1) - 1)
                    {
                        if (currentState[i, j + 1] == true)
                            aliveNum++;
                    }

                    if (i > 0 && j > 0)
                    {
                        if (currentState[i - 1, j - 1] == true)
                            aliveNum++;
                    }

                    if (i > 0 && j < currentState.GetLength(1) - 1)
                    {
                        if (currentState[i - 1, j + 1] == true)
                            aliveNum++;
                    }

                    if (i < currentState.GetLength(0) - 1 && j > 0)
                    {
                        if (currentState[i + 1, j - 1] == true)
                            aliveNum++;
                    }

                    if (i < currentState.GetLength(0) - 1 && j < currentState.GetLength(1) - 1)
                    {
                        if (currentState[i + 1, j + 1] == true)
                            aliveNum++;
                    }
                    #endregion

                    //Changing the cells state according to the rules.
                    if (currentState[i, j] == true)
                    {
                        if (aliveNum < 2)
                            nextState[i, j] = false;
                        if (aliveNum > 3)
                            nextState[i, j] = false;
                    }
                    else
                    {
                        if (aliveNum == 3)
                            nextState[i, j] = true;
                    }
                }
            }

            //Updating the Current array with the Next arrays values.
            for (int i = 0; i < currentState.GetLength(0); i++)
            {
                for (int j = 0; j < currentState.GetLength(1); j++)
                {
                    currentState[i, j] = nextState[i, j];
                }
            }
        }
    }

    public override void Redraw(PaintEventArgs e)
    {
        //Loop through the current state of the game, draw a grid and, if the cell is alive, a black square.
        for (int i = 0; i < currentState.GetLength(0); i++)
        {
            for (int j = 0; j < currentState.GetLength(1); j++)
            {
                e.Graphics.DrawRectangle(System.Drawing.Pens.Green, new System.Drawing.Rectangle(i * tileWidth, j * tileWidth, tileWidth, tileWidth));

                if (currentState[i, j] == true)
                    e.Graphics.FillRectangle(System.Drawing.Brushes.Black, new System.Drawing.Rectangle(i * tileWidth, j * tileWidth, tileWidth, tileWidth));
            }
        }
    }

    public override void MouseMoved(MouseEventArgs e)
    {
        if (mousedown)
        {
            if (e.Button == MouseButtons.Left && dimensions.Contains(e.Location))
            {
                //Calculating the tile which the mouse is over.
                int xPos = e.X / tileWidth;
                int yPos = e.Y / tileWidth;

                //If this tile hasn't been changed in this current click, change it.
                if (clicked[xPos, yPos] != true)
                {
                    //Changing the bools of each array to the opposite of what
                    //they were.
                    currentState[xPos, yPos] = !currentState[xPos, yPos];
                    nextState[xPos, yPos] = !nextState[xPos, yPos];
                    clicked[xPos, yPos] = !clicked[xPos, yPos];
                }
            }
        }
    }

    public override void MouseClicked(MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
        }
        else if (e.Button == MouseButtons.Right)
        {
            paused = !paused;
        }

        //A full click has been recorded, mouse is no longer down.
        //Clicked can also be cleared as a new one is needed for next mousedown.
        mousedown = false;
        clicked = new bool[clicked.GetLength(0), clicked.GetLength(1)];
    }

    public override void MouseDown(MouseEventArgs e)
    {
        mousedown = true;
    }
}
