namespace KamiSama.Configs
{
	public static class DefaultProviderExtender
    {
		public static void UseProvider<_ConfigType>(this _ConfigType instance, IConfigProvider<_ConfigType> provider)
			where _ConfigType : ConfigData<_ConfigType>
		{
			var type = typeof(ConfigData<_ConfigType>);

			var prop = type.GetProperty("Provider");
			prop.SetValue(null, provider);

			var method = type.GetMethod("Load");
			method.Invoke(null, null);
		}
    }
}
