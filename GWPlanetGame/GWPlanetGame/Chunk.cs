using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GWPlanetGame
{
    /// <summary>
    /// Class for managing verticalslices of the terrain.
    /// In a really rough state at the moment and needs more polish.
    /// </summary>
    class Chunk
    {
        public TileID _tile;

        public Chunk()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Texture2D terrainTexture, int X, int Y)
        {
            spriteBatch.Draw(terrainTexture,
                new Vector2(X, Y),
                new Rectangle(Tiles.TILE_WIDTH * (int)_tile, 0,
                    Tiles.TILE_WIDTH, Tiles.TILE_HEIGHT),
                    Color.White);
        }
    }
}
