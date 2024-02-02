﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace HesapKabardiT1.Managers
{
	public class ActionInvoker
	{
		private List<Action> acts=new List<Action>();
		public void AddAction(Action act)
		{
			acts.Add(act);
		}
		public ActionInvoker(DispatcherTimer timer) {
			timer.Tick += Timer_Tick;
			timer.Start();
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
