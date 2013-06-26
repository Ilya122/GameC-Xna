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
    public class CreditsMover
    {
        List<Font> credits = new List<Font>();
        Vector2 velocity = new Vector2(0, -3);
        SpriteFont spritefont;
        Color color = Color.White;
        float Y;
        int DistanceBetween = 10;
        bool played = false;
        Timer TimeToReset = new Timer(0, 60);
        #region Constructors
        public CreditsMover(SpriteFont sf, Game g) 
        { 
            this.spritefont = sf;
            this.Y = g.Window.ClientBounds.Height;
        }

        public CreditsMover(Vector2 vel, SpriteFont sf, Game g)
        {
            this.velocity = vel; 
            this.spritefont = sf;
            this.Y = g.Window.ClientBounds.Height;
        }
        public CreditsMover(Vector2 vel, SpriteFont sf, Game g, int dist)
        {
            this.velocity = vel;
            this.spritefont = sf;
            this.Y = g.Window.ClientBounds.Height;
            this.DistanceBetween = dist;
        }
        public CreditsMover(List<Font> fonts, Vector2 vel, SpriteFont sf, Game g)
        {
            this.credits = fonts;
            this.velocity = vel;
            this.spritefont = sf;
            this.Y = g.Window.ClientBounds.Height;
        }

        public CreditsMover(List<Font> fonts, Vector2 vel, SpriteFont sf, Game g, int dist)
        {
            this.credits = fonts;
            this.velocity = vel;
            this.spritefont = sf;
            this.Y = g.Window.ClientBounds.Height;
            this.DistanceBetween = dist;
        }
        #endregion

        //Update:
        public void Update()
        {
            if (!played)
            {
                for (int i = 0;i<credits.Count ; i++)
                {
                    credits[i].Pos += velocity;
                }
                if (this.credits.Last<Font>().Pos.Y < 0)
                { this.played = true; }
            }
            else
            { ResetPosition(); played = false; }
        }

        public void Draw(SpriteBatch sb)
        {
            foreach (Font f in credits)
            { f.Draw(sb); }
        }

        //Methods:
        /// <summary>
        /// Adds a credit to the list, Dont make it too long.
        /// </summary>
        /// <param name="s">The credit</param>
        /// <param name="g">The Game class that associated with your game.</param>
        public void AddCredit(string s,Game g)
        {
            this.credits.Add(new Font(spritefont, Vector2.Zero, s,color));
            float v= CenterX(s,g);
            this.credits.Last<Font>().Pos = new Vector2(v,Y);
        }

        public void StringArrayToList(String[] array, Game g)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Vector2 pos = new Vector2(CenterX(array[i], g), Y + (DistanceBetween * i));
                Font f= new Font(spritefont , pos , array[i] , color);
                this.credits.Add(f);
            }
        }

        private float CenterX(string s, Game g)
        {
            float v2 = this.spritefont.MeasureString(s).X / 2;
            float xCenterPos = g.Window.ClientBounds.Width / 2;
            return xCenterPos - v2;
        }

        private void ResetPosition()
        {
            this.TimeToReset.Update();
            if (TimeToReset.TimeOut)
            {
                for (int i = 0; i < credits.Count; i++)
                {
                    this.credits[i].Pos = new Vector2(this.credits[i].Pos.X, Y + (i * DistanceBetween));
                }
                TimeToReset.TimeOut = false;
            }
        }

        public List<Font> List { get { return this.credits; } set { this.credits = value; } }
        public int Distance { get { return this.DistanceBetween; } set { this.DistanceBetween = value; } }
        public Color Color { get { return this.color; } set { this.color = value; } }
        

    }
}
