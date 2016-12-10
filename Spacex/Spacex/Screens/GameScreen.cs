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

        public SpriteFont font;
        public int score = 0;

        public int column_time = 2000;
        public double column_passage = 0;

        public bool Game_Over = false;


        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            //Wczytanie textur
            background = Const.CONTENT.Load<Texture2D>("Texture/background");
            floor = Const.CONTENT.Load<Texture2D>("Texture/floor");
            font = Const.CONTENT.Load<SpriteFont>("Font/Font");
            spacecraft = new Pictures.spacecraft();
            scroll = new Pictures.scroll();
            column = new List<Pictures.column>();
            column.Add(new Pictures.column());
            score = 0;
            Game_Over = false;

            base.LoadContent();
        }

        public override void Update()
        {
            // poniżej został umieszczony kod który odpowiada za wynik, zniszczenie statku, pozycje kolumn
            Create_Column();
            if (!Game_Over)
            {
                for (int i = column.Count - 1; i > -1; i--) // kolumny 
                {
                    if (column[i].Position.X < -50)
                        column.RemoveAt(i);
                    else
                    {
                        column[i].Update();

                        if (!column[i].wynik && spacecraft.Position.X > column[i].Position.X + 50)
                        {
                            column[i].wynik = true;
                            score++;
                            // statek przeszedł to i wynik się zwiększa przez przejście przez kolumnę
                        }

                        if (spacecraft.Limit.Intersects(column[i].Upper_Limit) || spacecraft.Limit.Intersects(column[i].Lower_Limit))
                        {
                            // statek zniszczony bo dotknął kolumny albo dolnej i górnej granicy
                            Game_Over = true;
                        }
                    }
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

            Const.SPRITEBATCH.Draw(this.floor, new Vector2(0, 529), Color.White);
            scroll.Draw();
            spacecraft.Draw();

            // napis na górze "wynik"
            Const.SPRITEBATCH.DrawString(this.font, "Wynik: " + this.score.ToString(), new Vector2(10, 10), Color.Yellow);

            Const.SPRITEBATCH.End();
            base.Draw();
        }
    }
}