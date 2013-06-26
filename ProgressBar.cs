using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameClasses
{
    [Serializable]
    public class ProgressBar
    {
        Sprite picture;             //Static Tex.
        Texture2D redTexture;       //Tex which moves.
        Vector2 position;
        int Value;
        int MaxValue;
        Color color = Color.Red;
        float scaleX;
        float scaleY;

        //Constructors:
        public ProgressBar(Texture2D tex, Texture2D secondTex, Vector2 pos, int value, Color c, int scaleX, int scaleY)
        {
            picture = new Sprite(tex, pos);
            this.position = pos;
            this.redTexture = secondTex;
            this.Value = value;
            this.color = c;
            this.scaleX = scaleX;
            this.scaleY = scaleY;
        }

        public ProgressBar(GraphicsDevice gd, Color firstcolor, Color secondcolor,
            Vector2 pos, int width,int height, int value, int maxvalue)
        {
            TexRectanlge r = new TexRectanlge(gd, secondcolor, width, height, (int)pos.X, (int)pos.Y);
            this.picture = new Sprite(r.Texture, pos);
            color = firstcolor;
            TexRectanlge r2 = new TexRectanlge(gd, firstcolor, width, height, (int)pos.X, (int)pos.Y);
            this.redTexture = r2.Texture;
            this.position = pos;
            this.Value = value;
            this.MaxValue = maxvalue;
        }

        //Update and Draw:
        public void Update(int currentValue, int MaxValue)
        {
            this.Value = currentValue;
            this.MaxValue = MaxValue;
            this.Value = (int)MathHelper.Clamp(this.Value, 0, this.MaxValue);
        }

        public void Draw(SpriteBatch sb, Game g)
        {
            picture.Draw(sb,this.scaleX,this.scaleY);
            sb.Draw(redTexture, new Rectangle((int)position.X, (int)position.Y
, (int)MathHelper.Clamp((int)(this.scaleX * redTexture.Width * ((double)Value / this.MaxValue)),0,this.scaleX*redTexture.Width)
                , (int)(picture.Tex.Height * this.scaleY)), this.color);

        }

        //Properties:
        public Sprite Picture { get { return this.picture; } set { this.picture = value; } }
        public Vector2 Position { get { return this.position; } set { this.position = value; } }
        public float ScaleX { get { return this.scaleX; } set {  this.scaleX = value; } }
        public float ScaleY { get { return this.scaleY; } set { this.scaleY = value; } }
        //End----------------
    }
}
