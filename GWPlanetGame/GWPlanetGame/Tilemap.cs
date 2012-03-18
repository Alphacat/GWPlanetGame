using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GWPlanetGame
{
    /// <summary>
    /// A class for managing and drawing a tilemap to screen.
    /// TODO: Use a generic interface to make it possible to
    /// replace the array elements with different classes.
    /// </summary>
    class Tilemap
    {

        Chunk[,] _data;
        int _mapWidth, _mapHeight;
        Texture2D _terrainTexture;
        
        Random _maprand;

        /// <summary>
        /// Creates an 'empty' tilemap.
        /// </summary>
        /// <param name="width">Width of the tilemap.</param>
        /// <param name="height">Height of the tilemap.</param>
        public Tilemap(int width, int height, Texture2D terrainTexture)
        {
            _data = new Chunk[width, height];
            _mapWidth = width;
            _mapHeight = height;

            _terrainTexture = terrainTexture;

            _maprand = new Random();
        }

        /// <summary>
        /// Temporary helper function. This is just to aid
        /// in testing until a proper saver/loader can be
        /// written.
        /// </summary>
        public void MapFillRandom()
        {
            for( int i = 0; i < _mapWidth; i++ )
                for (int j = 0; j < _mapHeight; j++)
                {
                    _data[i, j] = new Chunk();
                    _data[i,j]._tile = (TileID)_maprand.Next(0, 5);
                }
        }
        
        /// <summary>
        /// Temporary helper function. This is just to aid
        /// in testing until a proper saver/loader can be
        /// written.
        /// </summary>
        public void MapFillPattern1()
        {
            for (int i = 0; i < _mapWidth; i++)
                for (int j = 0; j < _mapHeight; j++)
                {
                    _data[i, j] = new Chunk();
                    _data[i,j]._tile = (TileID)((i + j) % 5);
                }
        }

        /// <summary>
        /// Draw the terrain out, using the spritebatch and
        /// specified world camera.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="worldCamera"></param>
        public void Draw(SpriteBatch spriteBatch, WorldCamera worldCamera)
        {
            Rectangle viewRect = worldCamera.getRectangle();

            int iStart = ( viewRect.Left < 0)?(int)Math.Floor(viewRect.Left / (float)Tiles.TILE_WIDTH): viewRect.Left/Tiles.TILE_WIDTH;
            int iEnd = (viewRect.Left < 0) ? (int)Math.Floor(viewRect.Right / (float)Tiles.TILE_WIDTH) : viewRect.Right / Tiles.TILE_WIDTH;
            int jStart = (viewRect.Top < 0) ? (int)Math.Floor(viewRect.Top / (float)Tiles.TILE_HEIGHT) : viewRect.Top / Tiles.TILE_HEIGHT;
            int jEnd = (viewRect.Bottom < 0) ? (int)Math.Floor(viewRect.Bottom / (float)Tiles.TILE_HEIGHT) : viewRect.Bottom / Tiles.TILE_HEIGHT;
            /*// Test to make we're not trying to draw empty space.
            if ( iStart < 0 ) iStart = 0;
            // If starting point is to the right of the map, then none of it will be visible.
            else if ( iStart >= _mapWidth ) return;

            int jStart = viewRect.Top / Tiles.TILE_HEIGHT;
            if ( jStart < 0 ) jStart = 0;
            else if ( jStart >= _mapHeight ) return;


            int iEnd = viewRect.Right / Tiles.TILE_WIDTH;
            if (iEnd >= _mapWidth) iEnd = _mapWidth;
            else if (iEnd < 0) return;

            int jEnd = viewRect.Bottom / Tiles.TILE_HEIGHT;
            if (jEnd >= _mapHeight) jEnd = _mapHeight;
            else if (jEnd < 0) return;
             */


            for (int i = iStart; i <= iEnd; i++)
                for (int j = jStart; j <= jEnd; j++)
                {
                    if (i < 0 || i >= _mapWidth || j < 0 || j >= _mapHeight)
                        continue;
                    _data[i, j].Draw(spriteBatch, _terrainTexture, i * Tiles.TILE_WIDTH, j * Tiles.TILE_HEIGHT);
                }
        }
    }
}
