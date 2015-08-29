using System;

namespace Twiturence
{
	public class Post: IComparable
	{
		private string message;
		public string Message {
			get {
				return message;
			}
		}

		private DateTime time;
		public DateTime Time {
			get {
				return time;
			}
		}

		public Post (string messageExpected)
		{
			message = messageExpected;
			time = DateTime.Now;
		}

		public void Display()
		{
			TimeSpan currentTime = DateTime.Now.TimeOfDay;
			string displayTime;

			if (time.Day == DateTime.Now.Day &&
				time.Month == DateTime.Now.Month &&
				time.Year == DateTime.Now.Year)
			{  //-> same day
				TimeSpan elapsedTime = currentTime - time.TimeOfDay;
				if (elapsedTime.Hours != 0) 
				{
					displayTime = String.Format ("({0} hour(s) ago)", elapsedTime.Hours);
				} 
				else if (elapsedTime.Minutes != 0) 
				{
					displayTime = String.Format ("({0} minute(s) ago)", elapsedTime.Minutes);
				} 
				else 
				{
					displayTime = String.Format ("({0} second(s) ago)", elapsedTime.Seconds);
				}

			} 
			else //-> other day
			{
				displayTime = String.Format ("(Posted the {0}/{1}/{2})", time.Day, time.Month, time.Year);
			}

			Console.WriteLine (message + " " + displayTime);
		}

		#region IComparable implementation
		public int CompareTo (object obj)
		{
			Post postToCompare = (Post)obj;
			if (time.TimeOfDay > postToCompare.Time.TimeOfDay) 
			{
				return -1;
			}

			return 1;
		}
		#endregion

	}
}

