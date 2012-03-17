using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GWPlanetGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Member Variables
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

       // This is a texture we can render
        Texture2D myTexture;
        Texture2D numbers;

        // Map variables
        Tilemap terrain;
        WorldCamera worldCamera;

        // FPS counter
        Camera guiCamera;
        FPSCounter fpsCounter;
        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferMultiSampling = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Initialize camera
            worldCamera = new WorldCamera(this.GraphicsDevice);

            guiCamera = new Camera(this.GraphicsDevice);
            
            base.Initialize();

            // We need to move this down because we need LoadContent to load up numbers.
            fpsCounter = new FPSCounter(numbers, new Rectangle(0, 0, 8, 10), Color.Yellow);
            
            // Initialize random map data for testing
            terrain = new Tilemap(1000, 1000, myTexture);
            terrain.MapFillPattern1();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            myTexture = Content.Load<Texture2D>("Textures/TempTerrain");
            numbers = Content.Load<Texture2D>("Textures/Numbers");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            Vector2 diag = new Vector2(100,100);
            //diag.Normalize();

            worldCamera.Point += diag * (float)gameTime.ElapsedGameTime.TotalSeconds;


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Violet);

            // TODO: Add your drawing code here
            // Draw the sprite
            
            // Initialize the spriteBatch with our camera transform
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, worldCamera.Transform);

            // Pass the spritebatch and have it draw the terrain
            terrain.Draw(spriteBatch, worldCamera);
            spriteBatch.End();
            
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null, guiCamera.Transform);
            fpsCounter.Draw(gameTime, spriteBatch, guiCamera);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
