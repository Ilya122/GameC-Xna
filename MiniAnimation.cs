using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameClasses
{
    [Serializable]
    public class MiniAnimation
    {
        Texture2D tex;
        Vector2 pos;
        Vector2 sf;
        Vector2 cf;
        Vector2 ef;
        bool isplayed = false;
        int FPS = 1;
        int currentFrame = 1;

        public MiniAnimation(Vector2 position, ContentManager cm,string direction ,Vector2 CF, Vector2 EF, Vector2 FS)
        {
            this.pos = position;
            tex = cm.Load<Texture2D>(@direction);
            sf = FS;
            cf = CF;
            ef = EF;
        }
        public MiniAnimation(Vector2 position, Texture2D tex, Vector2 CF, Vector2 EF, Vector2 FS)
        {
            this.pos = position;
            this.tex= tex;
            sf = FS;
            cf = CF;
            ef = EF;
        }

        public MiniAnimation(Vector2 position, Texture2D tex, Vector2 CF, Vector2 EF, Vector2 FS, int fps)
        {
            this.pos = position;
            this.tex = tex;
            sf = FS;
            cf = CF;
            ef = EF;
            this.FPS = fps;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, new Rectangle((int)this.pos.X, (int)this.pos.Y, (int)sf.X, (int)sf.Y)
                , new Rectangle((int)cf.X * (int)sf.X, (int)cf.Y, (int)sf.X, (int)sf.Y)
                , Color.White);
            Update();
        }

        public void DrawMiror(SpriteBatch sb)
        {
            sb.Draw(tex, new Rectangle((int)this.pos.X, (int)this.pos.Y, (int)sf.X, (int)sf.Y)
                           , new Rectangle((int)cf.X * (int)sf.X, (int)cf.Y, (int)sf.X, (int)sf.Y)
                           , Color.White,0f,new Vector2(tex.Width/2,tex.Height/2),SpriteEffects.FlipHorizontally,1f);
            Update();
        }

        private void Update()
        {
            currentFrame++;
            if (isplayed && !(currentFrame>=FPS)) { return; }
            else
            {
                currentFrame = 0;
                this.cf.X++;
                if (cf.X > ef.X)
                {
                    cf.X = 0;
                    isplayed = true;
                }
            }
        }

        public bool IsPlayed { get { return isplayed; } set { this.isplayed = value; } }
        public Vector2 Position { get { return this.pos; } set { this.pos = value; } }
        //------------------------------------------

    }
}
