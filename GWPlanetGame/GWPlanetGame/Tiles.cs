using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

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
}