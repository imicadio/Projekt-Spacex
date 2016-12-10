﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex
{
    class Const
    {
        public static int GAME_WIDTH = 400;
        public static int GAME_HEIGHT = 600;
        public static string TITLE = "Spacex";

        public static GameTime GAMETIME;
        public static SpriteBatch SPRITEBATCH;
        public static ContentManager CONTENT;
        public static GraphicsDevice GRAPHICSDEVICE;

        public static Manager.InputManager INPUT;
    }
}