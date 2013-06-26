using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameClasses
{
    [Serializable]
    public class Timer
    {
        int timer = 0;
        int fps = 0;
        bool timeout=false;
        public Timer(int timer, int fps)
        { this.fps = fps; this.timer = timer; this.timeout = false; }

        public void Update()
        {
            if (!timeout)
            {
                this.timer++;
                if (timer > fps)
                { timeout = true; timer = 0; }
            }
        }

        public bool TimeOut { get { return this.timeout; } set { this.timeout = value; } }
        public void Reset()   { this.timeout = false; this.timer = 0; }
    }
}
