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
        /// Used for drawing objects using world coordinates.
        /// This also reorients the camera's orientation to
        /// the center of the screen, instead of the upper-left
        /// corner.
        /// </summary>
        protected override void UpdateMatrix()
        {
            //_matrixtransform = Matrix.CreateTranslation(new Vector3(-X, -Y, 0)) *
            //    Matrix.CreateScale(new Vector3(_zoom, _zoom, 0)) *
            //    Matrix.CreateTranslation(new Vector3(Width / 2, Height / 2, 0));
            _matrixtransform = Matrix.CreateTranslation(new Vector3(-X, -Y, 0));
        }
    }
}
