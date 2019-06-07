using KamiSama.ObjectPool;
using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleTest
{
	public class A : IDisposable
	{
		private static int x;

		public int X { get; }
		public A()
		{
			X = ++x;
			Console.WriteLine($"A's constructor is called. x = {x}.");
		}

		public void DoSomething() => Console.WriteLine($"Do something: {X}");

		public void Dispose() => Console.WriteLine($"Disposing {X}...");
	}
	class Program
	{
		private static ObjectPool<A> pool;
		private static Queue<A> queue;

		static void Main(string[] args)
		{
			queue = new Queue<A>();

			pool = new ObjectPool<A>(new ObjectPoolPolicy<A>
			{
				CreateFunc = () => new A(),
				LifeSpan = TimeSpan.FromSeconds(1),
				MaximumAvailableInstances = 10
			});
			var thread = new Thread(ThreadMain);

			thread.Start();
			while (true)
			{
				var a = pool.Get();
				lock(queue)
					queue.Enqueue(a);

				a.DoSomething();
			}
		}

		private static void ThreadMain()
		{
			while (true)
			{
				Thread.Sleep(200);
				A a = null;

				lock(queue)
				{
					if (queue.Count > 0)
						a = queue.Dequeue();
				}
				if (a != null)
				{
					if (true || a.X % 2 == 0)
					{
						Console.WriteLine($"Returning {a.X}...");

						pool.Return(a);
					} else
					{
						Console.WriteLine($"Killing {a.X}...");

						pool.MarkAsDead(a);
					}
				}
			}
		}
	}
}
