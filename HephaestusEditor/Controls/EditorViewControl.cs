#region File Description
/*
 * EditorViewControl.cs
 * 
 * Retrieves an Editor view from the Hephaestus engine
 * and then displays it into a Windows form.
 */
#endregion

#region Using Statements
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Hephaestus.Views;
#endregion

namespace HephaestusEditor.Controls
{
    /// <summary>
    /// EditorViewControl is a Windows Form control for displaying
    /// an Editor View retrieved from the Hephaestus engine.
    /// </summary>
    class EditorViewControl : GraphicsDeviceControl
    {
        BasicEffect effect;
        Stopwatch timer;
        float lastTime = 0.0f;
        EditorView editorView;
        
        /// <summary>
        /// Initializes the control.
        /// </summary>
        protected override void Initialize()
        {
            effect = new BasicEffect(this.GraphicsDevice);

            // Get our editor view.
            editorView = Hephaestus.ViewManager.GetEditorView(this.GraphicsDevice);

            // Start editor timer
            timer = Stopwatch.StartNew();

            // Hook the idle event to keep redrawing the animation
            Application.Idle += delegate { Invalidate(); };
        }

        /// <summary>
        /// Draws the control.
        /// </summary>
        protected override void Draw()
        {
            // Find out how much time has elapsed.
            float time = (float)timer.Elapsed.Seconds;
            float deltaTime = time - lastTime;
            lastTime = time;

            // Update the game engine, and then render it to the surface.
            editorView.Update(deltaTime);
            editorView.Draw(deltaTime);
        }
    }
    
}