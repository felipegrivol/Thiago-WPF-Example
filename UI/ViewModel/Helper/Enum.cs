namespace UI.ViewModel.Helper
{
	#region References

	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;
	using System.Reflection;

	#endregion

	public static class Enum
	{
		public static IDictionary<string, T> ToDictionary<T>() where T : struct
		{
			if (!typeof(T).IsEnum)
			{
				throw new Exception("Type is not Enum!");
			}

			Func<object, FieldInfo> getFieldInfo = o => o.GetType().GetField(o.ToString());
			Func<object, DescriptionAttribute> getDescriptionAttribute = o => Attribute.GetCustomAttribute(getFieldInfo(o), typeof(DescriptionAttribute)) as DescriptionAttribute;
			Func<object, string> getDescription = o =>
			{
				var d = string.Empty;
				var a = getDescriptionAttribute(o);
				if (a == null)
				{
					d = o.ToString();
				}
				else
				{
					d = a.Description;
				}

				return d;
			};
			Func<object, T> convertToT = o => (T)System.Enum.Parse(typeof(T), o.ToString());

			var enumValues = System.Enum.GetValues(typeof(T))
				.Cast<System.Enum>()
				.Select(value => new
				{
					Name = getDescription(value),
					Value = value
				})
				.OrderBy(item => item.Value)
				.ToDictionary(o => o.Name, o => convertToT(o.Value));

			return enumValues;
		}
	}
}