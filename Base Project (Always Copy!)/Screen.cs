using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base_Project__Always_Copy__
{
    public partial class Screen : Form
    {

        //Thread Variables.
        Boolean Running = false;
        Thread thread = null;

        //Our State manager.
        Manager manager = new Manager();

        //The multiplier for the thread.sleep in the update thread.
        //This is used as we cannot extract a value directly from the
        //Slider in that thread.
        int speedModifier = 0;

        #region Function Explanation
        //Constructor, sets Screen size and then begins Thread.
        #endregion
        public Screen()
        {
            InitializeComponent();
            BeginThread();
            //Sets speedModifier to initial Slider Value.
            //Useful in the case we don't start it at 1.
            speedModifier = Slider.Value;
        }

        #region Function Explanation
        //Exit Event, kills Thread on Window close.
        #endregion
        private void OnExit(object sender, FormClosingEventArgs e)
        {
            killThread();
        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            manager.MouseClicked(e);
        }

        private void MouseMoved(object sender, MouseEventArgs e)
        {
            manager.MouseMoved(e);
        }

        private void Redraw(object sender, PaintEventArgs e)
        {
            manager.Redraw(e);
        }

        #region Function Explanation
        //Creates and starts a Thread.
        #endregion
        public void BeginThread()
        {
            thread = new Thread(new ThreadStart(Update));
            thread.Start();
            Running = true;
        }

        #region Function Explanation
        //Kills the thread.
        #endregion
        public void killThread()
        {
            //Simply kills off the Thread.
            Running = false;
            thread.Abort();
            thread.Join();
        }

        #region Function Explanation
        //The main Update loop. Basically just updates Manager which handles
        //all Game updates.
        #endregion
        public void Update()
        {
            while (Running)
            {
                manager.Update();
                
                //Cause screen to redraw.
                DrawScreen.Invalidate();

                //Basic Thread Slowing.
                Thread.Sleep(10 * speedModifier);
            }
        }

        private void Repaint(object sender, PaintEventArgs e)
        {
            manager.Redraw(e);
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            manager.MouseDown(e);
        }

        public void ResizeWindow(object sender, EventArgs e)
        {
            manager.ResizeWindow(e, this.DrawScreen.Height, this.DrawScreen.Width);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            manager.CurrentState.ClearGrid();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            manager.CurrentState.Pause(lblPaused);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        #region Function Explanation
        //Adjusts speedModifier. This is used as we cannot extract a value directly from the
        //Slider in that thread.
        #endregion
        private void Slider_Moved(object sender, EventArgs e)
        {
            speedModifier = Slider.Value;
        }

        #region Shape Click Events
        private void Block_Click(object sender, EventArgs e)
        {
            manager.CurrentState.LoadShapeClick("Block");
        }

        private void Beehive_Click(object sender, EventArgs e)
        {
            manager.CurrentState.LoadShapeClick("Beehive");
        }

        private void Loaf_Click(object sender, EventArgs e)
        {
            manager.CurrentState.LoadShapeClick("Loaf");
        }

        private void Boat_Click(object sender, EventArgs e)
        {
            manager.CurrentState.LoadShapeClick("Boat");
        }

        private void Blinker_Click(object sender, EventArgs e)
        {
            manager.CurrentState.LoadShapeClick("Blinker");
        }

        private void Toad_Click(object sender, EventArgs e)
        {
            manager.CurrentState.LoadShapeClick("Toad");
        }

        private void Beacon_Click(object sender, EventArgs e)
        {
            manager.CurrentState.LoadShapeClick("Beacon");
        }

        private void Pulsar_Click(object sender, EventArgs e)
        {
            manager.CurrentState.LoadShapeClick("Pulsar");
        }

        private void Glider_Click(object sender, EventArgs e)
        {
            manager.CurrentState.LoadShapeClick("Glider");
        }

        private void LWSS_Click(object sender, EventArgs e)
        {
            manager.CurrentState.LoadShapeClick("LWSS");
        }
        #endregion


    }
}
