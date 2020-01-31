using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace KamiSama.Iso8583.Tests
{
	[TestClass]
	[ExcludeFromCodeCoverage]
	public class IsoMessageTests
	{
		[TestMethod]
		public void EmptyIsoMessageMustHavePrimaryId()
		{
			var msg1 = new IsoMessage(1100);
			var msg2 = new IsoMessage("1100");

			Assert.AreEqual("1100", msg1.Id);
			Assert.AreEqual("1100", msg2.Id);
		}
		[TestMethod]
		public void IndexerMethodMustSetAndGetFieldAndPrimaryBitmapForFieldBetween1And64()
		{
			var msg = new IsoMessage(1100);

			msg[2] = "5022291000000000";

			Assert.IsNotNull(msg.PrimaryBitmap);
			Assert.IsTrue(msg.Has(2));
			Assert.IsNotNull(msg[2]);
			Assert.AreEqual("4000000000000000", msg.PrimaryBitmap.ToString());
			Assert.AreEqual("5022291000000000", msg[2].ToString());
		}
		[TestMethod]
		public void IndexerMethodMustSetAndGetFieldAndSecondaryBitmapForFieldBetween65And128()
		{
			var msg = new IsoMessage(1100);
			msg[0] = new BitmapIsoField();
			Assert.IsNotNull(msg.PrimaryBitmap);
			msg[0] = null;
			Assert.IsNull(msg.PrimaryBitmap);

			msg[65] = "5022291000000000";

			Assert.IsNotNull(msg.PrimaryBitmap);
			Assert.IsNotNull(msg.SecondaryBitmap);
			Assert.IsTrue(msg.Has(1));
			Assert.IsNotNull(msg[65]);
			Assert.AreEqual("8000000000000000", msg.PrimaryBitmap.ToString());
			Assert.AreEqual("8000000000000000", msg.SecondaryBitmap.ToString());
			Assert.AreEqual("5022291000000000", msg[65].ToString());

			msg[65] = null;
			Assert.IsFalse(msg.SecondaryBitmap[1]);
		}
		[TestMethod]
		public void HasMethodMustReturnAppropiateBitmapFlag()
		{
			var msg = new IsoMessage(1100);

			Assert.IsFalse(msg.Has(0));
			msg[2] = "5022291000000000";
			Assert.IsTrue(msg.Has(0));
			Assert.IsTrue(msg.Has(2));
			Assert.IsFalse(msg.Has(1));
			Assert.IsFalse(msg.Has(65));

			msg[65] = "11111";
			Assert.IsTrue(msg.Has(1));
			Assert.IsTrue(msg.Has(65));

		}
		[TestMethod]
		public void HasMethodMustThrowExceptionForOutOfRangeIndexes()
		{
			var msg = new IsoMessage(1100);

			Assert.ThrowsException<IndexOutOfRangeException>(() => msg.Has(-1));
			Assert.ThrowsException<IndexOutOfRangeException>(() => msg.Has(129));
		}
		[TestMethod]
		public void IndexerMethodsMustThrowExceptionForOutOfRangeIndexes()
		{
			var msg = new IsoMessage(1100);

			Assert.ThrowsException<IndexOutOfRangeException>(() => msg[-1]);
			Assert.ThrowsException<IndexOutOfRangeException>(() => msg[129]);
			Assert.ThrowsException<IndexOutOfRangeException>(() => msg[-1] = "1");
			Assert.ThrowsException<IndexOutOfRangeException>(() => msg[129] = "2");
		}
		[TestMethod]
		public void ToStringMustDisplayToDebugString()
		{
			var msg = new IsoMessage(1100);
			Assert.AreEqual(msg.ToDebugString(), msg.ToString());
		}
		[TestMethod]
		public void ToDebugStringMustDisplayFieldsAndDebugStringValues()
		{
			var msg = new IsoMessage(1100);

			msg[2] = "5022291000000000";
			msg[65] = "5022291000000001";

			Assert.AreEqual(@"Iso Message: 1100
P00	 : (Bitmap) hex: C000000000000000 fields: P01, P02
P01	 : (Bitmap) hex: 8000000000000000 fields: S65
P02	 : 5022291000000000
S65	 : 5022291000000001", msg.ToDebugString());
		}
	}
}
