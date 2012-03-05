using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GWPlanetGame
{
    class WorldCamera : Camera
    {
        public WorldCamera(GraphicsDevice graphicsDevice)
            : base(graphicsDevice)
        { }

        /// <summary>
        /// Returns a rectangle representing the camera's position
        /// and size smoothed out to integer values. This is to
        /// assist in grabbing textures, which SpriteBatch wants in
        /// whole pixel amounts.
        /// TODO: Redo the math if the zoom feature is implemented.
        /// </summary>
        /// <returns>A rectangle representing the camera's position and area smoothed to whole integers.</returns>
        public override Rectangle getRectangle()
        {
            Rectangle tempRect = new Rectangle();
            // Here we round down (left and up, respectively).
            tempRect.X = (int)Math.Floor(X - Width / 2);
            tempRect.Y = (int)Math.Floor(Y - Height / 2);
            // Here we round up (right and down, respectively).
            tempRect.Width = (int)Math.Ceiling(X + Width / 2);
            tempRect.Height = (int)Math.Ceiling(Y + Height / 2);
            return tempRect;
        }

        /// <summary>
        /// Used for drawing objects using world coordinates.
        /// This also reorients the camera's orientation to
        /// the center of the screen, instead of the upper-left
        /// corner.
        /// </summary>
        protected override void UpdateMatrix()
        {
            _matrixtransform = Matrix.CreateTranslation(new Vector3(-X, -Y, 0)) *
                Matrix.CreateScale(new Vector3(_zoom, _zoom, 0)) *
                Matrix.CreateTranslation(new Vector3(Width / 2, Height / 2, 0));
        }
    }
}
