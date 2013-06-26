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
    enum Show {Live, Dead }
    public class Particle
    {
        Sprite picture;
        Vector2 velocity;
        int lifetime;
        int timer = 0;
        Show show = Show.Live;

        public Particle(int LifeTime, Texture2D tex, Vector2 pos, Vector2 vel, float angle, float ldepth, float scale)
        {
            picture = new Sprite(tex, pos, angle, new Vector2(tex.Width / 2, tex.Height / 2), ldepth , scale);
            this.velocity = vel;
            this.lifetime = LifeTime;
        }

        public void Update()
        {
            switch (show)
            {
                case Show.Live:
                    this.Picture.Pos += velocity;
                    this.timer++;
                    if (timer > lifetime)
                    { this.show = Show.Dead; }
                    break;
                case Show.Dead:
                    break;
            }
        }

        public Vector2 Velocity { get { return this.velocity; } set { this.velocity = value; } }
        public Sprite Picture { get { return this.picture; } }
        public int LifeTime { get { return this.lifetime; } set { this.lifetime = value; } }
        public bool IsDead { get { if (show == Show.Dead) return true; else { return false; } } }
    }
}
