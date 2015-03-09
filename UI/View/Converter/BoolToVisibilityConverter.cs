﻿namespace UI.View.Converter
{
	#region References

	using System;
	using System.Globalization;
	using System.Windows;
	using System.Windows.Data;

	#endregion

	[ValueConversion(typeof(bool), typeof(Visibility))]
	public sealed class BoolToVisibilityConverter : IValueConverter
	{
		public BoolToVisibilityConverter()
		{
			// set defaults
			this.TrueValue = Visibility.Visible;
			this.FalseValue = Visibility.Collapsed;
		}

		public Visibility TrueValue { get; set; }
		public Visibility FalseValue { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is bool))
			{
				return null;
			}
			return (bool)value ? this.TrueValue : this.FalseValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (Equals(value, this.TrueValue))
			{
				return true;
			}
			if (Equals(value, this.FalseValue))
			{
				return false;
			}
			return null;
		}
	}
}