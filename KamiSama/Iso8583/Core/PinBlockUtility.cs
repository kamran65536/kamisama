using KamiSama.Extensions;
using System;
using System.Security.Cryptography;

namespace KamiSama.Iso8583
{
	/// <summary>
	/// Pin Block Utility
	/// </summary>
	public static class PinBlockUtility
	{
		/// <summary>
		/// returns pin block hexadecimal for specified pan and pin and pinkey
		/// </summary>
		/// <param name="pan">PAN (Primary Account Number)</param>
		/// <param name="pin">pin for card</param>
		/// <param name="pinKey">pin encryption key</param>
		/// <returns></returns>
		public static string GetPinBlock(string pan, string pin, byte[] pinKey)
		{
			if (pan == null)
				throw new Exception($"pan is null.");
			if (pin == null)
				throw new Exception($"pin is null.");
			if (pinKey == null)
				throw new Exception($"pinKey is null.");

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
