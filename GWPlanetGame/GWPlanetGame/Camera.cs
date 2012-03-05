using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GWPlanetGame
{
    /// <summary>
    /// Camera class for the game. Has an overrideable method to
    /// control the matrix calculation the game uses for SpriteBatches.
    /// </summary>
    class Camera
    {
        // Reference to the current game's graphic device
        protected GraphicsDevice _graphicsDevice;

        // Camera's position
        protected Vector2 _point;

        // Camera's transform property.
        protected Matrix _matrixtransform;

        // Camera's zoom value.
        protected float _zoom;

        #region Constructors
        /// <summary>
        /// Constructor for our camera class.
        /// </summary>
        /// <param name="game"></param>
        public Camera( GraphicsDevice graphicsDevice )
        {
            _graphicsDevice = graphicsDevice;
            _point = new Vector2( 0.0f, 0.0f );
            _zoom = 1.0f;

            UpdateMatrix();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Returns a rectangle representing the camera's position
        /// and size smoothed out to integer values. This is to
        /// assist in grabbing textures, which SpriteBatch wants in
        /// whole pixel amounts.
        /// Override this if you modify your Matrix to
        /// orient the camera differently.
        /// TODO: See if there's a way to calculate this automatically based on the matrix transform.
        /// </summary>
        /// <returns>A rectangle representing the camera's position and area smoothed to whole integers.</returns>
        public virtual Rectangle getRectangle()
        {
            Rectangle tempRect = new Rectangle();
            // Here we round down (left and up, respectively).
            tempRect.X = (int)Math.Floor(X);
            tempRect.Y = (int)Math.Floor(Y);
            // Here we round up (right and down, respectively).
            tempRect.Width = (int)Math.Ceiling(X + Width);
            tempRect.Height = (int)Math.Ceiling(Y + Height);
            return tempRect;
        }

        /// <summary>
        /// Recalculate the camera's transformation matrix. Use this
        /// any time the camera's position or zoom factor is altered.
        /// TODO: Make this respond to window size events.
        /// </summary>
        protected virtual void UpdateMatrix()
        {
            _matrixtransform = Matrix.Identity;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Property to get the camera width manually.
        /// </summary>
        public float Width
        {            
            get { return _graphicsDevice.Viewport.Width; }
        }

        /// <summary>
        /// Property to get the camera height manually.
        /// </summary>
        public float Height
        {
            get { return _graphicsDevice.Viewport.Height; }
        }

        /// <summary>
        /// Property to get the camera size manually, represented as
        /// an (X,Y) coordinate pair by a Vector2.
        /// </summary>
        public Vector2 ScreenSize
        {
            get { return new Vector2(Width, Height); }
        }

        /// <summary>
        /// Property to get and set the camera's X coordinate manually.
        /// </summary>
        public float X
        {
            get { return _point.X; }
            set { _point.X = value; UpdateMatrix(); }
        }

        /// <summary>
        /// Property to get and set the camera's X coordinate manually.
        /// </summary>
        public float Y
        {
            get { return _point.Y; }
            set { _point.Y = value; UpdateMatrix(); }
        }

        /// <summary>
        /// Property to get and set the camera's position as
        /// an (X,Y) coordinate pair represented by a Vector2.
        /// </summary>
        public Vector2 Point
        {
            get { return _point; }
            set { _point = value; UpdateMatrix(); }
        }

        /// <summary>
        /// Fetch the camera's transform matrix.
        /// </summary>
        public Matrix Transform
        {
            get { return _matrixtransform; }
        }
        #endregion
    }
}
