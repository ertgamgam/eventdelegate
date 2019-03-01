using System;

namespace Training.Volvo
{
    class SpeedEventArgs:EventArgs
    {
        public SpeedEventArgs(int speed)
        {
            this.Speed = speed;
        }
        public int Speed { get; set; }
    }
}
