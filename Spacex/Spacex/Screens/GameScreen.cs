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
        public Texture2D floor;
        public Pictures.spacecraft spacecraft;
        public Pictures.scroll scroll;
        public List<Pictures.column> column;

        public int column_time = 2000;
        public double column_passage = 0;


        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            //Wczytanie textur
            background = Const.CONTENT.Load<Texture2D>("Texture/background");
            floor = Const.CONTENT.Load<Texture2D>("Texture/floor");
            spacecraft = new Pictures.spacecraft();
            scroll = new Pictures.scroll();
            column = new List<Pictures.column>();
            column.Add(new Pictures.column());

            base.LoadContent();
        }

        public override void Update()
        {
            Create_Column();            
            for (int i = column.Count - 1; i > -1; i--) // kolumny 
            {
                if (column[i].Position.X < -50)
                    column.RemoveAt(i);
                else
                {
                    column[i].Update();                     
                }
            }

            spacecraft.Update();
            scroll.Update();
            
            base.Update();
        }


        public void Create_Column() // tworzy kolumny
        {
            column_passage += Const.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (column_passage > column_time)
            {
                column.Add(new Pictures.column());
                column_passage = 0;
            }
        }


        // w metodzie Draw() umieszczone są tła, statki, wynik czy scroll
        public override void Draw()
        {
            // scroll pasek, żeby się cały czas przewijał
            Const.SPRITEBATCH.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, null, null); // scroll pasek, żeby się cały czas przewijał

            Const.SPRITEBATCH.Draw(this.background, Vector2.Zero, Color.White); // tło

            foreach (var item in column) // kolumny
            {
                item.Draw();
            }

            scroll.Draw();
            spacecraft.Draw();

            Const.SPRITEBATCH.End();
            base.Draw();
        }
    }
}