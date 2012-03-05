using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GWPlanetGame
{
    /// <summary>
    /// Simple class for tracking and displaying FPS in the game.
    /// </summary>
    class FPSCounter
    {
        // Member variables

        // These are related to our FPS calculations
        private int _frames;
        private double _elapsedTime;
        private int _lastfps;

        // These are related to the drawing aspect
        Texture2D _numTexture;
        Rectangle _sizeRect;
        Color _color;

        #region Constructors

        /// <summary>
        /// Creates a new FPSCounter that will track and display FPS performance
        /// with every draw call.
        /// </summary>
        /// <param name="numberTexture">A texture file with the numbers arranged, in order, from 0-9, all the same size.</param>
        /// <param name="sizeRect">The size and starting position of the numbers on the texture.</param>
        /// <param name="color">The color to tint the numbers.</param>
        public FPSCounter(Texture2D numberTexture, Rectangle sizeRect, Color color)
        {
            _frames = 0;
            _elapsedTime = 0.0;
            _lastfps = 0;

            // FPSCounter expects a texture with numbers 0-9 arranged in a line, all the same height and width
            _numTexture = numberTexture;
            _sizeRect = sizeRect;
            _color = color;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Called at the start of Draw() to calculate the fps thus far. Seperated
        /// out to allow for more convenient upgrading of the logic should the need
        /// arise.
        /// </summary>
        /// <param name="gameTime">The elapsed Gametime object obtained from Draw().</param>
        private void CalcFPS( GameTime gameTime )
        {
            _elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            if ( _elapsedTime >= 1 )
            {
                _lastfps = (int)Math.Round(_frames/_elapsedTime);
                _frames = 0;
                _elapsedTime = 0.0;                
            }
            _frames++;
        }

        /// <summary>
        /// The draw method for the FPSCounter. Calculates and then
        /// displays to the top-left corner of the screen.
        /// TODO: Move the spritebatch Begin() and End() calls inside?
        /// Less depending knowledge outside of how to instantiate the camera properly.
        /// </summary>
        /// <param name="gameTime">The elapsed game time, per the Game classes's Draw method.</param>
        /// <param name="spriteBatch">A primed SpriteBatch to draw with.</param>
        /// <param name="guiCamera">A camera set up to draw to regular screen coordinates.</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Camera guiCamera)
        {
            CalcFPS(gameTime);

            // Then we do our drawing.
            int i = 1;
            int frames = _lastfps;
            int currDigit = 0;
            do
            {
                currDigit = frames % 10;

                spriteBatch.Draw(
                    _numTexture,
                    new Vector2(guiCamera.Width - i * _sizeRect.Width, 0),
                    new Rectangle(_sizeRect.X + currDigit * _sizeRect.Width,
                        _sizeRect.Y,
                        _sizeRect.Width,
                        _sizeRect.Height),
                    _color,
                    0.0f,
                    new Vector2(),
                    1.0f,
                    SpriteEffects.None,
                    Layers.GUI_FPS
                );

                frames /= 10;
                i++;
            } while (frames != 0);
        }
        #endregion
    }
}
