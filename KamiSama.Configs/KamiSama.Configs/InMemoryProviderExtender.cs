namespace KamiSama.Configs
{
	public static class InMemoryProviderExtender
    {
		public static void UseInMemoryPrvider<_ConfigType>(this _ConfigType instance, _ConfigType config)
			where _ConfigType : ConfigData<_ConfigType>
			=> instance.UseProvider(new InMemoryConfigProvider<_ConfigType>(config));
    }
}
