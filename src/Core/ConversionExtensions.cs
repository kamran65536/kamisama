namespace KamiSama.Extensions;

/// <summary>
/// Conversion Extensions
/// </summary>
public static class ConversionExtensions
{
	/// <summary>
	/// Converts an object to another type
	/// </summary>
	/// <param name="obj">the source object</param>
	/// <param name="type">the desired type for conversion</param>
	/// <param name="defaultValue">default value if conversion is failed</param>
	/// <returns></returns>
	public static object? ConvertTo(this object? obj, Type type, object? defaultValue = null)
	{
		if (obj == null)
			return defaultValue;

		if (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>)))
			type = type.GetGenericArguments()[0];

		try
		{
			if (type.IsEnum)
				return Enum.Parse(type, obj.ToString()!, true);
			else
				return Convert.ChangeType(obj, type);
		}
		catch
		{
			return defaultValue;
		}
	}
	/// <summary>
	/// Converts an object to another type
	/// </summary>
	/// <typeparam name="T">the desired type for conversion</typeparam>
	/// <param name="obj">the source object</param>
	/// <param name="defaultValue">default value if conversion is failed</param>
	/// <returns></returns>
	public static T? ConvertTo<T>(this object? obj, T? defaultValue = default)
		=> (T?) obj.ConvertTo(typeof(T), defaultValue);
}
