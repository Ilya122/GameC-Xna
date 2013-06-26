using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace GameClasses
{
    [Serializable]
    public class AnimatedSprite : Sprite
    {
        //Varibles:
        protected Vector2 CurrentFrame;
        protected Vector2 StartFrame;
        protected Vector2 EndFrame;
        protected Vector2 FrameSize;

        //Constructors:
        /// <summary>
        /// Constructor of the Animated Sprite
        /// </summary>
        /// <param name="tex">The texture to use</param>
        /// <param name="pos">Draw position</param>
        /// <param name="CF">Current frame, usually same as SF</param>
        /// <param name="SF">Starting frame</param>
        /// <param name="EF">Ending frame</param>
        /// <param name="FS">Frame size, x=width, y=height</param>
        public AnimatedSprite(Texture2D tex, Vector2 pos, Vector2 CF, Vector2 SF, Vector2 EF, Vector2 FS)
            : base(tex, pos)
        {
            this.CurrentFrame = CF;
            this.StartFrame = SF;
            this.EndFrame = EF;
            this.FrameSize = FS;
            angle = 0;
            Origin = Vector2.Zero;
            LayerDepth = 0f;
        }
        /// <summary>
        /// Constructor of the Animated sprite
        /// </summary>
        /// <param name="tex">The texture to use</param>
        /// <param name="pos">Draw position</param>
        /// <param name="CF">Current frame, usually same as SF</param>
        /// <param name="SF">Starting frame</param>
        /// <param name="EF">Ending frame</param>
        /// <param name="FS">Frame size, x=width, y=height</param>
        /// <param name="angle">Angle of rotation</param>
        /// <param name="Origin">The origin you take to rotate</param>
        /// <param name="layerdepth">Layer depth of drawing</param>
        public AnimatedSprite(Texture2D tex, Vector2 pos, Vector2 CF, Vector2 SF, Vector2 EF, Vector2 FS
            , float angle, Vector2 Origin, float layerdepth)
            : base(tex, pos, angle, Origin, layerdepth)
        {
            this.CurrentFrame = CF;
            this.StartFrame = SF;
            this.EndFrame = EF;
            this.FrameSize = FS;
        }
        //Draw Methods:
        public new void Draw(SpriteBatch sb)
        {
            sb.Draw(base.Texture
                , new Rectangle((int)base.Position.X, (int)base.Position.Y, base.Texture.Width, base.Texture.Height)
                , new Rectangle((int)this.CurrentFrame.X * (int)this.FrameSize.X
                    , (int)this.CurrentFrame.Y * (int)this.FrameSize.Y
                    , (int)this.FrameSize.X, (int)this.FrameSize.Y),
                Color.White, base.angle, base.Origin, SpriteEffects.None, base.LayerDepth);
            Update();
        }

        public new void Draw(SpriteBatch sb,Color c)
        {
            sb.Draw(base.Texture
                , new Rectangle((int)base.Position.X, (int)base.Position.Y, base.Texture.Width, base.Texture.Height)
                , new Rectangle((int)this.CurrentFrame.X * (int)this.FrameSize.X
                    , (int)this.CurrentFrame.Y * (int)this.FrameSize.Y
                    , (int)this.FrameSize.X, (int)this.FrameSize.Y),
                c, base.angle, base.Origin, SpriteEffects.None, base.LayerDepth);
            Update();
        }

        public new void Draw(SpriteBatch sb, Color c, float scale)
        {
            sb.Draw(base.Texture
                ,base.Position
                , new Rectangle((int)this.CurrentFrame.X * (int)this.FrameSize.X
                    , (int)this.CurrentFrame.Y * (int)this.FrameSize.Y
                    , (int)this.FrameSize.X, (int)this.FrameSize.Y),
                c, base.angle, base.Origin,scale, SpriteEffects.None, base.LayerDepth);
            Update();
        }

        public new void Draw(SpriteBatch sb, Color c,float scale, SpriteEffects sp)
        {
            sb.Draw(base.Texture
                , base.Position
                , new Rectangle((int)this.CurrentFrame.X * (int)this.FrameSize.X
                    , (int)this.CurrentFrame.Y * (int)this.FrameSize.Y
                    , (int)this.FrameSize.X, (int)this.FrameSize.Y),
                c, base.angle, base.Origin, scale, sp, base.LayerDepth);
            Update();
        }
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------
        //--------------------------------------------------------------------------

        //Updates the frame.
        /// <summary>
        /// Updates to the next frame
        /// </summary>
        public void Update()
        {
            //Current frame.X determines the current frame in the X axis of the spritesheet.
            this.CurrentFrame.X++;
            if (this.CurrentFrame.X > this.EndFrame.X) //End frame X is the ending frame of the spritesheet
            {
                this.CurrentFrame.X = StartFrame.X;
                if (this.CurrentFrame.Y > this.EndFrame.Y)
                {
                    this.CurrentFrame.Y = StartFrame.Y;

                }
            }
        }
    }
}
