using System;
using System.Collections.Generic;
using Hephaestus.Views;
using Microsoft.Xna.Framework.Graphics;

namespace Hephaestus
{
    public static class ViewManager
    {
        static List<EngineView> _views;

        static ViewManager()
        {
            _views = new List<EngineView>();
        }

        public static EditorView GetEditorView(GraphicsDevice graphicsDevice)
        {
            EditorView view = new EditorView(graphicsDevice);
            _views.Add(view);
            return view;
        }

        public static GameView GetGameView(GraphicsDevice graphicsDevice)
        {
            GameView view = new GameView(graphicsDevice);
            _views.Add(view);
            return view;
        }
    }
}
