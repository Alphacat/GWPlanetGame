using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GWPlanetGame
{
    class Map
    {
        TileID[,] data;
        int mapWidth, mapHeight;
        Random maprand;

        public Map(int width, int height)
        {
            data = new TileID[width, height];
            mapWidth = width;
            mapHeight = height;

            maprand = new Random();
        }

        public void MapFillRandom()
        {
            for( int i = 0; i < mapWidth; i++ )
                for ( int j = 0; j < mapHeight; j++ )
                {
                    data[i,j] = (TileID) maprand.Next(0,5);
                }
        }

        public void MapFillPattern1()
        {
            for ( int i = 0; i < mapWidth; i++ )
                for ( int j = 0; j < mapHeight; j++ )
                {
                    data[i,j] = (TileID) ( (i+j) % 5 );
                }

        }

        public void DrawView(SpriteBatch spriteBatch, Texture2D texture )
        {
            // The old method examined everything in the array and figured out its destination.
            // Instead, we're now going to use the camera transform to take care of this logic
            // for us, and instead just draw everything without regard for where it goes.

            // Helper variables
            TileID drawTile;    // What tile are we drawing?

            Rectangle sourceRect;

            for ( int x = 0; x < mapWidth; x ++ )
                for (int y = 0; y < mapHeight; y++)
                {
                    drawTile = data[x,y];

                    // Build a sourcerect for the tile
                    sourceRect = new Rectangle(Tiles.TILE_WIDTH * (int)drawTile, 0,
                        Tiles.TILE_WIDTH, Tiles.TILE_HEIGHT);
                    spriteBatch.Draw(texture, new Vector2(x * Tiles.TILE_WIDTH, y * Tiles.TILE_HEIGHT),
                        sourceRect, Color.White);
                }
        }
    }
}
