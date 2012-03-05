﻿using System;
using Microsoft.Xna.Framework;

namespace GWPlanetGame
{
    /// <summary>
    /// Camera class for the game. The camera coordinates
    /// represent the center point that the camera is focued
    /// on.
    /// </summary>
    class Camera
    {
        // Reference to the current game instance
        private Game _game;

        // Camera's position
        private Vector2 _point;

        // Camera's transform property.
        private Matrix _matrixtransform;

        // Camera's zoom value.
        private float _zoom;

        #region Constructors
        /// <summary>
        /// Constructor for our camera class.
        /// </summary>
        /// <param name="game"></param>
        public Camera( Game game )
        {
            _game = game;
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
        /// </summary>
        /// <returns>A rectangle representing the camera's position and area smoothed to whole integers.</returns>
        public Rectangle getRectangle()
        {
            Rectangle tempRect = new Rectangle();
            // Here we round down (left and up, respectively).
            tempRect.X = (int)Math.Floor(X - Width/2);
            tempRect.Y = (int)Math.Floor(Y - Height/2);
            // Here we round up (right and down, respectively).
            tempRect.Width = (int)Math.Ceiling(X + Width/2);
            tempRect.Height = (int)Math.Ceiling(Y + Height/2);
            return tempRect;
        }

        /// <summary>
        /// Recalculate the camera's transformation matrix. Use this
        /// any time the camera's position or zoom factor is altered.
        /// TODO: Make this respond to window size events.
        /// </summary>
        private void UpdateMatrix()
        {
            _matrixtransform = Matrix.CreateTranslation(new Vector3(-X, -Y, 0)) *
                Matrix.CreateScale(new Vector3(_zoom, _zoom, 0)) *
                Matrix.CreateTranslation(new Vector3(Width / 2, Height / 2, 0));
        }
        #endregion

        #region Properties
        /// <summary>
        /// Property to get the camera width manually.
        /// </summary>
        public float Width
        {            
            get { return _game.GraphicsDevice.Viewport.Width; }
        }

        /// <summary>
        /// Property to get the camera height manually.
        /// </summary>
        public float Height
        {
            get { return _game.GraphicsDevice.Viewport.Height; }
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
