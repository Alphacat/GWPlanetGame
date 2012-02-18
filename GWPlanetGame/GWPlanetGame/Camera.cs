using System;
using Microsoft.Xna.Framework;

namespace GWPlanetGame
{
    /// <summary>
    /// Camera class for the game. Indicates a world position and
    /// screen size to draw. Has some utility functions for getting/setting
    /// the middle camera point, and others.
    /// </summary>
    class Camera
    {
        /// <summary>
        /// 
        /// </summary>
        private Vector2 mapPoint, screenSize;

        #region Constructors
        /// <summary>
        /// Constructor to set camera state based off an existing rectangle
        /// </summary>
        /// <param name="rectangle">Rectangle representing initial coordinate and screen size.</param>
        public Camera(Rectangle rectangle)
        {
            mapPoint = new Vector2( (float) rectangle.X, (float) rectangle.Y);
            screenSize = new Vector2( (float) rectangle.Width, (float) rectangle.Height);
        }

        /// <summary>
        /// Constructor to set camera state at (X,Y) = (0,0) by default, with width and height.
        /// </summary>
        /// <param name="width">Width of screen in pixels.</param>
        /// <param name="height">Height of screen in pixels.</param>
        public Camera(int width, int height)
        {
            mapPoint = new Vector2(0, 0);
            screenSize = new Vector2((float)width, (float)height);
        }

        /// <summary>
        /// Constructor to set camera state with four float parameters.
        /// </summary>
        /// <param name="x">Initial x camera point.</param>
        /// <param name="y">Initial y camera point.</param>
        /// <param name="width">Initial screen width.</param>
        /// <param name="height">Initial screen height.</param>
        public Camera(float x, float y, float width, float height)
        {
            mapPoint = new Vector2(x, y);
            screenSize = new Vector2(width, height);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a rectangle representing the camera's position
        /// and size smoothed out to integer values. This is to
        /// assist in grabbing textures, which SpriteBatch wants in
        /// whole pixel amounts.
        /// </summary>
        /// <returns>A rectangle representing the camera's position and area smoothed to whole integers.</returns>
        Rectangle getRectangle()
        {
            Rectangle tempRect = new Rectangle();
            // Here we round down (left and up, respectively).
            tempRect.X = (int)Math.Floor(X);
            tempRect.Y = (int)Math.Floor(Y);
            // Here we round up (right and down, respectively).
            tempRect.Width = (int)Math.Ceiling(Width);
            tempRect.Height = (int)Math.Ceiling(Height);
            return tempRect;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Property to get and set the camera width manually.
        /// </summary>
        public float Width
        {            
            get { return screenSize.X; }
            set { screenSize.X = value; }
        }

        /// <summary>
        /// Property to get and set the camera height manually.
        /// </summary>
        public float Height
        {
            get { return screenSize.Y; }
            set { screenSize.Y= value; }
        }

        /// <summary>
        /// Property to get and set the camera size manually, represented as
        /// an (X,Y) coordinate pair by a Vector2.
        /// </summary>
        public Vector2 ScreenSize
        {
            get { return screenSize; }
            set { screenSize = value; }
        }

        /// <summary>
        /// Property to get and set the camera's X coordinate manually.
        /// </summary>
        public float X
        {
            get { return mapPoint.X; }
            set { mapPoint.X = value; }
        }

        /// <summary>
        /// Property to get and set the camera's X coordinate manually.
        /// </summary>
        public float Y
        {
            get { return mapPoint.Y; }
            set { mapPoint.Y = value; }
        }

        /// <summary>
        /// Property to get and set the camera's midpoint as a Vector
        /// representing its (X,Y) coordinate pair. Intended to be a 
        /// quick way to have the camera 'look' at an object (like the player.)
        /// </summary>
        public Vector2 Midpoint
        {
            get { return new Vector2( X + Width / 2, Y + Height / 2 ); }
            set {
                mapPoint.X = ( value.X - screenSize.X/2 );
                mapPoint.Y = ( value.Y - screenSize.Y/2 );
            }
        }
        #endregion
    }
}
