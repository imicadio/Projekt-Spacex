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
        public Pictures.scroll scroll;


        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            //Wczytanie textur
            background = Const.CONTENT.Load<Texture2D>("Texture/background");
            spacecraft = new Pictures.spacecraft();
            scroll = new Pictures.scroll();

            base.LoadContent();
        }

        public override void Update()
        {
            spacecraft.Update();
            scroll.Update();
            base.Update();
        }


        // w metodzie Draw() umieszczone są tła, statki, wynik czy scroll
        public override void Draw()
        {
            // scroll pasek, żeby się cały czas przewijał
            Const.SPRITEBATCH.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, null, null);

            Const.SPRITEBATCH.Draw(this.background, Vector2.Zero, Color.White);

            scroll.Draw();
            spacecraft.Draw();

            Const.SPRITEBATCH.End();
            base.Draw();
        }
    }
}