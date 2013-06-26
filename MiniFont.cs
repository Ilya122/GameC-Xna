using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameClasses
{
    [Serializable]
    public class MiniFont:Font
    {
        int timer = 0;
        int countloops = 0;
        bool Isplayed = false;
        public MiniFont(SpriteFont sf,Vector2 pos, string text,Color c):base(sf,pos,text,c)
        {
        }

        public override void Draw(SpriteBatch sb)
        {
            if (!Isplayed)
            {
                timer++;
                if (timer > 6)
                {
                    base.position.Y -= 7;
                    timer = 0;
                    countloops++;
                }
                base.Draw(sb);
                if (countloops >= 5) { Isplayed = true; }
            }
        }

        public bool IsPlayed() { if (Isplayed == true)return true; else return false; }

    }
}
