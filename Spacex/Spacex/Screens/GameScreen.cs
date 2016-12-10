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
        public Pictures.spacecraft spacecraft;


        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            //Wczytanie textur
            background = Const.CONTENT.Load<Texture2D>("Texture/background");
            spacecraft = new Pictures.spacecraft();

            base.LoadContent();
        }

        public override void Update()
        {
            spacecraft.Update();
            base.Update();
        }


        // w metodzie Draw() umieszczone są tła, statki, wynik czy scroll
        public override void Draw()
        {
            Const.SPRITEBATCH.Begin();

            Const.SPRITEBATCH.Draw(this.background, Vector2.Zero, Color.White);

            spacecraft.Draw();

            Const.SPRITEBATCH.End();
            base.Draw();
        }
    }
}