using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GWPlanetGame
{
    class Camera
    {
        Rectangle viewingArea;

        #region Constructors
        public Camera(Rectangle rectangle)
        {
            viewingArea = rectangle;
        }

        public Camera(int width, int height)
        {
            viewingArea = new Rectangle( 0, 0, width, height );
        }
        #endregion


        public void SetMidpoint( int x, int y )
        {
            viewingArea.X = ( x - viewingArea.Width/2 );
            viewingArea.Y = ( y - viewingArea.Height/2 );
        }

        public void SetPoint(int x, int y)
        {
            viewingArea.X = x;
            viewingArea.Y = y;
        }

        #region Properties
        public int Width
        {
            get { return viewingArea.Width; }
            set { viewingArea.Width = value; }
        }

        public int Height
        {
            get { return viewingArea.Height; }
            set { viewingArea.Height = value; }
        }

        public int X
        {
            get { return viewingArea.X; }
            set { viewingArea.X = value; }
        }

        public int Y
        {
            get { return viewingArea.Y; }
            set { viewingArea.Y = value; }
        }
        #endregion
    }
}
