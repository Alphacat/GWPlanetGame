using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GWPlanetGame
{
    /// <summary>
    /// An enumeration for keeping track of all of the layers present in the game.
    /// These need to be divided out (and cast) to use them in SpriteBatch.Draw()
    /// though. We should be able to add and remove items from this list and keep
    /// the ordering consistent.
    /// </summary>
    static class Layers
    {
        public const float GUI_FPS = 0.0f;
        public const float GUI = 0.1f;
        public const float FLYING = 0.2f;
        public const float CLIMBING = .3f;
        public const float ENTITIES = .4f;
        public const float DIGGING = .5f;
        public const float FLOOR = .6f;
        public const float GROUND = .7f;
        public const float BACKGROUND = .8f;

    };
}
