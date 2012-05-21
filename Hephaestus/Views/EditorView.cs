using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Hephaestus.Views
{
    abstract public class EngineView
    {
        protected GraphicsDevice _graphicsDevice;

        abstract public void Update(float elapsedTime);

        abstract public void Draw(float elapsedTime);
    }

    public class EditorView : EngineView
    {
        public EditorView(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public override void Update(float elapsedTime)
        {
            _graphicsDevice.Clear(Microsoft.Xna.Framework.Color.Cyan);
        }

        public override void Draw(float elapsedTime)
        {
        }
    }

    public class GameView : EngineView
    {
        public GameView(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public override void Update(float elapsedTime)
        {
            _graphicsDevice.Clear(Microsoft.Xna.Framework.Color.DarkBlue);
        }

        public override void Draw(float elapsedTime)
        {
        }
    }
}
