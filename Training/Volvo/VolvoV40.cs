namespace Training.Volvo
{
    class VolvoV40
    {
        public VolvoV40(int speed, int maxSpeed,int range)
        {
            this.Speed = speed;
            this.MaxSpeed = maxSpeed;
            this.SpeedIncrease = range;
        }

        public delegate void MaxSpeedWarningEventHandler(object obj, SpeedEventArgs args);

        public event MaxSpeedWarningEventHandler MaxSpeedWarning;

        public int MaxSpeed { get; set; }

        public int Speed { get; set; }

        public int SpeedIncrease { get; set; }

        public int UpSpeed()
        {
            this.Speed += this.SpeedIncrease;
            if(this.Speed>=this.MaxSpeed && this.MaxSpeedWarning != null)
            {
                MaxSpeedWarning(this, new SpeedEventArgs(this.Speed));
            }
            return this.Speed;
        }
    }
}
