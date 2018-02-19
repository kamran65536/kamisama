using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using NLog;

namespace KamiSama.Agents
{
	[ExcludeFromCodeCoverage]
	public class RepeatingAgent : Agent
	{
		private readonly Func<RepeatingAgent, bool> func;
		public TimeSpan WaitInterval { get; }
		public RepeatingAgent(string name, TimeSpan waitInterval, Func<RepeatingAgent, bool> func = null)
			: base(name)
		{
			this.func = func ?? DoJob;
			this.WaitInterval = waitInterval;
		}
		public RepeatingAgent(string name, TimeSpan waitInterval, Func<bool> func)
			: base(name)
		{
			if (func == null)
				this.func = DoJob;
			else
				this.func = agent => func();

			this.WaitInterval = waitInterval;
		}
		protected RepeatingAgent(string name, TimeSpan waitInterval)
			: base(name)
		{
			this.func = DoJob;
			this.WaitInterval = waitInterval;
		}
		protected override void Run(Agent agent)
		{
			while (Running)
				try
				{
					if (!func(this))
						Thread.Sleep(WaitInterval);
				}
				catch (ThreadAbortException)
				{
					return;
				}
				catch (Exception e)
				{
					Logger.Error(e);
					Thread.Sleep(WaitInterval);
				}
		}

		protected virtual bool DoJob(RepeatingAgent agent)
		{
			return false;
		}
	}
}
