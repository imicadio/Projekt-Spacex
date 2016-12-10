using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex.Pictures
{
    public class spacecraft
    {
        public Texture2D[] Texture;
        public int texture_Position;
        public Vector2 Position;
        public float Rotation;
        public float Yfall;

        public spacecraft()
        {
            // wczytuje textury statka
            Texture = new Texture2D[3];
            this.Texture[0] = Const.CONTENT.Load<Texture2D>("Texture/spacecraft");
            this.Texture[1] = Const.CONTENT.Load<Texture2D>("Texture/spacecraft1");
            this.Texture[2] = Const.CONTENT.Load<Texture2D>("Texture/spacecraft2");

            this.Position = new Vector2(150, 300); // pozycja statka
        }

        public void Update()
        {
            // szybkość spadania
            Yfall += 0.2f;

            // obrót statku
            if (Yfall > 0f)
                Rotation = 0.5f;
            else
                Rotation = -0.5f;

            // dzęki temu statek spada
            this.Position.Y += Yfall;

        }

        public void Draw()
        {
            Const.SPRITEBATCH.Draw(this.Texture[this.texture_Position], this.Position, null, Color.White, this.Rotation, new Vector2(20, 20), 1f, SpriteEffects.None, 0f);
        }
    }
}