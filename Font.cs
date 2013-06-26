using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameClasses
{
    [Serializable]
    public class Font
    {
        /*    VARIBLES    */
        protected SpriteFont font;
        protected Vector2 position;
        protected string Text = "";
        protected Color color;
        /*----------------*/

        //Constructors
        public Font(SpriteFont font, Vector2 pos, string text)
        {
            this.font = font;
            this.position = pos;
            this.Text = text;
        }

        public Font(SpriteFont font, Vector2 pos, string text, Color color)
        {
            this.font = font;
            this.position = pos;
            this.Text = text;
            this.color = color;
        }


        //Method:
        //Returns the center of the font
        public Vector2 FontCenter()
        {
            //Returns a new Vector2 Instance with the center x and y axis.
            return new Vector2((this.font.MeasureString(this.Text).X / 2)
            , (this.font.MeasureString(this.Text).Y / 2));
        }
        //Returns the position of the font in the center of the screen
        public float FontCenterOfScreen(Game game)
        {
            Vector2 v2 = this.font.MeasureString(this.Text)/2;
            float xCenterPos = game.Window.ClientBounds.Width / 2;
            return xCenterPos - v2.X;

        }

        //Returns the Text of the button
        public string TEXT { get { return this.Text; } set { this.Text = value; } }
        //Returns the color
        public Color Color { get { return this.color; } set { this.color = value; } }
        //Draws the font.
        public virtual void Draw(SpriteBatch sb)
        { sb.DrawString(this.font, this.Text, this.position, this.color); }

        public Vector2 Pos { get { return this.position; } set { this.position = value; } }
    }
}
