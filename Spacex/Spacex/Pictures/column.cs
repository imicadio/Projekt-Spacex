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
            this.Position = new Vector2(250, 0); // ustawienie randomowo kolumn
        }

        public void Update()
        {
            
        }

        public void Draw()
        {
            Const.SPRITEBATCH.Draw(this.texture, this.Position, Color.White);            
        }
    }
}