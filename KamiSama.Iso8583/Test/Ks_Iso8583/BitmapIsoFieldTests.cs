using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using KamiSama.Iso8583;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Ks_Iso8583
{
	[TestClass]
	[TestCategory("Ks.Iso8583.BitmapIsoField")]
	[ExcludeFromCodeCoverage]
	public class BitmapIsoFieldTests
	{
		[TestMethod]
		public void IndexerMethodMustSetCorrectValueForNumbersBetween1And128()
		{
			var isoField = new BitmapIsoField();

			isoField[1] = true;
			isoField[64] = true;
			isoField[66] = true;

			Assert.IsTrue(isoField[1]);
			Assert.IsTrue(isoField[64]);
			Assert.IsTrue(isoField[66]);
			Assert.IsTrue(isoField[2]); //equals to 66
			Assert.IsTrue(isoField[128]);
		}
		[TestMethod]
		public void IndexerMethodMustThrowExceptionForSettingOutOfRangeIndexes()
		{
			var isoField = new BitmapIsoField();

			//setter method
			Assert.ThrowsException<IndexOutOfRangeException>(() => isoField[0] = true);
			Assert.ThrowsException<IndexOutOfRangeException>(() => isoField[129] = true);
			//getter method
			Assert.ThrowsException<IndexOutOfRangeException>(() => isoField[0]);
			Assert.ThrowsException<IndexOutOfRangeException>(() => isoField[129]);
		}
		[TestMethod]
		public void FromHexMethodMustSetAppropiateFlags()
		{
			var isoField = BitmapIsoField.FromHex("F23C840188E10000");
			var fields = new int[] { 1, 2, 3, 4, 7, 11, 12, 13, 14, 17, 22, 32, 33, 37, 41, 42, 43, 48 };

			for (int i = 1; i < 64; i++)
				Assert.AreEqual(fields.Contains(i), isoField[i]);
		}
		[TestMethod]
		public void DebugStringMustDisplayPrimaryBitmapFieldsForFieldNo0()
		{
			var primaryBitmap = BitmapIsoField.FromHex("F23C840188E10000");
			Assert.AreEqual("(Bitmap) hex: F23C840188E10000 fields: P01, P02, P03, P04, P07, P11, P12, P13, P14, P17, P22, P32, P33, P37, P41, P42, P43, P48", primaryBitmap.ToDebugString(0));
		}
		[TestMethod]
		public void DebugStringMustDisplayPrimaryBitmapFieldsForFieldNo1()
		{
			var secondaryBitmap = BitmapIsoField.FromHex("0100000010000000");
			Assert.AreEqual("(Bitmap) hex: 0100000010000000 fields: S72, S100", secondaryBitmap.ToDebugString(1));
		}
		[TestMethod]
		public void ToStringMethodMustDisplayHexValue()
		{
			var field = BitmapIsoField.FromHex("F23C840188E10000");

			Assert.AreEqual("F23C840188E10000", field.ToString());
		}
		[TestMethod]
		public void NoFlagToStringMethodMustDisplayZeroHex()
		{
			var field = new BitmapIsoField();

			Assert.AreEqual("0000000000000000", field.ToString());
		}
	}
}