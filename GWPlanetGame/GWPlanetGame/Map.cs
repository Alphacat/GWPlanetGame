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

        public void DrawView(SpriteBatch spriteBatch, Texture2D texture, Camera camera, Point point)
        {
            // Start at the upper left corner of the drawing area and work our
            //  way across.

            // Helper variables
            int tileX = 0;  // These are the x and y coordinates of the tile we're working with
            int tileY = 0;

            TileID drawTile;    // What tile are we drawing?

            Rectangle destRect, sourceRect;

            // Bounds for the tile we're drawing.
            int leftbound, upbound, rightbound, downbound;

            for( int x = camera.X; x <= camera.X + camera.Width; x += Tiles.TILE_WIDTH )
                for (int y = camera.Y; y <= camera.Y + camera.Height; y += Tiles.TILE_HEIGHT)
                {
                    // First step, find out which tile we're dealing with.
                    tileX = (x >= 0) ? (x / Tiles.TILE_WIDTH) : (x / Tiles.TILE_WIDTH - 1);
                    tileY = (y >= 0) ? (y / Tiles.TILE_WIDTH) : (y / Tiles.TILE_WIDTH - 1);

                    // Is this tile actually in our map?
                    if ( 0 <= tileX && tileX < mapWidth && 0 <= tileY && tileY < mapHeight )
                        drawTile = data[tileX, tileY];
                    else
                        // Default for now will be the black tile.
                        drawTile = TileID.BLACK;

                    // Now that we have what tile we're drawing, we need to know what portion to draw.
                    // We'll check the tile's bounds against our camera rectangle.
                    // Nope. We're going to draw the whole thing for now, just to make it easier.
                    // ( I don't think bleeding over the edge of the screen a little will hurt. )
                    // Left bound
                    //leftbound = ( (tileX * Tiles.TILE_WIDTH) < camera.X) ? camera.X % Tiles.TILE_WIDTH : 0;
                    leftbound = 0;
                    // Upper bound
                    //upbound = ( (tileY * Tiles.TILE_HEIGHT) < camera.Y) ? camera.Y % Tiles.TILE_HEIGHT : 0;
                    upbound = 0;
                    // Right bound
                    //rightbound = (((tileX + 1) * Tiles.TILE_WIDTH) > camera.X + camera.Width) ?
                    //    camera.X % Tiles.TILE_WIDTH : Tiles.TILE_WIDTH;
                    rightbound = Tiles.TILE_HEIGHT;
                    // Lower bound
                    //downbound = (((tileY + 1) * Tiles.TILE_HEIGHT) > camera.Y + camera.Height) ?
                     //   camera.Y % Tiles.TILE_HEIGHT : Tiles.TILE_HEIGHT;
                    downbound = Tiles.TILE_HEIGHT;

                    destRect = new Rectangle(tileX * Tiles.TILE_WIDTH - camera.X + point.X,
                                                            tileY * Tiles.TILE_HEIGHT - camera.Y + point.Y,
                                                            rightbound - leftbound,
                                                            downbound - upbound);
                    sourceRect = new Rectangle(Tiles.TILE_WIDTH * (int)drawTile + leftbound,
                                                            0,
                                                            rightbound - leftbound,
                                                            downbound - upbound);

                    // Now that we've figured out the bounds of the tile to draw, we need to grab our
                    //  tile from the source, and draw it to the screen.
                    spriteBatch.Draw(texture, destRect, sourceRect, Color.White);
                    // Whew! Now on to the next loop.
                }
        }
    }
}
