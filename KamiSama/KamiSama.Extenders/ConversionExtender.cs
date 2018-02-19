using System;

namespace KamiSama.Extenders
{
	public static class ConversionExtender
	{
		public static object ConvertTo(this object obj, Type type, object defaultValue = null)
		{
			if (obj == null)
				return defaultValue;

			if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>)))
				type = type.GetGenericArguments()[0];

			try
			{
				if (type.IsEnum)
					return Enum.Parse(type, obj + "", true);
				else
					return Convert.ChangeType(obj, type);
			}
			catch
			{
				//if (type.IsEnum)
				//{
				//	int intResult;
				//	if (int.TryParse(obj + "", out intResult))
				//		return (object)intResult;
				//}
				return defaultValue;
			}
		}

		public static T ConvertTo<T>(this object obj, T defaultValue = default(T))
			=> (T) obj.ConvertTo(typeof(T), defaultValue);
	}
}
