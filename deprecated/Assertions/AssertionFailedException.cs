using System;
using System.Runtime.Serialization;

namespace KamiSama.Extensions.Assertions
{
	[Serializable]
	public class AssertionFailedException : Exception
	{
		public AssertionFailedException() { }
		public AssertionFailedException(string message) : base(message) { }
		public AssertionFailedException(string message, Exception inner) : base(message, inner) { }
		protected AssertionFailedException(SerializationInfo info,StreamingContext context) : base(info, context) { }
	}
}
