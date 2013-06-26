using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameClasses
{
    [Serializable]
    public struct SpriteData
    {
        public Vector2 position;
        public float angle;
        public Vector2 origin;
        public float scale;
        public float layerdepth;
        public Rectangle sourceRec;
        public Matrix matrix;
        public SpriteData(Vector2 pos, float angle, Vector2 origin, float layerfepth, float scale, Rectangle Sr
            , Matrix mat) 
        {
            this.position = pos;
            this.angle = angle;
            this.origin = origin;
            this.scale = scale;
            this.layerdepth = layerfepth;
            this.sourceRec = Sr;
            this.matrix = mat;
        }

        public void SpriteToData(Sprite s)
        {
            this.position = s.Pos;
            this.angle = s.Angle;
            this.origin = s.Org;
            this.scale = s.Scale;
            this.layerdepth = s.Layerdepth;
            this.sourceRec = s.SourceRec;
            this.matrix = s.Matrix;
        }

        public Sprite DataToSprite(Texture2D tex)
        { return new Sprite(tex, this.position, this.angle, this.origin, this.layerdepth, this.scale, this.sourceRec,this.matrix); }
    }
    [Serializable]
    public class Sprite
    {
        //Varibles:
        protected Texture2D Texture;
        protected Vector2 Position;
        protected float angle;
        protected Vector2 Origin;
        protected float scale;
        protected float LayerDepth;
        protected Rectangle SourceRectangle;
        protected Matrix matrix;

        //Sprite Constructor
        #region Constructors:
        public Sprite(Texture2D tex, Vector2 pos)
        {
            Defeaultinitilize();
            this.Texture = tex;
            this.Position = pos;
            //this.Origin = new Vector2(tex.Width / 2, tex.Height / 2);
            this.CreateMatrix();
        }

        public Sprite(Texture2D tex, Vector2 pos, float angle, Vector2 origin, float layerdepth)
        {
            Defeaultinitilize();
            this.Texture = tex;
            this.Position = pos;
            this.angle = angle;
            this.Origin = origin;
            this.LayerDepth = layerdepth;
            this.CreateMatrix();
        }

        public Sprite(Texture2D tex, Vector2 pos, float angle, Vector2 origin, float layerdepth,float scale)
        {
            Defeaultinitilize();
            this.Texture = tex;
            this.Position = pos;
            this.angle = angle;
            this.Origin = origin;
            this.LayerDepth = layerdepth;
            this.scale = scale;
            this.CreateMatrix();
        }
        public Sprite(Texture2D tex, Vector2 pos, float angle, Vector2 origin, float layerdepth, float scale, Rectangle Sr)
        {
            Defeaultinitilize();
            this.Texture = tex;
            this.Position = pos;
            this.angle = angle;
            this.Origin = origin;
            this.LayerDepth = layerdepth;
            this.scale = scale;
            this.SourceRectangle = Sr;
            this.CreateMatrix();
        }

        public Sprite(Texture2D tex, Vector2 pos, float angle, Vector2 origin, float layerdepth, float scale, Rectangle Sr, Matrix mat)
        {
            Defeaultinitilize();
            this.Texture = tex;
            this.Position = pos;
            this.angle = angle;
            this.Origin = origin;
            this.LayerDepth = layerdepth;
            this.scale = scale;
            this.SourceRectangle = Sr;
            this.matrix = mat;
        }
        private void Defeaultinitilize()
        {
            this.Texture = null;
            this.Position = Vector2.Zero;
            this.angle = 0;
            this.Origin = Vector2.Zero;
            this.scale = 1f;
            this.LayerDepth = 1f;
        }
        #endregion

        #region Draws
        //-------------------DRAW
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(this.Texture,
                new Rectangle((int)(Position.X), (int)(Position.Y)
                    , (int)(Texture.Width * this.scale), (int)(Texture.Height * this.scale))
                , null , Color.White, this.angle, this.Origin, SpriteEffects.None, LayerDepth);
        }

        public void Draw(SpriteBatch sb, Rectangle r)
        {
            sb.Draw(this.Texture, r, null, Color.White, this.angle, this.Origin, SpriteEffects.None, LayerDepth);
        }

        public void Draw(SpriteBatch sb,int ScaleX, int ScaleY)
        {
            sb.Draw(this.Texture,
                new Rectangle((int)(Position.X), (int)(Position.Y), Texture.Width*ScaleX, Texture.Height*ScaleY)
                , null, Color.White, this.angle, this.Origin, SpriteEffects.None,this.LayerDepth);
        }

        public void Draw(SpriteBatch sb, float ScaleX, float ScaleY)
        {
            sb.Draw(this.Texture,
                new Rectangle((int)(Position.X), (int)(Position.Y), (int)(Texture.Width * ScaleX), (int)(Texture.Height * ScaleY))
                , null, Color.White, this.angle, this.Origin, SpriteEffects.None, this.LayerDepth);
        }
        public void Draw(SpriteBatch sb, Color c)
        {
            sb.Draw(this.Texture,
                new Rectangle((int)(Position.X), (int)(Position.Y), (int)(Texture.Width * this.scale), (int)(Texture.Height * this.scale))
                , null ,c, angle, this.Origin, SpriteEffects.None, LayerDepth);
        }
        
        public void Draw(SpriteBatch sb, Color c, float scale)
        {
            sb.Draw(this.Texture, this.Position, null, c, angle, this.Origin, 
                scale, SpriteEffects.None, this.LayerDepth);
        }

        public void Draw(SpriteBatch sb, float scale)
        {
            sb.Draw(this.Texture, this.Position, null, Color.White, angle, this.Origin,
                scale, SpriteEffects.None, this.LayerDepth);
        }

        public void Draw(SpriteBatch sb, Color c,float scale, SpriteEffects sp)
        {
            sb.Draw(this.Texture, this.Position, null, c, angle, this.Origin,
                scale, sp, this.LayerDepth);
        }
        public void Draw(SpriteBatch sb, Color c, float scale, SpriteEffects sp, Rectangle SourceRectangle)
        {
            sb.Draw(this.Texture, this.Position, SourceRectangle, c, angle, this.Origin,
                scale, sp, this.LayerDepth);
        }
        //-----------------------------END DRAW
        #endregion

        #region InersectPixels

        #region Pixel Not-Rotated
        private bool IntersectPixels(Rectangle rectangleA, Color[] dataA, Rectangle rectangleB, Color[] dataB)
        {
            int top = Math.Max(rectangleA.Top, rectangleB.Top);
            int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
            int left = Math.Max(rectangleA.Left, rectangleB.Left);
            int right = Math.Min(rectangleA.Right, rectangleB.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color colorA = dataA[(x - rectangleA.Left) +
                                         (y - rectangleA.Top) * rectangleA.Width];
                    Color colorB = dataB[(x - rectangleB.Left) +
                                         (y - rectangleB.Top) * rectangleB.Width];

                    if (colorA.A != 0 && colorB.A != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CollidePixel(Sprite s2)
        {
            if (this.CollideRectangle(s2))
            {
                Color[] ColorData1D = new Color[this.Texture.Width * this.Texture.Height];
                Texture.GetData(ColorData1D);
                Color[] ColorData1D2 = new Color[s2.Texture.Width * s2.Texture.Height];
                s2.Texture.GetData(ColorData1D2);
                if (this.IntersectPixels(this.Size, ColorData1D, s2.Size, ColorData1D2))
                { return true; }
            }
                return false;
        }
        public bool CollidePixel(Sprite s2, Rectangle rec, Rectangle rec2)
        {
            if (this.CollideRectangle(s2))
            {
                Color[] ColorData1D = new Color[this.Texture.Width * this.Texture.Height];
                this.Texture.GetData(ColorData1D);
                Color[] ColorData1D2 = new Color[s2.Texture.Width * s2.Texture.Height];
                s2.Texture.GetData(ColorData1D2);
                if (this.IntersectPixels(rec, ColorData1D, rec2, ColorData1D2))
                { return true; }
            }
            return false;
        }
        #endregion

        #region Roatated Pixel Collision

        public bool IntersectPixels(
                            Matrix transformA, int widthA, int heightA, Color[] dataA,
                            Matrix transformB, int widthB, int heightB, Color[] dataB)
        {
            Matrix transformAToB = transformA * Matrix.Invert(transformB);

            Vector2 stepX = Vector2.TransformNormal(Vector2.UnitX, transformAToB);
            Vector2 stepY = Vector2.TransformNormal(Vector2.UnitY, transformAToB);

            Vector2 yPosInB = Vector2.Transform(Vector2.Zero, transformAToB);
            
            for (int yA = 0; yA < heightA; yA++)
            {
                Vector2 posInB = yPosInB;
                for (int xA = 0; xA < widthA; xA++)
                {                    int xB = (int)Math.Round(posInB.X);
                    int yB = (int)Math.Round(posInB.Y);
                    if (0 <= xB && xB < widthB &&
                        0 <= yB && yB < heightB)
                    {
                        Color colorA = dataA[xA + yA * widthA];
                        Color colorB = dataB[xB + yB * widthB];
                        if (colorA.A != 0 && colorB.A != 0)
                        {
                            return true;
                        }
                    }
                    posInB += stepX;
                }
                yPosInB += stepY;
            }
            return false;
        }


        private  Rectangle CalculateBoundingRectangle(Rectangle rectangle,
                                                           Matrix transform)
        {
            Vector2 leftTop = new Vector2(rectangle.Left, rectangle.Top);
            Vector2 rightTop = new Vector2(rectangle.Right, rectangle.Top);
            Vector2 leftBottom = new Vector2(rectangle.Left, rectangle.Bottom);
            Vector2 rightBottom = new Vector2(rectangle.Right, rectangle.Bottom);

            Vector2.Transform(ref leftTop, ref transform, out leftTop);
            Vector2.Transform(ref rightTop, ref transform, out rightTop);
            Vector2.Transform(ref leftBottom, ref transform, out leftBottom);
            Vector2.Transform(ref rightBottom, ref transform, out rightBottom);

            Vector2 min = Vector2.Min(Vector2.Min(leftTop, rightTop),
                                      Vector2.Min(leftBottom, rightBottom));
            Vector2 max = Vector2.Max(Vector2.Max(leftTop, rightTop),
                                      Vector2.Max(leftBottom, rightBottom));

            return new Rectangle((int)min.X, (int)min.Y,
                                 (int)(max.X - min.X), (int)(max.Y - min.Y));
        }

        public bool CollideMatrix(Sprite s2)
        {
            if (this.CollideRectangle(s2))
            {
                this.CreateMatrix();
                s2.CreateMatrix();
                Rectangle bound2 = s2.CalculateBoundingRectangle 
                    (new Rectangle(0,0,s2.Texture.Width,s2.Texture.Height), s2.matrix);
                Color[] ColorData1D = new Color[this.Texture.Width * this.Texture.Height];
                this.Texture.GetData(ColorData1D);
                Color[] ColorData1D2 = new Color[s2.Tex.Width * s2.Tex.Height];
                s2.Texture.GetData(ColorData1D2);
                if (IntersectPixels(this.matrix, this.Size.Width, this.Size.Height, ColorData1D,
                    s2.matrix, bound2.Width, bound2.Height, ColorData1D2))
                { return true; }
            }
            return false;
        }
        #endregion
        #endregion

        public bool CollideRectangle(Sprite s2)
        {if(this.Size.Intersects(s2.Size)) return true; else return false; }

        public void CreateMatrix()
        {
            this.matrix =
                   Matrix.CreateTranslation(new Vector3(-this.Origin, 0.0f)) *
                   Matrix.CreateScale(scale) *
                   Matrix.CreateRotationZ(this.angle) *
                   Matrix.CreateTranslation(new Vector3(Position, 0.0f));
        }

        //Properties:
        public Vector2 Pos { get { return this.Position; } set { this.Position = value; } }
        public Texture2D Tex { get { return this.Texture; } set { this.Texture = value; } }
        public float Angle { get { return this.angle; } set { this.angle = value; } }
        public float Scale { get { return this.scale; } set { this.scale = value; } }
        public Vector2 Org { get { return this.Origin; } set { this.Origin = value; } }
        public float Layerdepth { get { return this.LayerDepth; } set { this.LayerDepth = value; } }
        public Rectangle Size { get { return new Rectangle((int)this.Pos.X, (int)this.Pos.Y, this.Tex.Width ,this.Tex.Height); } }
        public Rectangle SourceRec { get { return this.SourceRectangle; } }
        public Matrix Matrix { get { return this.matrix; } }
        public float X { get { return this.Pos.X; } set { this.Position.X = value; } }
        public float Y { get { return this.Pos.Y; } set { this.Position.Y = value; } }


    }
}
