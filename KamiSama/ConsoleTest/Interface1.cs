using KamiSama.Extenders.Attributes;

namespace ConsoleTest
{
	public interface Interface1
	{
	}

	[BindTo(typeof(Interface1), BindingProfile = "Runtime")]
	public class C1 : Interface1
	{
	}
	public class C2 : Interface1
	{
	}
}
