using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex.Screens
{
    class GameScreen : Screen
    {
        public Texture2D background;


        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            //Wczytanie textur

            background = Const.CONTENT.Load<Texture2D>("Texture/background");

            base.LoadContent();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw() // w metodzie Draw() umieszczone są tła, statki, wynik czy scroll
        {
            Const.SPRITEBATCH.Begin();

            Const.SPRITEBATCH.Draw(this.background, Vector2.Zero, Color.White);

            Const.SPRITEBATCH.End();
            base.Draw();
        }
    }
}