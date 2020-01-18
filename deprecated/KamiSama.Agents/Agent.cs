using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using NLog;

namespace KamiSama.Agents
{
	[ExcludeFromCodeCoverage]
	public class Agent
	{
		public string Name { get; }
		public Logger Logger { get; }
		private readonly Thread thread;
		private readonly Action<Agent> action;
		public bool Running { get; private set; }
		public Agent(string name, Action<Agent> action)
		{
			this.Name = name;
			this.action = action ?? this.Run;
			this.Logger = LogManager.GetLogger(name);
			this.thread = new Thread(ThreadMain);
			this.Running = false;
		}

		public Agent(string name, Action action)
		{
			this.Name = name;
			if (action == null)
				this.action = this.Run;
			else
				this.action = agent => action();

			this.Logger = LogManager.GetLogger(name);
			this.thread = new Thread(ThreadMain);
			this.Running = false;
		}

		protected Agent(string name)
		{
			this.Name = name;
			this.action = this.Run;
			this.Logger = LogManager.GetLogger(name);
			this.thread = new Thread(ThreadMain);
		}

		private void ThreadMain()
		{
			try
			{
				Running = true;
				action(this);
				Running = false;
			}
			catch (ThreadAbortException)
			{
			}
			catch (Exception e)
			{
				Logger.Error(e);
			}
		}

		protected virtual void Run(Agent agent)
		{
		}

		protected virtual void OnStart()
		{

		}

		protected virtual void OnStop()
		{

		}

		public void Start()
		{
			Logger.Info($"Starting {Name}...");
			thread.Start();
			OnStart();
			Logger.Trace("Started.");
		}

		public void Stop()
		{
			Logger.Info($"Stopping {Name}...");
			try
			{
				thread.Abort();
			}
			catch (Exception e)
			{
				Logger.Error(e, $"Agent {Name} with error.");
			}

			OnStop();
			Logger.Trace("Stopped.");
		}
	}
}
