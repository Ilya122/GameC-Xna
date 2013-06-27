using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace GameClasses
{
    public class Button
    {
        //Graphical:
        Texture2D tex;
        Texture2D overtex;
        Texture2D finaltex;
        Color c = Color.White;
        //Logical:
        Vector2 Position;
        Vector2 Origin;
        float angle = 0.0f;
        float scale = 1.0f;
        float layerdepth = 1.0f;
        Timer timer = new Timer(0, 30);   //Timer for Timed clicking (So you wont double click every time)
        //Sound:
        SoundEffect OverSound;                            //Over button sound.
        SoundEffect ClickSound;                           //Click sound.
        float Volume = 1.0f;
        bool SoundPlayed = false;                         //determines if the over sound has played


        #region Constructors:
        public Button(Texture2D texture, Texture2D overtexture, Vector2 Pos)
        {
            Init(texture, overtexture, Pos);
        }

        public Button(Texture2D texture, Texture2D overtexture, Vector2 Pos, Color c)
        {
            Init(texture, overtexture, Pos);
        }

        public Button(Texture2D texture, Texture2D overtexture, Vector2 Pos, float angle, float scale, Vector2 org)
        {
            Init(texture, overtexture, Pos);
            this.angle = angle;
            this.scale = scale;
            this.Origin = org;
        }

        public Button(Texture2D texture, Texture2D overtexture, Vector2 Pos
            , SoundEffect oversound, SoundEffect clickSound, float Volume)
        {
            Init(texture, overtexture, Pos);
            this.c = Color.White;
            this.Volume = Volume;
            this.OverSound = oversound;
            this.ClickSound = clickSound;
        }

        public Button(Texture2D texture, Texture2D overtexture, Vector2 Pos, Color c
            , SoundEffect oversound, SoundEffect clickSound, float Volume)
        {
            Init(texture, overtexture, Pos);
            this.c = c;
            this.Volume = Volume;
            this.OverSound = oversound;
            this.ClickSound = clickSound;
        }

        private void Init(Texture2D tex, Texture2D overTex, Vector2 Pos)
        {
            this.tex = tex;
            this.overtex = overTex;
            this.Position = Pos;
            this.finaltex = this.tex;
        }
        #endregion

        public Rectangle Size { get { return new Rectangle((int)Position.X, (int)Position.Y
            , (int)(tex.Width * scale), (int)(tex.Height * scale)); } }
        public float Scale { get { return this.scale; } set { this.scale = value; } }
        public float Angle { get { return this.angle; } set { this.angle = value; } }
        public float layerDepth { get { return this.layerdepth; } set { this.layerdepth = value; } }

        public void update()
        {
            MouseState ms = Mouse.GetState();
            if (CheckCullosion(ms))
            {
                this.finaltex = overtex;
                if (OverSound != null && !SoundPlayed) { OverSound.Play(Volume); SoundPlayed = true; }
            }
            else { this.finaltex = tex; }
        }

        public void ChangeTextures(Texture2D one, Texture2D over)
        {
            this.tex = one;
            this.overtex = over;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(finaltex, Size, c);
        }

        public void Draw(SpriteBatch sb, float Scale)
        {
            sb.Draw(finaltex, new Vector2(Size.X,Size.Y), null, c, 0, Vector2.Zero, Scale, SpriteEffects.None, 1f);
            this.scale = scale;
        }

        public void DrawScaled(SpriteBatch sb)
        {
            sb.Draw(this.finaltex, new Vector2(Size.X, Size.Y), null, c, angle, Origin, scale, SpriteEffects.None, layerdepth);
        }

        private bool CheckCullosion(MouseState ms)
        {
            if (Size.Contains(ms.X, ms.Y))
            { return true; }
            else
                return false;
        }

        public bool CheckClick(MouseState ms)
        {
            if (ms.LeftButton == ButtonState.Pressed)
            {
                if (CheckCullosion(ms))
                {
                    if (this.ClickSound != null) { ClickSound.Play(Volume); }
                    return true;
                }
            }
             return false; 
        }

        public bool CheckClickTimed(MouseState ms)
        {
            timer.Update();
            if (ms.LeftButton == ButtonState.Pressed && timer.TimeOut)
            {
                if (CheckCullosion(ms))
                {
                    if (this.ClickSound != null) { ClickSound.Play(Volume); }
                    timer.Reset();
                    return true;
                }
            }
            return false;
        }

    }
}
