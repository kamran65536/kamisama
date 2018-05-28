using System;

namespace KamiSama.SecureModule.Api
{
	[Flags]
    public enum KeyPermission
    {
		Encrypt		= 0x00000001,
		Decrypt		= 0x00000010,
		Exportable	= 0x00000100,
    }
}
