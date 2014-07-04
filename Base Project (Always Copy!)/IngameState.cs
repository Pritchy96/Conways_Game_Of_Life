using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class IngameState
{

    Rectangle dimensions = new Rectangle(0, 0, 640, 640);
    int tileWidth = 20;

    bool[,] currentState;
    bool[,] nextState;
    Point middleOfGrid;

    //When mouse is held down over a tile, it's corresponding value
    //in clicked is set to true. This stops it flicking back and forth erraticaly.
    bool[,] clicked;
    bool paused = true;
    bool mousedown = false;

    public IngameState()
    {
        //Setting Size of Arrays.
        currentState = new bool[(int)Math.Floor((Double)(dimensions.Width - dimensions.X) / tileWidth),
            (int)Math.Floor((Double)(dimensions.Height - dimensions.Y) / tileWidth)];

        nextState = new bool[currentState.GetLength(0), currentState.GetLength(1)];
        clicked = new bool[currentState.GetLength(0), currentState.GetLength(1)];

        //Finds middle of the grid.
        middleOfGrid = new Point((int)Math.Floor((Double)(currentState.GetLength(0) / 2)), (int)Math.Floor((Double)(currentState.GetLength(1) / 2)));
    }

    public void ClearGrid()
    {
        for (int i = 0; i < currentState.GetLength(0); i++)
        {
            for (int j = 0; j < currentState.GetLength(1); j++)
            {
                currentState[i, j] = false;
                nextState[i, j] = false;
            }
        }
    }

    public void Pause(Label lblPause)
    {
        if (paused == true)
        {
            paused = false;
            lblPause.Text = "Active";
        }
        else
        {
            paused = true;
            lblPause.Text = "Paused";
        }
    }

    public void Update()
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

    public void Redraw(PaintEventArgs e)
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

    public void MouseMoved(MouseEventArgs e)
    {
        if (mousedown)
        {
            //Initial check to see if we're within bounds of array (not foolproof).
            if (e.Button == MouseButtons.Left && dimensions.Contains(e.Location))
            {
                //Calculating the tile which the mouse is over.
                int xPos = e.X / tileWidth;
                int yPos = e.Y / tileWidth;

                //Second check to make sure it's not out of bounds. This stops errors with the bottom of the grid.
                if (xPos < currentState.GetLength(0) && yPos < currentState.GetLength(1))
                {
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
    }

    public void MouseClicked(MouseEventArgs e)
    {
        //A full click has been recorded, mouse is no longer down.
        //Clicked can also be cleared as a new one is needed for next mousedown.
        mousedown = false;
        clicked = new bool[clicked.GetLength(0), clicked.GetLength(1)];
    }

    public void MouseDown(MouseEventArgs e)
    {
        mousedown = true;

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

    public void ResizeWindow(EventArgs e, int width, int height)
    {

    }

    public void LoadShapeClick(String shapeName)
    {
        //Clears grid ready for shape load.
        ClearGrid();

        //Variable to send to AddShape.
        int[,] shape = new int[2,2];

        //Massive, horrible switch statement to see which button was clicked
        //and loading/drawing the respective shape.
        switch (shapeName)
        {
            #region Still Lifes
            case ("Block"):
                //Create the shape.
                shape = new int[,]
                {
                    {1, 1},
                    {1, 1}
                };
                break;

            case ("Beehive"):
                //Create the shape.
                shape = new int[,]
                {
                    {0, 1, 1, 0},
                    {1, 0, 0, 1},
                    {0, 1, 1, 0}
                };
                break;

            case ("Loaf"):
                //Create the shape.
                shape = new int[,]
                {
                    {0, 1, 1, 0},
                    {1, 0, 0, 1},
                    {0, 1, 0, 1},
                    {0, 0, 1, 0}
                };
                break;

            case ("Boat"):
                //Create the shape.
                shape = new int[,]
                {
                    {1, 1, 0},
                    {1, 0, 1},
                    {0, 1, 0}
                };
                break;
            #endregion

            #region Oscillators
            case ("Blinker"):
                //Create the shape.
                shape = new int[,]
                {
                    {1, 1, 1}        
                };
                break;

            case ("Toad"):
                //Create the shape.
                shape = new int[,]
                {
                    {0, 1, 1, 1},
                    {1, 1, 1, 0} 
                };
                break;

            case ("Beacon"):
                //Create the shape.
                shape = new int[,]
                {
                    {1, 1, 0, 0},  
                    {1, 1, 0, 0},  
                    {0, 0, 1, 1},  
                    {0, 0, 1, 1},  
                };
                break;

            case ("Pulsar"):
                //Create the shape.
                shape = new int[,]
                {
                    {0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1},
                    {1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1},
                    {1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1},
                    {0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0},
                    {1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1},
                    {1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1},
                    {1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1},
                    {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    {0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0},
                };
                break;

            #endregion

            #region Ships
            case ("Glider"):
                //Create the shape.
                shape = new int[,]
                {
                    {0, 1, 0},
                    {0, 0, 1},
                    {1, 1, 1},
                };
                break;

            case ("LWSS"):
                //Create the shape.
                shape = new int[,]
                {
                    {0, 1, 0, 0, 1},
                    {1, 0, 0, 0, 0},
                    {1, 0, 0, 0, 1},
                    {1, 1, 1, 1, 0}
                };
                break;
            #endregion
        }

        //Send the shape to the function to be made.
        AddShape(shape);
        //Pasuing so the player can see the shape.
        paused = true;
    }

    //Adds a shape to the game from an array of ints to specify the shape.
    public void AddShape(int[,] shape)
    {
        //Gets half the length of the shape size so we can offset it from the center to get it more central.
        Point offset = new Point((int)Math.Floor((Double)(shape.GetLength(1) / 2)), (int)Math.Floor((Double)(shape.GetLength(0) / 2)));

        //Finds the position which is best to start from using this data.
        Point startPos = new Point(middleOfGrid.X - offset.X, middleOfGrid.Y - offset.Y);

        //Loops through the positions in the game arrays and sets the required cells to true.
        for (int i = 0; i < shape.GetLength(0); i++)
        {
            for (int j = 0; j < shape.GetLength(1); j++)
            {
                if (shape[i, j] == 1)
                {
                    currentState[startPos.X + j, startPos.Y + i] = true;
                    nextState[startPos.X + j, startPos.Y + i] = true;
                }
            }
        }
    }
}
