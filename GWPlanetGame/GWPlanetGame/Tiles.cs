using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GWPlanetGame
{
    internal struct TileData
    {
        string textureName;
        Rectangle location;
    }

    enum TileID { BLACK = 0, RED = 1, GREEN = 2, YELLOW = 3, BLUE = 4 };

    class Tiles
    {
        public const int TILE_WIDTH = 20;
        public const int TILE_HEIGHT = 20;
        Dictionary<TileID,TileData> TileInfo = new Dictionary<TileID,TileData>();
    }

    /// <summary>
    /// Interface for a drawable tile object. This will enable us to have
    /// tiles with special behavior (tiles that change depending on adjacent
    /// tiles, for instance. )
    /// </summary>
    interface ITile
    {
        void Draw();
    }
}