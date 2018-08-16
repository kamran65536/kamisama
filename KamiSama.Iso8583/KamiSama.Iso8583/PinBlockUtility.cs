using System.Security.Cryptography;
using KamiSama.Extenders;

namespace KamiSama.Iso8583
{
	public static class PinBlockUtility
	{
		public static string GetPinBlock(string pan, string pin, byte[] pinKey)
		{
			if ((pan.Length < 16) ||
				(pan.Length > 19) ||
				(pin.Length < 4))
				return "";

			string pinBlockHex =
				"0" + // pin type
				pin.Length.ToString("X1") +
				pin;

			pinBlockHex = pinBlockHex.PadRight(16, 'F');

			byte[] pinBlock = pinBlockHex.FromHex();
			string panBlockHex = pan.PadRight(16, '0');

			panBlockHex =
				"0000" +
				 panBlockHex.Substring(panBlockHex.Length - 13, 12);
			panBlockHex = panBlockHex.PadRight(16, '0');

			byte[] panBlock = panBlockHex.FromHex();

			for (int i = 0; i < 8; i++)
				pinBlock[i] ^= panBlock[i];

			return pinBlock
				.DesEncrypt(pinKey, new byte[8], CipherMode.ECB, PaddingMode.Zeros)
				.ToHex();
		}
	}
}
