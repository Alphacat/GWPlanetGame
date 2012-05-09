using System;
using System.Collections.Generic;
using Hephaestus.Views;
using Microsoft.Xna.Framework.Graphics;

namespace Hephaestus
{
    static class ViewManager
    {
        static List<EditorView> _views;

        static public ViewManager()
        {
            _views = new List<EditorView>();
        }

        public EditorView GetEditorView( GraphicsDevice graphicsDevice )
        {
            EditorView view = new EditorView(graphicsDevice);
            _views.Add(view);
            return view;
        }
    }
}
