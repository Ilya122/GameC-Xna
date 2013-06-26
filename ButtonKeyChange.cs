using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameClasses
{
    [Serializable]
    enum State {Wait, Default }
    public class ButtonKeyChange
    {
        MenuButton Button;
        Keys Key1;
        Timer timer = new Timer(0, 10);
        State state = State.Default;
        Keys PrevKey;

        public ButtonKeyChange(SpriteFont sf, Vector2 pos, Keys k1)
        {
            Button = new MenuButton(sf, pos, k1.ToString());
            this.Key1=k1;
            PrevKey = Key1;
        }
        public ButtonKeyChange(SpriteFont sf, Vector2 pos ,Keys k1, Color C1, Color C2)
        {
            Button = new MenuButton(sf, pos, k1.ToString(),C1,C2);
            this.Key1=k1;
            PrevKey = Key1;
        }

        public void Update()
        {
            this.Button.Update(Mouse.GetState());
            this.Button.Rec = new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)Button.MeasureString.X, (int)Button.MeasureString.Y);
            timer.Update();
            if (timer.TimeOut)
            {
                switch (state)
                {
                    case State.Default:
                        if (Button.CheckClick(Mouse.GetState()))
                        { this.state = State.Wait; }
                        break;
                    case State.Wait:
                        KeyboardState ks = Keyboard.GetState();
                        if (ks.GetPressedKeys().Length > 0)
                        {
                            this.Key1 = ks.GetPressedKeys()[0];
                            ChangeText();
                            this.state = State.Default;
                        }
                        break;
                }
            }
        }
        public void Draw(SpriteBatch sb)
        {
            switch (state)
            {
                case State.Wait:
                    this.Button.TEXT = "Press Any Key";
                    this.Button.Draw(sb);
                    break;
                case State.Default:
                    this.Button.Draw(sb);
                    break;
            }
        }
        private void ChangeText()
        {
            string text = Key1.ToString();
            this.Button.TEXT = text;
        }

        public Vector2 Position { get { return this.Button.Pos; } set { this.Button.Pos = value; } }
        public Keys Key { get { return this.Key1; } set { this.Key1 = value; } }
        public bool Pressed { get { if (this.state == State.Wait)return true; else return false; } }
        //---------------------------------------
    }
}
