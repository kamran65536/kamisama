using System;
using System.Collections.Generic;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;

namespace KamiSama.Extenders.Ninject
{
	public static class Container
	{
		public static HashSet<string> ActiveProfiles { get; private set; }

		public static IKernel Instance { get; private set; }

		static Container()
		{
			Instance = new StandardKernel();
			ActiveProfiles = new HashSet<string>(StringComparer.InvariantCultureIgnoreCase);
		}
		public static void Reset()
		{
			try
			{
				Instance.Dispose();
			}
			catch
			{
			}
			Instance = new StandardKernel();
		}
		public static IBindingToSyntax<T> Bind<T>()
			=> Instance.Bind<T>();
		public static T Get<T>(params IParameter[] parameters) where T : class
			=> Instance.Get<T>(parameters);
		public static T Get<T>(string name, params IParameter[] parameters) where T : class
			=> Instance.Get<T>(name, parameters);
		public static T TryGet<T>(params IParameter[] parameters) where T : class
			=> Instance.TryGet<T>(parameters);
		public static T TryGet<T>(string name, params IParameter[] parameters) where T : class
			=> Instance.TryGet<T>(name, parameters);
		public static IEnumerable<T> GetAll<T>(params IParameter[] parameters)
			=> Instance.GetAll<T>(parameters);
	}
}
