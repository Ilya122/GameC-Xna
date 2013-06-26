using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;


namespace GameClasses
{
    [Serializable]
    public class SpriteButton
    {
        Sprite S1;
        Texture2D tex1;
        Texture2D tex2;

        public SpriteButton(Vector2 pos, Texture2D tex1, Texture2D tex2)
        {
            this.S1 = new Sprite(tex1, pos);
            this.tex1 = tex1;
            this.tex2 = tex2;
        }

        public void Update()
        {
            if (this.CheckCullosion(Mouse.GetState()))
            { this.S1.Tex = tex2; }
            else
            { this.S1.Tex = tex1; }
        }

        public void Draw(SpriteBatch sb)
        {
            this.S1.Draw(sb);
        }

        private bool CheckCullosion(MouseState ms)
        {
            //rect is the Rectangle of the font
            //rect2 is the rectangle of the mouse
            Rectangle rect = new Rectangle((int)S1.Pos.X, (int)S1.Pos.X
                , (int)S1.Tex.Width, (int)S1.Tex.Height);
            Rectangle rect2 = new Rectangle(ms.X, ms.Y, 1, 1);
            if (rect.Intersects(rect2))
                return true;
            else
                return false;
        }

        public bool CheckClick(MouseState ms)
        {
            if (ms.LeftButton == ButtonState.Pressed)
            { return CheckCullosion(ms); }
            else return false;
        }

    }
}
