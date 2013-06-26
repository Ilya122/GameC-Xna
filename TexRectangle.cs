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
    public class TexRectanlge
    {
        Texture2D tex;
        int width = 0;
        int height = 0;
        int x = 0;
        int y = 0;
        Color color;
        public TexRectanlge(GraphicsDevice gv, Color c, int width, int height, int x, int y)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            color = c;
            CreateTex(gv);
        }

        public TexRectanlge(GraphicsDevice gv, Color c, int radius, Vector2 Pos)
        {
            this.x = (int)Pos.X;
            this.y = (int)Pos.Y;
            this.width = radius;
            this.height = radius;
            color = c;
            CreateCircle(width, gv);
        }

        public TexRectanlge(GraphicsDevice gv, Color c, int width, int height, int x, int y, int alpha)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
            color = c;
            alpha = (int)MathHelper.Clamp(alpha,0, 100);
            CreateTex(gv,(byte)alpha);
        }

        public TexRectanlge(GraphicsDevice gv, Color c, int radius, Vector2 Pos, int alpha)
        {
            this.x = (int)Pos.X;
            this.y = (int)Pos.Y;
            this.width = radius;
            this.height = radius;
            color = c;
            alpha = (int)MathHelper.Clamp(alpha, 0, 100);
            CreateCircle(width, gv);
        }
        private void CreateTex(GraphicsDevice gv)
        { 
            Color[] colors = new Color[width*height];
            for (int i = 0; i < colors.Length; i++)
            {
                    colors[i] = color;
            }
            tex = new Texture2D(gv, width, height);
            tex.SetData<Color>(colors);

        }

        private void CreateTex(GraphicsDevice gv, byte alpha)
        {
            Color[] colors = new Color[width * height];
            for (int i = 0; i < colors.Length; i++)
            {
                colors[i] = color;
                colors[i].A= alpha;
            }
            tex = new Texture2D(gv, width, height);
            tex.SetData<Color>(colors);

        }

        public void Draw(SpriteBatch sb)
        { sb.Draw(tex, new Rectangle(x, y, width, height), Color.White); }

        public Vector2 Position { get { return new Vector2(x, y); } set { this.x = (int)value.X; this.y = (int)value.Y; } }
        public Rectangle Rectangle 
        {
            get {return new Rectangle(x, y, width, height); }
            set { this.x = value.X; this.y = value.Y; this.width = value.Width; this.height = value.Height; }
        }
        public Texture2D Texture { get { return this.tex; } }

        public void CreateCircle(int radius, GraphicsDevice gd)
        {
            int outerRadius = radius * 2 + 2; // So circle doesn't go out of bounds
            Texture2D texture = new Texture2D(gd, outerRadius, outerRadius);

            Color[] data = new Color[outerRadius * outerRadius];

            // Colour the entire texture transparent first.
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.TransparentWhite;

            // Work out the minimum step necessary using trigonometry + sine approximation.
            double angleStep = 1f / radius;

            for (double angle = 0; angle < Math.PI * 2; angle += angleStep)
            {
                // Use the parametric definition of a circle: http://en.wikipedia.org/wiki/Circle#Cartesian_coordinates
                int x = (int)Math.Round(radius + radius * Math.Cos(angle));
                int y = (int)Math.Round(radius + radius * Math.Sin(angle));

                data[y * outerRadius + x + 1] = Color.White;
            }

            texture.SetData(data);
            this.tex = texture;
        }
    }
}
