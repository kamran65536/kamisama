using System;
using System.Collections.Generic;
using System.Text;

namespace KamiSama.Extensions.NLog
{
    /// <summary>
    /// String Builder Extension methods
    /// </summary>
	internal static class StringBuilderEx
	{
        /// <summary>
        /// Append a number and pad with 0 to 2 digits
        /// </summary>
        /// <param name="builder">append to this</param>
        /// <param name="number">the number</param>
        internal static void Append2DigitsZeroPadded(this StringBuilder builder, int number)
        {
            builder.Append((char)((number / 10) + '0'));
            builder.Append((char)((number % 10) + '0'));
        }

        /// <summary>
        /// Append a number and pad with 0 to 4 digits
        /// </summary>
        /// <param name="builder">append to this</param>
        /// <param name="number">the number</param>
        internal static void Append4DigitsZeroPadded(this StringBuilder builder, int number)
        {
            builder.Append((char)(((number / 1000) % 10) + '0'));
            builder.Append((char)(((number / 100) % 10) + '0'));
            builder.Append((char)(((number / 10) % 10) + '0'));
            builder.Append((char)(((number / 1) % 10) + '0'));
        }
    }
}
