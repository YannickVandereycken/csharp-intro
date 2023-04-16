using System;
namespace TimeExercise
{
	public class Time
	{
		public Time(int hours, int minutes, int seconds)
		{
			this.Hours = hours;
			this.Minutes = minutes;
			this.Seconds = seconds;
		}

		private int seconds;
		private int minutes;
		private int hours;

		public int Seconds
		{
			get
			{
				return this.seconds;
			}
			set
			{
				if (value < 0 || value > 59) throw new ArgumentException("Must be between 0-59");
				this.seconds = value;
			}
		}
        public int Minutes
        {
            get
            {
                return this.minutes;
            }
            set
            {
                if (value < 0 || value > 59) throw new ArgumentException("Must be between 0-59");
                this.minutes = value;
            }
        }

		public int Hours { get; set; }

		public int TotalSeconds => (int)((Hours * 60 * 60) + (Minutes * 60) + Seconds);
    }
}

