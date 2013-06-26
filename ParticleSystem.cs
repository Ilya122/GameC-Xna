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
    public class ParticleSystem
    {
        List<Particle> particles = new List<Particle>();

        public ParticleSystem() { }

        public ParticleSystem(List<Particle> list)
        { this.particles = list; }

        public void Update()
        {
            for (int i = 0; i < particles.Count; i++)
            { 
                particles[i].Update();
                if (particles[i].IsDead)
                { particles.RemoveAt(i); }
            }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Particle p in particles)
            { p.Picture.Draw(sb); }
        }

        public void Add(Particle p)
        { particles.Add(p); }

        public Particle this[int indexer]
        {
            get { return this.particles[indexer]; }
            set { this.particles[indexer] = value; }
        }

        public int Length
        { get { return this.particles.Count; } }

        public void RemoveAt(int i)
        { this.particles.RemoveAt(i); }
    }
}
