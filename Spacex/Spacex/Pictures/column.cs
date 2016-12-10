using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex.Pictures
{
    public class column
    {
        public Texture2D texture;
        public Vector2 Position;

        public column()
        {
            this.texture = Const.CONTENT.Load<Texture2D>("Texture/column"); // wczytanie kolumn
            this.Position = new Vector2(420, Const.RANDOM.Next(-200, 5)); // ustawienie randomowo kolumn
        }

        public void Update()
        {
            this.Position.X -= 2f; // pozycja odległości od siebie
        }

        public void Draw()
        {
            Const.SPRITEBATCH.Draw(this.texture, this.Position, Color.White);            
        }
    }
}