using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using NLog;

namespace KamiSama.Agents
{
	[ExcludeFromCodeCoverage]
	public class PeriodicAgent : Agent
	{
		private readonly Action<PeriodicAgent> action;
		public TimeSpan Interval { get; }
		public PeriodicAgent(string name, TimeSpan interval, Action<PeriodicAgent> action = null)
			: base(name)
		{
			this.action = action ?? DoJob;
			this.Interval = interval;
		}
		public PeriodicAgent(string name, TimeSpan interval, Action action)
			: base(name)
		{
			if (action == null)
				this.action = DoJob;
			else
				this.action = agent => action();
			this.Interval = interval;
		}
		protected PeriodicAgent(string name, TimeSpan interval)
			: base(name)
		{
			this.action = DoJob;
			this.Interval = interval;
		}
		protected override void Run(Agent agent)
		{
			while (Running)
			{
				var start = DateTime.Now;
				try
				{
					action(this);
				}
				catch (ThreadAbortException)
				{
					return;
				}
				catch (Exception e)
				{
					Logger.Error(e);
				}
				var delta = DateTime.Now - start;

				if (delta < Interval)
					Thread.Sleep(Interval - delta );
			}
		}

		protected virtual void DoJob(Agent agent)
		{
		}
	}
}
