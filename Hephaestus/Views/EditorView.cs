using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Hephaestus.Views
{
    class EditorView
    {
        GraphicsDevice _graphicsDevice;

        public EditorView(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public void Update(float elapsedTime)
        {
            _graphicsDevice.Clear(Microsoft.Xna.Framework.Color.Beige);
        }

        public void Draw(float elapsedTime)
        {
        }
    }
}
