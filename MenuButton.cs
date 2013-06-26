
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
    [Serializable]
    public class MenuButton : Font
    {
        Color FirstColor = new Color();                   //Basic color.
        Color SecondColor = new Color();                  //Over Color
        Color FinalColor = new Color();                   //Color to show.
        SoundEffect OverSound;                            //Over button sound.
        SoundEffect ClickSound;                           //Click sound.
        Rectangle Rectangle = Rectangle.Empty;            //rectangle.
        float volume = 1f;                                //volume.
        bool SoundPlayed = false;                         //determines if the over sound has played.

        public MenuButton(SpriteFont spritefont, Vector2 Position, string text)
            : base(spritefont, Position, text) { FirstColor = Color.White; SecondColor = Color.Red; Initilize(Position); }

        public MenuButton(SpriteFont spritefont, Vector2 Position, string text, Color fcolor, Color scolor)
            : base(spritefont, Position, text) { FirstColor = fcolor; SecondColor = scolor; Initilize(Position); }

        public MenuButton(SpriteFont spritefont, Vector2 Position, 
            string text, Color fcolor, Color scolor, SoundEffect oversound, SoundEffect clickSound, float Volume)
            : base(spritefont, Position, text) 
        {
            FirstColor = fcolor; 
            SecondColor = scolor;
            this.OverSound = oversound;
            this.ClickSound = clickSound;
            this.volume = Volume;
            Initilize(Position);
        }

        private void Initilize(Vector2 Position)
        {
            this.Rectangle = new Rectangle((int)Position.X, (int)Position.Y
                  , (int)base.font.MeasureString(base.Text).X, (int)base.font.MeasureString(base.Text).Y);
        }

        public new void Draw(SpriteBatch sp)
        {
            sp.DrawString(this.font, this.Text, this.position, FinalColor);
        }

        public void Update(MouseState ms)
        {
            if (this.CheckCullosion(ms))
            { 
                this.FinalColor = this.SecondColor;
                if (OverSound != null && !SoundPlayed) { OverSound.Play(volume); SoundPlayed = true; }
            }
            else { this.FinalColor = this.FirstColor; SoundPlayed = false; }
        }

        //Checks if there is an collusion between the mouse and the menubutton
        private bool CheckCullosion(MouseState ms)
        {
            if (Rectangle.Contains(ms.X, ms.Y))
            { return true; }
            else
                return false;
        }
        //Checks if there is a click
        public bool CheckClick(MouseState ms)
        {
            if (ms.LeftButton == ButtonState.Pressed)
            {
                if (CheckCullosion(ms))
                {
                    if (this.ClickSound != null) { ClickSound.Play(volume); }
                    return true;
                }
                return false;
            }
            else
            { return false; }
        }

        /// <summary>
        /// Designed to take a function.
        /// </summary>
        /// <param name="ms">Mouse State</param>
        /// <param name="Target">Function that checks the mouse buttons and returns bool</param>
        /// <returns></returns>
        public bool CheckClick(MouseState ms , Func<bool> Target )
        {
            if (Target())
            { return CheckCullosion(ms); }
            else return false;
        }

        public float Volume { get { return this.volume; } set { this.volume = value; } }
        public Rectangle Rec { get { return this.Rectangle; } set { this.Rectangle = value; } }
        public Vector2 MeasureString { get { return base.font.MeasureString(base.Text); } }

    }
}
