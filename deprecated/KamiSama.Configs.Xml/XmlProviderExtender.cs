namespace KamiSama.Configs
{
	public static class XmlProviderExtender
    {
		public static void UseXmlProvider<_ConfigType>(this _ConfigType instance, string path)
			where _ConfigType : ConfigData<_ConfigType>
			=> instance.UseProvider(new XmlConfigProvider<_ConfigType>(path));
    }
}
