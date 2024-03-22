using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace HesapKabardiT1.Managers
{
	public class ActionInvoker
	{
		private List<Action> acts = new List<Action>();
		private DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(1), IsEnabled = true };

		public ActionInvoker()
		{
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		public void AddAction(Action act)
		{
			acts.Add(act);
		}

		private void Timer_Tick(object? sender, EventArgs e)
		{
			for (int i = 0; i < acts.Count; i++)
			{
				acts[i].Invoke();
				acts.RemoveAt(i);
			}
		}
	}
}
