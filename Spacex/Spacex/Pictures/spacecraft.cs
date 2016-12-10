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

        public int jump_time = 500;
        public double jump_fall = 0;

        public bool jump = true;

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

            // dzięki temu skacze w górę i opada
            jump_fall += Const.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if (jump_fall > jump_time)
            {
                jump = true;
                jump_fall = 0;
            }

            // spacja powoduje skok
            if (Const.INPUT.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.Space) && jump)
            {
                Yfall = -5;
            }

            // obrót statku
            if (Yfall > 0f)
                Rotation = 0.1f;
            else
                Rotation = -0.1f;

            // dzęki temu statek spada
            this.Position.Y += Yfall;

        }

        public void Draw()
        {
            Const.SPRITEBATCH.Draw(this.Texture[this.texture_Position], this.Position, null, Color.White, this.Rotation, new Vector2(20, 20), 1f, SpriteEffects.None, 0f);
        }
    }
}